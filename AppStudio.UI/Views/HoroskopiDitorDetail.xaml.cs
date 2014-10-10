using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

using Microsoft.Phone.Controls;

using MyToolkit.Paging;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public partial class HoroskopiDitorDetail
    {
        private bool _isDeepLink = false;

        public HoroskopiDitorDetail()
        {
            InitializeComponent();
            this.Loaded += HoroskopiDitorDetail_Loaded;
        }

        private void HoroskopiDitorDetail_Loaded(object sender, RoutedEventArgs e)
        {
            SmaatoAd.Pub = 923882789;
            SmaatoAd.Adspace = 65846048;
            SmaatoAd.StartAds();
        }

        public HoroskopiDitorViewModel HoroskopiDitorModel { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HoroskopiDitorModel = NavigationServices.CurrentViewModel as HoroskopiDitorViewModel;
            if (e.NavigationMode == NavigationMode.New && NavigationContext.QueryString.ContainsKey("id"))
            {
                string id = NavigationContext.QueryString["id"];
                if (!String.IsNullOrEmpty(id))
                {
                    _isDeepLink = true;
                    HoroskopiDitorModel = new HoroskopiDitorViewModel();
                    NavigationServices.CurrentViewModel = HoroskopiDitorModel;
                    HoroskopiDitorModel.LoadItem(id);
                }
            }
            if (HoroskopiDitorModel != null)
            {
                HoroskopiDitorModel.ViewType = ViewTypes.Detail;
            }
            DataContext = HoroskopiDitorModel;
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationServices.CurrentViewModel = null;
            }
            SpeechServices.Stop();
            base.OnNavigatedFrom(e);
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (_isDeepLink)
            {
                _isDeepLink = false;
                NavigationServices.NavigateToPage("MainPage");
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpeechServices.Stop();
        }
    }
}
