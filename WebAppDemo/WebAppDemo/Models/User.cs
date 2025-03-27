using System.ComponentModel.DataAnnotations;

namespace WebAppDemo.Models
{
    public partial class User
    {
       public string? userName { get; set; }

       public string? phoneNo { get; set; }

       public string? address { get; set; }

       public string? email { get; set; }

        public string? password { get; set; }

       public string? rePassword { get; set; }

       public string? gender { get; set; }

       public string? dp { get; set; }

    }
}
