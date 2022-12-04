using System.ComponentModel.DataAnnotations;

namespace TestingJobs.Models
{
    public class Initiator
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        //public List<Request> Requests { get; set; } = new();
    }
}
