using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestingJobs.Api;
using TestingJobs.Models;
using TestingJobs.Windows;

namespace TestingJobs
{
    public partial class MainWindow : Window
    {
        private GetRecord _getRecord;
        private TableType _currentTableType;
        private enum TableType
        {
            RequestTable, StatusTable, InitiatorTable, PriorityTable, TypeRequestTable
        }

        // Названия контроллеров: Initiators, Priorities,Statuses,Requests,TypeRequestes

        public MainWindow()
        {
            _getRecord = new GetRecord();


            _currentTableType = TableType.RequestTable;

            InitializeComponent();
            UpdateRecordsButton_Click(null,null);
        }

        public async Task LoadData()
        {
            try
            {
                string? data = await _getRecord.GetInformationAsync("Statuses");
                Views.StatusView = JsonConvert.DeserializeObject<ObservableCollection<Status>>(data);

                data = await _getRecord.GetInformationAsync("Priorities");
                Views.PriorityView = JsonConvert.DeserializeObject<ObservableCollection<Priority>>(data);

                data = await _getRecord.GetInformationAsync("Requests");
                Views.RequestView = JsonConvert.DeserializeObject<ObservableCollection<Request>>(data);

                data = await _getRecord.GetInformationAsync("Initiators");
                Views.InitiatorView = JsonConvert.DeserializeObject<ObservableCollection<Initiator>>(data);

                data = await _getRecord.GetInformationAsync("TypeRequestes");
                Views.TypeRequestView = JsonConvert.DeserializeObject<ObservableCollection<TypeRequest>>(data);

                data = await _getRecord.GetInformationAsync("NameRequest");
                Views.NameRequestView = JsonConvert.DeserializeObject<ObservableCollection<NameRequest>>(data);

            }
            catch
            {
                LoadData();
            }


        }
        private async void RefreshTable(TableType tableType)
        {
            switch (tableType)
            {
                case TableType.RequestTable:
                    requestTable.ItemsSource = Views.RequestView;
                    break;
                case TableType.StatusTable:
                    statusTable.ItemsSource = Views.StatusView;
                    break;
                case TableType.TypeRequestTable:
                    typeRequestTable.ItemsSource = Views.TypeRequestView;
                    break;
                case TableType.PriorityTable:
                    priorityTable.ItemsSource = Views.PriorityView;
                    break;
                case TableType.InitiatorTable:
                    initiatorTable.ItemsSource = Views.InitiatorView;
                    break;
            }
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TabItem tabItem)
            {
                TableType oldTable = _currentTableType;
                string nameTabItem = tabItem.Header.ToString();

                switch (nameTabItem)
                {
                    case "Заявки":
                        _currentTableType = TableType.RequestTable;
                        break;
                    case "Инициаторы":
                        _currentTableType = TableType.InitiatorTable;
                        break;
                    case "Приоритеты":
                        _currentTableType = TableType.PriorityTable;
                        break;
                    case "Статусы":
                        _currentTableType = TableType.StatusTable;
                        break;
                    case "Типы заявок":
                        _currentTableType = TableType.TypeRequestTable;
                        break;
                }

                if (_currentTableType != oldTable)
                {
                    RefreshTable(_currentTableType);
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            bDelete.IsEnabled = false;
            await DeleteRecordInTable(_currentTableType);
        }

        private async Task DeleteRecordInTable(TableType table)
        {
            DeleteRecord deleteRecord = new DeleteRecord();

            switch (table)
            {
                case TableType.RequestTable:
                    if (requestTable.SelectedItem is Request request)
                    {
                        await deleteRecord.DeleteAsync("Requests", request.Id);
                    }
                    break;
                case TableType.StatusTable:
                    if (statusTable.SelectedItem is Status status)
                    {
                        await deleteRecord.DeleteAsync("Statuses", status.Id);
                    }
                    break;
                case TableType.TypeRequestTable:
                    if (typeRequestTable.SelectedItem is TypeRequest typeRequest)
                    {
                        await deleteRecord.DeleteAsync("TypeRequestes", typeRequest.Id);
                    }
                    break;
                case TableType.InitiatorTable:
                    if (initiatorTable.SelectedItem is Initiator initiator)
                    {
                        await deleteRecord.DeleteAsync("Initiators", initiator.Id);
                    }
                    break;
                case TableType.PriorityTable:
                    if (priorityTable.SelectedItem is Priority priority)
                    {
                        await deleteRecord.DeleteAsync("Priorities", priority.Id);
                    }
                    break;
            }
            //Сон, чтобы завершился поток удаления
            bDelete.IsEnabled = true;
            await RefreshData();
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            RequestRecord requestRecord = new RequestRecord(null);
            requestRecord.Show();
        }

        private void CancelSearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditRecordButton_Click(object sender, RoutedEventArgs e)
        {
            switch (_currentTableType)
            {
                case TableType.RequestTable:
                    if (requestTable.SelectedItem is Request request)
                    {
                        new RequestRecord(request).Show();
                    }
                    break;
            }
        }

        private async Task RefreshData()
        {
            await LoadData();
            RefreshTable(_currentTableType);
        }
        private async void UpdateRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            await RefreshData();
            this.IsEnabled = true;
        }

        private void ExportCSVButton_Click(object sender, RoutedEventArgs e)
        {
            new DateWindow("Csv").Show();
        }

        private void ExportJSONButton_Click(object sender, RoutedEventArgs e)
        {
            new DateWindow("Json").Show();
        }

        private void CreateReportButton_Click(object sender, RoutedEventArgs e)
        {
            new DateWindow("Report").Show();
        }
    }
}
