using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using System.Text;

namespace BookshopTest
{
    internal static class DataGenerator
    {
        public static ICustomer newCustomer(IDataLayer dataLayer)
        {
            SimpleCustomer customer = newCustomer();
            customer.Id = dataLayer.Customers.add(customer);
            return customer;
        }
        public static Counter<IBook> newBooks(IDataLayer dataLayer)
        {
            Counter<IBook> books = new Counter<IBook>();
            Random r = new Random();
            int num = r.Next(2, 6);

            for (int i = 0; i < num; i++)
            {
                SimpleBook book = newBook();
                book.Id = dataLayer.Catalogue.add(book);
                books.Set(book, r.Next(1, 5));
            }
            return books;
        }
        public static Counter<IBook> newBooks()
        {
            Counter<IBook> books = new Counter<IBook>();
            books.Add(newBook());
            books.Add(newBook());
            books.Set(newBook(), 3);
            return books;
        }
        public static SimpleBook newBook()
        {
            Random r = new Random();

            string title = RandomNames();
            string author = RandomNames();
            string description = LoremIpsum(5, 3);
            double price = r.Next(50) + 10;

            return new SimpleBook(null, title, author, description, price);
        }
        public static SimpleCustomer newCustomer()
        {
            Random r = new Random();

            string firstName = RandomName();
            string lastName = RandomName();
            string address = RandomAddress();
            string? contactInfo = r.Next(500_000_000, 800_000_000).ToString();

            return new SimpleCustomer(null, firstName, lastName, address, contactInfo);
        }
        public static SimpleSupplier newSupplier()
        {
            Random r = new Random();

            string firstName = RandomName();
            string lastName = RandomName();
            string companyName = RandomName();
            string address = RandomAddress();
            string? contactInfo = r.Next(500_000_000, 800_000_000).ToString();

            return new SimpleSupplier(null, firstName, lastName, companyName, address, contactInfo);
        }

        internal static SimpleBook copy(IBook book)
        {
            return new SimpleBook(book.Id, book.Title, book.Author, book.Description, book.Price);
        }
        internal static SimpleCustomer copy(ICustomer customer)
        {
            return new SimpleCustomer(
                customer.Id, customer.FirstName, customer.LastName,
                customer.Address, customer.ContactInfo
                );
        }
        internal static SimpleSupplier copy(ISupplier supplier)
        {
            return new SimpleSupplier(
                supplier.Id, supplier.FirstName, supplier.LastName,
                supplier.CompanyName, supplier.Address, supplier.ContactInfo
                );
        }

        static string RandomAddress()
        {
            Random r = new Random();
            StringBuilder address = new StringBuilder();

            address.Append(r.Next(1, 100));
            address.Append(' ');
            address.Append(RandomName());
            address.Append(" Street, ");
            address.Append(r.Next(10_000, 100_000));
            address.Append(' ');
            address.Append(RandomName());

            return address.ToString();
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
