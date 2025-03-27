using System.ComponentModel.DataAnnotations;

namespace WebApiTask.Models
{
    public class StudentElection
    {
        [Key]
        public int Srno { get; set; }
        public int CandidateId { get; set; }
        public string type { get; set; } = "";
    }
}
