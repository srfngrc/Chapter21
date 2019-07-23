using System;

namespace StreamWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private void CreateLogFile()
        {

            //File Paths
            //Absolute
            string absolutePath = @"C:\Log.txt";

            //Relative path
            string relativePath = @"log.txt";

            string appFolder = Directory.GetCurrentDirectory();

            FileInfo aLogFile = new FileInfo(@"C:\Log.txt");
            if (aLogFile.Exists)
                MessageBox.Show("It exists!");

            if (File.Exists(@"C:\Log.txt"))
                MessageBox.Show("Exists!");

            FileStream aFile = new FileStream(absolutePath, FileMode.OpenOrCreate);
            FileStream streamLog = aLogFile.OpenRead();

            StreamWriter sw = new StreamWriter(streamLog);
            sw.WriteLine("Logged in successfully");
        }
    }
}
