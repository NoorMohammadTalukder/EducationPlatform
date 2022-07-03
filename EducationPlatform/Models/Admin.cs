//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EducationPlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Admin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide Name")]
        [RegularExpression(@"(?:[A-Z][a-zA-Z\. _]+)+[_a-zA-Z]", ErrorMessage = "Enter a valid name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please provide Email")]
        [EmailAddress(ErrorMessage = "Email format not matched ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide Phone Number")]
        [Phone(ErrorMessage = "Please provide Phone number")]
        public string Phone { get; set; }
        public byte[] Photo { get; set; }

        [Required(ErrorMessage = "Please provide Password")]
       
        public string Password { get; set; }
    }
}
