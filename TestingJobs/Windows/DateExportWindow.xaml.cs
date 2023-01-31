using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestingJobs.Models;

namespace TestingJobs.Windows
{
    /// <summary>
    /// Логика взаимодействия для DateExportWindow.xaml
    /// </summary>
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
               var exportRueqstes = Views.RequestView.Where(item => (item.DateCreate >= DateTime.Parse(dpMinDate.Text) && item.DateCreate <= DateTime.Parse(dpMaxDate.Text)));

                string json = JsonConvert.SerializeObject(exportRueqstes, Formatting.Indented);

                OpenFileDialog OPF = new OpenFileDialog();
                if (OPF.ShowDialog() == true)
                {
                    System.IO.File.WriteAllText(OPF.FileName, json);
                }
                Close();
            }
        }

    }
}
