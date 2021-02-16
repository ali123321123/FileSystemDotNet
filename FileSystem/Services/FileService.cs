
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileSystemManager.Services
{

    class FileService

    {
        private static readonly string resourcesFilepath = @"..\..\..\Resources";

        //Get All files by one Excention.
        public static string[] GetAllFilesExcention(string extension)
        {

            string[] files = System.IO.Directory.GetFiles(resourcesFilepath, "*" + extension);
            return files;

        }


        // Get all file names inside the resource folder
        public static string GetFileNames()
        {
            DirectoryInfo d = new DirectoryInfo(resourcesFilepath);
            FileInfo[] Files = d.GetFiles();
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
            }
            return str;
        }

        // Get Dracula size file 
        public static long GetDrauclaSize()
        {

            long length = new System.IO.FileInfo(@$"{resourcesFilepath}\Dracula.txt").Length;
            return length;
        }

        //Get dracula file line count
        public static int GetFileCount()
        {
            int lines = File.ReadAllLines($"{resourcesFilepath}\\Dracula.txt").Length;
            return lines;
        }

        //Dracula options methods 


        //Get the name of Dracula file.

        public static string GetFileNameToDracula()
        {
            return Path.GetFileName(@$"{resourcesFilepath}\Dracula.txt");
        }






        public static int GetWordCount(string word)
        {

            /*
            int wordCount = 0;
            Regex wholeWord = new Regex($@"\b{word}\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            using (StreamReader rdr = new StreamReader($"{resourcesFilepath}\\Dracula.txt"))
            {
                string line;
                while ((line = rdr.ReadLine()) != null)
                {
                    wordCount += wholeWord.Matches(line).Count;
                }
            }
            return wordCount;
        }
            */
            string content = File.ReadAllText(@$"{resourcesFilepath}\Dracula.txt");
            string[] words = content.Split(new char[] { '.', '.', ' ', '?', '\n', '\r' },
                  StringSplitOptions.RemoveEmptyEntries);
            return words.Count(q => q == word);
        }
    }
}
