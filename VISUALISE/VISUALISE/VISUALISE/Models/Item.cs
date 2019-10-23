using System;
using SQLite;

namespace Visualise.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int DBID { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}