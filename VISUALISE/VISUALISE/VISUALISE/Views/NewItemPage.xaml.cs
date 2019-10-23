﻿using System;
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
    public partial class NewItemPage : ContentPage
    {
        public Form Form { get; set; }

        public NewItemPage()
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
            Form DBForm = new Form()
            {
                ChartName = ChartName.Text,
                ChartDescription = Description.Text,
                XFormName = XName.Text,
                XFormType = xpicker.SelectedItem.ToString(),
                YFormName = YName.Text,
                YFormType = ypicker.SelectedItem.ToString()
            };

            try
            {
                var x = await App.Database.SaveAsync(DBForm);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Sorry! There was an error: {ex.Message}");
            }

            MessagingCenter.Send(this, "AddForm", Form);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}