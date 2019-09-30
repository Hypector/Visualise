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
        public string XFormType { get; set; }
        public string YFormName { get; set; }
        public string YFormType { get; set; }
		public List<String> XFormValues { get; set; }
		public List<String> YFormValues { get; set; }

		public int EntryCount { get; set; }
		public string EntryCountString { get; set; }
    }
}
