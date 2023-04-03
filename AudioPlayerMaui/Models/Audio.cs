namespace AudioPlayerMaui.Models;

public class Audio : INotifyPropertyChanged
{
    #region Constructor
    public Audio()
    {
        isPlayVisible = true;
    }
    #endregion

    #region Private
    private bool isPlayVisible;
    private bool isPauseVisible;
    private string currentAudioPosition;
    #endregion

    #region Properties
    public string AudioName { get; set; }
    public string AudioURL { get; set; }
    public string Caption { get; set; }
    public bool IsPlayVisible
    {
        get => isPlayVisible;
        set
        {
            isPlayVisible = value;
            OnPropertyChanged();
            isPauseVisible = !value;
        }
    }
    public bool IsPauseVisible
    {
        get => isPauseVisible;
        set
        {
            isPauseVisible = value;
            OnPropertyChanged();
        }
    }
    public string CurrentAudioPosition
    {
        get => currentAudioPosition;
        set
        {
            if (string.IsNullOrEmpty(currentAudioPosition))
                currentAudioPosition = string.Format("{0:mm\\:ss}", new TimeSpan());
            else
                currentAudioPosition = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Interface

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var changed = PropertyChanged;
        if (changed == null)
            return;

        changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}
