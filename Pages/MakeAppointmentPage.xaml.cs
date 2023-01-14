using Pitshop.Models;
using PitShop.Models;

namespace Pitshop.Pages;

public partial class MakeAppointmentPage : ContentPage
{
	public MakeAppointmentPage()
	{
		InitializeComponent();
	}

    private async void OnMakeAppointmentButtonClicked(object sender, EventArgs e)
    {
        var slist = new Appointment();
        var car = new Car();

        slist.Username = usernameEntry.Text;

        car.Brand = brandEntry.Text;
        car.Model = modelEntry.Text;
        car.ProductionDate = productionDatePicker.Date;
        car.EngineCapacity = Int32.Parse(engineCapacityEntry.Text);
        car.Fuel = fuelEntry.Text;
        car.Power= Int32.Parse(powerEntry.Text);

        var names = new List<string>() { "Aurel Vlaicu", "Crutoi Alexandru", "Daniliuc Alexandru"};
        var random = new Random();
        int randomIndex = random.Next(names.Count);
        slist.Mechanic= names[randomIndex];

        slist.Date = datePicker.Date;
        slist.Description = descriptionEditor.Text;

        await App.AppointmentDatabase.SaveAppointmentAsync(slist);

        await Navigation.PushModalAsync(new NotificationsPage());
    }

    private async void HomeButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Welcome());
    }
}