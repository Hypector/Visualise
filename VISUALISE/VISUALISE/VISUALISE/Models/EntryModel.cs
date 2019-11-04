using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Visualise.Models
{
    public class EntryModel
    {
        [PrimaryKey, AutoIncrement]
        public int DBID { get; set; }
        public int FormID { get; set;  }
        public string XValue { get; set; }
        public string YValue { get; set; }
    }
}
