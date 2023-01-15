using Pitshop.Models;
using Plugin.LocalNotification;

namespace Pitshop.Pages;

public partial class MakeAppointmentPage : ContentPage
{
	public MakeAppointmentPage()
	{
		InitializeComponent();
	}

    private async void SendNotification(Appointment slist)
    {
        Notification note = new Notification();
        var shopAddress = new Location(46.771118, 23.598461);
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        var distance = myLocation.CalculateDistance(shopAddress,
DistanceUnits.Kilometers);
        distance = (double)Math.Round(distance, 2);


        note.Username = slist.Username;
        note.FullCarName = slist.Brand + ' ' + slist.Model;
        note.Date = slist.Date;
        note.SendDate = DateTime.Now.AddSeconds(1);
        note.Description = slist.Description;
        note.Distance = distance;

        await App.NotificationDatabase.SaveNotificationAsync(note);

        var request = new NotificationRequest
        {
            Title = "Programare PitShop",
            Description = "Buna! Tocmai ai facut o programare la Pitshop pe data de" + note.Date + ":\n\tPentru userul: " + note.Username + "\n\tMasina: " + note.FullCarName + "\n\tDescriere: " + note.Description + "\n\tDistanta shop: " + note.Distance + " km",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = note.SendDate
            }
        };
        await LocalNotificationCenter.Current.Show(request);
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

        SendNotification(slist);

        await Navigation.PopModalAsync();
    }

    private async void HomeButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}