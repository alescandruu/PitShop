using System.Text;
using System;
using System.Security.Cryptography;
using Pitshop.Models;

namespace Pitshop.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void LoginButtonClicked(object sender, EventArgs e)
    {
        string Username = this.Username.Text;
        string Password = this.Password.Text;

        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));

            // Convert the byte array to a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            Password = builder.ToString();
        }

        var rc = App.Database.ValidateUser(Username, Password);

        if (rc != 0)
        {
            await Navigation.PushModalAsync(this);
            return;
        }

        await Navigation.PushModalAsync(new Welcome());
    }

    private async void RegisterButtonClicked(object Sender, EventArgs e)
	{
        await Navigation.PushModalAsync(new Register());
    }
}