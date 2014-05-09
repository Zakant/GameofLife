using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ChartControl
{
    [Serializable()]
    public abstract class BaseChartPath<T> : BindingList<T> where T : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public Color Color { get; set; }

        

    }
}
