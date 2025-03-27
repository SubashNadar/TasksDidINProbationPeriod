using System.ComponentModel.DataAnnotations;

namespace JqueryAjaxWebApp.Models
{
    public class department
    {
        [Key]
        public int deptId { get; set; }
        public string? deptName { get; set; }
    }
}
