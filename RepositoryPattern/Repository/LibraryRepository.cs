using LibraryManagementSystemApp.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace LibraryManagementSystemApp.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly SampleContext _context;

        public LibraryRepository(SampleContext context)
        {
            _context = context;
        }

        public LibraryRepository()
        {
            _context = new SampleContext();
        }

        public IEnumerable<Library> GetAllLibraries()
        {
            return _context.Libraries.ToList();
        }

        public Library GetLibraryById(int LibraryID)
        {
            return _context.Libraries.Find(LibraryID);
        }

        public int InsertLibrary(Library library)
        {
            _context.Libraries.Add(library);
            SaveLibrary();
            return library.Id;
        }

        public int UpdateLibrary(Library library)
        {
            _context.Entry(library).State = EntityState.Modified;
            SaveLibrary();
            return library.Id;
        }

        public void DeleteLibrary(int LibraryID)
        {
            throw new NotImplementedException();
        }

        public void SaveLibrary()
        {
            _context.SaveChanges();
        }
        public IEnumerable<Library> GetAllLibrariesUsingJoins()
        {
            var lib = _context.Libraries.Include("Books").ToList();
            return lib;
        }

        public IEnumerable<Library> GetLibraryByNameAndCity()
        {
            IEnumerable<Library> library = (from l in _context.Libraries
                                            where l.Name.Length == 3 && l.City.Contains("i")
                                            select l);
            
            return library;
        }
        public IEnumerable<Library> GetLibraryBookUsingJoin(string libraryName, string bookAuthor)
        {
            var libBook = (from library in _context.Libraries
                           join book in _context.Books
                           on library.Id equals book.Libraryid
                           where library.Name == libraryName && book.Author == bookAuthor
                           select new Library
                           {
                               Name = library.Name,
                               City = library.City,
                               Books = new List<Book>
                       {
                           new Book
                           {
                               Bookname = book.Bookname,
                               Author = book.Author
                           }
                       }
                           });

            return libBook;
        }


    }

}


