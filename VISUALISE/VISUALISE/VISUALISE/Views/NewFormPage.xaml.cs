using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Visualise.Models;
using Visualise.Data;
using SQLite;
using System.Diagnostics;

namespace Visualise.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewFormPage : ContentPage
    {
        public Form Form { get; set; }

        public NewFormPage()
        {
            InitializeComponent();

			Form = new Form();
			Form.XFormValues = new List<String>();
			Form.YFormValues = new List<String>();
			Form.EntryCount = 0;
			Form.EntryCountString = "No entries";

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
			if (string.IsNullOrEmpty(ChartName.Text) || string.IsNullOrEmpty(Description.Text) || string.IsNullOrEmpty(YName.Text) || string.IsNullOrEmpty(XName.Text) || string.IsNullOrEmpty(ChartType.SelectedItem.ToString()))
			{
				await DisplayAlert("Error", "Please fill out all the fields before saving", "OK");
			} else
			{
				Form.ChartName = ChartName.Text;
				Form.ChartDescription = Description.Text;
				Form.XFormName = XName.Text;
				Form.YFormName = YName.Text;
				
				if (ChartType.SelectedItem.ToString() == "Pie")
				{
					Form.XFormType = "Text";
					Form.YFormType = "Numeric";
				} else if (ChartType.SelectedItem.ToString() == "Line")
					Form.XFormType = "Numeric";
					Form.YFormType = "Numeric";

				try
				{
					var x = await App.Database.SaveQuestionAsync(Form);
				}
				catch (Exception ex)
				{
					Debug.WriteLine($"Sorry! There was an error: {ex.Message}");
				}

				MessagingCenter.Send(this, "AddForm", Form);
				await Navigation.PopModalAsync();
			}
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}