using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalniKutak.Services;
using DigitalniKutak.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalniKutak.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly KorisnikService korisnikService;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        public LoginViewModel( KorisnikService service)
        {
            this.korisnikService = service;
            Title = "Logovanje";
        }

        [RelayCommand]
        async Task OtvoriRegistraciju()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }


        [RelayCommand] 
        async Task UlogujSe()
        {
            if (this.IsBusy) return;

            try
            {
                this.IsBusy = true;
                if (await korisnikService.Uloguj(email,password))
                {
                    await Shell.Current.DisplayAlert($"Success","Uspesno ste se ulogovali", "OK");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert($"Error", $"Greska pri logovanju: {ex.Message}", "OK");
            }
            finally
            {
                this.IsBusy = false;
            }

        }

    }
}
