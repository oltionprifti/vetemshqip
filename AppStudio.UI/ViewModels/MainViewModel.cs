using System.Threading.Tasks;
using System.Windows.Input;

using AppStudio.Data;
using AppStudio.Services;


namespace AppStudio
{
    public class MainViewModels : BindableBase
    {
       private KategoriteViewModel _kategoriteModel;

        private ViewModelBase _selectedItem = null;
        private PrivacyViewModel _privacyModel;

        public MainViewModels()
        {
            _selectedItem = KategoriteModel;
            _privacyModel = new PrivacyViewModel();
        }
 
        public KategoriteViewModel KategoriteModel
        {
            get { return _kategoriteModel ?? (_kategoriteModel = new KategoriteViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            KategoriteModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public bool IsAppBarVisible
        {
            get
            {
                if (SelectedItem == null || SelectedItem == KategoriteModel)
                {
                    return true;
                }
                return SelectedItem != null ? SelectedItem.IsAppBarVisible : false;
            }
        }

        public bool IsLockScreenVisible
        {
            get { return SelectedItem == null || SelectedItem == KategoriteModel; }
        }

        public bool IsAboutVisible
        {
            get { return SelectedItem == null || SelectedItem == KategoriteModel; }
        }

        public bool IsPrivacyVisible
        {
            get { return SelectedItem == null || SelectedItem == KategoriteModel; }
        }


        public void UpdateAppBar()
        {
            OnPropertyChanged("IsAppBarVisible");
            OnPropertyChanged("IsLockScreenVisible");
            OnPropertyChanged("IsAboutVisible");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadData(bool isNetworkAvailable)
        {
            var loadTasks = new Task[]
            { 
                KategoriteModel.LoadItems(isNetworkAvailable),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }

        public ICommand LockScreenCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    LockScreenServices.SetLockScreen("/Assets/LockScreenImage.jpg");
                });
            }
        }
    }
}
