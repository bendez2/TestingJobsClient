using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace TestingJobs.Api
{
    class PostRecord
    {
        private string _urlApi = "https://apis.api-mauijobs.site/api/";
        private HttpClient _client;
        private HttpResponseMessage _response;

        public PostRecord()
        {
            _client = new HttpClient();

        }

        public async Task<bool> PostAsync(string nameController, string contentJson)
        {
            HttpContent content = new StringContent(contentJson);
            HttpClient client = new HttpClient();

            content.Headers.ContentType = MediaTypeHeaderValue.Parse(@"application/json");
            HttpResponseMessage response = await client.PostAsync(_urlApi + nameController, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Успешно");
                return true;
            }
            else
            {
                MessageBox.Show("Ошибка");
                return false;
            }

        }
    }
}
