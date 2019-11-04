using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Visualise.Models;
using Visualise.ViewModels;
using SQLite;
using System.Diagnostics;

namespace Visualise.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DataEntryPage : ContentPage
    {
<<<<<<< HEAD:VISUALISE/VISUALISE/VISUALISE/Views/ItemDetailPage.xaml.cs
        ItemDetailViewModel viewModel;
        public FormModel Form { get; set; }
        public EntryModel Entry { get; set; }
=======
        DataEntryViewModel viewModel;
        public Form Form { get; set; }
        public Entry Entry { get; set; }
>>>>>>> master:VISUALISE/VISUALISE/VISUALISE/Views/DataEntryPage.xaml.cs

        public DataEntryPage(DataEntryViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
			Entry = viewModel.Entry;
			Form = viewModel.Form;
			
			// type bindings
			if (Form.ChartType == "Line Graph")
			{
				val1.Keyboard = Keyboard.Numeric;
			} else
			{
				val1.Keyboard = Keyboard.Text;
			}
			val2.Keyboard = Keyboard.Numeric;
        }

		public DataEntryPage()
        {
            InitializeComponent();
			Form = new FormModel();
            Entry = new EntryModel
            {
                FormID = Form.DBID
			};
            viewModel = new DataEntryViewModel(Form);
            BindingContext = viewModel;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
<<<<<<< HEAD:VISUALISE/VISUALISE/VISUALISE/Views/ItemDetailPage.xaml.cs
            EntryModel DBEntry = new EntryModel()
            {
                FormID = Form.DBID,
                XValue = val1.Text,
                YValue = val2.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<EntryModel>();
                conn.Insert(DBEntry);
            }

            try
            {
                var x = await App.Database.SaveEntryAsync(DBEntry);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Sorry! There was an error: {ex.Message}");
            }

            await Navigation.PopModalAsync();
        }
=======
			if (string.IsNullOrEmpty(Entry.Val1) || string.IsNullOrEmpty(Entry.Val2))
			{
				await DisplayAlert("Error", "Please fill out all the fields before saving", "OK");
			} else
			{
				MessagingCenter.Send(this, "AddEntry", Entry);
				await Navigation.PopModalAsync();
			}
		}
>>>>>>> master:VISUALISE/VISUALISE/VISUALISE/Views/DataEntryPage.xaml.cs

		async void Cancel_Clicked(object sender, EventArgs e)
        {
			await Navigation.PopModalAsync();
        }
    }
}