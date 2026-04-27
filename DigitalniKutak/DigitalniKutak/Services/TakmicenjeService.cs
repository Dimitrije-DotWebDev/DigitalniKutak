using DigitalniKutak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DigitalniKutak.Services
{
    public class TakmicenjeService
    {
        HttpClient httpClient;
        List<Takmicenje> takmicenja;
        public string baseUrl;
        private readonly AppConfig _config;
        Takmicenje takmicenje;
        
        public TakmicenjeService(AppConfig config)
        {
            httpClient = new HttpClient();
            takmicenja = new List<Takmicenje>();
            _config = config;
            baseUrl = $"{_config.BaseApiUrl}";
        }
        
        public async Task<List<Takmicenje>> GetTakmicenja()
        {
            var url = baseUrl + "api/Takmicenje";

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                takmicenja = await response.Content.ReadFromJsonAsync<List<Takmicenje>>();
            }

            return takmicenja;
        }

        public async Task<bool> KreirajTakmicenje(MultipartFormDataContent data)
        {
            var url = baseUrl + "api/Takmicenje";
            var response = await httpClient.PostAsync(url, data);
            return response.IsSuccessStatusCode;
        }

    }
}
