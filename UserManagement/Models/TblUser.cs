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

        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
                ErrorMessage = "Email is required and must be properly formatted.")]
        [Display(Order = 10, Name = "Email")] public string Email { get; set; }

        //[Required(ErrorMessage = "Please enter your Address"), MaxLength(50)]

        public string Address { get; set; }

        //[Required(ErrorMessage = "Please enter your phone number"), MaxLength(50)]

        public string Phone { get; set; }
    }
}
