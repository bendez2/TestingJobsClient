using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestingJobs.Models
{
    public class Request
    {
        public int Id { get; set; } 

        public DateTime DateCreate { get; set; }

        public string TypeName { get; set; }

        public string Text { get; set; }

        public string Location { get; set; }

        public string Priority { get; set; }

        public DateTime ExucationTime { get; set; }

        public string StatusName { get; set; }

        public DateTime ChangeTime { get; set; }

        public string Comment { get; set; }

        public DateTime CloseTime { get; set; }

        public string InitiatorName { get; set; }

    }
}
