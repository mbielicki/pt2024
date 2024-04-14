using Bookshop.Data.Model;
using System.Text;

namespace BookshopTest
{
    internal static class DataGenerator
    {
        public static Book newBook()
        {
            Random r = new Random();

            string title = RandomNames();
            string author = RandomNames();
            string description = LoremIpsum(5, 3);
            double price = r.Next(50) + 10;

            return new Book(null, title, author, description, price);
        }

        internal static Book copyBook(Book book)
        {
            return new Book(book.Id, book.Title, book.Author, book.Description, book.Price);
        }

        static string LoremIpsum(int wordsNumber, int sentencesNumber)
        {
            StringBuilder result = new StringBuilder();

            for (int s = 0; s < sentencesNumber; s++)
            {
                result.Append(LoremIpsum(wordsNumber));
                result.Append(". ");
            }

            return result.ToString();
        }
        static string LoremIpsum(int wordsNumber = 2)
        {
            var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                    "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                    "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random();

            StringBuilder result = new StringBuilder();

            for (int w = 0; w < wordsNumber; w++)
            {
                if (w > 0) { result.Append(" "); }
                string newWord = words[rand.Next(words.Length)];
                if (w == 0)
                {
                    newWord = char.ToUpper(newWord[0]) + newWord.Substring(1);
                }
                result.Append(newWord);
            }
            return result.ToString();
        }
        static string RandomName()
        {
            Random r = new Random();
            string[] syllables = ["eng", "er", "a", "ly", "ed", "i", "es", "re", "son", "in", "e", "con", "y", "ter", "ji", "al", "de", "com",
                                "o", "di", "en", "an", "ty", "ry", "u", "ti", "ri", "be", "per", "to", "pro", "ac", "ad", "ar", "ers", "mi",
                                "or", "ark", "ble", "der", "ma", "na", "si", "un", "at", "en", "ca", "ja", "man", "ap", "els", "ens", "an"];
            string Name = "";

            int numSyllables = r.Next(4) + 2;
            for (int i = 0; i < numSyllables; i++)
            {
                Name += syllables[r.Next(syllables.Length)];

            }
            return char.ToUpper(Name[0]) + Name.Substring(1); ;
        }

        static string RandomNames(int n = 2)
        {
            string Name = "";

            for (int i = 0; i < n; i++)
            {
                Name += RandomName();
                if (i != n - 1) Name += " ";
            }

            return Name;
        }
    }
}
