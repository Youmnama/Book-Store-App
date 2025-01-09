using Microsoft.EntityFrameworkCore;

namespace Book_Store_App.Models.Domain
{
    public class DataBaseContext :DbContext
    {


        public DataBaseContext( DbContextOptions<DataBaseContext> options    ):base (options)
        {
            
        }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Puplisher> Puplisher { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> author { get; set; }
    }
}
