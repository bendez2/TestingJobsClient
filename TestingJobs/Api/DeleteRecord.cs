using System.Net.Http;
using System.Windows;

namespace TestingJobs.Api
{
    public class DeleteRecord
    {
        private string _urlApi = "https://apis.api-mauijobs.site/api/";
        private HttpResponseMessage _response;
        private HttpClient _client;

        public async void DeleteAsync(string apiControllerName, int id)
        {
            _client= new HttpClient();
            _response = await _client.DeleteAsync(_urlApi + apiControllerName + "/" + id.ToString());

            if (_response.IsSuccessStatusCode)
            {
                MessageBox.Show("Запись удалена");
            }
            else
            {
                MessageBox.Show("Запись не удалена. Запись уже используется в другой таблице");
            }
        }
    }
}
