using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Security;

namespace circularMT
{
    class FileAccessClass
    {
        public enum FileJob
        {
            Open = 1,
            SaveAs = 2,
            Directory = 0
        }
//basic file/folder selection method
        public static string FileString(FileJob OpenSave, String Title, String Extension)
            {
            if (OpenSave == FileJob.SaveAs)
                {
                return SaveAFile(Title, Extension);
                }
            else if (OpenSave == FileJob.Open)
                {
                return OpenAFile(Title, Extension);
                }
            else if (OpenSave == FileJob.Directory)
                {
                return SelectAFolder(Title, Extension);
                }
            else
                {
                return "Cancel";
                }
            }

        //selects a file to open
        private static string OpenAFile(String Title, String Extension)
            {
            try
                {
                OpenFileDialog textDialog = new OpenFileDialog();
                textDialog.ValidateNames = true;
                textDialog.ShowHelp = false;
                textDialog.AddExtension = true;
                textDialog.Title = Title;
                textDialog.Filter = Extension;
                textDialog.CheckFileExists = true;
                textDialog.ShowDialog();

                if (textDialog.FileName == "")
                    {
                    return "Cancel";
                    }
                else
                    {
                    return textDialog.FileName;
                    }
                }
            catch (SecurityException ex)
                {
                MessageBox.Show("Your OS will not let this program access any files. This may because it is runing from a network drive, copy the program to your desktop and retry.", "Error", MessageBoxButtons.OK);
                return "Cancel";
                }
            catch (Exception ex)
                {
                return "Cancel";
                }
            }//End method

        //selects a file to save too
        private static string SaveAFile(String Title, String Extension)
            {
            try
                {
                SaveFileDialog textDialog = new SaveFileDialog();
                textDialog.ValidateNames = true;
                textDialog.ShowHelp = false;
                textDialog.AddExtension = true;
                textDialog.Title = Title;
                textDialog.Filter = Extension;
                textDialog.ShowDialog();

                if (textDialog.FileName == "")
                    {
                    return "Cancel";
                    }
                else
                    {
                    return textDialog.FileName;
                    }
                }
            catch (SecurityException ex)
                {
                MessageBox.Show("Your OS will not let this program access any files. This may because it is runing from a network drive, copy the program to your desktop and retry.", "Error", MessageBoxButtons.OK);
                return "Cancel";
                }
            catch (Exception ex)
                {
                return "Cancel";
                }
            }//End method

        //selects a folder to work with
        private static string SelectAFolder(String Title, String Extension)
            {
            try
                {
                FolderBrowserDialog textDialog = new FolderBrowserDialog();
                if (System.IO.Directory.Exists(Extension))
                    {
                    textDialog.SelectedPath = Extension;
                    }
                textDialog.ShowNewFolderButton = false;
                textDialog.Description = Title;
                textDialog.ShowDialog();

                if (textDialog.SelectedPath == "")
                    {
                    return "Cancel";
                    }
                else if (textDialog.SelectedPath == Title)
                    {
                    return "Cancel";
                    }
                else
                    {
                    return textDialog.SelectedPath;
                    }
                }
            catch (SecurityException ex)
                {
                MessageBox.Show("Your OS will not let this program access any files. This may because it is runing from a network drive, copy the program to your desktop and retry.", "Error", MessageBoxButtons.OK);
                return "Cancel";
                }
            catch (Exception ex)
                {
                return "Cancel";
                }
            }//End method

    }
}


