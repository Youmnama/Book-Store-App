using Book_Store_App.Models.Domain;
using Book_Store_App.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Book_Store_App.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices Bookservices;
        private readonly IAuthorServices authorServices;
        private readonly IGenreServices genreServices;
        private readonly IPublisher publisherServices;  

        public BookController(IBookServices bookservices , IGenreServices genreServices,IPublisher publisherServices ,IAuthorServices authorServices)
        {
            this .Bookservices = bookservices; 
            this.authorServices= authorServices;
            this.genreServices= genreServices;
            this .publisherServices= publisherServices;     
            
        }
        public IActionResult Add()
        {
            var model = new Book();
            model.AuthorList = authorServices.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString() }).ToList();
            model.PublisherList = publisherServices.GetAll().Select(a => new SelectListItem { Text = a.PuplisherName, Value = a.Id.ToString() }).ToList();
            model.GenreList = genreServices.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.AuthorList = authorServices.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherServices.GetAll().Select(a => new SelectListItem { Text = a.PuplisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreServices.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result =Bookservices .Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);

        }

        public IActionResult Update( int id)
        {
            var model = Bookservices.FindById(id);
            model.AuthorList = authorServices.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherServices.GetAll().Select(a => new SelectListItem { Text = a.PuplisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreServices.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AuthorList = authorServices.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherServices.GetAll().Select(a => new SelectListItem { Text = a.PuplisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreServices.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = Bookservices.update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);

        }

        public IActionResult delete(int id)
        {


            var result = Bookservices.delete(id);
            return RedirectToAction("GetAll");




        }

        public IActionResult GetAll()
        {

            var data = Bookservices.GetAll();
            return View(data);




        }
    }
}
 