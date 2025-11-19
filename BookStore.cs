using System;

public class BookStore
{
    public Catalog Catalog { get; }

    public BookStore(Catalog catalog)
    {
        Catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
    }

    public void Rent(string isbn)
    {
        var book = Catalog[isbn];
        book.Rent();          
    }

    public void Return(string isbn)
    {
        var book = Catalog[isbn];
        book.Return();
    }

    public void SetPrice(string isbn, double price)
    {
        var book = Catalog[isbn];
        book.Reprice(price);
    }

    public void PrintCatalog()
    {
        foreach (var book in Catalog.Books)
        {
            Console.WriteLine(book);
        }
    }
}
