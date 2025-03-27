using System.ComponentModel.DataAnnotations;

namespace JqueryAjaxWebApp.Models
{
    public class CState
    {
        [Key]
        public int csid { get; set; }
        public string? sname { get; set; }
        public int cid { get; set; }
    }
}
