using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace DempProgram
{
    class Program
    {
       
      
        static void Main(string[] args)
        {
                   

            //Palindrome function
            Console.WriteLine("Enter string to check for palindrome:");
            string inputString = Console.ReadLine();
            bool checkPalindrome = Palindrome(inputString);
            if (checkPalindrome)
            {
                Console.WriteLine("Given string is a Palindrom!");
            }
            else
            {
                Console.WriteLine("Given string is not a Palindrom!!");
            }

            //GroupByOwners function
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Input.txt", "Randy");
            dictionary.Add("Code.py", "Stan");
            dictionary.Add("Output.txt", "Randy");
            Dictionary<string, List<string>> result = groupByOwners(dictionary);
            foreach (KeyValuePair<string, List<string>> dict in result)
            {
                string separator = ", ";
                Console.WriteLine("{0}:{1}", dict.Key, String.Join(separator, dict.Value));
            }

            //ParseLogfile function
            parseLogFile();

          




        }


        static bool Palindrome(string inputString)
        {
            bool isPalindrome = false;
            string reverseString = new string(inputString.ToCharArray().Reverse().ToArray());
            if (String.Equals(inputString, reverseString))
            {
                isPalindrome = true;
            }
            return isPalindrome;
        }



        static Dictionary<string, List<string>> groupByOwners(Dictionary<string, string> fileOwners)
        {
            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            try
            {
                foreach (var item in fileOwners)
                {
                    string fileOwnerName = item.Value;
                    string fileName = item.Key;
                    if (!d.ContainsKey(fileOwnerName))
                    {
                        List<string> fileNamesOfOwner = new List<string>();
                        fileNamesOfOwner.Add(fileName);
                        d.Add(fileOwnerName, fileNamesOfOwner);
                    }
                    else
                    {
                        d[fileOwnerName].Add(fileName);
                    }
                }
            }
            catch (Exception e)
            {
                //
            }
            return d;


        }

        static void parseLogFile()
        {
            //string inputLogFilePath = @"~/Files/LogFile.log";
            StringBuilder sb = new StringBuilder();
            var lstrPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            lstrPath = lstrPath.Remove(0, 6);//To remove file:\\
             lstrPath = lstrPath.ToLowerInvariant();
            if (lstrPath.Contains("bin"))
            {
                lstrPath = lstrPath.Substring(0, lstrPath.LastIndexOf("bin"));
            }
            
            string inputLogFilePath = lstrPath + @"Files\LogFile.log";
            string outPutLogFilePath = lstrPath + @"Files\TextFile1.log";
            try
            {
                string[] lines = File.ReadAllLines(inputLogFilePath);
                foreach (string line in lines)
                {
                    if (line.ToUpper().Contains("WARNING") || line.ToUpper().Contains("ERROR"))
                    {
                        sb.AppendLine(line);
                    }
                }



                using (StreamWriter writer = new StreamWriter(outPutLogFilePath))
                {
                    writer.Write(sb.ToString());
                }

            }
            catch (Exception)
            {
                //
            }
        }

       



    }
}
