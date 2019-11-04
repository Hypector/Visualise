using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Visualise.Models
{
    public class FormModel
    {
        [PrimaryKey, AutoIncrement]
        public int DBID { get; set; }
        public string ChartName { get; set; }
        public string ChartDescription { get; set; }
        public string XAxisName { get; set; }
        public string YAxisName { get; set; }
        public string ChartType { get; set; }

    }
}
