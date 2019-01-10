﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenresDto Genre { get; set; }

        [Required]
        public int NumbersInStock { get; set; }

    }
}