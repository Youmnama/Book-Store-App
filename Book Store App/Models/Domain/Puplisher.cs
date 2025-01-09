using System.ComponentModel.DataAnnotations;

namespace Book_Store_App.Models.Domain
{
    public class Puplisher
    {

        public int Id { get; set; }
        [Required]
        public string PuplisherName { get; set; }    
    }
}
