using Book_Store_App.Models.Domain;

namespace Book_Store_App.Repositories.Implementation
{
    public interface IBookServices
    {

        bool Add(Book model);
        bool update(Book model);
        bool delete(int id);

        Book FindById(int id);
        IEnumerable<Book> GetAll();

    }
}
