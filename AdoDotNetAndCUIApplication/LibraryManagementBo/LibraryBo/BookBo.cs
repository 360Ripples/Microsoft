using CommonUtility;
using LibraryManagementDao.LibraryAdoDao;
using LibraryManagementDao.LibraryException;
using LibraryManagementVo;
using Serilog;
using System.Data;

namespace LibraryManagementBo.LibraryBo
{


    public class BookBo
    {



        IBookDao bookDao = new BookDao();
        BookManagementLogger logger = new BookManagementLogger();



        public bool InsertBook(BookVo vo)
        {
            bool flag = false;
            bool b = false;


            try
            {
                Log.Information("Adding a Book {Vo}", vo);
                int n = vo.isbn.Length;
                if (n != 10)
                {
                    b = false;
                }

                int sum = 0;
                for (int i = 0; i < 9; i++)
                {
                    int digit = vo.isbn[0] - '0';

                    if (0 > digit || 9 < digit)
                    {
                        Log.Debug("ISBN RULE 1:ISBN invalid for the given id {Id}", vo.id);
                        return b;

                    }

                    sum += digit * (10 - i);
                }


                char last = vo.isbn[9];
                if (last != 'X' && (last < '0'
                             || last > '9'))
                {
                    Log.Debug("ISBN RULE 2:ISBN invalid for the given id {Id}", vo.id);
                    return b;
                }


                sum += last == 'X' ? 10 : last - '0';


                b = sum % 11 == 0;
                if (b)
                {
                    Log.Debug("Valid ISBN Number for the given id {id}", vo.id);
                }
                else
                {
                    throw new BookManagementException("ISBN Number Not Valid.Plz give the Valid one and proceed with Adding Book Details..");
                }

                flag = bookDao.AddBook(vo);//true

                Log.Information("Adding Book {BookResponce}response...", flag);
            }
            catch (BookManagementException e)
            {
                throw new BookManagementException(e.Message);

            }

            return flag;//true

        }
        public BookVo GetBook(int id)
        {
            BookVo vo = new BookVo();
            vo = bookDao.FetchBook(id);
            return vo;


        }
        public List<BookVo> GetBooks()
        {

            List<BookVo> list = new List<BookVo>();
            list = bookDao.FetchBooks();
            return list;

        }


    }
}
