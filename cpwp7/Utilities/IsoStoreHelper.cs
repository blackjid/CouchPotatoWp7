using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace cpwp7.Utilities
{
    public class IsoStoreHelper
    {
        public static Stream StreamFileFromIsoStore(string filename)
        {
            try
            {
                var isoStore = IsolatedStorageFile.GetUserStoreForApplication();
                using (isoStore)
                {
                    return isoStore.OpenFile(filename, FileMode.Open);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }


        public static bool FileExists(string filename)
        {
            try
            {
                var isoStore = IsolatedStorageFile.GetUserStoreForApplication();
                using (isoStore)
                {
                    return isoStore.FileExists(filename);
                   }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public static void DeleteFile(string filename)
        {
            var isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            try
            {
                isoStore.DeleteFile(filename);
            }
            catch
            {
            }
        }

        public static string GetFileAsString(string filename)
        {
            var filestream = StreamFileFromIsoStore(filename);

            var s = new StreamReader(filestream);
            return s.ReadToEnd();
        }

        public static void CreateDirectoryStructure(string fileName)
        {
            var strBaseDir = string.Empty;
            var delimStr = "/";
            var delimiter = delimStr.ToCharArray();
            var dirsPath = fileName.Split(delimiter);

            //Get the IsoStore
            var isoStore = IsolatedStorageFile.GetUserStoreForApplication();

            //Recreate the directory structure
            for (int i = 0; i < dirsPath.Length - 1; i++)
            {
                strBaseDir = Path.Combine(strBaseDir, dirsPath[i]);
                if (!isoStore.DirectoryExists(strBaseDir))
                    isoStore.CreateDirectory(strBaseDir);
            }
        }

        public static void SaveToIsoStore(string fileName, Stream stream)
        {
            byte[] data = ReadFully(stream, (int)stream.Length);
            stream.Close();

            SaveToIsoStore(fileName, data);
        }

        public static void SaveToIsoStore(string fileName, byte[] data)
        {
            try
            {
                CreateDirectoryStructure(fileName);
                //Get the IsoStore
                var isoStore = IsolatedStorageFile.GetUserStoreForApplication();

                //Write the file
                using (var bw = new BinaryWriter(isoStore.CreateFile(fileName)))
                {
                    bw.Write(data);
                    bw.Close();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }



        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length</param>
        public static byte[] ReadFully(Stream stream, int initialLength)
        {
            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[initialLength];
            int read = 0;

            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;

                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = stream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        return buffer;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }



    }
}
