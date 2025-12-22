using DigitalniKutak.ViewModel;

namespace DigitalniKutak.View;

public partial class NovostPage : ContentPage
{
	public NovostPage(NovostViewModel novostViewModel)
	{
		InitializeComponent();
		BindingContext = novostViewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}