﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

public class ObservableCollectionExt<T> : ObservableCollection<T>
{
    public void Reset(IEnumerable<T> newItemList)
    {
        CheckReentrancy();
        Items.Clear();
        foreach (var item in newItemList)
        {
            Items.Add(item);
        }
        OnPropertyChanged(new PropertyChangedEventArgs("Count"));
        OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    public ObservableCollectionExt(List<T> items = null)
    {
        if (items != null)
        {
            Items.Clear();
            foreach (var model in items)
            {
                Items.Add(model);
            }
            OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
