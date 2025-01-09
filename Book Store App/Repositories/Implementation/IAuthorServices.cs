using Book_Store_App.Models.Domain;

namespace Book_Store_App.Repositories.Implementation
{
    public interface IAuthorServices
    {
        bool Add(Author model);
        bool update(Author model);
        bool delete(int id);

        Author FindById(int id);
        IEnumerable<Author> GetAll();
    }
}
