using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Visualise.Models;
using Visualise.Views;
using Xamarin.Forms;
using Entry = Xamarin.Forms.Entry;

namespace Visualise.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
		public Form Form { get; set; }
        public ItemDetailViewModel(Form form = null)
        {
            Title = form?.ChartName;
            Form = form;
       }
    }
}
