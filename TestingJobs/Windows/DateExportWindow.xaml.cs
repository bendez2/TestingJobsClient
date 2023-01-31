using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TestingJobs.Models;

namespace TestingJobs.Windows
{

    public partial class DateExportWindow : Window
    {
        private string _formatExport;
        public DateExportWindow(string format)
        {
            InitializeComponent();
            _formatExport = format;
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            if (_formatExport == "Json")
            {
                List<ExportRequest> exportRequestes = ConvertRequest(Views.RequestView.Where(item => (item.DateCreate >= DateTime.Parse(dpMinDate.Text) && item.DateCreate <= DateTime.Parse(dpMaxDate.Text))).ToList());

                string json = JsonConvert.SerializeObject(exportRequestes, Formatting.Indented);

                OpenFileDialog OPF = new OpenFileDialog();

                if (OPF.ShowDialog() == true)
                {
                    System.IO.File.WriteAllText(OPF.FileName, json);
                }
                Close();
            }
        }


        private List<ExportRequest> ConvertRequest(List<Request> requests)
        {
            List<ExportRequest> exportRequests = new List<ExportRequest>();

            foreach (Request request in requests)
            {   
                ExportRequest exportRequest = new ExportRequest();

                exportRequest.Id = request.Id;
                exportRequest.NameRequest = request.Type.NameRequest.Name;
                exportRequest.NamePriority = request.Type.Priority.Name;
                exportRequest.DateCreate = request.DateCreate;
                exportRequest.CloseTime = request.CloseTime;
                exportRequest.IfSLA = $"Время реагирования {request.Type.SlaDay} дня/дней и {request.Type.SlaHours} часа/часов";
                exportRequest.ExucationTime = request.ExucationTime;
                exportRequest.InitiatorName = request.Initiator.Name;
                if (request.Employee != null)
                {
                    exportRequest.EmployeeName = request.Employee.Name;
                }
                else
                {
                    exportRequest.EmployeeName = "";
                }
                exportRequests.Add(exportRequest);
            }
            return exportRequests;
        }
    }
}
