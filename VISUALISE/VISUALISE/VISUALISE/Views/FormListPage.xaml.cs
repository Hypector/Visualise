using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Visualise.Models;
using Visualise.Views;
using Visualise.ViewModels;

namespace Visualise.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        FormListViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new FormListViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var form = args.SelectedItem as Form;
            if (form == null)
                return;

            await Navigation.PushModalAsync(new NavigationPage(new DataEntryPage(new DataEntryViewModel(form))));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddForm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewFormPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Forms.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}