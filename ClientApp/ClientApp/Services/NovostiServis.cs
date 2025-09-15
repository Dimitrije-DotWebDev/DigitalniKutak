using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ClientApp.Services
{
    public class NovostiServis
    {
        HttpClient _httpClient;
        public string BaseUrl { get; set; }

        NovostiServis()
        {
            _httpClient = new HttpClient();
            BaseUrl = @"http://localhost:5286/api/";
        }

        public async Task<List<Novost>> LoadNovosti()
        {
            var url = BaseUrl + "Novosti";
            var response = await _httpClient.GetAsync(url);
            List<Novost> novosti = new List<Novost>();
            if (response.IsSuccessStatusCode)
            {
                 novosti = await response.Content.ReadFromJsonAsync<List<Novost>>();

            }
            return novosti;
        }

    }
}
