using System.ComponentModel.DataAnnotations;

namespace JqueryAjaxWebApp.Models
{
    public class Manager
    {
        [Key]
        public int mid { get; set; }
        public string? mname { get; set; }
    }
}
