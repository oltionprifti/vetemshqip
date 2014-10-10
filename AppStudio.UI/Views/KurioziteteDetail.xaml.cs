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
    public partial class KurioziteteDetail
    {
        private bool _isDeepLink = false;

        public KurioziteteDetail()
        {
            InitializeComponent();
            this.Loaded += KurioziteteDetail_Loaded;
        }

        private void KurioziteteDetail_Loaded(object sender, RoutedEventArgs e)
        {
            SmaatoAd.Pub = 923882789;
            SmaatoAd.Adspace = 65846048;
            SmaatoAd.StartAds();
        }

        public KurioziteteViewModel KurioziteteModel { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            KurioziteteModel = NavigationServices.CurrentViewModel as KurioziteteViewModel;
            if (e.NavigationMode == NavigationMode.New && NavigationContext.QueryString.ContainsKey("id"))
            {
                string id = NavigationContext.QueryString["id"];
                if (!String.IsNullOrEmpty(id))
                {
                    _isDeepLink = true;
                    KurioziteteModel = new KurioziteteViewModel();
                    NavigationServices.CurrentViewModel = KurioziteteModel;
                    KurioziteteModel.LoadItem(id);
                }
            }
            if (KurioziteteModel != null)
            {
                KurioziteteModel.ViewType = ViewTypes.Detail;
            }
            DataContext = KurioziteteModel;
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
