using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Visualise.Models;

namespace Visualise.Data
{
    public class FormsDB
    {
        readonly SQLiteAsyncConnection database;

        public FormsDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<FormModel>().Wait();
            database.CreateTableAsync<EntryModel>().Wait();
        }

        //Get
        public Task<FormModel> GetFormAsync(int ID)
        {
            return database.Table<FormModel>()
                .Where(i => i.DBID == ID)
                .FirstOrDefaultAsync();
        }
        public Task<EntryModel> GetEntryAsync(int ID)
        {
            return database.Table<EntryModel>()
                .Where(i => i.DBID == ID)
                .FirstOrDefaultAsync();
        }

        //Add
        public Task<int> SaveFormAsync(FormModel form)
        {
            if (form.DBID != 0)
            {
                return database.UpdateAsync(form);
            }
            else
            {
                return database.InsertAsync(form);
            }
        }
        public Task<int> SaveEntryAsync(EntryModel entry)
        {
            if (entry.DBID != 0)
            {
                return database.UpdateAsync(entry);
            }
            else
            {
                return database.InsertAsync(entry);
            }
        }

        //Delete
        public Task<int> DeleteFormAsync(FormModel form)
        {
            return database.DeleteAsync(form);
        }
        public Task<int> DeleteEntryAsync(EntryModel entry)
        {
            return database.DeleteAsync(entry);
        }
    }
}
