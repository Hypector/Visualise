using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Visualise.Models;
using Visualise.Views;
using Entry = Visualise.Models.Entry;
using System.Collections.Generic;

namespace Visualise.ViewModels
{
	public class HistoryDataModel
	{
		public string xVal { get; set; }
		public string yVal { get; set; }
	}
    public class HistoryViewModel : BaseViewModel
    {
		public List<HistoryDataModel> HistoryData { get; set; }

        public HistoryViewModel(Form form)
        {
            Title = "History";
			HistoryData = new List<HistoryDataModel>();
			for (int i = 0; i < form.XFormValues.Count; i++)
			{
				HistoryData.Add(new HistoryDataModel { xVal = form.XFormValues[i], yVal = form.YFormValues[i] }) ;
			}
        }
    }
}