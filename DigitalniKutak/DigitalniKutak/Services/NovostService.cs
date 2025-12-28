using DigitalniKutak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DigitalniKutak.Services
{
    public class NovostService
    {
        HttpClient httpClient;
        List<Novost> novosti;
        public string baseUrl;
        private readonly AppConfig _config;
        Novost novost;

        public NovostService(AppConfig config) {
            httpClient = new HttpClient();
            novosti = new List<Novost>();
            _config = config;
            baseUrl = $"{_config.BaseApiUrl}";
        }

        public async Task<List<Novost>> GetNovosti() {
            var url = baseUrl + "api/Novosti";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                novosti = await response.Content.ReadFromJsonAsync<List<Novost>>();
            }

            return novosti;
        }

        public async Task<Novost> GetNovostById(Guid Id)
        {
            var url = baseUrl + $"api/Novosti/{Id}";

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                novost = await response.Content.ReadFromJsonAsync<Novost>();
                novost.SlikaPutanja = $"{baseUrl}{novost.SlikaPutanja}";
                novost.FajlPutanja = $"{baseUrl}{novost.FajlPutanja}";
            }
            return novost;
        }   
        


    }
}
