using Android.Database;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalniKutak.Model;
using DigitalniKutak.Services;
using Kotlin.Properties;
using System;
using System.Collections.Generic;
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
        public Guid Id { get; set; }
        [ObservableProperty]
        public Novost novost { get; set; }

        

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
                var novost = await novostService.GetNovostById(Id);

            }
            catch ( Exception ex)
            {
                
            }
            finally
            {
                this.IsBusy = false;
            }
        }

    }
}
