using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
namespace TARY_Library_Silverlight
{
    public static class CallPage
    {
        
        public static void CallTaryPage(PhoneApplicationPage Page){

            TaryPage.updateURI = new Uri("http://storage.live.com/items/624F7A1CF19E16DF!183");//關於作者
            Page.NavigationService.Navigate(new Uri("/TARY_Library_Silverlight;component/TaryPage.xaml", UriKind.Relative));
        }

        public static void CallTaryPageTest(PhoneApplicationPage Page){

            TaryPage.updateURI = new Uri("http://storage.live.com/items/624F7A1CF19E16DF!209");//測試用 (TARYCENTER)
            Page.NavigationService.Navigate(new Uri("/TARY_Library_Silverlight;component/TaryPage.xaml", UriKind.Relative));
        }

        

    }
}
