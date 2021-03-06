﻿
namespace Sturnus.Wpf.DynamicContentControl.Demo.ViewModels
{
    public class SampleViewModel
    {
        #region Properties
        public string HelloWorld
        {
            get
            {
                return @"<TextBlock Text=""Hello World!"" />";
            }
        }

        public string Homer
        {
            get
            {
                return @"<StackPanel HorizontalAlignment=""Left"">
                             <TextBlock Text=""D'oh!!!"" />
                             <Image gif:ImageBehavior.AnimatedSource=""Images/homer.gif"" gif:ImageBehavior.AnimateInDesignMode=""True"" Width=""250"" Height=""250"" />
                         </StackPanel>";
            }
        }
        #endregion
    }
}
