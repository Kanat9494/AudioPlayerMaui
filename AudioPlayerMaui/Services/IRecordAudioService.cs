namespace AudioPlayerMaui.Services;

public interface IRecordAudioService
{
    void StartRecord();
    string StopRecord();
    void PauseRecord();
    void ResetRecord();
}
