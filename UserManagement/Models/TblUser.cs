using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UserManagement.Models
{
    public partial class TblUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name"), MaxLength(50)]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Please enter your Email"), MaxLength(50)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Please enter your Address"), MaxLength(50)]

        public string Address { get; set; }

        //[Required(ErrorMessage = "Please enter your phone number"), MaxLength(50)]

        public string Phone { get; set; }
    }
}
