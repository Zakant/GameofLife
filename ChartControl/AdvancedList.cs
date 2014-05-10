using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChartControl
{
    public class AdvancedList<T> : List<T>, INotifyPropertyChanged where T : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent(object sender, string name)
        {
            var myevent = PropertyChanged;
            if (myevent != null)
                myevent.Invoke(sender, new PropertyChangedEventArgs(name));
        }

        protected void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChangedEvent(sender, e.PropertyName);
        }


        public new void Add(T item)
        {
            base.Add(item);
            item.PropertyChanged += HandlePropertyChanged;
            RaisePropertyChangedEvent(this, "Add");
        }
        public new void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);
            foreach (T t in collection)
                t.PropertyChanged += HandlePropertyChanged;
            RaisePropertyChangedEvent(this, "AddRange");
        }

        public new bool Remove(T item)
        {
            bool b = base.Remove(item);
            item.PropertyChanged -= HandlePropertyChanged;
            RaisePropertyChangedEvent(this, "Remove");
            return b;
        }
      
        public new int RemoveAll(Predicate<T> match)
        {
            foreach (T t in this.Where(new Func<T, bool>(x => match(x))))
                t.PropertyChanged -= HandlePropertyChanged;
            int i = RemoveAll(match);
            RaisePropertyChangedEvent(this, "RemoveAll");
            return i;
        }

        public new void RemoveAt(int index)
        {
            this[index].PropertyChanged -= HandlePropertyChanged;
            base.RemoveAt(index);
            RaisePropertyChangedEvent(this, "RemoveAt");
        }

        public new void RemoveRange(int index, int count)
        {
            for (int i = index; i < index + count; i++)
                this[i].PropertyChanged -= HandlePropertyChanged;
                base.RemoveRange(index, count);
            RaisePropertyChangedEvent(this, "RemoveRange");
        }

        public new void Clear()
        {
            base.Clear();
            RaisePropertyChangedEvent(this, "Clear");
        }

    }
}
