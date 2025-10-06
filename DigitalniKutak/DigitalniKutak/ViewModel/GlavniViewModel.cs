using DigitalniKutak.Model;
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
        public ObservableCollection<Novost> Novosti { get; } = new ObservableCollection<Novost>();
        public GlavniViewModel(NovostService novostService)
        {
            Title = "Početna strana";
            this.novostService = novostService;
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
    }
}
