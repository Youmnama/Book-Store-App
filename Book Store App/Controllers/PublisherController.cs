using Book_Store_App.Models.Domain;
using Book_Store_App.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store_App.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IGenreServices services;
        public  PublisherController(IGenreServices services)
        {
            this.services = services;

        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre model)
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
        public IActionResult Update(Genre model)
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
