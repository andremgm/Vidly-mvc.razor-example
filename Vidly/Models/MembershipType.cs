using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        [Required]
        public byte Id { get; set; }
        public short signUpFee { get; set; }
        public byte durationInMonths { get; set; }
        public byte discountRate { get; set; }
        [Required]
        public string membershipName { get; set; }



        public static readonly byte unknown = 0;
        public static readonly byte payAsYouGo = 1;

    }
}