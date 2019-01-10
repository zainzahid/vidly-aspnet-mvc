using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        public string MembershipTypeName { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonth { get; set; }

        public byte DiscountRate { get; set; }
    }
}