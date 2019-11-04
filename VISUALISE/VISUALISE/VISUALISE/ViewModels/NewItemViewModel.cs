using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Visualise.ViewModels
{
    class NewItemViewModel : INotifyPropertyChanged
    {
        string chart = string.Empty;

        public string Chart
        {
            get { return chart; }
            set
            {
                if (chart == value)
                    return;
                chart = value;

                if (value == "Line Graph")
                    IsLineGraph = true;
                else
                    IsLineGraph = false;

                OnPropertyChanged(nameof(Chart));
                OnPropertyChanged(nameof(IsLineGraph));
            }
        }
        public bool IsLineGraph { get; private set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
