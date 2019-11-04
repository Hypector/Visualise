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
    public partial class HistoryListPage : ContentPage
    {
        public HistoryListPage(HistoryViewModel historyViewModel)
        {
            InitializeComponent();
			BindingContext = historyViewModel;
        }
    }
}
