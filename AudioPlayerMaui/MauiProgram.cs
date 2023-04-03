using AudioPlayerMaui.Platforms.Android.Services;
using Microsoft.Extensions.Logging;

namespace AudioPlayerMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

#if ANDROID 
        builder.Services.AddTransient<IAudioPlayerService, AudioPlayerService>();
        builder.Services.AddTransient<IRecordAudioService, RecordAudioService>();
#endif

		builder.Services.AddTransient<PlayerPage>();
		//builder.Services.AddTransient<AppShell>();
        return builder.Build();
	}
}
