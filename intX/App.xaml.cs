using System;
using System.IO;
using intX.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace intX
{
    public partial class App : Application
    {
        static RateDatabase database;

        public App()
        {
            InitializeComponent();
            MainPage = new TabbedPage
            {
                Children ={
                new Views.Main(),
                new Views.Login()
                }
            };

        }
        public static RateDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RateDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RatingSQLite.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
