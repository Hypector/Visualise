using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Visualise.Models;
using Visualise.Data;
using SQLite;
using System.Diagnostics;
using Visualise.ViewModels;

namespace Visualise.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();

            BindingContext = new NewItemViewModel();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            FormModel DBForm = new FormModel()
            {
                ChartName = ChartName.Text,
                ChartDescription = Description.Text,
                XAxisName = XName.Text,
                YAxisName = YName.Text,
                ChartType = chartType.SelectedItem.ToString()
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<FormModel>();
                conn.Insert(DBForm);
            }

            try
            {
                var x = await App.Database.SaveFormAsync(DBForm);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Sorry! There was an error: {ex.Message}");
            }

            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}