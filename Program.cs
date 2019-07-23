using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamWrite
{
    class Program
    {
        //static
        static void Main(string[] args)
        {
            //StreamWriterSRFN();
            StreamReaderSRFN();
        }

        private static void StreamReaderSRFN()
        {
            string line;
            try
            {
                FileStream aFile = new FileStream("Log.txt", FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                line = sr.ReadLine();
                // Read data in line by line.
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(e.ToString());
                return;
            }
            Console.ReadKey();
        }

        private static void StreamWriterSRFN()
        {
            try
            {
                //OPTION 1:
                //FileStream aFile = new FileStream("Log.txt", FileMode.OpenOrCreate); SOBREESCRIBE!
                FileStream aFile = new FileStream("Log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(aFile);

                //OPTION 2: for me better
                //StreamWriter sw = new StreamWriter("Log.txt", true);
                
                bool truth = true;
                // Write data to file.
                sw.WriteLine("Hello to you, Serafin.");
                sw.WriteLine("It is now {0} and things are looking good.", DateTime.Now.ToLongDateString());
                sw.Write("More than that,");
                sw.Write(" it's {0} that C# is fun.", truth);
                sw.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(e.ToString());
                Console.ReadLine();
                return;
            }
        }
        private static void CreateLogFile()
        {

            //File Paths
            //Absolute
            string absolutePath = @"C:\Log.txt";

            //Relative path
            string relativePath = @"log.txt";

            string appFolder = Directory.GetCurrentDirectory();

            FileInfo aLogFile = new FileInfo(@"C:\Log.txt");
            if (aLogFile.Exists)
                Console.WriteLine("It exists!");

            if (File.Exists(@"C:\Log.txt"))
                Console.WriteLine("Exists!");

            FileStream aFile = new FileStream(absolutePath, FileMode.OpenOrCreate);
            FileStream streamLog = aLogFile.OpenRead();

            StreamWriter sw = new StreamWriter(streamLog);
            sw.WriteLine("Logged in successfully");
        }
    }
}
