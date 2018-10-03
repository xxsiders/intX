using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace intX.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            err.Text = "";
        }

        public async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var items = await App.Database.GetAdminAsync();

            Models.Admin admin = new Models.Admin()
            {
                Password = pass.Text
            };

            if (items.Count() == 0)
            {
                var item = await App.Database.SaveAdminAsync(admin);
            }
            else if (items.FirstOrDefault().Password==pass.Text)
            {
                err.Text = "";

                await Navigation.PushModalAsync(new Views.Admin());
            }
            else
            {
                err.Text = "Error";
            }
            pass.Text = "";

        }
    }
}
