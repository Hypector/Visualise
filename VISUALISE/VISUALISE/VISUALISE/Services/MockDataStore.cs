using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visualise.Models;

namespace Visualise.Services
{
    public class MockDataStore : IDataStore<Form>
    {
        List<Form> forms;

        public MockDataStore()
        {
            forms = new List<Form>();
			List<String> xList = new List<String>();
			List<String> yList = new List<String>();
			var mockForms = new List<Form>
            {
                new Form { Id = Guid.NewGuid().ToString(), ChartName = "Spending Tracker", ChartDescription = "Track how much you spend on various categories (Example)", XFormName="Amount Spent", YFormName="Category", XFormValues=xList, YFormValues=yList },
            };

            foreach (var form in mockForms)
            {
                forms.Add(form);
            }
        }

        public async Task<bool> AddFormAsync(Form form)
        {
            forms.Add(form);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateFormAsync(Form form)
        {
            var oldForm = forms.Where((Form arg) => arg.Id == form.Id).FirstOrDefault();
            forms.Remove(oldForm);
            forms.Add(form);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteFormAsync(string id)
        {
            var oldForm = forms.Where((Form arg) => arg.Id == id).FirstOrDefault();
            forms.Remove(oldForm);

            return await Task.FromResult(true);
        }

        public async Task<Form> GetFormAsync(string id)
        {
            return await Task.FromResult(forms.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Form>> GetFormsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(forms);
        }
    }
}