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
    public partial class RegisterViewModel:BaseViewModel
    {
        private readonly KorisnikService korisnikService;
        [ObservableProperty]
        Korisnik k;

        [ObservableProperty]
        private ImageSource slikaUrl = null;
        public RegisterViewModel(KorisnikService korisnikService)
        {
            this.korisnikService = korisnikService;
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
                requestBody.Add(new StringContent(K.TipKorisnika.ToString()), "TipKorisnika");
                requestBody.Add(new StringContent(K.Odeljenje), "Odeljenje");
                requestBody.Add(new StringContent(K.Razred), "Razred");
                requestBody.Add(new StringContent(K.DatumRodjenja.ToString()), "DatumRodjenja");


                var success = await korisnikService.Registruj(k);
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
            try
            {
                // Use MediaPicker to select a photo
                FileResult photo = await MediaPicker.PickPhotoAsync();

                if (photo != null)
                {
                    // Load the image from the stream
                    using Stream stream = await photo.OpenReadAsync();
                    SlikaUrl = ImageSource.FromStream(() => stream);

                    // You can also get the full file path if needed (e.g., for uploading to a server)
                    string localFilePath = photo.FullPath;
                    // Further logic for uploading to a server can be added here
                    // e.g., UploadToServer(localFilePath);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., permissions not granted)
                Console.WriteLine($"Error picking image: {ex.Message}");
            }
        }

    }
}
