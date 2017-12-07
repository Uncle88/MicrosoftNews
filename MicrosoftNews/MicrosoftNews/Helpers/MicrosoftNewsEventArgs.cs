using System;
using System.Collections.ObjectModel;
using MicrosoftNews.Models;

namespace MicrosoftNews.Helpers
{
    public class MicrosoftNewsEventArgs : EventArgs
    {
        public MicrosoftNewsEventArgs(ObservableCollection<Item> list)
        {
            Items = list;
        }

        public ObservableCollection<Item> Items { get; set; }
    }
}
