using System;
using SQLite;

namespace Visualise.Models
{
    public class Entry
    {
        [PrimaryKey, AutoIncrement]
        public int DBID { get; set; }
        public string FormID { get; set; }
        public string Val1 { get; set; }
        public string Val2 { get; set; }
    }
}
