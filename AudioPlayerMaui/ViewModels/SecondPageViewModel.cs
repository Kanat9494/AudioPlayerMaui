namespace AudioPlayerMaui.ViewModels;

[QueryProperty(nameof(Test), "Test")]
public class SecondPageViewModel : INotifyPropertyChanged
{
    public SecondPageViewModel()
    {
        BackToPlayer = new Command(OnBackTo);
    }
    private async void OnBackTo()
    {
        await Shell.Current.GoToAsync($"{nameof(PlayerPage)}?{nameof(PlayerPageViewModel.Test)}=asdlfkjasdf;lk");
    }
    public Command BackToPlayer { get; set; }
    private string test;
    public string Test
    {
        get => test;
        set
        {
            test = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
