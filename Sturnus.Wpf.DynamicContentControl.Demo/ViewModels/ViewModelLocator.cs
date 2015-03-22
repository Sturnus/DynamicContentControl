
namespace Sturnus.Wpf.DynamicContentControl.Demo.ViewModels
{
    public class ViewModelLocator
    {
        #region Properties
        private MainViewModel _mainViewModel;
        public MainViewModel MainViewModel
        {
            get { return _mainViewModel ?? (_mainViewModel = new MainViewModel()); }
        }
        #endregion
    }
}
