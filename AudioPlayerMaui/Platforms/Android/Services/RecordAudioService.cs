namespace AudioPlayerMaui.Platforms.Android.Services;

public class RecordAudioService : IRecordAudioService
{
    #region Fields

    private MediaRecorder mediaRecorder;
    private string storagePath;
    private bool isRecordStarted = false;

    #endregion

    #region Methods
    public void StartRecord()
    {
        if (mediaRecorder == null)
        {
            SetAudioFilePath();
            mediaRecorder = new MediaRecorder();
            mediaRecorder.Reset();
            mediaRecorder.SetAudioSource(AudioSource.Mic);
            mediaRecorder.SetOutputFormat(OutputFormat.AacAdts);
            mediaRecorder.SetAudioEncoder(AudioEncoder.Aac);
            mediaRecorder.SetOutputFile(storagePath);
            mediaRecorder.Prepare();
            mediaRecorder.Start();
        }
        else
            mediaRecorder.Resume();

        isRecordStarted = true;
    }

    public void PauseRecord()
    {
        if (mediaRecorder == null)
            return;

        mediaRecorder.Pause();
        isRecordStarted = false;
    }

    public void ResetRecord()
    {
        if (mediaRecorder != null)
        {
            mediaRecorder.Resume();
            mediaRecorder.Reset();
        }

        mediaRecorder = null;
        isRecordStarted = false;
    }

    public string StopRecord()
    {
        if (mediaRecorder == null)
            return string.Empty;

        mediaRecorder.Resume();
        mediaRecorder.Stop();
        mediaRecorder = null;
        isRecordStarted = false;
        return storagePath;
    }

    private void SetAudioFilePaht()
    {
        string fileName = "/Record_" + DateTime.UtcNow.ToString("ddMMM_hhmmss") + ".mp3";
        var path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        storagePath = path + fileName;
        Directory.CreateDirectory(path);
    }
    #endregion
}
