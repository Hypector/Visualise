﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Visualise.Models;
using Visualise.Data;

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
            try
            {
                //var x = await FormsDB.SaveQuestionAsync(Form);
            }
            catch
            {

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