using System.Linq;
using intX.Models;
using Xamarin.Forms;
namespace intX.Views{

public partial class Admin : ContentPage
    {    

        public Admin()
        {

            InitializeComponent();
            GetDataAr();

        }

        void Submit_Clicked(object sender, System.EventArgs e)
        {
            if (submit.Text == "save")
            {
                CreateDataEng();
                Application.Current.MainPage.DisplayAlert("Data", "Saved", "OK");

            }
            else
            {
                CreateDataAr();
                Application.Current.MainPage.DisplayAlert("Data", "تم الحفظ", "OK");
            }
        }


        void English(object sender, System.EventArgs e)
        {
            GetDataEng();
        }
        void Arabic(object sender, System.EventArgs e)
        {
            GetDataAr();
        }
        public async void CreateDataEng()
        {
            var items = await App.Database.GetItemsAsync();
            var item = items.Where(x => x.lang == "eng").FirstOrDefault();
            if (item != null)
            {
                Rate rate = new Rate
                {
                    ID = item.ID,
                    q1 = q1.Text,
                    q2 = q2.Text,
                    q3 = q3.Text,
                    q4 = q4.Text,
                    left = left.Text,
                    center = center.Text,
                    right = right.Text,
                    lang = "eng"
                };
                var res = await App.Database.UpdateItems(rate);
            }
            else
            {
                Rate rate = new Rate
                {
                    q1 = q1.Text,
                    q2 = q2.Text,
                    q3 = q3.Text,
                    q4 = q4.Text,
                    left = left.Text,
                    center = center.Text,
                    right = right.Text,
                    lang = "eng"
                };
                var res = await App.Database.SaveItemAsync(rate);
            }
         }
        public async void CreateDataAr()
        {
            var items = await App.Database.GetItemsAsync();
            var item = items.Where(x => x.lang == "ar").FirstOrDefault();
            if (item != null)
            {
                Rate rate = new Rate
                {
                    ID = item.ID,
                    q1 = q1.Text,
                    q2 = q2.Text,
                    q3 = q3.Text,
                    q4 = q4.Text,
                    left = left.Text,
                    center = center.Text,
                    right = right.Text,
                    lang = "ar"
                };
                var res = await App.Database.UpdateItems(rate);
            }
            else
            {
                Rate rate = new Rate
                {
                    q1 = q1.Text,
                    q2 = q2.Text,
                    q3 = q3.Text,
                    q4 = q4.Text,
                    left=left.Text,
                    center=center.Text,
                    right=right.Text,
                    lang = "ar"
                };
                var res = await App.Database.SaveItemAsync(rate);
            }


        }
        public async void GetDataEng()
        {
            var items = await App.Database.GetItemsAsync();
            var item = items.Where(x => x.lang == "eng").FirstOrDefault();
            if (item != null)
            {
                q1.Text = item.q1;
                q2.Text = item.q2;
                q3.Text = item.q3;
                q4.Text = item.q4;
                left.Text = item.left;
                center.Text = item.center;
                right.Text = item.right;
            }
            submit.Text = "save";
            report.Text = "Reports";
            back.Text = "Back";
            lists.Text = "Record";
            tright.Text = "right";
            tcenter.Text = "center";
            tleft.Text = "left";

        }
        public async void GetDataAr()
        {
            var items = await App.Database.GetItemsAsync();
            var item = items.Where(x => x.lang == "ar").FirstOrDefault();
            if (item != null)
            {
                q1.Text = item.q1;
                q2.Text = item.q2;
                q3.Text = item.q3;
                q4.Text = item.q4;
                left.Text = item.left;
                center.Text = item.center;
                right.Text = item.right;
            }
            submit.Text = "حفظ";
            report.Text = "التقارير";
            back.Text = "رجوع";
            lists.Text = "السجل";
            tright.Text = "يمين";
            tcenter.Text = "وسط";
            tleft.Text = "شمال";

        }

        void backbtn(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        async void listsbtnbtn(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.List());
        }
        async void reportsbtn(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Report());
        }


    }
}
