using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChartControl
{
    public abstract class BasePoint<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaiseNotifyPropertyChanged(string propertyname)
        {
            var myevent = PropertyChanged;
            if (myevent != null)
                myevent.Invoke(this, new PropertyChangedEventArgs(propertyname));
            }
        private T _xvalue;
        public T X
        {
            get { return _xvalue; }
            set
            {
                _xvalue = value;
                RaiseNotifyPropertyChanged("X");
            }
        }
        private T _yvalue;
        public T Y
        {
            get { return _yvalue; }
            set
            {
                _yvalue = value;
                RaiseNotifyPropertyChanged("Y");
            }
        }

        
    }
}
