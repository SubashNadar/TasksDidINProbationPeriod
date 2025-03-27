using System.ComponentModel.DataAnnotations;

namespace MvcForFrstApi.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } = 0;
        public string StudentName { get; set; } = "";
        public DateTime Dob { get; set; } = DateTime.Now;
        public string PhoneNo { get; set; } = "";
        public char Gender { get; set; }

        public string type { get; set; } = "";
    }
}
