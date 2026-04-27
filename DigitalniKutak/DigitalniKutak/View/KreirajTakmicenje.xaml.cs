using DigitalniKutak.ViewModel;

namespace DigitalniKutak.View;

public partial class KreirajTakmicenje : ContentPage
{
	public KreirajTakmicenje(KreirajTakmicenjaViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}