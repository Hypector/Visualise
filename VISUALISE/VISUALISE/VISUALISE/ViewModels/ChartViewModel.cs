using Visualise.Models;
using Visualise.Views;
using Xamarin.Forms;

namespace Visualise.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {
		public Form Form { get; set; }
        public ChartViewModel(Form form = null)
        {
            Title = form?.ChartName;
            Form = form;
		}
    }
}

