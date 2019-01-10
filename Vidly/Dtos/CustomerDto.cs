using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public int MembershipTypeId { get; set; }

        public string BirthDate { get; set; }

    }
}