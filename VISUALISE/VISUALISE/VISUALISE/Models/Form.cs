using System;

namespace Visualise.Models
{
    public class Form
    {
        public string Id { get; set; }
        public string ChartName { get; set; }
        public string ChartDescription { get; set; }
        public string XFormName { get; set; }
        public string YFormName { get; set; }
		public Array XFormValues { get; set; }
		public Array YFormValues { get; set; }
    }
}
