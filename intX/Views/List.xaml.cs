using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using intX.Models;
using Syncfusion.XlsIO;
using UIKit;
using Xamarin.Forms;

namespace intX.Views
{
    public partial class List : ContentPage
    {
        public List()
        {
            InitializeComponent();
            GetData();

        }
        async void GetData()
        {
            var lista = await App.Database.GetUserAsync();
            ObservableCollection<User> list = new ObservableCollection<User>();
            foreach (var item in lista.OrderByDescending(x => x.date).ToList())
            {
                list.Add(item);
            }
            MylistView.ItemsSource = list;
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        async void Emailbtn(object sender, System.EventArgs e)
        {
            var lista = await App.Database.GetUserAsync();
            string emails = string.Join("\n", lista.Select(x => x.email).ToArray());
            UIPasteboard clipboard = UIPasteboard.General;
            clipboard.String = emails;
            await Application.Current.MainPage.DisplayAlert("Data", "Emails copied", "OK");

        }
        async void Phonebtn(object sender, System.EventArgs e)
        {
            var lista = await App.Database.GetUserAsync();
            string phone = string.Join("\n", lista.Select(x => x.phone).ToArray());
            UIPasteboard clipboard = UIPasteboard.General;
            clipboard.String = phone;
            await Application.Current.MainPage.DisplayAlert("Data", "Phones copied", "OK");
        }

        void MainListView_ItemSelected(object sender, System.EventArgs e)
        {
            string q1, q2, q3, q4;
            User item = (User)MylistView.SelectedItem;
            int id = item.ID;
            q1 = item.q1;
            q2 = item.q2;
            q3 = item.q3;
            q4 = item.q4;
            Application.Current.MainPage.DisplayAlert("Data", $" {q1} \n {q2} \n {q3} \n {q4}", "OK");
        }
        async void SaveToExcel(object sender, System.EventArgs e)
        {
            ExcelData();
        }
        async void ExcelData()
        {
            List<Models.User> list = await App.Database.GetUserAsync();
            list = list.OrderByDescending(x => x.date).ToList();
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Set the default application version as Excel 2013.
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2016;

                //Create a workbook with a worksheet
                IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);

                //Access first worksheet from the workbook instance.
                IWorksheet worksheet = workbook.Worksheets[0];

                //Adding text to a cell
                worksheet.Range["A1"].Text = "Rate";
                worksheet.Range["B1"].Text = "Email";
                worksheet.Range["C1"].Text = "Phone";
                worksheet.Range["D1"].Text = "Date";
                worksheet.Range["E1"].Text = "Answer 1";
                worksheet.Range["F1"].Text = "Answer 2";
                worksheet.Range["G1"].Text = "Answer 3";
                worksheet.Range["H1"].Text = "Answer 4";
                try
                {
                    for (int i = 1; i < list.Count + 1; i++)
                    {
                        worksheet.Range["A" + (i + 1)].Text = list[i].Rate.ToString();
                        worksheet.Range["B" + (i + 1)].Text = list[i].email;
                        worksheet.Range["C" + (i + 1)].Text = list[i].phone;
                        worksheet.Range["D" + (i + 1)].Text = list[i].date.ToShortDateString();
                        worksheet.Range["E" + (i + 1)].Text = list[i].q1;
                        worksheet.Range["F" + (i + 1)].Text = list[i].q2;
                        worksheet.Range["G" + (i + 1)].Text = list[i].q3;
                        worksheet.Range["H" + (i + 1)].Text = list[i].q4;
                    }

                }
                catch (Exception ex)
                {

                }

                //Save the workbook to stream in xlsx format. 
                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);

                workbook.Close();

                //Save the stream as a file in the device and invoke it for viewing
                await Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("GettingStared.xlsx", "application/msexcel", stream);

            }

        }
    }
}
