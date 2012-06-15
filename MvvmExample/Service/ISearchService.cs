using System.Collections.Generic;
using Microsoft.Practices.Prism.Events;
using MvvmExample.Dto;
using MvvmExample.Event;
using RestSharp;

namespace MvvmExample.Service
{
    public interface ISearchService
    {
        void LoadFeed(string url);
    }

    public class  SearchService:ISearchService
    {
        private readonly IEventAggregator _eventAggregator;

        public SearchService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void LoadFeed(string url)
        {
            RestClient client = new RestClient
            {
                BaseUrl = url
            };
            var request = new RestRequest { RequestFormat = DataFormat.Xml };

            client.ExecuteAsync<List<Item>>(request, response =>
            {
                _eventAggregator.GetEvent<DataReadyEvent>().Publish(new DataReadyEventArgs(response.Data));
             
            });
        }
    }
}