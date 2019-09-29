using System;
using System.Collections.Generic;

namespace Visualise.Models
{
    public class Form
    {
        public string Id { get; set; }
        public string ChartName { get; set; }
        public string ChartDescription { get; set; }
        public string XFormName { get; set; }
        public string YFormName { get; set; }
		public List<String> XFormValues { get; set; }
		public List<String> YFormValues { get; set; }
    }
}
