class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }

    public Book(string title, string author, int publicationYear)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
    }

    public override string ToString()
    {
        return $"{Title}, avtori - {Author}, {PublicationYear} weli";
    }
}


