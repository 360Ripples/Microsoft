using LibraryManagementVo;
using System.Data;

namespace LibraryManagementDao.LibraryAdoDao
{
    public interface IBookDao
    {
        public bool AddBook(BookVo vo);
        public BookVo FetchBook(int id);
        public List<BookVo> FetchBooks();
        
    }
}