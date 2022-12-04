using System.ComponentModel.DataAnnotations;

namespace TestingJobs.Models
{
    public class Priority
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

       // public List<TypeRequest> RequestTypes { get; set; } = new(); 
    }
}
