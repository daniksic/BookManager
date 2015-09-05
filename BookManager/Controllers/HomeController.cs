using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManager.BL.Repository;
using BookManager.Entities.Books;

namespace BookManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var booksRepo = new Books();
            var books = booksRepo.GetByPage(0);//REFACTORING model should be DTO

            return View(books);
        }

        struct keyarr
        {
            public int key { get; set; }
            public object arr { get; set; }
        }

        public ActionResult Delete()
        {
            //[[1,2,[3]],4] -> [1,2,3,4]
            var arrs = new Object[] { 1, 2, new Object[] { 3 }, 4 };

            var result = new List<int>();

            foreach (var item in arrs)
            {
                if (item is int)
                {
                    result.Add((int)item);
                }
                else
                {

                }
            }



            return View();
        }

        [HttpPost]
        public ActionResult Delete(Book model)
        {
            var booksRepo = new Books();
            var success = booksRepo.Delete(model);
            if (success)
            {
                return RedirectToAction("index");
            }

            return View(model);
        }
    }
}