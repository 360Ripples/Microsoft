using LibraryManagementSystemApp.Models;
using LibraryManagementSystemApp.Repository;

namespace LibraryManagementSystemApp.BO
{
    public class LibraryBO
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryBO(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public IEnumerable<Library> GetAllLibraries()
        {
            return (_libraryRepository.GetAllLibraries());

        }
        public Library GetLibraryById(int LibraryID)
        {
            return (_libraryRepository.GetLibraryById(LibraryID));
        }
        public int InsertLibrary(Library library)
        {
            int i;
            try
            {
                //Bussiness logic
                i = _libraryRepository.InsertLibrary(library);
            }
            catch (Exception ex)
            {
                return -1;

            }
            return i;

        }

        public int UpdateLibrary(Library library)
        {
            int code;
            try
            {
                code = _libraryRepository.UpdateLibrary(library);

            }
            catch (Exception ex)
            {
                return -1;

            }
            return code;

        }
        public IEnumerable<Library> GetAllLibrariesUsingJoins()
        {
            return (_libraryRepository.GetAllLibrariesUsingJoins());

        }
        public IEnumerable<Library> GetLibraryByNameAndCity()
        {
            IEnumerable<Library> l = _libraryRepository.GetLibraryByNameAndCity();
            return l;
        }

        public IEnumerable<Library> GetLibraryBookUsingJoin(string libraryName, string bookAuthor)
        {
            IEnumerable<Library> l =_libraryRepository.GetLibraryBookUsingJoin(libraryName,bookAuthor);
            return l;
        }
    }
}

