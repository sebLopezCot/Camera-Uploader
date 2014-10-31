using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Dolinay; // Drive Detector Namespace

namespace Camera_Uploader
{
    public partial class MainWindow : Form
    {
        private DriveDetector driveDetector = null;
        private Boolean searchingForRemoval = false;
        private Boolean deviceConnected = false;
        private String deviceRootDirectory = "";

        public MainWindow()
        {
            InitializeComponent();

            // Drive detector event handlers
            driveDetector = new DriveDetector();
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(driveDetector_DeviceArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(driveDetector_DeviceRemoved);

            // Set the file dialog filter for image files
            selectPhotosDialogBox.Filter = "Bitmap Files (*.bmp;*.dib)|*.BMP;*.DIB|" +
                                           "JPEG (*.jpg;*.jpeg;*.jpe;*.jfif)|*.JPG;*JPEG;*.JPE;*.JFIF|" + 
                                           "GIF (*.gif)|*.GIF|" +
                                           "TIFF (*.tif;*.tiff)|*.TIF;*.TIFF|" +
                                           "PNG (*.png)|*.PNG|" +
                                           "All Picture Files|*.BMP;*.DIB;*.JPG;*JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG|" +
                                           "All files|*.*";

            selectPhotosDialogBox.FilterIndex = 6; // Sets all picture files as the default filter
            destinationFolderDialogBox.SelectedPath = "D:\\Pictures"; // Sets the starting directory
        }

        // Device has been connected
        void driveDetector_DeviceArrived(object sender, DriveDetectorEventArgs e)
        {
            if (!deviceConnected)
            {
                deviceRootDirectory = e.Drive; // Stores the root directory of the device
                selectPhotosDialogBox.InitialDirectory = e.Drive; // Sets the root directory of the device as the file dialog directory
                deviceConnected = true;
                driveFeedbackLabel.Text = "Your device has been identified as drive " + e.Drive.Replace("\\", "");
                selectPhotosButton.Enabled = true;
            }
        }

        // Device has been disconnected
        void driveDetector_DeviceRemoved(object sender, DriveDetectorEventArgs e)
        {
            if (searchingForRemoval) 
            {
                this.Close();
            }
        }

        private void selectPhotosButton_Click(object sender, EventArgs e)
        {
            selectPhotosDialogBox.ShowDialog();
        }

        private void selectPhotosDialogBox_FileOk(object sender, CancelEventArgs e)
        {
            destinationFolderButton.Enabled = true;
        }

        private void destinationFolderButton_Click(object sender, EventArgs e)
        {
            // User selects the location
            if (destinationFolderDialogBox.ShowDialog() == DialogResult.OK) 
            {
                // Confirms that the user wants to copy the photos.
                if (MessageBox.Show("Camera Uploader will now copy your photos. Do you want to continue?",
                                    "Camera Uploader", MessageBoxButtons.YesNo) == DialogResult.Yes) 
                {
                    // Asks if the user wants to delete the photos from the device after copying them.
                    DialogResult result = new DialogResult();
                    result = MessageBox.Show("Would you like to erase the photos off your device after copying is finished?",
                        "Camera Uploader", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes) 
                    {
                        // Move photos
                        movePhotos(selectPhotosDialogBox.FileNames, destinationFolderDialogBox.SelectedPath);
                        
                        // Update user
                        MessageBox.Show("Moving finished. You may now unplug your device.", "Camera Uploader");

                        // Update device removal state
                        searchingForRemoval = true;
                    }
                    else if (result == DialogResult.No)
                    {
                        // Copy photos
                        copyPhotos(selectPhotosDialogBox.FileNames, destinationFolderDialogBox.SelectedPath);

                        // Update user
                        MessageBox.Show("Copying finished. You may now unplug your device.", "Camera Uploader");

                        // Update device removal state
                        searchingForRemoval = true;
                    }
                }
            }
        }

        // Moves the photos to the desired directory.
        private void movePhotos(String[] fileNames, String destinationDirectory) 
        {
            // Call the progress dialog
            ProgressDialog progressDialog = new ProgressDialog();
            progressDialog.Show();
            int totalPictures = fileNames.Length;
            int progressChangeInterval = (int)(100 / totalPictures);

            // Move the photos
            for (int i = 0; i < fileNames.Length; i++ )
            {
                String fName = fileNames[i];
                String simpleFileName = fName.Substring(fName.LastIndexOf("\\")); // Returns simple name and '\' in front

                // Update user
                progressDialog.setProgressText("Moving photo " + (i + 1).ToString() + " of " + totalPictures);

                try
                {
                    // File not found
                    if (!File.Exists(fName))
                    {
                        // Update user
                        progressDialog.setImageHolder(null);
                        MessageBox.Show(simpleFileName.Replace("\\", "") + " was not found. It was not moved.", "Camera Uploader");
                    }
                    else
                    {
                        // New file location contains this file.
                        if (File.Exists(destinationDirectory + simpleFileName))
                        {
                            // Load the picture
                            Image tempImage = Image.FromFile(fName);
                            progressDialog.setImageHolder(tempImage);

                            // Ask the user what they prefer to do.
                            DialogResult result = new DialogResult();
                            result = MessageBox.Show(simpleFileName.Replace("\\", "") + " already exists. Would you like to delete it?" +
                                " (You may cancel moving the file by clicking 'Cancel'. If you would like to keep both files, press 'No'.)",
                                "Camera Uploader", MessageBoxButtons.YesNoCancel);

                            if (result == DialogResult.Yes)
                            {
                                // Unload picture from dialog box
                                tempImage.Dispose();

                                // Delete old file
                                File.Delete(destinationDirectory + simpleFileName);

                                // Move new file
                                File.Move(fName, destinationDirectory + simpleFileName);
                            }
                            else if (result == DialogResult.No)
                            {
                                // Unload picture from dialog box
                                tempImage.Dispose();

                                // Keep both files and rename new one
                                File.Move(fName, destinationDirectory + simpleFileName.Replace(simpleFileName.Substring(simpleFileName.LastIndexOf(".")), "") + " (copy)" + simpleFileName.Substring(simpleFileName.LastIndexOf(".")));    
                            }
                        }
                        else
                        {
                            // Move new file
                            File.Move(fName, destinationDirectory + simpleFileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Update user
                    Image tempImage = Image.FromFile(fName);
                    progressDialog.setImageHolder(tempImage);
                    tempImage.Dispose();

                    MessageBox.Show("An error occurred when moving files. " + ex.Message, "Camera Uploader");
                }

                // Update user
                progressDialog.setProgressBarValue(progressChangeInterval * (i+1));
            }

            // End progress dialog
            progressDialog.Close();
        }

        // Copies the photos to the desired directory.
        private void copyPhotos(String[] fileNames, String destinationDirectory)
        {
            // Call the progress dialog
            ProgressDialog progressDialog = new ProgressDialog();
            progressDialog.Show();
            int totalPictures = fileNames.Length;
            int progressChangeInterval = 100 / totalPictures;
            
            // Copy the photos
            for (int i = 0; i < fileNames.Length; i++)
            {
                String fName = fileNames[i];
                String simpleFileName = fName.Substring(fName.LastIndexOf("\\")); // Returns simple name and '\' in front

                // Update user
                progressDialog.setProgressText("Copying photo " + (i + 1).ToString() + " of " + totalPictures);

                try
                {
                    // File not found
                    if (!File.Exists(fName))
                    {
                        // Update user
                        progressDialog.setImageHolder(null);
                        MessageBox.Show(simpleFileName.Replace("\\", "") + " was not found. It was not copied.", "Camera Uploader");
                    }
                    else
                    {
                        // New file location contains this file.
                        if (File.Exists(destinationDirectory + simpleFileName))
                        {
                            // Load the picture
                            Image tempImage = Image.FromFile(fName);
                            progressDialog.setImageHolder(tempImage);

                            // Ask the user what they prefer to do.
                            DialogResult result = new DialogResult();
                            result = MessageBox.Show(simpleFileName.Replace("\\", "") + " already exists. Would you like to delete it?" +
                                " (You may cancel copying the file by clicking 'Cancel'. If you would like to keep both files, press 'No'.)",
                                "Camera Uploader", MessageBoxButtons.YesNoCancel);

                            if (result == DialogResult.Yes)
                            {
                                // Unload picture from dialog box
                                tempImage.Dispose();

                                // Delete old file
                                File.Delete(destinationDirectory + simpleFileName);

                                // Copy new file
                                File.Copy(fName, destinationDirectory + simpleFileName);
                            }
                            else if (result == DialogResult.No)
                            {
                                // Unload picture from dialog box
                                tempImage.Dispose();

                                // Keep both files and rename new one
                                File.Copy(fName, destinationDirectory + simpleFileName.Replace(simpleFileName.Substring(simpleFileName.LastIndexOf(".")), "") + " (copy)" + simpleFileName.Substring(simpleFileName.LastIndexOf(".")));
                            }
                        }
                        else
                        {
                            // Copy new file
                            File.Copy(fName, destinationDirectory + simpleFileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Update user
                    Image tempImage = Image.FromFile(fName);
                    progressDialog.setImageHolder(tempImage);
                    tempImage.Dispose();

                    MessageBox.Show("An error occurred when copying files.", "Camera Uploader");
                }

                // Update user
                progressDialog.setProgressBarValue(progressChangeInterval * (i+1));
            }

            // End progress dialog
            progressDialog.Close();
        }
    }
}
