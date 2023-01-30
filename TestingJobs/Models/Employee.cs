using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestingJobs.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

    }
}
