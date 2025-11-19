using System;
using System.Collections.Generic;
using System.Linq;

public class Catalog
{
    private readonly Dictionary<string, Book> _books = new();

    public IReadOnlyCollection<Book> Books => _books.Values.ToList().AsReadOnly();

    public void Add(Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book));

        if (_books.ContainsKey(book.Isbn))
            throw new ArgumentException($"Book with ISBN {book.Isbn} already exists.");

        _books.Add(book.Isbn, book);
    }

    public bool Remove(string isbn)
    {
        if (isbn == null)
            throw new ArgumentNullException(nameof(isbn));

        return _books.Remove(isbn);
    }

    public bool Contains(string isbn)
    {
        if (isbn == null)
            throw new ArgumentNullException(nameof(isbn));

        return _books.ContainsKey(isbn);
    }

    public Book this[string isbn]
    {
        get
        {
            if (!_books.TryGetValue(isbn, out var book))
                throw new KeyNotFoundException($"Book with ISBN {isbn} not found.");
            return book;
        }
    }

    public Book this[int index]
    {
        get
        {
            if (index < 0 || index >= _books.Count)
                throw new IndexOutOfRangeException("Index is out of range.");

            return _books.Values.ElementAt(index);
        }
    }

    public Book this[(string author, int index) key]
    {
        get
        {
            var (author, index) = key;

            if (author == null)
                throw new ArgumentNullException(nameof(author));

            var booksByAuthor = _books.Values
                .Where(b => b.Author == author)
                .ToList();

            if (index < 0 || index >= booksByAuthor.Count)
                throw new IndexOutOfRangeException(
                    $"Author '{author}' has no book at index {index}.");

            return booksByAuthor[index];
        }
    }
}
