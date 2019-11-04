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
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public FormModel Form { get; set; }
        public EntryModel Entry { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
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

		public ItemDetailPage()
        {
            InitializeComponent();
			Form = new FormModel();
            Entry = new EntryModel
            {
                FormID = Form.DBID
			};
            viewModel = new ItemDetailViewModel(Form);
            BindingContext = viewModel;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
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

		async void Cancel_Clicked(object sender, EventArgs e)
        {
			await Navigation.PopModalAsync();
        }
    }
}