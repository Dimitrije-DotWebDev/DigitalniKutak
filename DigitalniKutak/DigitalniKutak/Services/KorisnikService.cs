using DigitalniKutak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DigitalniKutak.Services
{
    public class KorisnikService
    {
        HttpClient httpClient;
        public string baseUrl;
        private readonly AppConfig _config;

        public KorisnikService(AppConfig config)
        {
            httpClient = new HttpClient();
            _config = config;
            baseUrl = $"{_config.BaseApiUrl}";
        }

        public async Task<bool> Registruj(Korisnik k)
        {
            var url = baseUrl + "api/Korisnik/register";
            var response = await httpClient.PostAsJsonAsync(url,k);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
