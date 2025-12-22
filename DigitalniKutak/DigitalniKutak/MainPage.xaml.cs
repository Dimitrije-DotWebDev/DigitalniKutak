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
        protected override void OnAppearing()
        {
            (BindingContext as GlavniViewModel).GetNovostCommand.Execute(null);
            (BindingContext as GlavniViewModel).GetSekcijeCommand.Execute(null);
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
