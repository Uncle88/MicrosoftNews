using System;
using System.Collections.ObjectModel;
using MicrosoftNews.Models;
using Xamarin.Forms;

namespace MicrosoftNews.ViewModels
{
    public class DetailsListViewModel : ViewModelBase
    {
        string _descriptionNews;
        public string Description 
        {
            get
            {
                return _descriptionNews;
            }
            set
            {
                if (_descriptionNews != value)
                    _descriptionNews = value;
                OnPropertyChanged();
            }
        }
        public DetailsListViewModel(Item item)
        {
            Description = item.Description;
        }
    }
}