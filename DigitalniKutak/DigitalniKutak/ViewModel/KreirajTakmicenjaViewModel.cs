using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalniKutak.Model;
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
    public partial class KreirajTakmicenjaViewModel : BaseViewModel
    {
        private readonly TakmicenjeService TakmicenjeService;
        [ObservableProperty]
        Takmicenje t;


        public KreirajTakmicenjaViewModel(TakmicenjeService takmicenjeService)
        {
            this.TakmicenjeService = takmicenjeService;
            this.T = new Takmicenje();
            this.IsBusy = false;
        }

        [RelayCommand]
        async Task KreirajTakmicenje()
        {
            if (this.IsBusy) return;

            try
            {
                this.IsBusy = true;
                var requestBody = new MultipartFormDataContent();
                requestBody.Add(new StringContent(T.Naziv), "naziv");
                requestBody.Add(new StringContent(T.Opis), "opis");
                requestBody.Add(new StringContent(T.DatumOdrzavanja.ToString("yyyy.MM.dd hh:mm")), "datumOdrzavanja");
                requestBody.Add(new StringContent(T.PoOdeljenju.ToString()), "poOdeljenju");
                requestBody.Add(new StringContent(T.Kategorija.ToString()), "kategorija");
                requestBody.Add(new StringContent(T.DozvoliNaziveEkipa.ToString()), "dozvoliNaziveEkipa");
                requestBody.Add(new StringContent(T.MaxBrojClanova.ToString()), "maxBrojClanova");

                var sucsess = await TakmicenjeService.KreirajTakmicenje(requestBody);
                if (sucsess)
                {
                    await Shell.Current.DisplayAlert($"Success", "Uspesno ste se kreirali takmicenje", "OK");
                    await Shell.Current.GoToAsync($"{nameof(TakmicenjaPage)}");
                }
                else
                {
                    await Shell.Current.DisplayAlert($"Error", "Greska pri kreiranju takmicenja", "OK");
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
