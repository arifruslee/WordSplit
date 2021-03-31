using System;
using System.Linq;

namespace WordSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstElement = args[0];
            var secondElement = args[1];
            var outputResult = String.Empty;

            var arraySecondElement = secondElement.Split(",");

            //Filter out to only those contained in firstElement
            var listContainedElements = arraySecondElement.Where(w => firstElement.ToUpper().Contains(w.ToUpper())).ToList();

            //Only continue process if more than 1 word exists
            if (listContainedElements.Count <= 1)
            {
                outputResult = "String not possible";
                Console.WriteLine(outputResult);
                return;
            }

            //Check if combination of 2 words. Starts with and Ends with
            var firstWord = listContainedElements.Where(w => firstElement.ToUpper().StartsWith(w.ToUpper())).FirstOrDefault();
            var secondWord = listContainedElements.Where(w => firstElement.ToUpper().EndsWith(w.ToUpper())).FirstOrDefault();

            //Also checks to make sure there are no other additional chars. Only combination of both words.
            if (firstWord + secondWord != firstElement)
                outputResult = "String not possible";
            else
                outputResult = firstWord + "," + secondWord;

            Console.WriteLine(outputResult);
        }
    }
}
