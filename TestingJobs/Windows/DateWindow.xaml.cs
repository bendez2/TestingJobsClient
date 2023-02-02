using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using TestingJobs.Components;
using TestingJobs.Models;

namespace TestingJobs.Windows
{

    public partial class DateWindow : Window
    {
        private string _formatExport;
        public DateWindow(string format)
        {
            InitializeComponent();

            if (format == "Report")
            {
                tbDangerous.Visibility = Visibility.Collapsed;
            }

            _formatExport = format;
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            if (dpMaxDate.Text != "" && dpMinDate.Text != "" && DateTime.Parse(dpMaxDate.Text).Year - DateTime.Parse(dpMinDate.Text).Year <= 1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                List<ExportRequest> exportRequestes = ConvertRequest(Views.RequestView.Where(item => (item.DateCreate >= DateTime.Parse(dpMinDate.Text) && item.DateCreate <= DateTime.Parse(dpMaxDate.Text))).ToList());

                if (_formatExport == "Json")
                {
                    saveFileDialog.Filter = "JSON|*.json";

                    string json = JsonConvert.SerializeObject(exportRequestes, Formatting.Indented);

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        System.IO.File.WriteAllText(saveFileDialog.FileName, json);
                    }
                }
                else if (_formatExport == "Csv")
                {
                    saveFileDialog.Filter = "CSV|*.csv";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                        using (var streamWriter = new StreamWriter(saveFileDialog.FileName, false, Encoding.GetEncoding(1251)))
                        {
                            var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"));
                            csvConfig.HasHeaderRecord = false;

                            var csvWriter = new CsvWriter(streamWriter, csvConfig);
                            csvWriter.WriteRecords(exportRequestes);
                        }
                    }
                }
                else
                {
                    new Report().FirstReport(exportRequestes);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Не указан период или выбран период больше года");
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
