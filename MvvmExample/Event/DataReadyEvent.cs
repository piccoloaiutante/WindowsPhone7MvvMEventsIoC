using System;
using System.Collections.Generic;
using Microsoft.Practices.Prism.Events;
using MvvmExample.Dto;

namespace MvvmExample.Event
{
    public class DataReadyEvent :CompositePresentationEvent<DataReadyEventArgs>
    {
         
    }

    public class DataReadyEventArgs:EventArgs
    {
        private readonly IList<Item> _data;

        public DataReadyEventArgs(IList<Item> data)
        {
            _data = data;
        }

        public IList<Item> Data
        {
            get { return _data; }
        }
    }
}