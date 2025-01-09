using Book_Store_App.Models.Domain;

namespace Book_Store_App.Repositories.Implementation
{
    public class PublisherServices : IPublisher
    {
        private readonly DataBaseContext context;
        public PublisherServices(DataBaseContext context)
        {
            this.context = context;         
            
        }
        public bool Add(Puplisher model)
        {
            try
            {
                context.Puplisher.Add(model);
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
                context.Puplisher.Remove(data);
                context.SaveChanges();
                return true;

            }
            catch(Exception Ex)
            {
                return false;

            }
        }

        public Puplisher FindById(int id)
        {
            return context.Puplisher.Find(id);
        }

        public IEnumerable<Puplisher> GetAll()
        {
            return context.Puplisher.ToList(); 
        }

        public bool update(Puplisher model)
        {
            try
            {
                context.Puplisher.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
