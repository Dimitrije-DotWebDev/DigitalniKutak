using DigitalniKutak.ViewModel;

namespace DigitalniKutak.View;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}