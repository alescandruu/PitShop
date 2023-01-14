namespace Pitshop.Pages;

public partial class NotificationsPage : ContentPage
{
	public NotificationsPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (App.AppointmentDatabase.GetAppointmentAsync().Result == null) return;

        listView.ItemsSource = await App.AppointmentDatabase.GetAppointmentAsync();
    }

    private async void HomeButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Welcome());
    }
}