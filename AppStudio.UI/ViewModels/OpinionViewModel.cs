using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class OpinionViewModel : ViewModelBase<RssSchema>
    {
        override protected string CacheKey
        {
            get { return "OpinionDataSource"; }
        }

        override protected IDataSource<RssSchema> CreateDataSource()
        {
            return new OpinionDataSource(); // RssDataSource
        }

        override public bool IsGoToSourceVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void GoToSource()
        {
            base.GoToSource("{FeedUrl}");
        }

        override public bool IsRefreshVisible
        {
            get { return ViewType == ViewTypes.List; }
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("OpinionDetail");
        }
    }
}
