using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{
    static void Main(string[] args)
    {
        BookManager bookManager = new BookManager();

        while (true)
        {

            Console.WriteLine("1. axali wignis damateba siashi");
            Console.WriteLine("2. yveal wignis siis chveneba");
            Console.WriteLine("3. wignis dzebna misi satauris mixedvit");
            Console.WriteLine("4. dasruleba");

            Console.WriteLine(" airchiet sasurveli moqmedeba ");
            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    Console.Write("sheiyvanet wignis satauri: ");
                    string title = Console.ReadLine();
                    Console.Write("sheiyvanet wignis avtori: ");
                    string author = Console.ReadLine();
                    Console.Write("sheiyvanet gamocemis weli: ");
                    int year;
                    if (!int.TryParse(Console.ReadLine(), out year))
                    {
                        Console.WriteLine("gamocemis weli arasworia ");
                        break;
                    }
                    bookManager.AddBook(title, author, year);
                    break;
                case "2":
                    Console.Write("wignebis chamonatvali:");
                    bookManager.ShowBooks();
                    break;
                case "3":
                    Console.Write("shiyvanet sadziebo wignis satauri: ");
                    string searchTitle = Console.ReadLine();
                    bookManager.SearchByTitle(searchTitle);
                    break;
                case "4":
                    Console.WriteLine("dasruleba");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("araswori moqmedeba. ");
                    break;
            }
        }
    }
}


