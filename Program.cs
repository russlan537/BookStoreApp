using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var catalog = new Catalog();
            catalog.Add(new Book("978-5-4461-0923-5", "CLR via C#", "Jeffrey Richter", 55.0, 3));
            catalog.Add(new Book("978-0-1347-0779-3", "Clean Code", "Robert C. Martin", 48.5, 1));
            catalog.Add(new Book("978-1-1188-9912-4", "C# in Depth", "Jon Skeet", 52.9, 2));

            var store = new BookStore(catalog);

            Console.WriteLine("=== Каталог при запуске ===");
            store.PrintCatalog();

            Console.WriteLine("\nПроверим книгу по ISBN:");
            var book = catalog["978-0-1347-0779-3"];
            Console.WriteLine($"Найдена книга: {book.Title} — Автор: {book.Author}");

            Console.WriteLine("\nАренда книги 'Clean Code'");
            store.Rent("978-0-1347-0779-3");
            store.PrintCatalog();

            Console.WriteLine("\nПопытка снова арендовать 'Clean Code':");
            try
            {
                store.Rent("978-0-1347-0779-3");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nВозврат книги 'Clean Code'");
            store.Return("978-0-1347-0779-3");
            store.PrintCatalog();

            Console.WriteLine("\nИзменение цены книги 'C# in Depth'");
            store.SetPrice("978-1-1188-9912-4", 59.9);
            store.PrintCatalog();

            Console.WriteLine("\nКнига с индексом [0]:");
            Console.WriteLine(catalog[0]);

            Console.WriteLine("\nУдаление книги 'CLR via C#'");
            catalog.Remove("978-5-4461-0923-5");
            store.PrintCatalog();

            Console.WriteLine("\n=== Проверка индексаторов ===");

            Console.WriteLine("Поиск книги по ISBN:");
            var cleanCode = catalog["978-0-1347-0779-3"];
            Console.WriteLine(cleanCode);

            Console.WriteLine("\nКнига с индексом [1]:");
            Console.WriteLine(catalog[1]);

            Console.WriteLine("\nПервая книга Роберта Мартина:");
            try
            {
                var bookByAuthor = catalog[("Robert C. Martin", 0)];
                Console.WriteLine(bookByAuthor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обращении по кортежу: {ex.Message}");
            }

            Console.WriteLine("\nПроверка исключения для несуществующего индекса:");
            try
            {
                Console.WriteLine(catalog[10]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
            }

            Console.WriteLine("\nПроверка завершена успешно.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Глобальная ошибка: {ex.Message}");
        }

        Console.WriteLine("\nРабота программы завершена.");
    }
}
