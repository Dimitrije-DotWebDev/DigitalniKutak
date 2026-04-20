using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalniKutak.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {
            
        }

        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private bool isBusy;
    }
}
