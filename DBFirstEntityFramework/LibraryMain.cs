using DBFirstEntityFramework;

internal class LibraryMain
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to my DBFirst Application Using Entity Framework!");
        LibraryDAO dao=new LibraryDAO();
         //dao.saveLibrary();
        //dao.filterDemo();
        //dao.fetchAllUsingJoins();
        dao.FetchAllUsingLazyLoading();
        //dao.InsertLibraryWithBooks();

       // BookDAO bookDAO=new BookDAO();
        //bookDAO.saveBook();
        //bookDAO.fetchBooks();   
        
    }
}