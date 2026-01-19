using CommunityToolkit.Mvvm.Input;
using DigitalniKutak.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalniKutak.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Title = "Logovanje";
        }

        [RelayCommand]
        async Task OtvoriRegistraciju()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        } 

    }
}
