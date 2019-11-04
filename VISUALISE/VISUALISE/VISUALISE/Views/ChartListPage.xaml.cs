using SQLite;
using System;
using System.ComponentModel;
using Visualise.Models;
using Visualise.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Visualise.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        ChartListViewModel viewModel;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ChartListViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var form = args.SelectedItem as Form;
            if (form == null)
                return;

            await Navigation.PushAsync(new ChartPage(new ChartViewModel(form)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<FormModel>();
                var Form = conn.Table<FormModel>().ToList();

                FormListView.ItemsSource = Form;
            }

            if (viewModel.Forms.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}
    