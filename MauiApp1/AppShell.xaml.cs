namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            // Register routes for navigation
            Routing.RegisterRoute(nameof(Pages.ProfilePage), typeof(Pages.ProfilePage));
            Routing.RegisterRoute(nameof(Pages.SettingsPage), typeof(Pages.SettingsPage));
            Routing.RegisterRoute(nameof(Pages.AboutPage), typeof(Pages.AboutPage));

            // Set navigation for shell
            Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
        }

        // Method to programmatically navigate to pages if needed
        public async Task NavigateToPageAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
        
        // Handle the logout button click in the flyout footer
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Close the flyout
            FlyoutIsPresented = false;
            
            // Clear any user-specific data if needed
            Preferences.Remove("ProfileName");
            Preferences.Remove("ProfileCity");
            Preferences.Remove("ProfilePhone");
            Preferences.Remove("ProfileAboutMe");
            
            // Show confirmation to the user
            await DisplayAlert("Logged Out", "You have been successfully logged out.", "OK");
            
            // Navigate to the main page
            await GoToAsync("//MainPage");
        }
    }
}
