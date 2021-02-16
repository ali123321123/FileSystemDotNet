using FileSystemManager.Services;
using System;

namespace FileSystem
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Show the menu 
            MenuPrompt();
        }




        public static void MenuPrompt()
        {
            string Input = "";
            //All options in the menu
            Console.WriteLine("Welcome to your file system, you can choose an option under ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("1_ Show all files in Resources folder");
            Console.WriteLine("2_ Get specific files by their extension in Resources folder");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------Dracula manipulation--------");
            Console.WriteLine("3_ Get the file name");
            Console.WriteLine("4_ How big the file is");
            Console.WriteLine("5_  How many lines the file has");
            Console.WriteLine("6_ How many times the specific word is found in the file");
            Console.WriteLine("7_  Exit");
            try { 
                 Input = Console.ReadLine(); 
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.Message);
            }

            switch (Input)
            {
                case "1":
                    LoggingService.FileNameLogging();
                    break;
                case "2":
                    Console.WriteLine("The avalible extension: .txt,.jpeg,.jfif,.png,jpg,.txt");
                    Console.WriteLine("Enter the file extension please");
                    string input = Console.ReadLine();
                    //Get all file to one extension
                    LoggingService.ExtensionLogging(input);
                    break;
                    //Dracula options
                case "3":
                    LoggingService.DraculaFileLog();
                    break;
                case "4":
                    ;
                    LoggingService.DraculaFileSize();
                    break;
                case "5":
                    LoggingService.DraculaLineCount();
                    break;
                case "6":
                    Console.WriteLine("Enter the word you like to find  ^_^");
                    string word = Console.ReadLine();
                    LoggingService.WordCountDracula(word);
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You should choose a number between 1 and 7");
                    break;
            }     
        }
    }
}
