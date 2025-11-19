using System;

public class Book
{
    private string _isbn;
    private string _title;
    private string _author;
    private double _price;
    private int _stock;

    public string Isbn
    {
        get => _isbn;
        private set => _isbn = value ?? throw new ArgumentNullException(nameof(Isbn));
    }

    public string Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(Title));
    }

    public string Author
    {
        get => _author;
        set => _author = value ?? throw new ArgumentNullException(nameof(Author));
    }

    public double Price
    {
        get => _price;
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Price), "Price must be >= 0.");
            _price = value;
        }
    }

    public int Stock
    {
        get => _stock;
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Stock), "Stock must be >= 0.");
            _stock = value;
        }
    }

    public bool IsAvailable => Stock > 0;

    public Book(string isbn, string title, string author, double price, int stock)
    {
        Isbn = isbn;
        Title = title;
        Author = author;
        Price = price;
        Stock = stock;
    }

    public void Rent()
    {
        if (!IsAvailable)
            throw new InvalidOperationException($"Book '{Title}' is not available for rent.");

        Stock -= 1;
    }

    public void Return()
    {
        Stock += 1;
    }

    public void Reprice(double newPrice)
    {
        Price = newPrice; 
    }

    public override string ToString()
    {
        return $"{Isbn} | {Title} | {Author} | {Price:0.00} | stock={Stock}";
    }
}
