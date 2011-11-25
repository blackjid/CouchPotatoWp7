using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.IO;
using GalaSoft.MvvmLight;
using System.Windows.Resources;

namespace cpwp7.Utilities
{
    /// <summary>
    /// Caches web images
    /// </summary>
    internal static class ImageCache
    {
        internal static Dictionary<string, BitmapImage> queue = new Dictionary<string, BitmapImage>();

        public static BitmapImage GetImage(string url)
        {
            // When in design mode of Visual Studio or Blend
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // The image to be returned to the image control
                BitmapImage image = new BitmapImage();
                image.UriSource = new Uri(url);
                return image;
            }
            
            // Get the filename and path
            string filename = Path.GetFileName(url);
            string fullpath = Path.Combine("Shared", filename);

            // The file doesn't exists.
            // Check if is in the queue to be downloaded.
            if (queue.ContainsKey(fullpath))
            {
                // Return the image associated with this path
                System.Diagnostics.Debug.WriteLine("Exist in cache " + fullpath);
                return queue[fullpath];
            }
            
            //Try to get the file from isolated storage if it exists, if no it will check in the download queue
            using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
            {
                // The image to be returned to the image control
                BitmapImage image = new BitmapImage();
                Uri uri = new Uri("SplashScreenImage.jpg", UriKind.Relative);
                StreamResourceInfo resourceInfo = Application.GetResourceStream(uri);
                image.SetSource(resourceInfo.Stream);
                //image.CreateOptions = BitmapCreateOptions.BackgroundCreation;
                //image.SetSource(new MemoryStream(new byte[0]));
                
                if (iso.FileExists(fullpath))
                {
                    //The file exists. Read the file and return the stream to the image
                    System.Diagnostics.Debug.WriteLine("Image Loaded from storage " + fullpath);
                    using (IsolatedStorageFileStream stream = iso.OpenFile(fullpath, FileMode.Open))
                    {
                        
                        // The image to be returned to the image control
                        image.SetSource(stream);
                        //queue.Add(url, image);
                        
                    }
                }
                else
                {

                    

                    // It isn't being downloaded.
                    // Download it
                    ImageDownloadHelper.DownloadImage(url, image);
                }   // Save the name in the queue
                queue.Add(fullpath, image);
                return image;
            }
        }
    }

}
