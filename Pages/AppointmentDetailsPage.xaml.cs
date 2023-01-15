using Pitshop.Models;

namespace Pitshop.Pages;

public partial class AppointmentDetailsPage : ContentPage
{
	public AppointmentDetailsPage()
	{
		InitializeComponent();
	}

	private async void OnBackButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Appointment)BindingContext;
        await App.AppointmentDatabase.DeleteAppointmentAsync(slist);
        await Navigation.PopModalAsync();
    }
}