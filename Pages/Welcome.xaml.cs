namespace Pitshop.Pages;

public partial class Welcome : ContentPage
{
	public Welcome()
	{
		InitializeComponent();
	}

    private async void OnMakeAppointmentButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MakeAppointmentPage());
    }

    private async void OnCurrentAppointmentsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CurrentAppointmentsPage());
    }

    private async void OnNotificationsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NotificationsPage());
    }

    private async void OnLogoutButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Login());
    }
}