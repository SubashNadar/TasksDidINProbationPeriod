using System.ComponentModel.DataAnnotations;

namespace JqueryAjaxWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter User Name !")]
        [Display(Name = "User Name ")]
        public string? usrname { get; set; }

        [Required(ErrorMessage = "Please enter Password !")]
        [Display(Name = "Password ")]
        [DataType(DataType.Password)]
        public string? password { get; set; }
    }
}
