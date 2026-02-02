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
    }
}
