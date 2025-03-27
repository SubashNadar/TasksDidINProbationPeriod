using System.ComponentModel.DataAnnotations;

namespace JqueryAjaxWebApp.Models
{
    public partial class Employee
    {
        [Key]
        public int empId { get; set; }

        [Required(ErrorMessage = "Please enter name !")]
        [Display(Name = "Name ")]
        public string? empname { get; set; }

        [Required(ErrorMessage = "Please pick birthdate")]
        [Display(Name = "DOB ")]
        public DateTime dob { get; set; }

        [Required(ErrorMessage = "Please select gender !")]
        [Display(Name = "Gender ")]
        public char gender { get; set; }

        [Required(ErrorMessage = "Please enter email !")]
        [Display(Name = "Email ")]
        public string?email { get; set; }

        [Required(ErrorMessage = "Please enter password !")]
        [Display(Name = "Password ")]
        [DataType(DataType.Password)]
        public string? usrpassword { get; set; }

        [Required(ErrorMessage = "Please Enter password again!")]
        [Display(Name = " Re-password ")]
        [DataType(DataType.Password)]
        [Compare("usrpassword")]
        public string? rePassword { get; set; }

        [Required(ErrorMessage = "Please enter mobile no !")]
        [Display(Name = "PhoneNo ")]
        public string? phoneno { get; set; }

        [Required(ErrorMessage = "Please select country !")]
        [Display(Name = "Country ")]
        public string? countryName { get; set; }

        [Required(ErrorMessage = "Please select state !")]
        [Display(Name = "State ")]
        public string? cStateName { get; set; }

        //[Required(ErrorMessage = "Please select department !")]
        //[Display(Name = "Department ")]
        //public string? deptName { get; set; }

        //[Required(ErrorMessage = "Please select manager !")]
        //[Display(Name = "Manager ")]
        //public string? managerName { get; set; }

        //[Required(ErrorMessage = "Please select role")]
        //[Display(Name = "role ")]
        //public string? roleName { get; set; }
        //[Required(ErrorMessage = "Please select department !")]
        //[Display(Name = "Department ")]
        //public string? deptName2 { get; set; }

        //[Required(ErrorMessage = "Please select manager !")]
        //[Display(Name = "Manager ")]
        //public string? managerName2 { get; set; }

        //[Required(ErrorMessage = "Please select role")]
        //[Display(Name = "role ")]
        //public string? roleName2 { get; set; }
        //[Required(ErrorMessage = "Please select department !")]
        //[Display(Name = "Department ")]
        //public string? deptName3 { get; set; }

        //[Required(ErrorMessage = "Please select manager !")]
        //[Display(Name = "Manager ")]
        //public string? managerName3 { get; set; }

        //[Required(ErrorMessage = "Please select role")]
        //[Display(Name = "role ")]
        //public string? roleName3 { get; set; }
        //[Required(ErrorMessage = "Please select department !")]
        //[Display(Name = "Department ")]
        //public string? deptName4 { get; set; }

        //[Required(ErrorMessage = "Please select manager !")]
        //[Display(Name = "Manager ")]
        //public string? managerName4 { get; set; }

        //[Required(ErrorMessage = "Please select role")]
        //[Display(Name = "role ")]
        //public string? roleName4 { get; set; }
        //[Required(ErrorMessage = "Please select department !")]
        //[Display(Name = "Department ")]
        //public string? deptName5 { get; set; }

        //[Required(ErrorMessage = "Please select manager !")]
        //[Display(Name = "Manager ")]
        //public string? managerName5 { get; set; }

        //[Required(ErrorMessage = "Please select role")]
        //[Display(Name = "role ")]
        //public string? roleName5 { get; set; }
    }
}
