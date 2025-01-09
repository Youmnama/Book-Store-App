using Book_Store_App.Models.Domain;
using System.Security.Policy;

namespace Book_Store_App.Repositories.Implementation
{
    public class BookServices : IBookServices
    {
        private readonly DataBaseContext context;
        public BookServices(DataBaseContext context)
        {
            this.context = context;         
            
        }
        public bool Add(Book model)
        {
            try
            {
                context.Book.Add(model);
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
                context.Book.Remove(data);
                context.SaveChanges();
                return true;

            }
            catch(Exception Ex)
            {
                return false;

            }
        }

        public Book FindById(int id)
        {
            return context.Book.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {

            var data = (from book in context.Book
                        join author in context.author
                      on book.AuthorId equals author.Id
                        join Publisher in context.Puplisher on book.PublisherId equals Publisher.Id
                        join genre in context.Genre on book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            AuthorId = book.AuthorId,
                            GenreId = book.Id,
                            Isbn = book.Isbn,
                            PublisherId = Publisher.Id,

                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            GeneName = genre.Name,
                            AuthorName = author.AuthorName,
                            PublisherName = Publisher.PuplisherName
                        }).ToList();
                          return data; 
        }

        public bool update(Book model)
        {
            try
            {
                context.Book.Update(model);
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
