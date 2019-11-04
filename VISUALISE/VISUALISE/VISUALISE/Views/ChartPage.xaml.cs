using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Visualise.Models;
using Visualise.ViewModels;
using SQLite;
using Visualise.Services;

namespace Visualise.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ChartPage : ContentPage
    {
        ChartViewModel viewModel;
        public Form Form { get; set; }
		private bool _canRemove = true;
        public IDataStore<Form> DataStore => DependencyService.Get<IDataStore<Form>>() ?? new MockDataStore();

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
        async void Remove_Clicked(object sender, EventArgs e)
        {
			if (_canRemove)
			{
				var answer = await DisplayAlert("Remove", "Do you want to remove this chart?", "Yes", "No");
				if (answer)
				{
					_canRemove = false;
					Remove_Clicked(true, System.EventArgs.Empty);
				}
			} else
			{
				MessagingCenter.Send(this, "RemoveForm", Form);
				await Navigation.PopAsync();
			}

        }

		public ChartPage()
        {
            InitializeComponent();
			Form = new Form();

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