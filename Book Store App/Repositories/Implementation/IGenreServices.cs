using Book_Store_App.Models.Domain;

namespace Book_Store_App.Repositories.Implementation
{
    public interface IGenreServices
    {

        bool Add(Genre model);
        bool update(Genre model);
        bool delete(int id);

        Genre FindById(int id);
        IEnumerable<Genre> GetAll();

    }
}
