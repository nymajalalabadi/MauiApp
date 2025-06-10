using Microsoft.Maui.Controls;

namespace MauiApp1.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            
            // Set the CheckBox initial state based on current app theme
            if (Application.Current != null)
            {
                DarkModeCheckBox.IsChecked = Application.Current.UserAppTheme == AppTheme.Dark;
            }
            
            // Add event handler for checkbox changes
            DarkModeCheckBox.CheckedChanged += OnDarkModeCheckBoxChanged;
        }
        
        private void OnDarkModeCheckBoxChanged(object? sender, CheckedChangedEventArgs e)
        {
            if (Application.Current != null)
            {
                // Update the app theme based on checkbox
                Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
                
                // Save the preference to device storage
                Preferences.Set("DarkModeEnabled", e.Value);
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Save notification preferences
            Preferences.Set("NotificationsEnabled", NotificationsCheckBox.IsChecked);
            
            // Save other settings here
            
            DisplayAlert("Settings", "Settings saved successfully", "OK");
        }
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            // Clean up event handler when page disappears
            DarkModeCheckBox.CheckedChanged -= OnDarkModeCheckBoxChanged;
        }
    }
} 