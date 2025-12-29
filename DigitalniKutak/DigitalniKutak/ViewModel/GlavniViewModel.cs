using DigitalniKutak.Model;
using DigitalniKutak.View;
using DigitalniKutak.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace DigitalniKutak.ViewModel
{
    public partial class GlavniViewModel : BaseViewModel
    {
        NovostService novostService;
        SekcijaServis sekcijaService;
        public ObservableCollection<Novost> Novosti { get; } = new ObservableCollection<Novost>();
        public ObservableCollection<Sekcija> Sekcije { get; } = new ObservableCollection<Sekcija>();
        public GlavniViewModel(NovostService novostService, SekcijaServis sekcijaServis)
        {
            Title = "Početna strana";
            this.novostService = novostService;
            this.sekcijaService = sekcijaServis;
        }

        [RelayCommand]
        async Task GetNovostAsync()
        {
            if (this.IsBusy)
                return;
            try
            {
                IsBusy = true;
                var novosti = await novostService.GetNovosti();

                if (this.Novosti.Count != 0)
                {
                    this.Novosti.Clear();
                }

                foreach (var novost in novosti)
                {
                    novost.SlikaPutanja = $"{novostService.baseUrl}{novost.SlikaPutanja}";
                    novost.FajlPutanja = $"{novostService.baseUrl}{novost.FajlPutanja}";
                    this.Novosti.Add(novost);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get novosti: {ex.Message}", "OK");
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GetSekcijeAsync()
        {
            if (this.IsBusy)
                return;

            try
            {
                IsBusy = true;
                var sekcije = await sekcijaService.GetSekcije();
                if (this.Sekcije.Count != 0)
                {
                    this.Sekcije.Clear();
                }

                foreach (var sekcija in sekcije)
                {
                    this.Sekcije.Add(sekcija);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get Sekcije: {ex.Message}", "OK");
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        [RelayCommand]
        async Task OtvoriNovost(Guid id)
        {
            await Shell.Current.GoToAsync($"{nameof(NovostPage)}",true,new Dictionary<string, object> {
                { "Id", id}
            });

            /*
             "Id": 3123asd-123asdvxf-asxcvxcva13-asdasxc32
             */
        }

        [RelayCommand]
        async Task GetSve()
        {
            if (this.IsBusy)
                return;
            try
            {

                IsBusy = true;
                var sekcije = await sekcijaService.GetSekcije();
                if (this.Sekcije.Count != 0)
                {
                    this.Sekcije.Clear();
                }

                foreach (var sekcija in sekcije)
                {
                    this.Sekcije.Add(sekcija);
                }

                
                var novosti = await novostService.GetNovosti();

                if (this.Novosti.Count != 0)
                {
                    this.Novosti.Clear();
                }

                foreach (var novost in novosti)
                {
                    novost.SlikaPutanja = $"{novostService.baseUrl}{novost.SlikaPutanja}";
                    novost.FajlPutanja = $"{novostService.baseUrl}{novost.FajlPutanja}";
                    this.Novosti.Add(novost);
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get Sekcije and Novosti: {ex.Message}", "OK");
            }
            finally
            {
                this.IsBusy = false;
            }

        }

        [RelayCommand]
        async Task OtvoriLogin()
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }


    }
}
