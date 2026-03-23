using DigitalniKutak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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

        public async Task<bool> Registruj(MultipartFormDataContent data)
        {
            var url = baseUrl + "api/Korisnik/register";
            var response = await httpClient.PostAsync(url,data);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Uloguj(string email, string password)
        {
            var url = baseUrl + "api/Korisnik/login";

            var payload = new 
            {
                Email = email,
                Password = password
            };
            string json = JsonSerializer.Serialize(payload);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(await response.Content.ReadAsStringAsync());
            await Shell.Current.DisplayAlert(dictionary["token"].ToString(), "asd", "asdd");
            return response.IsSuccessStatusCode;
        }

    }
}
