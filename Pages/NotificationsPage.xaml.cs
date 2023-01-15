using Pitshop.Models;

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

        if (App.NotificationDatabase.GetNotificationAsync().Result == null) return;

        listView.ItemsSource = await App.NotificationDatabase.GetNotificationAsync();
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushModalAsync(new NotificationDetailsPage
            {
                BindingContext = e.SelectedItem as Notification
            });
        }
    }

    private async void HomeButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}