﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static readonly int Romance = 2;
    }
}