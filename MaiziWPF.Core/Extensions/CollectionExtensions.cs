using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MaiziWPF.Core
{
    public static class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return new ObservableCollection<T>();

            return new ObservableCollection<T>(source);
        }
    }
}
