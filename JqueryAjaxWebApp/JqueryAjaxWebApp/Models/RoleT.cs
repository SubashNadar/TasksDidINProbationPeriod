using System.ComponentModel.DataAnnotations;

namespace JqueryAjaxWebApp.Models
{
    public class RoleT
    {
        [Key]
        public int rid { get; set; }

        public string? rname { get; set; }
    }
}
