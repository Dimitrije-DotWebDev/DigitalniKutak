using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using DigitalniKutak.Model;
using DigitalniKutak.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DigitalniKutak.ViewModel
{
    public partial class RegisterViewModel : BaseViewModel
    {
        private readonly KorisnikService korisnikService;
        [ObservableProperty]
        Korisnik k;

        [ObservableProperty]
        bool isPasswordNotChecked;

        [ObservableProperty]
        string potvrdaSifre;

        FileResult _selectedImage;


        [ObservableProperty]
        private ImageSource slikaUrl = null;
        public RegisterViewModel(KorisnikService korisnikService)
        {
            this.korisnikService = korisnikService;
            K = new Korisnik();
        }

        [RelayCommand]
        async Task RegistrujKorisnika()
        {
            if (this.IsBusy) return;

            try
            {
                this.IsBusy = true;
                var requestBody = new MultipartFormDataContent();
                requestBody.Add(new StringContent(K.Ime), "Ime");
                requestBody.Add(new StringContent(K.Prezime), "Prezime");
                requestBody.Add(new StringContent(K.Email), "Email");
                requestBody.Add(new StringContent(K.Username), "Username");
                requestBody.Add(new StringContent(K.Password), "Password");

                requestBody.Add(new StringContent(K.Odeljenje), "Odeljenje");
                requestBody.Add(new StringContent(K.Razred), "Razred");
                requestBody.Add(new StringContent(K.DatumRodjenja.ToString("o")), "DatumRodjenja");
                
                if(_selectedImage != null)
                {
                    var stream = await _selectedImage.OpenReadAsync();
                    var fileContent = new StreamContent(stream);
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    requestBody.Add(fileContent, "Slika", _selectedImage.FileName);
                }

                var success = await korisnikService.Registruj(requestBody);
                if (success)
                {
                    await Shell.Current.DisplayAlert($"Success", "Uspesno ste se registrovali", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert($"Error", "Greska pri registrovanju", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert($"Error", $"Fatal Error: {ex.Message}", "OK");
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task UcitajSliku()
        {
            _selectedImage = await MediaPicker.PickPhotoAsync();
            if (_selectedImage != null)
            {
                SlikaUrl = ImageSource.FromFile(_selectedImage.FullPath);
            }
        }

        [RelayCommand]
        public void PasswordNotCheck()
        {
            IsPasswordNotChecked = K.Password != PotvrdaSifre;
        }

    }
}
