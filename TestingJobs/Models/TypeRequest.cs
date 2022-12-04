using System.ComponentModel.DataAnnotations;

namespace TestingJobs.Models
{
    public class TypeRequest
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }
        
        public int PriorityID { get; set; }
        //public Priority? Priority { get; set; }

        public string SLA { get; set; }
    }
}
