using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(25)]
        public string name { get; set; }

       

        [Required]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password",ErrorMessage ="Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
