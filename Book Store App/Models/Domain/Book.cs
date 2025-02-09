﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store_App.Models.Domain
{
    public class Book
    {


        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Isbn { get; set; }
        public int TotalPages { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        [NotMapped]
        public string ? AuthorName { get; set; }
        [NotMapped]
        public string ? GeneName { get; set; }
        [NotMapped]
        public string? PublisherName { get; set; }
        [NotMapped]
        public List<SelectListItem> AuthorList { get; set; } = new List<SelectListItem>();

        [NotMapped]
        public List<SelectListItem> GenreList { get; set; } = new List<SelectListItem>();
        [NotMapped]
        public List<SelectListItem> PublisherList { get; set; } = new List<SelectListItem>();
    }
}
