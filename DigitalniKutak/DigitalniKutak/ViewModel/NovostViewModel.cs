
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
    [QueryProperty("Id", "Id")]
    public partial class NovostViewModel : BaseViewModel
    {
        private NovostService novostService;

        [ObservableProperty]
        Guid id;
        [ObservableProperty]
        Novost novost;

        

        public NovostViewModel(NovostService novostService)
        {
            this.novostService = novostService;
        }

        [RelayCommand]
        async Task GetNovostID()
        {
            if (this.IsBusy) return;

            try
            {
                IsBusy = true;
                var novost = await novostService.GetNovostById(id);
                this.Novost = novost;
                this.Title = novost.Naslov;
            }
            catch ( Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get Novost: {ex.Message}", "OK");
            }
            finally
            {
                this.IsBusy = false;
            }
        }

    }
}
