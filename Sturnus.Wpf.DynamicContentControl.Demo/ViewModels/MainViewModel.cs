using System;
using System.Windows.Threading;

namespace Sturnus.Wpf.DynamicContentControl.Demo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Constructor
        public MainViewModel()
        {
            // Start a timer to update the DateAndTime property every second
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => { RaisePropertyChanged("DateAndTime"); };
            timer.Start();
        }
        #endregion

        #region Properties
        public string HelloWorld
        {
            get 
            {
                return @"<TextBlock Text=""Hello World!"" />";
            }
        }

        public string DateAndTime
        {
            get
            {
                return string.Format(@"<TextBlock Text=""{0}"" />", DateTime.Now);
            }
        }

        public string Maxtrix
        {
            get 
            {
                return @"<Grid>
                            <Grid.Resources>
                                <x:Array x:Key=""xamlNamespacesMatrix"" Type=""sys:String"">
                                    <sys:String>xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""</sys:String>
                                    <sys:String>xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""</sys:String>
                                    <sys:String>xmlns:gif=""http://wpfanimatedgif.codeplex.com;assembly=WpfAnimatedGif""</sys:String>
                                </x:Array>
                            </Grid.Resources>
                            <sturnus:DynamicContentControl XamlText=""{Binding MaxtrixImage}"" XamlNamespaces=""{StaticResource xamlNamespacesMatrix}"" />
                         </Grid>";
            }
        }

        public string MaxtrixImage
        {
            get
            {
                return @"<Image gif:ImageBehavior.AnimatedSource=""{Binding MaxtrixImageSource}"" gif:ImageBehavior.AnimateInDesignMode=""True"" />";
            }
        }

        public string MaxtrixImageSource
        {
            get
            {
                return "Images/matrix.gif";
            }
        }
        #endregion
    }
}
