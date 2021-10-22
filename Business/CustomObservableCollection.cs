using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Business
{
    public class CustomObservableCollection<T> : ObservableCollection<T>
    {
        public CustomObservableCollection()
        {
        }

        public CustomObservableCollection(IEnumerable<T> items) : this()
        {
            foreach (var item in items)
                Add(item);
        }

        public void ReportItemChange(T item)
        {
            var args =
                new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Replace,
                    item,
                    item,
                    IndexOf(item));
            OnCollectionChanged(args);
        }
    }
}