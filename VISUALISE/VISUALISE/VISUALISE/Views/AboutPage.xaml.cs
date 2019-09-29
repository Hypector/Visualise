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
        AboutViewModel viewModel;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AboutViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var form = args.SelectedItem as Form;
            if (form == null)
                return;

            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage(new ItemDetailViewModel(form))));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Forms.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}
    