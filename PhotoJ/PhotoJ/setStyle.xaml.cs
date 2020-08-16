using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using TARY_Library_Silverlight;
using TARY_Library_Silverlight.Photo;
using TARY_Library_Silverlight.Popup;
using System.Windows.Threading;

using System.Windows.Media.Imaging;


namespace PhotoJ
{
    public partial class setStyle : PhoneApplicationPage
    {

        PhotoBoard Board;
        StackPanel Bar = new StackPanel();

        Button btnOk = new Button();
        DispatcherTimer dt;
        

        maskList ImgList = new maskList(); 


        public setStyle()
        {








            InitializeComponent();


            //將背景樣式 加入至bglist中
            for (int i = 0; i < ImgList.List().Count; i++)
            {
                ImgList.List()[i].MouseLeftButtonUp += new MouseButtonEventHandler(setStyle_MouseLeftButtonUp);
                bgList.Children.Add(ImgList.List()[i]);
            }



            Board  = new PhotoBoard(this);
            Board.Margin = new Thickness(0, 80, 0, 0);
            PHOTO.Children.Add(Board);






            Bar.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            PHOTO.Children.Add(Bar);







            btnOk = new Button();
            btnOk.Content = "確定";
            btnOk.Width = 150;
            btnOk.FontSize = 32;
            btnOk.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            btnOk.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            btnOk.Click += new RoutedEventHandler(btnOk_Click);
            btnOk.BorderBrush = myStyle.ButtonColor;
            btnOk.Foreground = myStyle.ButtonColor;
            PHOTO.Children.Add(btnOk);



            PHOTO.Children.Remove(bgView);
            PHOTO.Children.Add(bgView);

        }
        void setStyle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mask bgObj = sender as mask;

            if (bgObj.SORT == 0)
            {
                Board.ChangeBgNum = Convert.ToInt32(bgObj.BG);
            }
            else
            {
                BitmapImage IMG = new BitmapImage();
                IMG.UriSource = new Uri(bgObj.BG,UriKind.RelativeOrAbsolute);

                Board.ChgBg3(IMG);
            }

        }

        void btnOk_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Board.Source = this.Board.Source;

            this.NavigationService.GoBack();
        }








        private void PHOTO_Loaded(object sender, RoutedEventArgs e)
        {
            Board.Source = MainPage.Board.Source;
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                Board.Margin = new Thickness(0, 80, 0, 0);
                bgView.Width = 480;
            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                Board.Margin = new Thickness(0, 0, 0, 0);
                bgView.Width = 800;
            }




            //ScrollViewer temp = bgView;
            PHOTO.Children.Remove(bgView);
            PHOTO.Children.Add(bgView);
        }
    }
}