using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalniKutak.Services;
using DigitalniKutak.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DigitalniKutak.Model.ENUMs;

namespace DigitalniKutak.ViewModel
{
    public partial class TakmicenjaViewModel : BaseViewModel
    {

        [ObservableProperty]
        private SessionService sessionServis;
        [ObservableProperty]
        private bool canView = false;

        public TakmicenjaViewModel(SessionService _sessionService)
        {
            Title = "Takmicenja";
            SessionServis = _sessionService;
            CanView = SessionServis.canView;
        }

        [RelayCommand]
        async Task OtvoriKreiranjeTakmicenja()
        {
            await Shell.Current.GoToAsync($"{nameof(KreirajTakmicenje)}");
        }
    }
}
