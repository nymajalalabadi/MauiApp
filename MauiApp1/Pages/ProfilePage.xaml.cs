using Microsoft.Maui.Controls;

namespace MauiApp1.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            // Load saved profile data from preferences
            NameEntry.Text = Preferences.Get("ProfileName", "Sample User");
            CityEntry.Text = Preferences.Get("ProfileCity", "New York");
            PhoneEntry.Text = Preferences.Get("ProfilePhone", "");
            AboutMeEditor.Text = Preferences.Get("ProfileAboutMe", "");
        }

        private void OnChangeProfilePictureClicked(object? sender, EventArgs e)
        {
            DisplayAlert("Change Picture", "Profile picture change feature will be added in the next version", "OK");
        }

        private async void OnSaveChangesClicked(object? sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                await DisplayAlert("Validation Error", "Name cannot be empty", "OK");
                return;
            }

            // Save profile data to preferences
            Preferences.Set("ProfileName", NameEntry.Text);
            Preferences.Set("ProfileCity", CityEntry.Text);
            Preferences.Set("ProfilePhone", PhoneEntry.Text);
            Preferences.Set("ProfileAboutMe", AboutMeEditor.Text);

            await DisplayAlert("Save Information", "Profile information saved successfully", "OK");
        }
    }
} 