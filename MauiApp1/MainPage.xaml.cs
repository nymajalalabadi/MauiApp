namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            CounterLabel.Text = "Current count: 0";
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Tapped {count} time";
            else
                CounterBtn.Text = $"Tapped {count} times";

            // Update the counter label
            CounterLabel.Text = $"Current count: {count}";

            // Apply visual feedback
            CounterBtn.BackgroundColor = Colors.Green;
            
            // Reset button color after a short delay
            Application.Current?.Dispatcher.Dispatch(async () => {
                await Task.Delay(200);
                CounterBtn.BackgroundColor = null; // Revert to default
            });

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
