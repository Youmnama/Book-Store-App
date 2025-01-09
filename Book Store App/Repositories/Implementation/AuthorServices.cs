using Book_Store_App.Models.Domain;

namespace Book_Store_App.Repositories.Implementation
{
    public class AuthorServices :IAuthorServices
    {

        private readonly DataBaseContext context;
        public AuthorServices(DataBaseContext context)
        {
            this.context = context;

        }
        public bool Add(Author model)
        {
            try
            {
                context.author.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;

            }

        }

        public bool delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.author.Remove(data);
                context.SaveChanges();
                return true;

            }
            catch (Exception Ex)
            {
                return false;

            }
        }

        public Author FindById(int id)
        {
            return context.author.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return context.author.ToList();
        }

        public bool update(Author model)
        {
            try
            {
                context.author.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;

            }
        }


    }
}
