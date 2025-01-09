using Book_Store_App.Models.Domain;

namespace Book_Store_App.Repositories.Implementation
{
    public class GenreServices : IGenreServices
    {
        private readonly DataBaseContext context;
        public GenreServices(DataBaseContext context)
        {
            this.context = context;         
            
        }
        public bool Add(Genre model)
        {

            try
            {
                context.Genre.Add(model);
                context.SaveChanges();
                return true;
            }
            catch(Exception Ex)
            {
                return false;

            }
       
        }

        public bool delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if(data ==null)
                    return false;    
                context.Genre.Remove(data);
                context.SaveChanges();
                return true;

            }
            catch(Exception Ex)
            {
                return false;

            }
        }

        public Genre FindById(int id)
        {
            return context.Genre.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return context.Genre.ToList(); 
        }

        public bool update(Genre model)
        {
            try
            {
                context.Genre.Update(model);
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
