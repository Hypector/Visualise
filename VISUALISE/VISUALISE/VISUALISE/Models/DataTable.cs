using System;
using SQLite;

namespace Visualise.Models
{
    public class DataTable
    {
        [PrimaryKey, AutoIncrement]
        public int DBID { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Array XVals { get; set; }
        public Array YVals { get; set; }
    }
}
