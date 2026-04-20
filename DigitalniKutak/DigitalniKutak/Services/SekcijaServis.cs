
using DigitalniKutak.Model;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalniKutak.Services
{
    public class SekcijaServis
    {
        HttpClient httpClient;
        List<Sekcija> Sekcije;
        private readonly AppConfig _config;
        public string baseUrl;

        public SekcijaServis(AppConfig config)
        {
            this.httpClient = new HttpClient();
            Sekcije = new List<Sekcija>();
            this._config = config;
            baseUrl = $"{_config.BaseApiUrl}";
        }

        public async Task<List<Sekcija>> GetSekcije()
        {
            var url = baseUrl + "api/Sekcije";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Sekcije = await response.Content.ReadFromJsonAsync<List<Sekcija>>();
            }

            return Sekcije;
        }


    }
}
