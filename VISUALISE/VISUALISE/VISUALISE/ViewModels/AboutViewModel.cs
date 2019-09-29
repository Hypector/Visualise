using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Visualise.Models;
using Xamarin.Forms;

namespace Visualise.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<Form> Forms { get; set; }
        public Command LoadItemsCommand { get; set; }

        public AboutViewModel()
        {
            Title = "Charts";
            Forms = new ObservableCollection<Form>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Forms.Clear();
                var forms = await DataStore.GetFormsAsync(true);
                foreach (var form in forms)
                {
                    Forms.Add(form);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}