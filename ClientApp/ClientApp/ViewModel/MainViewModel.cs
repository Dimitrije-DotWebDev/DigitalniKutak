using ClientApp.Model;
using ClientApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        public NovostiServis novostiServis { get; set; }

        ObservableCollection<Novost> novosti { get; set; }
        MainViewModel(NovostiServis novostiServis)
        {
            this.Naslov = "Pocetna";
            this.IsBusy = false;
            this.novostiServis = novostiServis;

        }
    }
}
