using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Practices.Prism.Events;
using MvvmExample.Dto;
using MvvmExample.Event;
using MvvmExample.Infrastrucutre;
using MvvmExample.Service;
using RestSharp;

namespace MvvmExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IEventAggregator _aggregator;
        private readonly ISearchService _searchService;
        private IList<Item> _posts;

        public IList<Item> Posts
        {
            get { return _posts; }
        }
        public DelegateCommand OpenDetailCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(IEventAggregator aggregator,ISearchService searchService)
        {
            _aggregator = aggregator;
            _searchService = searchService;
            OpenDetailCommand = new DelegateCommand(ExecuteOpenDetailCommand);

            LoadFeed(@"http://www.webdebs.org/category/eventi/feed/");

            _aggregator.GetEvent<DataReadyEvent>().Subscribe(OnDataReadyEvent);
        }

        public void OnDataReadyEvent(DataReadyEventArgs obj)
        {
            _posts = obj.Data;
            OnPropertyChanged("Posts");
        }

        private void ExecuteOpenDetailCommand()
        {
            App.Container.Resolve<INavigationService>().NavigateTo(new Uri("/View/DetailView.xaml", UriKind.RelativeOrAbsolute));
            
        }

        private void LoadFeed(string url)
        {
            _searchService.LoadFeed(url);
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        
    }
}