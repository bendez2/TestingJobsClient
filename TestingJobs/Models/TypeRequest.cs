using System.Text.Json.Serialization;

namespace TestingJobs.Models
{
    public class TypeRequest
    {
        public int Id { get; set; }

        public int NameRequestId { get; set; }

        public NameRequest NameRequest { get; set; }

        public int PriorityID { get; set; }

        public Priority Priority { get; set; }

        public int SlaDay { get; set; }

        public int SlaHours { get; set; }

    }
}
