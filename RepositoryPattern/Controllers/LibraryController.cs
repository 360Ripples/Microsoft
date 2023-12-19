using LibraryManagementSystemApp.BO;
using LibraryManagementSystemApp.Models;
using LibraryManagementSystemApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web;

namespace LibraryManagementSystemApp.Controllers
{
    public class LibraryController : Controller
    {
        private LibraryBO _libraryBO = null;
        private ILibraryRepository _libraryRepository = null;

        public LibraryController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
            _libraryBO = new LibraryBO(libraryRepository);
        }
        // GET: LibraryController
        public ActionResult Index()
        {
            IEnumerable<Library> libraryList = _libraryBO.GetAllLibraries();
            return View("Views/Library/LibraryList.cshtml", libraryList);
        }

        // GET: LibraryController/Details/5
        public ActionResult Details(int id)
        {
            Library l = _libraryBO.GetLibraryById(id);
            return View("Views/Library/Details.cshtml", l);
        }

        // GET: LibraryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibraryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Library lib)
        {
            Console.WriteLine("Create Method trigerred{0}", lib);
            int id = _libraryBO.InsertLibrary(lib);
            Console.WriteLine("Library created with id{0}", id);
            if (id > 0)
            {
                ViewData["Response"] = "Library Added Successfully";
            }
            else
            {
                ViewData["Response"] = "Library Failed to Add..";
            }
            return View("Views/Library/Create.cshtml", lib);

        }

        // GET: LibraryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LibraryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Library lib)
        {
            Console.WriteLine("Create Method trigerred{0}", lib);
            int id = _libraryBO.UpdateLibrary(lib);
            Console.WriteLine("Library created with id{0}", id);
            if (id > 0)
            {
                ViewData["Response"] = "Library Updated Successfully";
            }
            else
            {
                ViewData["Response"] = "Library Failed to update..";
            }
            return View("Views/Library/Edit.cshtml", lib);
        }

        // GET: LibraryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LibraryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: LibraryController/LibraryBooks
        public ActionResult LibraryBooks()
        {
            IEnumerable<Library> libraryList = _libraryBO.GetAllLibrariesUsingJoins();
            return View("Views/Library/LibraryBooks.cshtml", libraryList);
        }

        // GET: LibraryController/LibraryWithFilter
        
        public ActionResult LibraryFilterByName()
        {
            IEnumerable<Library> l = _libraryBO.GetLibraryByNameAndCity();
            return View("Views/Library/ListView.cshtml", l);

        }

       
        public ActionResult LibraryJoinBook(string libraryName,string bookAuthor)
        {
           /* 
            if (libraryName == null)
            {
                libraryName = "";
            }
            if (bookAuthor == null)
            {
                bookAuthor = "";
            }*/

            var lib = _libraryBO.GetLibraryBookUsingJoin(libraryName,bookAuthor);
            return View("Views/Library/LibraryJoinBook.cshtml",lib);
        }
    }
}
