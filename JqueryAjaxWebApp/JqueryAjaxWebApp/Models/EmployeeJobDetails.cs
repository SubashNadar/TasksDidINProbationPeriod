using System.ComponentModel.DataAnnotations;

namespace JqueryAjaxWebApp.Models
{
    public class EmployeeJobDetails
    {
        [Key]
        
        public int ejdId { get; set; }
        public int employeeId { get; set; }
        public int deptid { get; set; }
        public int managid { get; set; }
        public int roleid { get; set; }
    }
}
