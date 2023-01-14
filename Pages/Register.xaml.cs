using System.Text;
using System;
using System.Security.Cryptography;
using Pitshop.Models;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace Pitshop.Pages;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}

    private async void RegisterButtonClicked(object sender, EventArgs e)
    {
        var slist = new User();

        slist.Username = this.Username.Text;
        string Password = this.Password.Text;
        slist.Email = this.Email.Text;

        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            slist.Password = builder.ToString();
        }
        
        var rc = App.Database.SaveUserAsync(slist);

        if(rc != 0)
        {
            await Navigation.PushModalAsync(this);
            return;
        }

        await Navigation.PushModalAsync(new Welcome());
    }

    private async void LoginButtonClicked(object Sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Login());
    }
}