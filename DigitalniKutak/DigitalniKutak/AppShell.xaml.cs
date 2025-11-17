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
        }
    }
}
