using Pitshop.Pages;
using System;
using Pitshop.Data;
using System.IO;

namespace Pitshop;

public partial class App : Application { 

    static UserDatabase database;

    public static UserDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "User.db3"));
            }
            return database;
        }
    }

    static AppointmentDatabase appointmentdatabase;

    public static AppointmentDatabase AppointmentDatabase
    {
        get
        {
            if (appointmentdatabase == null)
            {
                appointmentdatabase = new
               AppointmentDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Appointment.db3"));
            }
            return appointmentdatabase;
        }
    }

    static NotificationDatabase notificationdatabase;

    public static NotificationDatabase NotificationDatabase
    {
        get
        {
            if (notificationdatabase == null)
            {
                notificationdatabase = new
               NotificationDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Notification.db3"));
            }
            return notificationdatabase;
        }
    }

    public App()
	{
		InitializeComponent();

        MainPage = new Login();
	}
}
