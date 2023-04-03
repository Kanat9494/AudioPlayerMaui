namespace AudioPlayerMaui.Views;

public partial class PlayerPage : ContentPage
{
	public PlayerPage(IAudioPlayerService audioPlayerService, IRecordAudioService recordAudioService)
	{
		InitializeComponent();

        BindingContext = new PlayerPageViewModel(audioPlayerService, recordAudioService);
    }
}