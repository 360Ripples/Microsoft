using LibraryManagementSystemApp.Models;
using System.Collections.Generic;

namespace LibraryManagementSystemApp.Repository
{
    public interface ILibraryRepository
    {
        IEnumerable<Library> GetAllLibraries();
        Library GetLibraryById(int LibraryID);
        int InsertLibrary(Library library);
        int UpdateLibrary(Library library);
        void DeleteLibrary(int LibraryID);
        void SaveLibrary();
        IEnumerable<Library> GetAllLibrariesUsingJoins();
        IEnumerable<Library> GetLibraryByNameAndCity();
        public IEnumerable<Library> GetLibraryBookUsingJoin(string libraryName, string bookAuthor);
    }
}
