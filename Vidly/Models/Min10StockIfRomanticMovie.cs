using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min10StockIfRomanticMovie:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.GenreId != Genres.Romance)
                return ValidationResult.Success;

            return (movie.NumbersInStock < 10)
                ? new ValidationResult("Number In Stock Should be More than 10 for Romantic Movie")
                : ValidationResult.Success;
        }
    }
}