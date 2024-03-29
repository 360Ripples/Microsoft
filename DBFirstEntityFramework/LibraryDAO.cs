﻿using DBFirstEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstEntityFramework
{
    public class LibraryDAO
    {
        public void saveLibrary()
        {
            using (SampleContext context = new SampleContext())
            {
                //Creating a new Library
                var library = new Library();


                library.Id = 10;
                library.Name = "Global Library";
                library.City = "Chennai";


                //Adding new library to the context object
                //Now the context object will track this entity
                context.Libraries.Add(library);
                //Now the context object wll track the Library entity as in Added State
                Console.WriteLine($"Before SaveChanges Entity State: {context.Entry(library).State}");
                //Calling the SaveChanges method to store the newly added entity into the database
                //The context object will generate the INSERT SQL Querey as the Entity in Added State
                context.SaveChanges();
                //Once the SaveChanges Method Executed Successfully, the entity state will changed to Unchanged
                Console.WriteLine($"After SaveChanges Entity State: {context.Entry(library).State}");

                //Verifying the newly Added Library
                List<Library> listLibraries = context.Libraries.ToList();
                foreach (Library l in listLibraries)
                {
                    Console.WriteLine($"ID: {l.Id} Name = {l.Name} City = {l.City}");
                }
                Console.ReadKey();
            }
        }
        public void fetchAllUsingJoins()
        {
            using (SampleContext context = new SampleContext())
            {

                //Method Syntax
                var lib = context.Libraries.Include("Books").ToList();

                //Method Syntax with Lambda Exp
                // var lib = context.Libraries.Include(x => x.Books).ToList();
                foreach (var l in lib)
                {
                    Console.WriteLine($"Library Name: {l.Name} {l.City}");
                    foreach (var books in l.Books)
                    {
                        Console.WriteLine($"\tBook ID: {books.Bookid} Book Name: {books.Bookname} Author:{books.Author}");
                    }
                }
                Console.Read();
            }

        }
        public void filterDemo()
        {

            using (SampleContext context = new SampleContext())
            {
                var library = (from l in context.Libraries
                               where l.City == "Chennai" || l.Name.Length == 4
                               select l).ToList();
              
                foreach (var l in library)
                {
                    Console.WriteLine($"Library Name: {l.Name},City: {l.City}");
                }

                Console.Read();


            }
        }
        public void FetchAllUsingLazyLoading()
        {
            using (SampleContext context = new SampleContext())
            {
                // Lazy loading will occur when accessing the Books property
                var libraries = context.Libraries.ToList();

                foreach (var library in libraries)
                {
                    Console.WriteLine($"Library Name: {library.Name} {library.City}");

                    // Lazy loading will occur here when accessing the Books property
                    foreach (var books in library.Books)
                    {
                        Console.WriteLine($"\tBook ID: {books.Bookid} Book Name: {books.Bookname} Author: {books.Author}");
                    }
                }

                Console.Read();
            }

        }
        public void InsertLibraryWithBooks()
        {
            using (SampleContext context = new SampleContext())
            {
                // Create a new Library and associate books with it
                Library l = new Library
                {
                    Id = 11,
                    Name = "SSS",
                    City = "Delhi",
                    Books = new List<Book>
            {
                new Book { Bookid=11 ,Bookname = "Python", Author = "Raji" },
                new Book { Bookid=12 ,Bookname = "HTML", Author = "Kalai" },
                
            }
                };

                // Add the newLibrary and its associated books to the context
                context.Libraries.Add(l);

                // Save changes to the database
                context.SaveChanges();
            }
        }
        

    }
}