namespace Pitshop.Pages;

public partial class CurrentAppointmentsPage : ContentPage
{
	public CurrentAppointmentsPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (App.AppointmentDatabase.GetAppointmentAsync().Result == null) return;

        listView.ItemsSource = await App.AppointmentDatabase.GetAppointmentAsync();
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            //await Navigation.PushAsync(new ListPage
            //{
            //    BindingContext = e.SelectedItem as ShopList
            //});
        }
    }

    private void OnDetailsButtonClicked(object sender, EventArgs e) {
    }

    private void OnDeleteButtonClicked(object sender, EventArgs e) {
    }

    private async void HomeButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Welcome());
    }
}