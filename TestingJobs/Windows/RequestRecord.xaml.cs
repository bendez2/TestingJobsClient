using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestingJobs.Api;
using TestingJobs.Models;

namespace TestingJobs.Windows
{

    public partial class RequestRecord : Window
    {
        public Request? _request;


        public RequestRecord(Request? request)
        {
            InitializeComponent();

            _request = request;

            LoadData();
        }

        private async Task LoadData()
        {
            Status.ItemsSource = Views.StatusView;
            Type.ItemsSource = Views.NameRequestView;
            Priority.ItemsSource = Views.PriorityView;
            Initiator.ItemsSource = Views.InitiatorView;

            if(_request == null)
            {
                _request = new Request();
                LoadNewRecord();
            }
            else
            {
                _request.ChangeTime = DateTime.Now;
            }
            DataContext = _request;

        }

        private void LoadNewRecord()
        {
            _request.DateCreate = DateTime.Now;
            DateCreate.Text = _request.DateCreate.ToString();

            _request.ChangeTime= DateTime.Now;

            Status.SelectedItem = Views.StatusView.FirstOrDefault(item => (item.Name == "В ожидании обработки"));
        }


        private async void SaveRecord_Click(object sender, RoutedEventArgs e)
        {
            bSave.IsEnabled = false;
            
            PostRecord postRecord = new PostRecord();

            string a = JsonConvert.SerializeObject(_request);

            if (await postRecord.PostAsync("Requests", a))
            {
                CloseThisWindow();
            }
            else
            {
                bSave.IsEnabled = true;
            }

        }

        private void CloseThisWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.LoadData();
            Close();
        }

        private void CancelRecord_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Type_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            EditStatus();
        }

        private void Priority_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            EditStatus();
        }
        private void EditStatus()
        {
            if (Priority.SelectedValue != null && Type.SelectedValue != null)
            {
                TypeRequest? t = Views.TypeRequestView.Where(item => (item.PriorityID == (Int32)Priority.SelectedValue && item.NameRequestId == (Int32)Type.SelectedValue)).FirstOrDefault();
                _request.ExucationTime = _request.DateCreate.Add(new TimeSpan(t.SlaDay, t.SlaHours, 0, 0));

                _request.StatusId = Views.StatusView.First(i => i.Name == "В обработке").Id;
            }
        }

        private void Priority_Selected(object sender, RoutedEventArgs e)
        {
            EditStatus();
        }
    }
}
