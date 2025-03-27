using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppDemo.Models
{
    
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int useriD { get; set; } 


        [Required(ErrorMessage = "Please enter username !")]
        [Display(Name = "UserName :")]
        [StringLength(maximumLength: 10, MinimumLength = 4, ErrorMessage = "userName length should be max :- 10 or min :- 4")]
        [Remote("IsUserNameAvailable", "Customer", HttpMethod = "POST", ErrorMessage = "User Already Available")]
        public string? userName { get; set; }

        [Required(ErrorMessage = "Please pnter phoneNo !")]
        [Display(Name = "PhoneNo :")]
        [StringLength(maximumLength: 12, MinimumLength = 10, ErrorMessage = "PhoneNo InvaLid")]
        public string? phoneNo { get; set; }

        [Required(ErrorMessage = "Please enter address !")]
        [Display(Name = "Address :")]
        public string? address { get; set; }

        
        [Required(ErrorMessage = "Please enter email !")]
        [Display(Name = "Email-Id :")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Please enter password !")]
        [Display(Name = "Password :")]
        [StringLength(maximumLength: 14, MinimumLength = 8, ErrorMessage = "password length should be max :- 14 or min :- 8")]
        [DataType(DataType.Password)]
        public string? password { get; set; }

        [Required(ErrorMessage = "Please Enter Re-password !")]
        [Display(Name = "Re-password :")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string? rePassword { get; set; }

        [Required(ErrorMessage = "Select Gender !")]
        [Display(Name = "Gender :")]
        public string? gender { get; set; }

        [Required(ErrorMessage = "Select image !")]
        [Display(Name = "Profile Image:")]
        public string? dp { get; set; }
    }
}
