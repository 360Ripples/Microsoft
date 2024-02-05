using Castle.Core.Internal;
using CommonUtility;
using LibraryManagementBo.LibraryBo;
using LibraryManagementBo.LibraryService;
using LibraryManagementDao.LibraryAdoDao;
using LibraryManagementDao.LibraryException;
using LibraryManagementVo;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Data;

namespace LibraryManagementSystem
{
    public static class LibraryManagementSystemMain
    {
        static BookVo vo = new BookVo();
        static BookBo bookBo = new BookBo();
        static BookManagementLogger logger = new BookManagementLogger();
        static BookService bookService = new BookService();
        static ResponseObject responseObject = new ResponseObject();

        private static void Main(string[] args)
        {

            logger.BuildConfigure();
            Log.Information("Library Management System Application Started...");




            string? repeat = "y";
            while (repeat == "y")
            {
                Console.WriteLine("select an option:");
                Console.WriteLine("1.Add Book\n2.Fetch Book By ID\n3.Fetch All the Books\n4.Update Book");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        FetchBook();
                        break;
                    case 3:
                        FetchBooks();
                        break;
                    case 4:
                        UpdateBook();
                        break;
                    
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }
                Console.WriteLine("Do you Want to continue? If yes,press y");
                repeat = Console.ReadLine();

            }


        }

        private static void FetchBooks()
        {
            Log.Information("Fetch Books Method Started..");

            responseObject = bookService.GetAllBooks();
            List<BookVo> dataList = new List<BookVo>();
            dataList = responseObject.GetBookVoList();
            if (dataList != null)
            {
                foreach (BookVo vo in dataList)
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------");
                    Console.WriteLine("Book Id" + "\t\t" + "Book Name" + "\t\t" + "Author Name" + "\t\t" + "ISBN");
                    Console.WriteLine("--------------------------------------------------------------------------------------");
                    Console.WriteLine(vo.id + "\t\t" + vo.name + "\t\t\t" + vo.author + "\t\t" + vo.isbn);
                }
            }
            else
            {

                Console.WriteLine(responseObject.GetFailureMessage());

            }

        }

        private static void UpdateBook()
        {
            Console.WriteLine("Enter the Book ID:");
            vo.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Book Name:");
            vo.name = Console.ReadLine();



        }

        private static void FetchBook()
        {
            Log.Information("Fetch Book Method Started..");
            Console.WriteLine("Enter the Book ID to be fetched:");
            int id = Convert.ToInt32(Console.ReadLine());
            responseObject = bookService.GetBookById(id);
            vo = responseObject.GetVo();
            if (vo != null)
            {


                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("Book Id" + "\t\t" + "Book Name" + "\t\t" + "Author Name" + "\t\t" + "ISBN");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine(vo.id + "\t\t" + vo.name + "\t\t\t" + vo.author + "\t\t" + vo.isbn);

            }
            else
            {

                Console.WriteLine(responseObject.GetFailureMessage());

            }

        }

        private static void AddBook()
        {

            Log.Information("Adding Book Detail ...");
            Console.WriteLine("Enter the Book ID:");
            vo.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Book Name:");
            vo.name = Console.ReadLine();
            Console.WriteLine("Enter the Author Name:");
            vo.author = Console.ReadLine();
            Console.WriteLine("Enter the ISBN Number:");
            vo.isbn = Console.ReadLine();

            responseObject = bookService.SaveBook(vo);//true

            if (responseObject.GetSuccessMessage() != null)
            {

                Console.WriteLine(responseObject.GetSuccessMessage());

            }
            else
            {

                Console.WriteLine(responseObject.GetFailureMessage());
            }





        }
      
    }
}