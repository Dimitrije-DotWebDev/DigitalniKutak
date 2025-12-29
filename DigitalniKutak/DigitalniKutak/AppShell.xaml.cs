using DigitalniKutak.Model;
using DigitalniKutak.View;

namespace DigitalniKutak
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {

            InitializeComponent();
            Routing.RegisterRoute(nameof(NovostPage), typeof(NovostPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        }
    }
}
