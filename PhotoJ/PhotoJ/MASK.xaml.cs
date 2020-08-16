using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using TARY_Library_Silverlight;
using TARY_Library_Silverlight.Popup;
namespace PhotoJ
{
    public partial class MASK : PhoneApplicationPage
    {



        //圖畫版
        DrawBoard DrawBox = new DrawBoard(Colors.Red,5);
        ButtonList DrawFontSize;
        Button DrawBack;

        List<DataXY> Data = new List<DataXY>();
        double StopV, StopH;

        static int ERInum = 0;
        
        public static MyOBJText BufferObjText;//暫存用
        public static BitmapImage Bimg;
        
        ImageBrush BGbrush = new ImageBrush();
        WriteableBitmap SaveImage;
        
        public static double screenWidthL = 800;
        public static double screenHeightL = 410;

        public static double screenWidthP = 480;
        public static double screenHeightP = 728;


        double defX = 0;
        double defY = 0;
        double XXX, YYY;
        MyOBJ TEMP;


        bool drawIng = false;


        Button btnOk = new Button();

        public MASK()
        {
            InitializeComponent();








            btnOk = new Button();
            btnOk.Content = "確定";
            btnOk.Width = 150;
            btnOk.FontSize = 32;
            btnOk.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            btnOk.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            btnOk.Click += new RoutedEventHandler(btnOk_Click);
            btnOk.BorderBrush = myStyle.ButtonColor;
            btnOk.Foreground = myStyle.ButtonColor;





            string[] F = new string[] {"30", "25", "20", "15", "10", "5","3" }; 
            DrawFontSize = new ButtonList(this,F,4);
            DrawFontSize.Foreground = myStyle.ButtonColor;
            DrawFontSize.BorderBrush = myStyle.ButtonColor;
            DrawFontSize.Loaded+=DrawFontSize_Loaded;


            DrawBack = new Button();
            DrawBack.Click +=DrawBack_Click;
            DrawBack.Margin = new Thickness(50, 0, 0, 0);
            DrawBack.Content = "返回";
            DrawBack.Foreground = myStyle.ButtonColor;
            DrawBack.BorderBrush = myStyle.ButtonColor;
            DrawBack.IsEnabled = false;





            btnOk = new Button();
            btnOk.Content = "確定";
            btnOk.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            btnOk.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            btnOk.Click += new RoutedEventHandler(btnOk_Click);
            btnOk.BorderBrush = myStyle.ButtonColor;
            btnOk.Foreground = myStyle.ButtonColor;




            G_Draw.Children.Add(DrawFontSize);
           
            G_Draw.Children.Add(DrawBack);
            G_Draw.Children.Add(btnOk);


            DataXY R = new DataXY(MainPage.Bimg);
            Data.Add(R);
            
                
                
            Bimg = MainPage.Bimg;
            photoMake(Bimg);

            updateStyle();//修正按鈕顏色


        }


        void btnOk_Click(object sender, RoutedEventArgs e)
        {
             MainPage.Board.Source = Bimg;
             this.NavigationService.GoBack();            
        }




        void photoMake(BitmapImage M)
        {

            //載入圖片

            BGbrush.ImageSource = M;
            PHOTO.Background = BGbrush;
            PHOTO.Width = M.PixelWidth;
            PHOTO.Height = M.PixelHeight;
            SaveImage = new WriteableBitmap(M.PixelWidth, M.PixelHeight);

            setDef();
        }

        void photoMakeUpdate(BitmapImage M)
        {

            //載入圖片

            BGbrush.ImageSource = M;
            PHOTO.Background = BGbrush;
        }




        void updateStyle()
        {


            //繪圖
            pointSwitch.Foreground = myStyle.ButtonColor;
            pointSwitch.BorderBrush = myStyle.ButtonColor;

        }
















        public void setDef(){
                    //代表因為圖片至中  顧需要圖片與邊界的距離

            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                defX = (screenWidthP - PHOTO.Width) / 2;
                defY = (screenHeightP - PHOTO.Height) / 2;

                if (defX < 0) defX = 0;
                if (defY < 0) defY = 0;
            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                defX = (screenWidthL - PHOTO.Width) / 2;
                defY = (screenHeightL - PHOTO.Height) / 2;

                if (defX < 0) defX = 0;
                if (defY < 0) defY = 0;
            }
        }

        private void addOBJ_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            
            StopH = scrollPhoto.HorizontalOffset;
            StopV = scrollPhoto.VerticalOffset;


            scrollPhoto.ScrollToHorizontalOffset(StopH);
            scrollPhoto.ScrollToVerticalOffset(StopV);

            TEMP = sender as MyOBJ;
            TEMP.TformX -= StopH;
            TEMP.TformY -= StopV;


            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                XXX = (int)(TEMP.TformX / screenWidthP);
                YYY = (int)(TEMP.TformY / screenHeightP);
                TEMP.TformX = TEMP.TformX % screenWidthP;
                TEMP.TformY = TEMP.TformY % screenHeightP;
            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                XXX = (int)(TEMP.TformX / screenWidthL);
                YYY = (int)(TEMP.TformY / screenHeightL);
                TEMP.TformX = TEMP.TformX % screenWidthL;
                TEMP.TformY = TEMP.TformY % screenHeightL;
            }

            TEMP.TformX += defX;
            TEMP.TformY += defY;


            PHOTO.Children.Remove(TEMP);
            PHOTO2.Children.Add(TEMP);
            PHOTO2.Background = new SolidColorBrush(Color.FromArgb(0,0,0,0));


        }

        private void addOBJ_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {



            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                TEMP.TformX += XXX * screenWidthP;
                TEMP.TformY += YYY * screenHeightP;

            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                TEMP.TformX += XXX * screenWidthL;
                TEMP.TformY += YYY * screenHeightL;
            }


            TEMP.TformX += StopH;
            TEMP.TformY += StopV;

            TEMP.TformX -= defX;
            TEMP.TformY -= defY;
            //--------------------

            PHOTO2.Children.Clear();
            PHOTO.Children.Add(TEMP);
            PHOTO2.Background = null;




            scrollPhoto.ScrollToHorizontalOffset(scrollPhoto.HorizontalOffset);


        }


        
        private void DrawBack_Click(object sender, EventArgs e)
        {
            if (Data.Count == 1)
            {
                Bimg = Data[Data.Count - 1].Bimg;
                photoMake(Bimg);

            }
            else
            {
                Bimg = Data[Data.Count - 1].Bimg;
                photoMake(Bimg);
                Data.RemoveAt(Data.Count - 1);
            }
        }




        public static MemoryStream Sendms;









        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {


            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {


                DrawBox.Width = screenWidthP;
                DrawBox.Height = screenHeightP;




                scrollPhoto.Width = screenWidthP;
                scrollPhoto.Height = screenHeightP;
                PHOTO2.Width = screenWidthP;
                PHOTO2.Height = screenHeightP;


                G_Draw.Width = screenWidthP;
                G_Image.Width = screenWidthP;

            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {

                DrawBox.Width = screenWidthL;
                DrawBox.Height = screenHeightL;

                scrollPhoto.Width = screenWidthL ;
                scrollPhoto.Height = screenHeightL;
                PHOTO2.Width = screenWidthL;
                PHOTO2.Height = screenHeightL;


                G_Draw.Width = screenWidthL;
                G_Image.Width = screenWidthL;
            }
            setDef();
        }






        private void Draw_Click(object sender, EventArgs e)
        {
            DrawIng = false;
            G_Image.Visibility = System.Windows.Visibility.Collapsed;
            G_Draw.Visibility = System.Windows.Visibility.Visible;
        }







        public static int ERI{
            get{
                ERInum++;
                return ERInum;
            } 
        }





        int PointSize = 10;
         private void DrawFontSize_Loaded(object sender, RoutedEventArgs e)
         {

             if (DrawFontSize.Index != 6)
             {
                 PointSize = 30 - DrawFontSize.Index * 5;
             }
             else
             {
                 PointSize = 3;
             }
         }









        bool DrawIng
        {
            get
            {
                return drawIng; 
            }
            set
            {
                drawIng = value;


                scrollPhoto.ScrollToHorizontalOffset(scrollPhoto.HorizontalOffset);
                scrollPhoto.ScrollToVerticalOffset(scrollPhoto.VerticalOffset);




                
                if (drawIng)
                {
                    //DrawBox.penColor = ((SolidColorBrush)(DrawColor.Background)).Color;
                    

                    //DrawBox.DrawT= true;
                    pointSwitch.Content = "停止";
                    DrawBack.IsEnabled = true;

                    //scrollPhoto.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    //scrollPhoto.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
              
                    PHOTO2.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                }
                else
                {
                    //MessageBox.Show(DrawBox.ink.Strokes.Count().ToString());


                    //DrawBox.DrawT = false;
                    pointSwitch.Content = "開始";
                    DrawBack.IsEnabled = false;
                    PHOTO2.Background = null;
                }
            }
        }
















        private void pointSwitch_Click(object sender, RoutedEventArgs e)
        {

            DrawIng=!DrawIng;
        }












        public  double screenWidth
        {
            get
            {
                if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
                {
                    return screenWidthP;

                }
                else
                {
                    return screenWidthL;
                }
            }
        }


        public  double screenHeight
        {
            get
            {
                if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
                {
                    return screenHeightP;

                }
                else
                {
                    return screenHeightL;
                }
            }
        }
















        MyOBJdraw TEMPdraw;

        private void addOBJdraw_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {

            
            StopH = scrollPhoto.HorizontalOffset;
            StopV = scrollPhoto.VerticalOffset;


            scrollPhoto.ScrollToHorizontalOffset(StopH);
            scrollPhoto.ScrollToVerticalOffset(StopV);

            TEMPdraw = sender as MyOBJdraw;



            TEMPdraw.TformX -= StopH;
            TEMPdraw.TformY -= StopV ;


            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                XXX = (int)(TEMPdraw.TformX / screenWidthP);
                YYY = (int)(TEMPdraw.TformY / screenHeightP);
                TEMPdraw.TformX = TEMPdraw.TformX % screenWidthP;
                TEMPdraw.TformY = TEMPdraw.TformY % screenHeightP;
            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                XXX = (int)(TEMPdraw.TformX / screenWidthL);
                YYY = (int)(TEMPdraw.TformY / screenHeightL);
                TEMPdraw.TformX = TEMPdraw.TformX % screenWidthL;
                TEMPdraw.TformY = TEMPdraw.TformY % screenHeightL;
            }

            TEMPdraw.TformX += defX;
            TEMPdraw.TformY += defY;


            //TEMPdraw.TformX += TEMPdraw.diffScaleX;
            //TEMPdraw.TformY += TEMPdraw.diffScaleY;

            PHOTO.Children.Remove(TEMPdraw);
            PHOTO2.Children.Add(TEMPdraw);
            PHOTO2.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));


        }


        private void addOBJdraw_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {



            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                TEMPdraw.TformX += XXX * screenWidthP;
                TEMPdraw.TformY += YYY * screenHeightP;

            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                TEMPdraw.TformX += XXX * screenWidthL;
                TEMPdraw.TformY += YYY * screenHeightL;
            }


            TEMPdraw.TformX += StopH;
            TEMPdraw.TformY += StopV;

            TEMPdraw.TformX -= defX;
            TEMPdraw.TformY -= defY;



            //--------------------

            PHOTO2.Children.Clear();
            PHOTO.Children.Add(TEMPdraw);
            PHOTO2.Background = null;




            scrollPhoto.ScrollToHorizontalOffset(scrollPhoto.HorizontalOffset);


        }



        private void addOBJdraw_Hold(object sender, GestureEventArgs e)
        {

            //刪除物件
            MyOBJdraw A = sender as MyOBJdraw;
            PHOTO2.Children.Remove(A);
            PHOTO2.Background = null;
        }





        private void PHOTO2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawIng)
            {
                
                //Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.MASK(Bimg, (int)P.X, (int)P.Y, PointSize);
                //photoMake(Bimg);
            }
        }


        Point locS, locE;
        private void PHOTO2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            



            locS = e.GetPosition(this.PHOTO);
            DataXY R = new DataXY(Bimg);
            Data.Add(R);
        }

        private void PHOTO2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            locE = e.GetPosition(this.PHOTO);

            UpdateBimg();


        }





        void UpdateBimg()
        {
            try
            {
                Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.MASK(Bimg, (int)locS.X, (int)locS.Y, (int)locE.X, (int)locE.Y, PointSize);
               
            }
            catch
            {

            }
            photoMakeUpdate(Bimg);
           // MessageBox.Show("X:"+locS.X.ToString()+","+locS.Y.ToString());
        }




    










    }
    public class DataXY{
        List<Point> XY = new List<Point>();//存座標用
        public BitmapImage Bimg;

        public DataXY(BitmapImage bimg) {
            Bimg = bimg;
        }

    }



}