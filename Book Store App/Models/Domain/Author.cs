using System.ComponentModel.DataAnnotations;

namespace Book_Store_App.Models.Domain
{
    public class Author
    {

        public int Id { get; set; }

        [Required]

        public string AuthorName { get; set; }
    }
}
