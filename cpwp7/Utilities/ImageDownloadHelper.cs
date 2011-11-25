using System;
using System.Net;
using System.Windows;
using System.Threading;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace cpwp7.Utilities
{
    internal static class ImageDownloadHelper
    {
        //Helper method to load the image
        public static void DownloadImage(string url, BitmapImage image)
        {
            // Get the filename and path
            string filename = Path.GetFileName(url);
            string fullpath = Path.Combine("Shared", filename);
            
            //Creating the auxiliary object to be passed to the asynchronous call
            AsyncDataTransfer transfer = new AsyncDataTransfer();
            transfer.Image = image;
            transfer.Path = fullpath;

            //Creating the Query
            var wc = (HttpWebRequest)HttpWebRequest.Create(url);
            transfer.WebRequest = wc;

            wc.BeginGetResponse(RequestCallback, transfer);
        }

        private static void RequestCallback(IAsyncResult result)
        {
            //The query was successful
            if (!result.IsCompleted)
            {
                return;
            }

            //Manufacture of auxiliary object
            AsyncDataTransfer transfer = (AsyncDataTransfer)result.AsyncState;
            try
            {

                System.Diagnostics.Debug.WriteLine("Downloaded Succesfull " + transfer.Path);
                
                var response = (HttpWebResponse)transfer.WebRequest.EndGetResponse(result);
                var responseStream = response.GetResponseStream();               

                //Write the image file

                using (var bw = new BinaryWriter(IsolatedStorageFile.GetUserStoreForApplication().CreateFile(transfer.Path)))
                {
                    byte[] b = new byte[4096];
                    int read = 0;
                    while ((read = responseStream.Read(b, 0, b.Length)) > 0)
                    {
                        bw.Write(b, 0, read);
                    }
                    bw.Flush();
                    bw.Close();
                }
                //using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication()){
                //    using (IsolatedStorageFileStream stream = iso.OpenFile(transfer.Path, FileMode.Open)) {
                //        transfer.Image.SetSource(stream);
                //    }
                //}
                    
                    
                
                
                ImageCache.queue.Remove(transfer.Path);
                //Put the picture
                Deployment.Current.Dispatcher.BeginInvoke(() => transfer.Image.SetSource(responseStream));
                
            //    {
            //        using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
            //        {
            //            using (IsolatedStorageFileStream stream = iso.OpenFile(transfer.Path, FileMode.Open))
            //            {
            //                transfer.Image.SetSource(stream);
            //            }
            //        }
            //});

                //foreach (KeyValuePair<string, BitmapImage> entry in ImageCache.queue)
                //{
                //    if (entry.Key == transfer.Path)
                //    {
                //        Deployment.Current.Dispatcher.BeginInvoke(() => entry.Value.SetSource(responseStream));
                //    }
                //}
            }
            catch
            {
                //Do nothing, because no image could be downloaded
            }
        }

    }
    //Helper class for the asynchronous call
    internal class AsyncDataTransfer
    {
        public ManualResetEvent ResetEvent { get; set; }
        public HttpWebRequest WebRequest { get; set; }
        public BitmapImage Image { get; set; }
        public string Path { get; set; }
    }
}
