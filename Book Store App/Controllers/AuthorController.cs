using Book_Store_App.Models.Domain;
using Book_Store_App.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store_App.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorServices services;
        public AuthorController(IAuthorServices services)
        {
            this.services = services;

        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = services.Add(model);

            if (result)
            {
                TempData["Message"] = "Added Successfully";
                return RedirectToAction(nameof(Add));

            }
            TempData["Message"] = "Erorr Has Occared";
            return View(model);

        }

        public IActionResult Update(int id)
        {
            var record = services.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = services.update(model);

            if (result)
            {
                TempData["Message"] = "Updated Successfully";
                return RedirectToAction(nameof(Add));

            }
            TempData["Message"] = "Erorr Has Occared";
            return View(model);

        }

        public IActionResult delete(int id)
        {

            var result = services.delete(id);

            return RedirectToAction("GetAll");




        }

        public IActionResult GetAll()
        {

            var data = services.GetAll();

            return View(data);




        }
    }
}
