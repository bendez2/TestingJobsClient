using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestingJobs.Models;

namespace TestingJobs.Api
{
    public class GetRecord
    {
        private string _urlApi = "https://apis.api-mauijobs.site/api/";
        private HttpClient _client;
        private HttpResponseMessage _response;

        public GetRecord()
        {
            _client = new HttpClient();

        }

        public async Task<string> GetInformationAsync(string nameController)
        {
            _response = await _client.GetAsync(_urlApi + nameController);
            if(_response.IsSuccessStatusCode )
            {
                HttpContent _responseContent = _response.Content;
                string a = await _responseContent.ReadAsStringAsync();

                return a;
            }
            else
            {
                MessageBox.Show("Невозможно соединиться с сервером.");
               
                return null;
            }
        }
    }
}
