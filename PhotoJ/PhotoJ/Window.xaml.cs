using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using TARY_Library_Silverlight;
using System.Windows.Media;
namespace PhotoJ
{

    public partial class Window : PhoneApplicationPage
    {

        BitmapImage Bimg;


        ButtonColor BG, BORDER;
        ButtonList CTYPE2;
        public static PhotoViewer OBJ;
        imgList ImgList = new imgList(); 


        public Window()
        {
            InitializeComponent();

            //將背景樣式 加入至bglist中
            for (int i = 0; i < ImgList.List().Count; i++)
            {
                ImgList.List()[i].MouseLeftButtonUp += new MouseButtonEventHandler(Window_MouseLeftButtonUp);
                bgList.Children.Add(ImgList.List()[i]);
            }



            Init();






            OK.BorderBrush = myStyle.ButtonColor;
            OK.Foreground = myStyle.ButtonColor;
        }

        void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            bgImg bgObj = sender as bgImg;

            ImageBrush B = new ImageBrush();
            B.ImageSource = bgObj.Bimg;
            B.Stretch = Stretch.UniformToFill;

            if (bgObj.CNAME == "background/null.png")
                OBJ.PHOTOS.Background = null;
            else
                OBJ.PHOTOS.Background = B;
        }


        public void Init()
        {



            this.LayoutRoot.Children.Add(OBJ);

            BG = new ButtonColor(this,Color.FromArgb(255, 195, 195, 195));
            BG.BorderBrush = myStyle.ButtonColor;
            BG.Foreground = myStyle.ButtonColor;
            BG.Width = 150;
            BG.Loaded += new RoutedEventHandler(update_Loaded);

            BORDER = new ButtonColor(this, Color.FromArgb(255, 255, 255, 255));
            BORDER.BorderBrush = myStyle.ButtonColor;
            BORDER.Foreground = myStyle.ButtonColor;
            BORDER.Width = 100;
            BORDER.Loaded += new RoutedEventHandler(update_Loaded);





            string[] strTYPE2 = new string[] { "無陰影", "輕微", "微右下", "微左下", "明顯", "偏右下", "偏左下" };

            CTYPE2 = new ButtonList(this, strTYPE2, 1);
            CTYPE2.Width = 140;
            CTYPE2.Height = 80;
            CTYPE2.Loaded  += new RoutedEventHandler(update_Loaded);
            CTYPE2.BorderBrush = myStyle.ButtonColor;
            CTYPE2.Foreground = myStyle.ButtonColor;




            TOOL.Children.Add(CTYPE2);
            TOOL.Children.Add(BORDER);
            TOOL.Children.Add(BG);
            
            
            updatePhoto();
        }












        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Bimg = new BitmapImage(new Uri("image/a1.jpg",UriKind.RelativeOrAbsolute));
            image1.Source = Bimg;



            var photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += PhotoChooserTaskCompleted;
            photoChooserTask.Show();

        }

        void updatePhoto(){


            OBJ.BorderThickness = CTYPE2.Index;

            OBJ.VIEW.Background = new SolidColorBrush(BORDER.Index);
            OBJ.BorderBush = new SolidColorBrush(BG.Index);
        }






        private void update_Loaded(object sender, RoutedEventArgs e)
        {
            updatePhoto();
        }


        void PhotoChooserTaskCompleted(object sender, PhotoResult e)
        {

            switch (e.TaskResult)
            {
                case TaskResult.OK:
                    Bimg = new BitmapImage(new Uri(e.OriginalFileName));






                    image1.Source = Bimg;
                    break;
            }



        }


        private void image1_ImageOpened(object sender, RoutedEventArgs e)
        {

            //tUpdate = true;//back的時候 就更新


            /* 無須縮小
            if (Bimg.PixelWidth >= 1000 || Bimg.PixelHeight >= 1000)
            {

                Point P = TARY_Library_Silverlight.Photo.PhotoEdit.BestSize2(Bimg, 1000, 1000);

                Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.Size(Bimg, (int)P.X, (int)P.Y);
            }*/



            MyOBJ myPhoto = new MyOBJ(0, Bimg, Bimg.PixelWidth,  Bimg.PixelHeight);
            myPhoto.Hold += myPhoto_Hold;
            //PV2.PHOTO.Children.Add(myPhoto);


            //image1.Width = W;
            //image1.Height = H;


        }
        private void myPhoto_Hold(object sender, GestureEventArgs e)
        {

            //刪除物件
            MyOBJ A = sender as MyOBJ;
            //PV2.PHOTO.Children.Remove(A);
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {

              //  G_PHOTO.Width = 480;
               // G_PHOTO.Height = 360;
                bgView.Width = 340;
                bgView.Margin = new Thickness(0,0,0,0);
                TOOL.SetValue(Grid.RowProperty, 0);

            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                //G_PHOTO.Width = 480;
               // G_PHOTO.Height = 360;
                bgView.Width = 290;
                bgView.Margin = new Thickness(380, 0, 0, 0);
                TOOL.SetValue(Grid.RowProperty, 1);
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {







            if(OBJ.PhotoKey=="S0C"){
                //螢幕手機背景製作
                WriteableBitmap SaveImage = new WriteableBitmap((int)(OBJ.Width), (int)(OBJ.Height));
                SaveImage.Render(OBJ, null);
                SaveImage.Invalidate();
                BitmapImage tempBimg = TARY_Library_Silverlight.Photo.PhotoEdit.SaveBitmap(SaveImage, 100);
                MainPage.Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.Size(tempBimg, (int)(tempBimg.PixelWidth * 1.25), (int)(tempBimg.PixelHeight * 1.25));
                NavigationService.Navigate(new Uri("/makephoto.xaml", UriKind.Relative));



            }else{


                 WriteableBitmap SaveImage = new WriteableBitmap((int)(OBJ.Width), (int)(OBJ.Height));
                 SaveImage.Render(OBJ, null);
                 SaveImage.Invalidate();
                 BitmapImage tempBimg = TARY_Library_Silverlight.Photo.PhotoEdit.SaveBitmap(SaveImage, 100);

                 MainPage.Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.Size(tempBimg, (int)(tempBimg.PixelWidth * 1.5), (int)(tempBimg.PixelHeight * 1.5));
                 NavigationService.Navigate(new Uri("/makephoto.xaml", UriKind.Relative));
            }







        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {

            if (MainPage.ClosePhoto)
            {
                NavigationService.GoBack();

                return;
            }


            if (OBJ.PhotoKey == "P")
            {
                this.SupportedOrientations = SupportedPageOrientation.Portrait;
            }
            else if (OBJ.PhotoKey == "L")
            {
                this.SupportedOrientations = SupportedPageOrientation.Landscape;
            }
            else
            {

                if (OBJ.PhotoKeyS == "P")
                {
                    this.SupportedOrientations = SupportedPageOrientation.Portrait;
                }
                else
                {
                    this.SupportedOrientations = SupportedPageOrientation.Landscape;
                }
            }

        }






        private void testbtn_Click(object sender, RoutedEventArgs e)
        {

        }



    }
}