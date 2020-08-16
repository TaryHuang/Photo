using Microsoft.Phone.Controls;

using System.Windows;

using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Navigation;

using Microsoft.Phone.Shell;

namespace TARY_Library_Silverlight.Photo
{
    public class PhotoBoard : Grid
    {
        public bool Vswitch = false;//是否已經讀取最原始圖檔 (準備做還原用)
        BitmapImage VSource = new BitmapImage();//最原始的
        BitmapImage TempSource = new BitmapImage();
        BitmapImage source = new BitmapImage();

        //四種不同顏色對換
        int changebgNum = 0;


        Image Img = new Image();

        Canvas Bg = new Canvas();

        bool maskSwitch;
        public Mask mask;

        //最佳螢幕比例解 以參考4:3 或 16:9比例
        double ScreenWidthP = 480, ScreenHeightP = 640;
        double ScreenWidthL = 640, ScreenHeightL = 480;

        PhoneApplicationPage Page;


        public double addX, addY;//邊界位移量

        bool CutSwitch = false;



        public PhotoBoard(PhoneApplicationPage PAGE)
        {
            this.Page = PAGE;
            Page.OrientationChanged +=Page_OrientationChanged;
            Init();
        }


        public PhotoBoard(PhoneApplicationPage PAGE,double W,double H)
        {
            this.Page = PAGE;
            Page.OrientationChanged += Page_OrientationChanged;
            Init();


            ScreenWidthP = W;
            ScreenHeightP = H;
            ScreenWidthL = H;
            ScreenHeightL = W;

        }


        private void Page_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            updateImgSize();
        }





        public void Init(){

            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Img.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Img.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Bg.Children.Add(Img);


            mask = new Mask(100,100);
            mask.ManipulationCompleted+=mask_ManipulationCompleted;
            MaskSwitch = false;


            Bg.Children.Add(mask);
            this.Children.Add(Bg);
            
        }




        void MastUpdateLoc()
        {
            if (mask.TformX  < 0)
            {
                mask.TformX = 0;


                if (mask.TformX + mask.myWidth> Img.Width)
                {
                    //SIZE太大了 故要將SIZE調整回來
                    mask.myWidth = Img.Width;
                }
            }
            else if (mask.TformX + mask.myWidth> Img.Width)
            {
                mask.TformX = Img.Width - mask.myWidth;

                if (mask.TformX < 0)
                {
                    //SIZE太大了 故要將SIZE調整回來
                    mask.myWidth = Img.Width;
                    mask.TformX = 0;
                }
            }




            if (mask.TformY < 0)
            {
                mask.TformY = 0;


                if (mask.TformY + mask.myHeight> Img.Height)
                {
                    //SIZE太大了 故要將SIZE調整回來
                    mask.myHeight = Img.Height;
                }
            }
            else if (mask.TformY + mask.myHeight > Img.Height)
            {
                mask.TformY = Img.Height - mask.myHeight;

                if (mask.TformY < 0)
                {
                    //SIZE太大了 故要將SIZE調整回來
                    mask.myHeight = Img.Height;
                    mask.TformY = 0;
                }
            }

        }


        private void mask_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

            MastUpdateLoc();
   
        }

        public BitmapImage Source{
            get
            {
                return source;
            }

            set
            {
                source = value;
                if (Vswitch==false)
                {
                    TempSource = value;//載入暫存檔 用於剪裁+顏色對換用
                    VSource = value;
                    Vswitch = true;
                }


                

                Img.Source = source;//指定給圖

                updateImgSize();
            }
        }



        public void Reload(){
            TempSource = VSource;
            Source = VSource;
            MaskSwitch = false;
            ChangeBgNum = 0;
            ValLight = 0;
        }


        public void Clear()
        {
            Vswitch = false;
            MaskSwitch = false;
            changebgNum = 0;
            valLight = 0;
        }


        void updateImgSize(){
            Point P;
            if (Page.Orientation == PageOrientation.PortraitDown || Page.Orientation == PageOrientation.PortraitUp)
            {
                P = PhotoEdit.BestSize(source, ScreenWidthP, ScreenHeightP);
            }else{
                P = PhotoEdit.BestSize(source, ScreenWidthL, ScreenHeightL);
            }


            addX = (ScreenWidth - P.X) >0 ? (ScreenWidth - P.X)/2 : 0;
            addY = (ScreenHeight - P.Y) > 0 ? (ScreenHeight - P.Y) / 2 : 0;


            Img.Margin = new Thickness(addX, addY,0,0);
            mask.addX = addX;
            mask.addY = addY;


            Img.Width = P.X;
            Img.Height = P.Y;

            if (CutSwitch)
            {
                mask.TformX = 0;
                mask.TformY = 0;
                mask.myWidth = Img.Width;
                mask.myHeight = Img.Height;
                CutSwitch = false;
            }
            else
            {
                mask.myWidth = 100;
                mask.myHeight = 100;
                mask.TformX = 10;
                mask.TformY = 10;

            }
        }


        public double ScreenWidth
        {
            get
            {
                if (Page.Orientation == PageOrientation.PortraitDown || Page.Orientation == PageOrientation.PortraitUp)
                {
                    return ScreenWidthP;

                }
                else
                {
                    return ScreenWidthL;
                }
            }
        }

        public double ScreenHeight
        {
            get
            {
                if (Page.Orientation == PageOrientation.PortraitDown || Page.Orientation == PageOrientation.PortraitUp)
                {
                    return ScreenHeightP;

                }
                else
                {
                    return ScreenHeightL;
                }
            }

        }

        public bool MaskSwitch
        {
            get
            {
                return maskSwitch;
            }

            set
            {
                maskSwitch = value;
                if (maskSwitch)
                {
                    mask.myWidth = 100;
                    mask.myHeight = 100;
                    mask.TformX = 10;
                    mask.TformY = 10;
                    mask.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    mask.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
        }







        int valLight = 0;


        public int ValLight
        {
            get
            {
                return valLight; 
            }
            set
            {

                valLight = value;
                Source = PhotoEdit.Light(TempSource, valLight);
                //TempSource = Source;
            }
        }



        public void Contrast(double ValR, double ValG, double ValB)
        {

            Source = PhotoEdit.Contrast(TempSource, ValR, ValG, ValB);

             //TempSource = source;
        }

        


        public void Rgb(int ValR, int ValG, int ValB)
        {

            Source = PhotoEdit.RGB(TempSource, ValR, ValG, ValB);

             //TempSource = source;
        }

        
        public void Turn()
        {
            CutSwitch = true;
            //旋轉



            Source = PhotoEdit.Turn(source, -90);//旋轉

            TempSource = source;
            updateTempSource();
        }



        void updateTempSource(){
            if(ValLight==0) return ;

            ValLight = valLight;
            
        }

        public int ChangeBgNum
        {
            get
            {
                return changebgNum;

            }

            set
            {
                changebgNum = value;


                switch (changebgNum)
                {
                    case 0: Source = TempSource; break;
                    case 1: Source = PhotoEdit.ChgBg2(TempSource, 0); break;
                    //case 1: Source = PhotoEdit.ttt(TempSource, 0); break;
                    case 2: Source = PhotoEdit.ChgBg2(TempSource, 1); break;
                    case 3: Source = PhotoEdit.ChgBg2(TempSource, 2); break;
                    case 4: Source = PhotoEdit.ChgBg2(TempSource, 3); break;
                    case 5: Source = PhotoEdit.ChgBg1(TempSource); break;
                    case 6: Source = PhotoEdit.AdjustTobBlur(TempSource,10); break;
                    case 7: Source = PhotoEdit.ConvertToInvert(TempSource); break;
                        
                    default: Source = TempSource; changebgNum = 0; break;
                }

                if (changebgNum != 0)
                {
                    valLight = 0;
                }
            }
        }
        
        public void ChangeBg()
        {
            CutSwitch = true;
            //色系兌換
            ChangeBgNum++;
        }







        public void Cut()
        {
            CutSwitch = true;

            MastUpdateLoc();//矯正座標





            //很難!! 解了快十二小時 才解出來= =+
            double D = source.PixelWidth / Img.Width; //先求出比例倍數
            double D2 = source.PixelHeight / Img.Height; //先求出比例倍數

            double X1 = mask.TformX * D;
            double X2 = mask.TformY * D2;
            double X3 = (Img.Width - (mask.TformX + mask.myWidth)) * D;
            double X4 = (Img.Height - (mask.TformY + mask.myHeight)) * D2;



            Source = PhotoEdit.Cut(source, (int)X1, (int)X2, (int)X3, (int)X4);

            TempSource = Source;
            //updateTempSource(); 待修正
        }


        public void ChgBg3(BitmapImage P)
        {

            Source = PhotoEdit.ChgBg3(TempSource, P);
        }

                        
    }
}
