using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public string ReleaseDate { get; set; }

        public Genres Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        [Display(Name = "Numbers In Stock")]
        [Required]
        //[Min10StockIfRomanticMovie]
        public int NumbersInStock { get; set; }

        [Display(Name = "Numbers Available")]
        [Required]
        //[Min10StockIfRomanticMovie]
        public int NumbersAvailable { get; set; }
    }
}