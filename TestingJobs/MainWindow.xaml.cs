using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using TestingJobs.Api;
using TestingJobs.Models;

namespace TestingJobs
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _urlApi = "https://apis.api-mauijobs.site/api/";
        private TableType _currentTableType;
        private HttpClient _client;
        private HttpResponseMessage _response;

        private enum TableType
        {
            RequestTable, StatusTable, InitiatorTable, PriorityTable, TypeRequestTable
        }

        // Названия контроллеров: Initiators, Priorities,Statuses,Requests,TypeRequestes

        public MainWindow()
        {
            _client = new HttpClient();
            _currentTableType = TableType.RequestTable;

            InitializeComponent();
            RefreshTable(_currentTableType);
        }

        private async void RefreshTable(TableType tableType)
        {
            switch (tableType)
            {
                case TableType.RequestTable:
                    _response = await _client.GetAsync(_urlApi + "Requests");

                    if (_response.StatusCode == HttpStatusCode.OK)
                    {
                        HttpContent _responseContent = _response.Content;
                        var a = await _responseContent.ReadAsStringAsync();

                        Request[] requests1 = JsonConvert.DeserializeObject<Request[]>(a);
                        requestTable.ItemsSource = requests1;
                    }
                    break;
                case TableType.StatusTable:
                    _response = await _client.GetAsync(_urlApi + "Statuses");

                    if (_response.StatusCode == HttpStatusCode.OK)
                    {
                        HttpContent _responseContent = _response.Content;
                        var a = await _responseContent.ReadAsStringAsync();

                        Status[] requests1 = JsonConvert.DeserializeObject<Status[]>(a);
                        statusTable.ItemsSource = requests1;
                    }
                    break;
                case TableType.TypeRequestTable:
                    _response = await _client.GetAsync(_urlApi + "TypeRequestes");

                    if (_response.StatusCode == HttpStatusCode.OK)
                    {
                        HttpContent _responseContent = _response.Content;
                        var a = await _responseContent.ReadAsStringAsync();

                        TypeRequest[] requests1 = JsonConvert.DeserializeObject<TypeRequest[]>(a);
                        typeRequestTable.ItemsSource = requests1;
                    }
                    break;
                case TableType.PriorityTable:
                    _response = await _client.GetAsync(_urlApi + "Priorities");

                    if (_response.StatusCode == HttpStatusCode.OK)
                    {
                        HttpContent _responseContent = _response.Content;
                        var a = await _responseContent.ReadAsStringAsync();

                        Priority[] requests1 = JsonConvert.DeserializeObject<Priority[]>(a);
                        priorityTable.ItemsSource = requests1;
                    }
                    break;
                case TableType.InitiatorTable:
                    _response = await _client.GetAsync(_urlApi + "Initiators");

                    if (_response.StatusCode == HttpStatusCode.OK)
                    {
                        HttpContent _responseContent = _response.Content;
                        var a = await _responseContent.ReadAsStringAsync();

                        Initiator[] requests1 = JsonConvert.DeserializeObject<Initiator[]>(a);
                        initiatorTable.ItemsSource = requests1;
                    }
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecordInTable(_currentTableType);
        }

        private void DeleteRecordInTable(TableType table)
        {
            DeleteRecord deleteRecord = new DeleteRecord();

            switch (table)
            {
                case TableType.RequestTable:
                    if (requestTable.SelectedItem is Request request)
                    {
                        deleteRecord.DeleteAsync("Requests", request.Id);
                    }
                    break;
                case TableType.StatusTable:
                    if (statusTable.SelectedItem is Status status)
                    {
                        deleteRecord.DeleteAsync("Statuses", status.Id);
                    }
                    break;
                case TableType.TypeRequestTable:
                    if (typeRequestTable.SelectedItem is TypeRequest typeRequest)
                    {
                        deleteRecord.DeleteAsync("TypeRequestes", typeRequest.Id);
                    }
                    break;
                case TableType.InitiatorTable:
                    if (initiatorTable.SelectedItem is Initiator initiator)
                    {
                        deleteRecord.DeleteAsync("Initiators", initiator.Id);
                    }
                    break;
                case TableType.PriorityTable:
                    if (priorityTable.SelectedItem is Priority priority)
                    { 
                        deleteRecord.DeleteAsync("Priorities", priority.Id);
                    }
                    break;
            }
            //Сон, чтобы завершился поток удаления
            Thread.Sleep(2000);
            RefreshTable(table);
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelSearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
