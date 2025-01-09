using System.ComponentModel.DataAnnotations;

namespace Book_Store_App.Models.Domain
{
    public class Genre
    {

        public int Id { get; set; }
        [Required]

        public string Name { get; set; }


    }
}
