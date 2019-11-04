using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Visualise.Models;
using Visualise.Views;
using Xamarin.Forms;
using Entry = Visualise.Models.Entry;

namespace Visualise.ViewModels
{
    public class DataEntryViewModel : BaseViewModel
    {
		public Form Form { get; set; }
		public Entry Entry { get; set; }
        public DataEntryViewModel(Form form = null)
        {
            Title = form?.ChartName;
            Form = form;
			Entry = new Entry
			{
				FormID = Form.Id
			};
		}
    }
}
