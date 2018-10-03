using System;
using System.Collections.Generic;
using CoreGraphics;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using UIKit;
using SQLite;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using System.Linq;
using System.Threading.Tasks;
using Foundation;

namespace intX.Views
{
    public partial class Report : ContentPage
    {
        public Report()
        {
            InitializeComponent();
            reportDaily();
            reportWeek();
            reportMonth();
            reportYear();
            datetxt.Text = DateTime.Now.ToShortDateString();
        }
        public async void reportDaily()
        {
            DateTime dates = DateTime.Now.Date;
            var lista = await App.Database.GetUserAsync();
            int fi = lista.Where(x => x.Rate == 5 && x.date.Day == dates.Day).Count();
            int fo = lista.Where(x => x.Rate == 4 && x.date.Day == dates.Day).Count();
            int thr = lista.Where(x => x.Rate == 3 && x.date.Day == dates.Day).Count();
            int tw = lista.Where(x => x.Rate == 2 && x.date.Day == dates.Day).Count();
            int one = lista.Where(x => x.Rate == 1 && x.date.Day == dates.Day).Count();
            var entries = new[]
            {
                new Entry(one)
                {
                    Label = "1",
                    ValueLabel = one.ToString(),
                    Color = SKColor.Parse("#B22222")
                },
                new Entry(tw)
                {
                    Label = "2",
                    ValueLabel = tw.ToString(),
                    Color = SKColor.Parse("#FFA500")
                },
                new Entry(thr)
                {
                    Label = "3",
                    ValueLabel = thr.ToString(),
                    Color = SKColor.Parse("#FF4500")
                },
                new Entry(fo)
                {
                    Label = "4",
                    ValueLabel = fo.ToString(),
                    Color = SKColor.Parse("#A5B358")
                },
                new Entry(fi)
                {
                    Label = "5",
                    ValueLabel = fi.ToString(),
                    Color = SKColor.Parse("#008000")
                }
            };

            var chart = new BarChart() { Entries = entries };
            this.dchart.Chart = chart;
            this.dchart.Chart.LabelTextSize = 30;
        }
        public async void reportWeek()
        {

            DateTime dates = DateTime.Now;

            DateTime week = dates.AddDays(-7).Date;
            var lista = await App.Database.GetUserAsync();
            int fi = lista.Where(x => x.Rate == 5).Where(x => x.date >= week).Count();
            int fo = lista.Where(x => x.Rate == 4).Where(x => x.date >= week).Count();
            int thr = lista.Where(x => x.Rate == 3).Where(x => x.date >= week).Count();
            int tw = lista.Where(x => x.Rate == 2).Where(x => x.date >= week).Count();
            int one = lista.Where(x => x.Rate == 1).Where(x => x.date >= week).Count();
            var entries = new[]
            {
                new Entry(one)
                {
                    Label = "1",
                    ValueLabel = one.ToString(),
                    Color = SKColor.Parse("#B22222")
                },
                new Entry(tw)
                {
                    Label = "2",
                    ValueLabel = tw.ToString(),
                    Color = SKColor.Parse("#FFA500")
                },
                new Entry(thr)
                {
                    Label = "3",
                    ValueLabel = thr.ToString(),
                    Color = SKColor.Parse("#FF4500")
                },
                new Entry(fo)
                {
                    Label = "4",
                    ValueLabel = fo.ToString(),
                    Color = SKColor.Parse("#A5B358")
                },
                new Entry(fi)
                {
                    Label = "5",
                    ValueLabel = fi.ToString(),
                    Color = SKColor.Parse("#008000")
                }
            };

            var chart = new BarChart() { Entries = entries };
            this.wchart.Chart = chart;
            this.wchart.Chart.LabelTextSize = 30;

        }

        public async void reportMonth()
        {
            DateTime dates = DateTime.Now.Date;
            var lista = await App.Database.GetUserAsync();

            int fi = lista.Where(x => x.Rate == 5 && x.date.Month == dates.Month).Count();
            int fo = lista.Where(x => x.Rate == 4 && x.date.Month == dates.Month).Count();
            int thr = lista.Where(x => x.Rate == 3 && x.date.Month == dates.Month).Count();
            int tw = lista.Where(x => x.Rate == 2 && x.date.Month == dates.Month).Count();
            int one = lista.Where(x => x.Rate == 1 && x.date.Month == dates.Month).Count();

            var entries = new[]
            {
                new Entry(one)
                {
                    Label = "1",
                    ValueLabel = one.ToString(),
                    Color = SKColor.Parse("#B22222")
                },
                new Entry(tw)
                {
                    Label = "2",
                    ValueLabel = tw.ToString(),
                    Color = SKColor.Parse("#FFA500")
                },
                new Entry(thr)
                {
                    Label = "3",
                    ValueLabel = thr.ToString(),
                    Color = SKColor.Parse("#FF4500")
                },
                new Entry(fo)
                {
                    Label = "4",
                    ValueLabel = fo.ToString(),
                    Color = SKColor.Parse("#A5B358")
                },
                new Entry(fi)
                {
                    Label = "5",
                    ValueLabel = fi.ToString(),
                    Color = SKColor.Parse("#008000")
                }
            };

            var chart = new BarChart() { Entries = entries };
            this.mchart.Chart = chart;
            this.mchart.Chart.LabelTextSize = 30;

        }
        public async void reportYear()
        {
            DateTime dates = DateTime.Now.Date;
            var lista = await App.Database.GetUserAsync();

            int fi = lista.Where(x => x.Rate == 5 && x.date.Year == dates.Year).Count();
            int fo = lista.Where(x => x.Rate == 4 && x.date.Year == dates.Year).Count();
            int thr = lista.Where(x => x.Rate == 3 && x.date.Year == dates.Year).Count();
            int tw = lista.Where(x => x.Rate == 2 && x.date.Year == dates.Year).Count();
            int one = lista.Where(x => x.Rate == 1 && x.date.Year == dates.Year).Count();

            var entries = new[]
            {
                new Entry(one)
                {
                    Label = "1",
                    ValueLabel = one.ToString(),
                    Color = SKColor.Parse("#B22222")
                },
                new Entry(tw)
                {
                    Label = "2",
                    ValueLabel = tw.ToString(),
                    Color = SKColor.Parse("#FFA500")
                },
                new Entry(thr)
                {
                    Label = "3",
                    ValueLabel = thr.ToString(),
                    Color = SKColor.Parse("#FF4500")
                },
                new Entry(fo)
                {
                    Label = "4",
                    ValueLabel = fo.ToString(),
                    Color = SKColor.Parse("#A5B358")
                },
                new Entry(fi)
                {
                    Label = "5",
                    ValueLabel = fi.ToString(),
                    Color = SKColor.Parse("#008000")
                }
            };

            var chart = new DonutChart() { Entries = entries };
            this.ychart.Chart = chart;
            this.ychart.Chart.LabelTextSize = 30;

        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
