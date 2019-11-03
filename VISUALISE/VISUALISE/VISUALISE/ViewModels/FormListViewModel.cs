using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Visualise.Models;
using Visualise.Views;
using Entry = Visualise.Models.Entry;

namespace Visualise.ViewModels
{
    public class FormListViewModel : BaseViewModel
    {
        public ObservableCollection<Form> Forms { get; set; }
        public Command LoadItemsCommand { get; set; }

        public FormListViewModel()
        {
            Title = "Forms";
            Forms = new ObservableCollection<Form>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewFormPage, Form>(this, "AddForm", async (obj, form) =>
            {
                var newForm = form as Form;
                Forms.Add(newForm);
                await DataStore.AddFormAsync(newForm);
            });

            MessagingCenter.Subscribe<DataEntryPage, Entry>(this, "AddEntry", async (obj, entry) =>
            {
				var newEntry = entry as Entry;
				Form form = await DataStore.GetFormAsync(newEntry.FormID);
				form.XFormValues.Add(entry.Val1);
				form.YFormValues.Add(entry.Val2);
				form.EntryCount++;
				form.EntryCountString = form.EntryCount.ToString() + " entries";
				if (form.EntryCount == 1) {
					form.EntryCountString = form.EntryCount.ToString() + " entry";
				} else {
					form.EntryCountString = form.EntryCount.ToString() + " entries";
				}
				await DataStore.UpdateFormAsync(form);

//                Forms.Add(newForm);
//               await DataStore.AddFormAsync(newForm);
            });
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