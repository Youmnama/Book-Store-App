using Book_Store_App.Models.Domain;
using System.Security.Policy;

namespace Book_Store_App.Repositories.Implementation
{
    public interface IPublisher
    {
        bool Add(Puplisher model);
        bool update(Puplisher model);
        bool delete(int id);

        Puplisher FindById(int id);
        IEnumerable<Puplisher> GetAll();
    }
}
