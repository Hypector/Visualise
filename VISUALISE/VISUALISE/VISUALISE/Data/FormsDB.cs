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
            database.CreateTableAsync<Form>().Wait();
        }

        //Get
        public Task<Form> GetAsync(int ID)
        {
            return database.Table<Form>()
                .Where(i => i.DBID == ID)
                .FirstOrDefaultAsync();
        }

        //Add
        public Task<int> SaveAsync(Form form)
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

        //Delete
        public Task<int> DeleteAsync(Form form)
        {
            return database.DeleteAsync(form);
        }
    }
}
