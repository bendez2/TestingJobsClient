using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TestingJobs.Models
{
    class ExportRequest
    {
        [JsonProperty("№ заявки")]
        public int Id { get; set; }

        [JsonProperty("Тип заявки")]
        public string NameRequest { get; set; }

        [JsonProperty("Приоритет")]
        public string NamePriority { get; set; }
        [JsonProperty("Время подачи")]
        public DateTime DateCreate { get; set; }

        [JsonProperty("Время закрытия")]
        public DateTime? CloseTime { get; set; }

        [JsonProperty("Условия SLA")]
        public string IfSLA { get; set; }

        [JsonProperty("Выполнение SLA")]
        public DateTime ExucationTime { get; set; }

        [JsonProperty("Автор")]
        public string InitiatorName { get; set; }

        [JsonProperty("Исполнитель")]
        public string? EmployeeName { get; set; }
    }
}


