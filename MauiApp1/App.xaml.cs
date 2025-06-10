namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Load and apply the saved theme preference
            if (Preferences.ContainsKey("DarkModeEnabled"))
            {
                bool isDarkModeEnabled = Preferences.Get("DarkModeEnabled", false);
                UserAppTheme = isDarkModeEnabled ? AppTheme.Dark : AppTheme.Light;
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}