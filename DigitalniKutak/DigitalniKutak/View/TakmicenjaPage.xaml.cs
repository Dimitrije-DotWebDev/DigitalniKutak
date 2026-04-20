using DigitalniKutak.ViewModel;

namespace DigitalniKutak.View;

public partial class TakmicenjaPage : ContentPage
{
	public TakmicenjaPage( TakmicenjaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}