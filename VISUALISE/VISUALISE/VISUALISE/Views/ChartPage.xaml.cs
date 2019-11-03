using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Visualise.Models;
using Visualise.ViewModels;

namespace Visualise.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ChartPage : ContentPage
    {
        ChartViewModel viewModel;
        public Form Form { get; set; }

        public ChartPage(ChartViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
			Form = viewModel.Form;
        }
        async void History_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryListPage(new HistoryViewModel(Form)));
        }

		public ChartPage()
        {
            InitializeComponent();
			Form = new Form();

            viewModel = new ChartViewModel(Form);
            BindingContext = viewModel;
        }
   }
}