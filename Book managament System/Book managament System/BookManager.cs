class BookManager
{
    private List<Book> books = new List<Book>();


    public void AddBook(string title, string author, int publicationYear)
    {
        Book book = new Book(title, author, publicationYear);
        books.Add(book);
        Console.WriteLine(" wigni warmatebit daemata bibliotekashi.");
    }


    public void ShowBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine(" wignebi ver moidzebna.");
            return;
        }

        foreach (var i in books)
        {
            Console.WriteLine(i);
        }
    }


    public void SearchByTitle(string title)
    {
        bool found = false; 
        foreach (var i in books)
        {
            if (i.Title.ToLower() == title.ToLower()) 
            {
                Console.WriteLine(i);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine(" wigni ver moidzebna.");
        }
    }
}


