namespace AudioPlayerMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        //ShellContent.Content = page;

        Routing.RegisterRoute(nameof(SecondPage), typeof(SecondPage));
        Routing.RegisterRoute(nameof(PlayerPage), typeof(PlayerPage));

    }
}
