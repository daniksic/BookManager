using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
Write a console application that reads in a text file and prints out its size in bytes. Use async to fire the 
method that reads the file size before handing control back to display a message stating the file is 
being read, finally print the size of the file.
    */
namespace FileSizeAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please insert full path of file you want to measure:");
                string path = Console.ReadLine();

                if (File.Exists(path))
                {
                    ProccessFileAsync(path)
                        .ContinueWith((s) => {
                            Console.WriteLine(s.Result.Length);
                            });
                }

            }

        }

        private static async Task<string> ProccessFileAsync(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath,
        FileMode.Open, FileAccess.Read, FileShare.Read,
        bufferSize: 4096, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }
    }
}
