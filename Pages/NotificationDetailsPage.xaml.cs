using Pitshop.Models;

namespace Pitshop.Pages;

public partial class NotificationDetailsPage : ContentPage
{
	public NotificationDetailsPage()
	{
		InitializeComponent();
	}
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void OnLocationButtonClicked(object sender, EventArgs e)
    {
        var shopAddress = new Location(46.771118, 23.598461);

        var options = new MapLaunchOptions
        {
            Name = "PitShop",
        };
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(shopAddress, options);
    }
}