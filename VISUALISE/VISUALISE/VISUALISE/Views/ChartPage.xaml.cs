using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Visualise.Models;
using Visualise.ViewModels;
using SQLite;

namespace Visualise.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ChartPage : ContentPage
    {
        ChartViewModel viewModel;
        public FormModel Form { get; set; }

        public ChartPage(ChartViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

		public ChartPage()
        {
            InitializeComponent();
			Form = new FormModel();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<EntryModel>();
                var Form = conn.Table<EntryModel>().ToList();
            }

            viewModel = new ChartViewModel(Form);
            BindingContext = viewModel;
        }
   }
}