using Microsoft.Maui.Controls;
using System.Reflection;

namespace MauiApp1.Pages
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            AddAppVersionInfo();
        }

        private void AddAppVersionInfo()
        {
            // You can get the assembly version if needed
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyVersion = assembly.GetName().Version;
            
            // Update version info with current assembly version
            // Or you can keep this hardcoded if preferred
        }

        private void OnBackButtonClicked(object? sender, EventArgs e)
        {
            // For Shell-based navigation, we should simply show the flyout menu
            // since the about page is a top-level page in the flyout
            if (Shell.Current != null)
            {
                Shell.Current.FlyoutIsPresented = true;
            }
        }
    }
} 