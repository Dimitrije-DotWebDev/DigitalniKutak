using DigitalniKutak.ViewModel;

namespace DigitalniKutak.View;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=viewModel;
	}

	
}