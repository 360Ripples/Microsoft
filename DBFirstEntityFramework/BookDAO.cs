using DBFirstEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstEntityFramework
{
    public class BookDAO
    {
        public void saveBook()
        {
            using (SampleContext context = new SampleContext())
            {
                // Create a new book
                var book = new Book()
                {
                    Bookid = 8,  // Set a unique book id
                    Bookname = "Web Api",
                    Author = "John",
                    Libraryid = 3  
                };

                // Add the new book to the context
                context.Books.Add(book);

                // Save changes to the database
                context.SaveChanges();
                Console.WriteLine("Record Added successfully..."+book.Bookid);
            }


        }
        public void fetchBooks()
        {
            using (SampleContext context = new SampleContext())
            {
                var books = context.Books.ToList();

                foreach (var book in books)
                {
                    Console.WriteLine($"Book ID: {book.Bookid}, Name: {book.Bookname}, Author: {book.Author}");
                }
            }


        }
    }

}
