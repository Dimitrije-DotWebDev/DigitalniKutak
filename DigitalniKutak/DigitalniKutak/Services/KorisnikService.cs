
using DigitalniKutak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static DigitalniKutak.Model.ENUMs;

namespace DigitalniKutak.Services
{
    public class KorisnikService
    {
        HttpClient httpClient;
        public string baseUrl;
        private readonly AppConfig _config;
        private readonly SessionService sessionService;

        public KorisnikService(AppConfig config, SessionService _sessionService)
        {
            httpClient = new HttpClient();
            _config = config;
            sessionService = _sessionService;
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
            //await Shell.Current.DisplayAlert(dictionary?["token"].ToString(), "asd", "asdd");
            sessionService.Token = dictionary?["token"].ToString();
            sessionService.Korisnik = new Korisnik
            {
                ImageUrl = dictionary?["imageUrl"].ToString(),
                Ime = dictionary?["ime"].ToString(),
                Prezime = dictionary?["prezime"].ToString(),
                TipKorisnika = Enum.TryParse<UserType>(
                            dictionary?["tipKorisnika"].GetString(),
                            out var tip
                        ) ? tip : UserType.Student,
                Email = dictionary?["email"].ToString(),
                Odeljenje = dictionary?["odeljenje"].ToString(),
                Razred = dictionary?["razred"].ToString(),
                DatumRodjenja = Convert.ToDateTime(dictionary?["datumRodjenja"].ToString())
            };

            return response.IsSuccessStatusCode;
        }

    }
}
