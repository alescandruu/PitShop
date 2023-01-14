using Pitshop.Models;

namespace Pitshop.Pages;

public partial class MakeAppointmentPage : ContentPage
{
	public MakeAppointmentPage()
	{
		InitializeComponent();
	}

    private async void OnMakeAppointmentButtonClicked(object sender, EventArgs e)
    {
        Appointment slist = new Appointment();

        slist.Username = usernameEntry.Text;

        slist.Brand = brandEntry.Text;
        slist.Model = modelEntry.Text;
        slist.ProductionDate = productionDatePicker.Date;
        slist.EngineCapacity = int.Parse(engineCapacityEntry.Text);
        slist.Fuel = fuelEntry.Text;
        slist.Power = int.Parse(powerEntry.Text);

        var names = new List<string>() { "Aurel Vlaicu", "Crutoi Alexandru", "Daniliuc Alexandru"};
        var random = new Random();
        int randomIndex = random.Next(names.Count);
        slist.Mechanic = names[randomIndex];

        slist.Date = datePicker.Date;
        slist.Description = descriptionEditor.Text;

        await App.AppointmentDatabase.SaveAppointmentAsync(slist);

        await Navigation.PopAsync();
    }

    private async void HomeButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Welcome());
    }
}