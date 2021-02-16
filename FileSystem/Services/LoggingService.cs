using System;
using System.Diagnostics;
using System.IO;

namespace FileSystemManager.Services
{
    class LoggingService
    {
          
        private static string loggingPath = "..\\..\\..\\Logging.txt"; // path to the logo file

        public static void FileNameLogging()
        {
            var stopWatch = Stopwatch.StartNew(); // To measure how long time the method will take
            string fileNames = FileService.GetFileNames();
            stopWatch.Stop();
            double timeToExecute = stopWatch.Elapsed.TotalMilliseconds;
            Logg($"The function GetFileNames took {timeToExecute} ms");

            //Log the operation to logging file, and show it to the console.
            Console.WriteLine($"Resource folder containes following files: {fileNames}");
           
        }

     

        public static void ExtensionLogging(string extension)
        {
            string output = "";
   
            var stopWatch = Stopwatch.StartNew();
            string[] fileNames = FileService.GetAllFilesExcention(extension);
            stopWatch.Stop();
            double timeToExecute = stopWatch.Elapsed.TotalMilliseconds;
            Logg($"The GetAllFilesExcention function took {timeToExecute} ms");
            //If the extension doesn't exists
            if (fileNames.Length < 1)
            {
                Console.WriteLine($"Resource folder doesn't contains this {extension}");

            }

            foreach(string file in fileNames){

                output += Path.GetFileName(file) +",";
            };
            
            Console.WriteLine($"Resource folder contains following files {output}");
             
            
        }
        //Get and log dracula filename
        public static void DraculaFileLog()
        {
            var stopWatch = Stopwatch.StartNew();
            string fileName = FileService.GetFileNameToDracula();
            stopWatch.Stop();
            double timeToExecute = stopWatch.Elapsed.TotalMilliseconds;
            Logg($"The function GetFileNameToDracula() took {timeToExecute} ms");
            Console.WriteLine($"The file name is: {fileName}");
  
        }
        //Get Dracula file size
        public static void DraculaFileSize()
        {
            var stopWatch = Stopwatch.StartNew();
            long fileSize = FileService.GetDrauclaSize();
            stopWatch.Stop();
            double timeToExecute = stopWatch.Elapsed.TotalMilliseconds;
            Logg($" The function took {timeToExecute} ms");
            Console.WriteLine($"The File size: {fileSize} ");
            
        }

        public static void DraculaLineCount()
        {
            var stopWatch = Stopwatch.StartNew();
            int lines = FileService.GetFileCount();
            stopWatch.Stop();
            double timeToExecute = stopWatch.Elapsed.TotalMilliseconds;
            Logg($"The function took {timeToExecute} ms ");
            Console.WriteLine($"Dracula file has {lines} lines ");
          
        }


        public static void WordCountDracula(string word)
        {
            var stopWatch = Stopwatch.StartNew();
            int count = FileService.GetWordCount(word);
            stopWatch.Stop();
            if (count == 0) {
                Console.WriteLine($"The file doesn't contain this word: {word} ");
                    };
            double timeToExecute = stopWatch.Elapsed.TotalMilliseconds;
            Logg($" The function took {timeToExecute} ms");
            Console.WriteLine($"The word {word} appears {count} times in the text");
           
        }

        public static void Logg(string output)
        {
            var currentTime = DateTime.Now.ToString("dd'-'MM'-'yyyy'T'HH':'mm':'ss");
   
            try
            {

                File.AppendAllText(@loggingPath, $"{currentTime}: {output}" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error occurs : " + ex);
            }
        }

    }

}
