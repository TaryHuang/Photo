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


namespace PhotoJ
{
    public partial class setRgb : PhoneApplicationPage
    {

        PhotoBoard Board;

        Slider BarR, BarG, BarB;

        Button btnOk = new Button();
        DispatcherTimer dt;
        StackPanel Bar = new StackPanel();
        public setRgb()
        {
            InitializeComponent();
            Board  = new PhotoBoard(this);
            Board.Margin = new Thickness(0, 80, 0, 0);
            PHOTO.Children.Add(Board);



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

            BarR = new Slider();
            BarR.Value = 30;
            BarR.Maximum = 60;
            BarR.ValueChanged += new RoutedPropertyChangedEventHandler<double>(Bar_ValueChanged);
            Bar.Children.Add(BarR);


            BarG = new Slider();
            BarG.Value = 30;
            BarG.Maximum = 60;
            BarG.ValueChanged += new RoutedPropertyChangedEventHandler<double>(Bar_ValueChanged);
            Bar.Children.Add(BarG);

            BarB = new Slider();
            BarB.Value = 30;
            BarB.Maximum = 60;
            BarB.ValueChanged += new RoutedPropertyChangedEventHandler<double>(Bar_ValueChanged);
           
            Bar.Children.Add(BarB);
            Bar.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            PHOTO.Children.Add(Bar);
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(120);
            dt.Tick += new EventHandler(dt_Tick);
            dt.Stop();

            








        }

        void btnOk_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Board.Source = this.Board.Source;

            this.NavigationService.GoBack();
        }

        
        void dt_Tick(object sender, EventArgs e)
        {



            
            Board.Rgb(-1 * (int)(((int)(BarR.Value) * -1) + 30), -1 * (int)(((int)(BarG.Value) * -1) + 30), -1 * (int)(((int)(BarB.Value) * -1) + 30));



            
            dt.Stop();
        }



        void Bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dt.Stop();
            dt.Start();
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
            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                Board.Margin = new Thickness(0, 0, 0, 0);
            }
        }
    }
}