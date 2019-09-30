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

        //Get Question
        public Task<Form> GetQuestionAsync(int ID)
        {
            return database.Table<Form>()
                .Where(i => i.DBID == ID)
                .FirstOrDefaultAsync();
        }

        //Add Question
        public Task<int> SaveQuestionAsync(Form form)
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

        //Delete Question
        public Task<int> DeleteQuestionAsync(Form form)
        {
            return database.DeleteAsync(form);
        }
    }
}
