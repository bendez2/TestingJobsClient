using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestingJobs.Models
{
    public class Priority
    {
        public int Id { get; set; }

        public string Name { get; set; } 
    }
}
