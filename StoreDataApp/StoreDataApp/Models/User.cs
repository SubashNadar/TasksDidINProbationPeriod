using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace StoreDataApp.Models
{
    public class User
    {
        [Required(ErrorMessage = "Plzz Enter userName !")]
        [Display(Name = "Enter userName :")]
        [StringLength(maximumLength: 10, MinimumLength = 4, ErrorMessage = "userName Length Should be Max :- 10 or Min :- 4")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Plzz Enter PhoneNo !")]
        [Display(Name = "Enter PhoneNo :")]
        [StringLength(maximumLength: 12, MinimumLength = 10, ErrorMessage = "PhoneNo InvaLid")]
        public string phoneNo { get; set; }

        [Required(ErrorMessage = "Plzz Enter address !")]
        [Display(Name = "Enter address :")]
        public string address { get; set; }

        [Required(ErrorMessage = "Plzz Enter email !")]
        [Display(Name = "Enter email :")]
        public string email { get; set; }

        [Required(ErrorMessage = "Plzz Enter password !")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Plzz Enter Re-password !")]
        [Display(Name = " Re-password :")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string rePassword { get; set; }

    [Required(ErrorMessage = "Select Gender Gender !")]
    [Display(Name = "Gender:")]
    public string gender { get; set; }

    [Required(ErrorMessage = "Select Profile image !")]
    [Display(Name = "Profile Image:")]
    public string dp { get; set; }

}
}