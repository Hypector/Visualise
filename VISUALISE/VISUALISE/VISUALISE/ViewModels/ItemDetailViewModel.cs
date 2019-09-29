using System;

using Visualise.Models;

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
