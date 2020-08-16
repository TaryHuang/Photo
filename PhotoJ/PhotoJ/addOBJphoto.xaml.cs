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

    public partial class addOBJphoto : PhoneApplicationPage
    {

        BitmapImage Bimg;


        ButtonList CTYPE, CTYPE2, SIZE;
        ButtonColor BG, BORDER;
        PhotoChooserTask photoChooserTask = new PhotoChooserTask();
        int tempHeight = 360;//暫存 使用標準照片 用

        //**********************************************
        //2013.06.07 
        bool VopenPhoto = false;// 初始化
        //**********************************************



        public addOBJphoto()
        {
            InitializeComponent();

            Init();




            OK.BorderBrush = myStyle.ButtonColor;
            OK.Foreground = myStyle.ButtonColor;

            photoChooserTask.Completed += PhotoChooserTaskCompleted;
        }


        public void Init()
        {


            string[] strTYPE = new string[] { "4 : 3", "16 : 9", "4:3(直)", "16:9(直)", "4:3(橫)", "16:9(橫)" };

            CTYPE = new ButtonList(this, strTYPE,0);
            CTYPE.BorderThickness = new Thickness(0, 0, 0, 0);
            CTYPE.Width = 140;
            CTYPE.Height = 80;
            CTYPE.Loaded += new RoutedEventHandler(updateType_Loaded);
            CTYPE.BorderBrush = myStyle.ButtonColor;
            CTYPE.Foreground = myStyle.ButtonColor;
            G_TYPE.Children.Add(CTYPE);





            string[] strTYPE2 = new string[] { "無陰影", "輕微", "微右下", "微左下", "明顯", "偏右下", "偏左下" };

            CTYPE2 = new ButtonList(this, strTYPE2, 1);
            //CTYPE2.BorderThickness = new Thickness(0, 0, 0, 0);
            CTYPE2.Width = 140;
            CTYPE2.Height = 80;
            CTYPE2.Loaded += new RoutedEventHandler(update_Loaded);
            CTYPE2.BorderBrush = myStyle.ButtonColor;
            CTYPE2.Foreground = myStyle.ButtonColor;


            BG = new ButtonColor(this, Color.FromArgb(255, 195, 195, 195));
            BG.BorderBrush = myStyle.ButtonColor;
            BG.Foreground = myStyle.ButtonColor;
            BG.Width = 150;
            BG.Loaded += new RoutedEventHandler(update_Loaded);
           
            BORDER = new ButtonColor(this, Color.FromArgb(255, 255, 255, 255));
            BORDER.BorderBrush = myStyle.ButtonColor;
            BORDER.Foreground = myStyle.ButtonColor;
            BORDER.Width = 100;
            BORDER.Loaded += new RoutedEventHandler(update_Loaded);

            string[] strSIZE = new string[] { "無邊框", "細框", "中框", "粗框", "四邊細框", "四邊中框", "四邊粗框", "2:1細框", "2:1中框", "2:1粗框", "上下細框", "上下中框", "上下粗框", "左右細框", "左右中框", "左右粗框" };

            SIZE = new ButtonList(this,strSIZE,2);
            SIZE.Loaded += new RoutedEventHandler(update_Loaded);
            SIZE.BorderBrush = myStyle.ButtonColor;
            SIZE.Foreground = myStyle.ButtonColor;

            TOOL.Children.Add(SIZE);
            TOOL.Children.Add(CTYPE2);
            TOOL.Children.Add(BORDER);
            TOOL.Children.Add(BG);
            
            
            updatePhoto();
        }













        void updatePhoto(){
            int num = 0;
            switch (SIZE.Index)
            {
                case 0: num = 0; break;
                case 1: num = 6; break;
                case 2: num = 10; break;
                case 3: num = 20; break;
                case 4: num = 6; break;
                case 5: num = 10; break;
                case 6: num = 20; break;
                case 7: num = 12; break;
                case 8: num = 20; break;
                case 9: num = 26; break;
                case 10: num = 6; break;
                case 11: num = 10; break;
                case 12: num = 20; break;
                case 13: num = 6; break;
                case 14: num = 10; break;
                case 15: num = 20; break;
            }


            if (SIZE.Index == 1 || SIZE.Index == 2 || SIZE.Index == 3)
            {
                G_PHOTO.BorderThickness = new Thickness(num, num, num, (num*4));
            }else
            if(SIZE.Index==4 || SIZE.Index==5 ||SIZE.Index==6){
                G_PHOTO.BorderThickness = new Thickness(num, num, num, num);
            }
            else if (SIZE.Index == 7 || SIZE.Index == 8 || SIZE.Index == 9)
            {
                G_PHOTO.BorderThickness = new Thickness(num, num / 2, num, num / 2);
            }
            else if (SIZE.Index == 10 || SIZE.Index == 11 || SIZE.Index == 12)
            {
                G_PHOTO.BorderThickness = new Thickness(0, num, 0, num);
            }
            else if (SIZE.Index == 13 || SIZE.Index == 14 || SIZE.Index == 15)
            {
                G_PHOTO.BorderThickness = new Thickness(num, 0, num,0);
            }
            else
            {
                G_PHOTO.BorderThickness = new Thickness(0, 0, 0, 0);
            }




            //影子
            if(CTYPE2.Index==1){
                S_PHOTO.BorderThickness =new Thickness(1,1,1,1);
            }
            else if (CTYPE2.Index == 2)
            {
                S_PHOTO.BorderThickness = new Thickness(1, 1, 4, 4);

            }
            else if (CTYPE2.Index == 3)
            {

                S_PHOTO.BorderThickness = new Thickness(4, 1, 1, 4);
            }

            else if (CTYPE2.Index == 4)
            {
                S_PHOTO.BorderThickness = new Thickness(2, 2, 2, 2);

            }

            else if (CTYPE2.Index == 5)
            {

                S_PHOTO.BorderThickness = new Thickness(2, 2, 5, 5);
            }

            else if (CTYPE2.Index == 6)
            {
                S_PHOTO.BorderThickness = new Thickness(5, 2, 2, 5);

            }
            else
            {
                S_PHOTO.BorderThickness =new Thickness(0,0,0,0);
            }










            G_PHOTO.Background = new SolidColorBrush(BG.Index);
            G_PHOTO.BorderBrush = new SolidColorBrush(BORDER.Index);
        }


        private void updateType_Loaded(object sender, RoutedEventArgs e)
        {


            if (CTYPE.Index == 4)
            {
                //4:3
                G_PHOTO.Width = 533;
                S_PHOTO.Width = 533;
                G_PHOTO.Height = 400;
                S_PHOTO.Height = 400;
                this.SetValue(SupportedOrientationsProperty, SupportedPageOrientation.Landscape);


            }
            else if(CTYPE.Index ==5)
            {
                //16:9
                G_PHOTO.Width = 640;
                S_PHOTO.Width =640;
                G_PHOTO.Height = 360;
                S_PHOTO.Height = 360;
                this.SetValue(SupportedOrientationsProperty, SupportedPageOrientation.Landscape);

            }
            else if (CTYPE.Index == 3)
            {
                

                //16:9
                G_PHOTO.Width = 320;
                S_PHOTO.Width = 320;
                G_PHOTO.Height = 568;
                S_PHOTO.Height = 568;
                this.SetValue(SupportedOrientationsProperty, SupportedPageOrientation.Portrait);

            }
            else if (CTYPE.Index == 2)
            {
                //4:3
                G_PHOTO.Width = 420;
                S_PHOTO.Width = 420;
                G_PHOTO.Height = 560;
                S_PHOTO.Height = 560;

                this.SetValue(SupportedOrientationsProperty, SupportedPageOrientation.Portrait);
            }
            else if (CTYPE.Index == 1)
            {
                //4:3
                G_PHOTO.Width = 480;
                S_PHOTO.Width = 480;
                G_PHOTO.Height = 270;
                S_PHOTO.Height = 270;

                this.SetValue(SupportedOrientationsProperty, SupportedPageOrientation.PortraitOrLandscape);
            }

            else if (CTYPE.Index == 0)
            {
                //4:3
                G_PHOTO.Width = 480;
                S_PHOTO.Width = 480;
                G_PHOTO.Height = 360;
                S_PHOTO.Height = 360;

                this.SetValue(SupportedOrientationsProperty, SupportedPageOrientation.PortraitOrLandscape);
            }



            
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

                //**********************************************
                //2013.06.07  為了修改 連續按兩下執行PhotoChooserTaskCompleted 使app跳出程式
                default:
                    BitmapImage bbb = new BitmapImage(new Uri("/PhotoJ;component/Images/BG1.png"));
                    image2.Source = bbb; break;
                //**********************************************
            }



        }


        private void image1_ImageOpened(object sender, RoutedEventArgs e)
        {

            //tUpdate = true;//back的時候 就更新



            if (Bimg.PixelWidth >= 1000 || Bimg.PixelHeight >= 1000)
            {

                Point P = TARY_Library_Silverlight.Photo.PhotoEdit.BestSize2(Bimg, 1000, 1000);

                Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.Size(Bimg, (int)P.X, (int)P.Y);
            }



            MyOBJ myPhoto = new MyOBJ(0, Bimg, Bimg.PixelWidth,  Bimg.PixelHeight);
            myPhoto.Hold += myPhoto_Hold;
            myPhoto.V = (int)((myPhoto.V_MinBAN) / 2);

            PHOTO.Children.Add(myPhoto);


            //image1.Width = W;
            //image1.Height = H;


        }
        private void myPhoto_Hold(object sender, GestureEventArgs e)
        {

            //刪除物件
            MyOBJ A = sender as MyOBJ;
            PHOTO.Children.Remove(A);

        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {

              //  G_PHOTO.Width = 480;
               // G_PHOTO.Height = 360;


                TOOL.SetValue(Grid.RowProperty, 0);

            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                //G_PHOTO.Width = 480;
               // G_PHOTO.Height = 360;
                TOOL.SetValue(Grid.RowProperty, 1);
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {





            WriteableBitmap SaveImage = new WriteableBitmap((int)S_PHOTO.Width, (int)S_PHOTO.Height);


            S_PHOTO.Background = new SolidColorBrush(Colors.White);
            SaveImage.Render(S_PHOTO, null);
            SaveImage.Invalidate();


            Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.SaveBitmap(SaveImage, 100);






            //------------------------------------
            makephoto.BufferObjPhoto = Bimg;
            NavigationService.GoBack();
        }

        private void btnOpen_Click(object sender, MouseButtonEventArgs e)
        {

            if(PHOTO.Children.Count !=0){

                return;
            }

            if (!VopenPhoto)
            {
                VopenPhoto = true;
                photoChooserTask.Show();
            }
        }

        private void PhoneApplicationPage_LayoutUpdated(object sender, EventArgs e)
        {
            VopenPhoto = false;
        }



    }
}