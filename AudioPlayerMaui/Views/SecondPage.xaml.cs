namespace AudioPlayerMaui.Views;

public partial class SecondPage : ContentPage
{
	public SecondPage()
	{
		InitializeComponent();

		this.BindingContext = new SecondPageViewModel();
	}
}