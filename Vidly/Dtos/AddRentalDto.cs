using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class AddRentalDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}