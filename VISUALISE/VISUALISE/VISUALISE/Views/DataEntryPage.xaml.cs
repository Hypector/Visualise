using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Visualise.Models;
using Visualise.ViewModels;
using Entry = Visualise.Models.Entry;

namespace Visualise.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public Form Form { get; set; }
        public Entry Entry { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
			Entry = viewModel.Entry;
			Form = viewModel.Form;
			
			// type bindings
			if (Form.XFormType == "Numeric")
			{
				val1.Keyboard = Keyboard.Numeric;
			} else
			{
				val1.Keyboard = Keyboard.Text;
			}

			if (Form.YFormType == "Numeric")
			{
				val2.Keyboard = Keyboard.Numeric;
			} else
			{
				val2.Keyboard = Keyboard.Text;
			}
        }

		public ItemDetailPage()
        {
            InitializeComponent();
			Form = new Form();
			Entry = new Entry
			{
				FormID = Form.Id
			};
            viewModel = new ItemDetailViewModel(Form);
            BindingContext = viewModel;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddEntry", Entry);
			await Navigation.PopModalAsync();
		}

		async void Cancel_Clicked(object sender, EventArgs e)
        {
			await Navigation.PopModalAsync();
        }
    }
}