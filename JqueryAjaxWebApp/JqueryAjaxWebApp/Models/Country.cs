using System.ComponentModel.DataAnnotations;

namespace JqueryAjaxWebApp.Models
{
    public class Country
    {
        [Key]
        public int cid { get; set; }
        public string? cname { get; set; }
    }
}
