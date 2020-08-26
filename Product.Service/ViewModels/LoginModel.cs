using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Service.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

    }

    public class RegisterModel
    {
        [Required(ErrorMessage ="First Name is required.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name is required.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Email is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Mobile is required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid mobile number")]
        public string Mobile { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters.", MinimumLength = 5)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [Compare("Password",ErrorMessage ="Password and confirm password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}
