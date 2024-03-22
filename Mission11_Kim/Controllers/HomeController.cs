using Microsoft.AspNetCore.Mvc;
using Mission11_Kim.Models;
using Mission11_Kim.Models.ViewModels;
using System.Diagnostics;

/*
 * Donna Kim
 * Section 03
 * Description: This application takes a bookstore database and displays the books table data on a website
 */

namespace Mission11_Kim.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _repo;
        public HomeController(IBookstoreRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10; // Want to display 10 different records on one page

            var bookList = new BooksListViewModel
            {
                // set up the books data
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                // set up pagination info
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            // return the created view model to the index page
            return View(bookList);
        }
    }
}
