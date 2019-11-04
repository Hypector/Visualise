using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Visualise.Models;
using Visualise.Views;
using Xamarin.Forms;
using Entry = Visualise.Models.Entry;

namespace Visualise.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
		public FormModel Form { get; set; }
		public EntryModel Entry { get; set; }
        public ItemDetailViewModel(FormModel form = null)
        {
            Title = form?.ChartName;
            Form = form;
			Entry = new EntryModel
			{
				FormID = Form.DBID
			};
		}
    }
}
