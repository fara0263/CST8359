using System.Diagnostics;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            IList<string> words = new List<string>();

            do
            {
                ConsoleMenu();

                switch(Console.ReadLine())
                {
                    case "1":
                        ImportWordsFromFile(words);
                        break;
                    case "2":
                        BubbleSort(words);
                        break;
                    case "3":
                        LambdaSort(words);
                        break;
                    case "4":
                        DistinctWords(words);
                        break;
                    case "5":
                        FirstFiftyWords(words);
                        break;
                    case "6":
                        PrintReverse(words);
                        break;
                    case "7":
                        EndsWithA(words);
                        break;
                    case "8":
                        IncludesM(words);
                        break;
                    case "9":
                        LessThanFourCharsIncludesI(words);
                        break;
                    case "x":
                        option = 1;
                        break;
                    default:
                        break;
                }
            }
            while (option == 0);
        }

        static void ImportWordsFromFile(IList<string> words)
        {
            try
            {
                words.Clear();

                using(StreamReader sr = new StreamReader("Words.txt"))
                {
                    string word;

                    while((word = sr.ReadLine()) != null)
                    {
                        words.Add(word);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Console.WriteLine(words.Count);
        }

        static void BubbleSort(IList<string> words)
        {
            var timer = new Stopwatch();

            timer.Start();

            for(int i = 0; i < words.Count - 1; i++)
            {
                for(int j = 0; j <= words.Count - i - 1; j++)
                {
                    if (string.Compare(words[j], words[j + 1]) == 1)
                    {
                        var temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
            }

            timer.Stop();

            Console.WriteLine("Lambda sort took " + timer.ElapsedMilliseconds + " ms.");
        }

        static void LambdaSort(IList<string> words)
        {
            IList<string> sortedList = words;

            var timer = new Stopwatch();
            timer.Start();

            sortedList = words.OrderBy(w => w).ToList();

            timer.Stop();

            Console.WriteLine("Lambda sort took " + timer.ElapsedMilliseconds + " ms.");
        }

        static void DistinctWords(IList<string> words)
        {
            var UniqueWords = words.Distinct().ToList();

            Console.WriteLine("Number of distinct words: " + UniqueWords.Count);
        }

        static void FirstFiftyWords(IList<string> words)
        {
            var FirstFifty = words.Take(50).ToList();

            foreach(var word in FirstFifty)
            {
                Console.WriteLine(word);
            }
        }

        static void PrintReverse(IList<string> words)
        {
            var ListReverse = words.Reverse().ToList();

            foreach(var word in ListReverse)
            {
                Console.WriteLine(word);
            }
        }

        static void EndsWithA(IList<string> words)
        {
            var filteredList = words.Where(w => w.EndsWith("a")).ToList();
            
            foreach(var word in filteredList)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("Number of words that end with 'a': " + filteredList.Count());
        }

        static void IncludesM(IList<string> words)
        {
            var filteredList = words.Where(w => w.ToLower().Contains("m")).ToList();

            foreach (var word in filteredList)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("Number of words that include 'm': " + filteredList.Count());
        }

        static void LessThanFourCharsIncludesI(IList<string> words)
        {
            var filteredList = words.Where(w => w.Length < 4 && w.ToLower().Contains("i")).ToList();

            foreach (var word in filteredList)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("Number of words that are less than 4 characters long and include 'i': " + filteredList.Count());
        }
        static void ConsoleMenu()
        {
            Console.WriteLine("1 - Import words from file");
            Console.WriteLine("2 - Bubble sort words");
            Console.WriteLine("3 - LINQ / Lambda sort words");
            Console.WriteLine("4 - Count the distinct words");
            Console.WriteLine("5 - Take the first 50 words");
            Console.WriteLine("6 - Reverse print the words");
            Console.WriteLine("7 - Get and display words that end with 'a' and display the count");
            Console.WriteLine("8 - Get and display words that include 'm' and display the count");
            Console.WriteLine("9 - Get and display words that are less than 4 characters long and include the letter 'l' and display the count");
            Console.WriteLine("x - Exit");
        }
    }
}