
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
        public string baseUrl;

        public SekcijaServis()
        {
            this.httpClient = new HttpClient();
            Sekcije = new List<Sekcija>();
            baseUrl = @"http://localhost:5286/";
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
