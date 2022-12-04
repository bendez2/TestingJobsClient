using System.ComponentModel.DataAnnotations;

namespace TestingJobs.Models
{
    public class Status
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        //public List<Request> Requests { get; set; } = new();
    }
}
