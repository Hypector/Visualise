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
<<<<<<< HEAD:VISUALISE/VISUALISE/VISUALISE/ViewModels/ItemDetailViewModel.cs
		public FormModel Form { get; set; }
		public EntryModel Entry { get; set; }
        public ItemDetailViewModel(FormModel form = null)
=======
		public Form Form { get; set; }
		public Entry Entry { get; set; }
        public DataEntryViewModel(Form form = null)
>>>>>>> master:VISUALISE/VISUALISE/VISUALISE/ViewModels/DataEntryViewModel.cs
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
