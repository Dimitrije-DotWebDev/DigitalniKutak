using DigitalniKutak.Model;
using DigitalniKutak.ViewModel;

namespace DigitalniKutak
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(GlavniViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        /*private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }*/
    }

}
