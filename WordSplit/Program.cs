using System;
using System.Linq;

namespace WordSplit
{
    class Program
    {
        public static string WordSplitFunc(string[] args)
        {
            var firstElement = args[0];
            const string outputResult = "String not possible";

            var arraySecondElement = args[1].Split(",");

            //Filter out to only those contained in firstElement
            var listContainedElements = arraySecondElement.Where(w => firstElement.ToUpper().Contains(w.ToUpper())).ToList();

            //Only continue process if more than 1 word exists
            if (listContainedElements.Count <= 1)
                return outputResult;

            //Check if combination of 2 words. Starts with and Ends with
            var firstWord = listContainedElements.Where(w => firstElement.ToUpper().StartsWith(w.ToUpper())).FirstOrDefault();
            var secondWord = listContainedElements.Where(w => firstElement.ToUpper().EndsWith(w.ToUpper())).FirstOrDefault();
            
            //resultCheck since firstElement has no comma
            var resultCheck = firstWord + secondWord;
            var result = $"{firstWord},{secondWord}";

            return firstElement == resultCheck ? result : outputResult;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(WordSplitFunc(args));
        }
    }
}
