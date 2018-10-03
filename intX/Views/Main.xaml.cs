using System;
using System.Collections.Generic;
using System.Linq;
using intX.Models;
using Xamarin.Forms;

namespace intX.Views
{
    public partial class Main : ContentPage
    {
        public Main()
        {
            InitializeComponent();
            GetDataAr();
        }

        void Arabic(object sender, System.EventArgs e)
        {
            GetDataAr();
        }
         void Reload(object sender, System.EventArgs e)
        {
             clearAll();
        }
        void English(object sender, System.EventArgs e)
        {
            GetDataEng();
        }

        void r1(object sender, System.EventArgs e)
        {
            rating.Text = "1";
        }
        void r2(object sender, System.EventArgs e)
        {
            rating.Text = "2";
        }
        void r3(object sender, System.EventArgs e)
        {
            rating.Text = "3";
        }
        void r4(object sender, System.EventArgs e)
        {
            rating.Text = "4";
        }
        void r5(object sender, System.EventArgs e)
        {
            rating.Text = "5";
        }

        async void Submit_Clicked(object sender, System.EventArgs e)
        {
            if (rating.Text!="0")
            {

                Models.User user = new Models.User()
                {
                    Rate = Convert.ToInt32(rating.Text),
                    q1 = q1.Text,
                    q2 = q2.Text,
                    q3 = q3.Text,
                    q4 = q4.Text,
                    email = email.Text,
                    phone = phone.Text,
                    date = DateTime.Now
                };
                var item = await App.Database.SaveUserAsync(user);
                clearAll();
                if (submitbtn.Text == "save")
                {
                    await Application.Current.MainPage.DisplayAlert("Rating", "Thank You", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("تقييم", "شكرا لك", "حسنا");
                }
            }else
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Rate Please - برجاء التقييم", "OK");
            }
        }
        public async void GetDataEng()
        {
            var items = await App.Database.GetItemsAsync();
            var item = items.Where(x => x.lang == "eng").FirstOrDefault();
            if (item != null)
            {
                q1.Placeholder = item.q1;
                q2.Placeholder = item.q2;
                q3.Placeholder = item.q3;
                q4.Placeholder = item.q4;
                email.Placeholder = "Email";
                phone.Placeholder = "Phone";
                left.Source = item.left;
                center.Text = item.center;
                right.Source = item.right;
            }
            submitbtn.Text = "save";
            refr.Text = "Clear";
            rtext.Text = "Your Rating?";
        }
        public async void GetDataAr()
        {
            var items = await App.Database.GetItemsAsync();
            var item = items.Where(x => x.lang == "ar").FirstOrDefault();
            if (item != null)
            {
                q1.Placeholder = item.q1;
                q2.Placeholder = item.q2;
                q3.Placeholder = item.q3;
                q4.Placeholder = item.q4;
                email.Placeholder = "البريد الالكترونى";
                phone.Placeholder = "الهاتف";
                left.Source = item.left;
                center.Text = item.center;
                right.Source = item.right;
            }
            submitbtn.Text = "حفظ";
            refr.Text = "مسح";
            rtext.Text = "ما تقييمك؟";
        }
        void clearAll(){
            q1.Text = "";
            q2.Text = "";
            q3.Text = "";
            q4.Text = "";
            email.Text = "";
            phone.Text = "";
            rating.Text = "0";
        }
    }
}
