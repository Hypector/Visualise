using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Visualise.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddFormAsync(T form);
        Task<bool> UpdateFormAsync(T form);
        Task<bool> DeleteFormAsync(string id);
        Task<T> GetFormAsync(string id);
        Task<IEnumerable<T>> GetFormsAsync(bool forceRefresh = false);
    }
}
