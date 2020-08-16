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
    public partial class makephoto : PhoneApplicationPage
    {



        //圖畫版
        DrawBoard DrawBox = new DrawBoard(Colors.Red,5);
        ButtonColor DrawColor;
        ButtonList DrawFontSize;
        Button DrawBack;
        bool AppBarsave = false;
        ApplicationBarIconButton B1, B2, B3, B4;
        ApplicationBarMenuItem M1,C1,C2,C3,C4;//合併圖 啟動用
        PopupMessageForm MSG, MSG2;

        double StopV, StopH;

        static int ERInum = 0;
        
        public static MyOBJText BufferObjText;//暫存用


        ImageBrush BGbrush = new ImageBrush();
        WriteableBitmap SaveImage;

        public static double screenWidthL = 728;
        public static double screenHeightL = 410;

        public static double screenWidthP = 480;
        public static double screenHeightP = 658;


        double defX = 0;
        double defY = 0;
        double XXX, YYY;
        MyOBJ TEMP;


        bool drawIng = false;
        ButtonList ImageButton;



        PhotoChooserTask photoChooserTask = new PhotoChooserTask();

        //**********************************************
        //2013.06.07 
        bool VopenPhoto = false;// 初始化
        //**********************************************


        public makephoto()
        {
            InitializeComponent();




            C1 = (ApplicationBarMenuItem)ApplicationBar.MenuItems[0];
            C2 = (ApplicationBarMenuItem)ApplicationBar.MenuItems[1];
            C3 = (ApplicationBarMenuItem)ApplicationBar.MenuItems[2];
            C4 = (ApplicationBarMenuItem)ApplicationBar.MenuItems[3];
            ApplicationBar.MenuItems.Remove(C4);






            var VAR = from table in MainPage.tDBHandler.FastTable
                      orderby table.Title
                      select table;

            foreach(FastTable AAA in VAR){
                myButton BTN = new myButton(AAA.ID,AAA.CTYPE,AAA.Title);

                BTN.Click += new RoutedEventHandler(FastAddObj_Click);
                if(BTN.CTYPE==2){
                    BTN.WIDTH = AAA.Width;
                    BTN.HEIGHT = AAA.Height;
                }
                BTN.Foreground = myStyle.ButtonColor;
                BTN.BorderBrush = myStyle.ButtonColor;    


                MYTOOL.Children.Add(BTN);
            }

            


            //000000000000000000000000000000000
            string[] myLoveList = new string[] {  "表情符號","可愛圖片", "裝飾用品", "水果食物", "花草樹木", "生日派對", "標語節慶", "恐怖嚇人", "紋身造型", "花火煙霧" };
            ImageButton = new ButtonList(this, myLoveList, 0);
            ImageButton.Loaded += new RoutedEventHandler(ImageButton_Loaded);
            ImageButton.Foreground = myStyle.ButtonColor;
            ImageButton.BorderBrush = myStyle.ButtonColor;
            ImageButton.Click += new RoutedEventHandler(ImageButton_Click);
            G_Image.Children.Add(ImageButton);



            //----------------------
            Button Exit = new Button();
            Exit.Content = "離 開";
            Exit.Click += Exit_Click;
            Button CANCEL = new Button();
            CANCEL.Click+=CANCEL_Click;
            CANCEL.Content = "繼 續";
            MSG = new PopupMessageForm(this, "系統訊息", "您的相片已儲存！\n是否繼續編輯？", Exit, CANCEL);
            LayoutRoot.Children.Add(MSG);




            Button Exit2 = new Button();
            Exit2.Content = "確 定";
            Exit2.Click += Exit2_Click;
            Button CANCEL2 = new Button();
            CANCEL2.Content = "取 消";
            CANCEL2.Click += CANCEL_Click;
            MSG2 = new PopupMessageForm(this, "系統訊息", "您確定要離開相片編輯？", Exit2, CANCEL2);
            LayoutRoot.Children.Add(MSG2);
            //----------------------







            DrawColor = new ButtonColor(this, Colors.Red);
            DrawColor.Loaded+=DrawColor_Loaded;
            DrawColor.Foreground = myStyle.ButtonColor;
            DrawColor.BorderBrush = myStyle.ButtonColor;
 
            DrawColor.Width = 120;


            string[] F = new string[] { "72", "64", "56", "48", "32", "28", "24", "18", "12", "8", "4", "2" }; 
            DrawFontSize = new ButtonList(this,F,9);
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

            



            G_Draw.Children.Add(DrawFontSize);
            G_Draw.Children.Add(DrawColor);
            G_Draw.Children.Add(DrawBack);



            PHOTO3.Children.Add(DrawBox);



            ImageUpdate();

            photoMake(MainPage.Bimg);

            updateStyle();//修正按鈕顏色


            photoChooserTask.Completed += PhotoChooserTaskCompleted;
        }

        void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            VImagesBox.ScrollToHorizontalOffset(VImagesBox.HorizontalOffset);
        }

        void ImageUpdate(){

            

            objList OBJList = new objList();
            List<obj> tempBox = OBJList.List(ImageButton.Index);


            ImagesBox.Children.Clear();
            for (int i = 0; i < tempBox.Count; i++)
            {
                tempBox[i].MouseLeftButtonUp += new MouseButtonEventHandler(makephoto_MouseLeftButtonUp);
                ImagesBox.Children.Add(tempBox[i]);
            }



           

        }




        void updateStyle()
        {


            //繪圖
            pointSwitch.Foreground = myStyle.ButtonColor;
            pointSwitch.BorderBrush = myStyle.ButtonColor;



        }

        private void FastAddObj_Click(object sender, RoutedEventArgs e)
        {
            myButton btn = sender as myButton;



            if(btn.CTYPE == 0){
            //新增文字

                ObjTextTable DATA = (from table in MainPage.tDBHandler.ObjTextTable
                                   where btn.ERI == table.MASTERI
                                   select table).First();

                string[] C1 = DATA.COLOR.Split(','); 
                string[] C2 = DATA.COLOR2.Split(','); 
                MyOBJText addOBJ = new MyOBJText(ERInum, "文字",DATA.TEXT,Color.FromArgb(Convert.ToByte(C1[0]), Convert.ToByte(C1[1]), Convert.ToByte(C1[2]), Convert.ToByte(C1[3]))
                                                ,DATA.CTYPE,Color.FromArgb(Convert.ToByte(C2[0]), Convert.ToByte(C2[1]), Convert.ToByte(C2[2]), Convert.ToByte(C2[3]))
                                                ,DATA.CTYPE2);


                addOBJ.TformX = scrollPhoto.HorizontalOffset + 20;
                addOBJ.TformY = scrollPhoto.VerticalOffset + 20;

                addOBJ.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(addOBJText_ManipulationStarted);
                addOBJ.Hold += addOBJText_Hold;
                addOBJ.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(addOBJText_ManipulationCompleted);

                PHOTO.Children.Add(addOBJ);
            }
            else if (btn.CTYPE == 1)
            {

                ObjDateTable DATA = (from table in MainPage.tDBHandler.ObjDateTable
                                     where btn.ERI == table.MASTERI
                                     select table).First();


                CultureInfo TW = new CultureInfo("zh-TW");
                CultureInfo US = new CultureInfo("en-US");

                string strDate = "";
                DateTime DATE;
                if (DATA.DATETYPE == 1)
                    DATE = DATA.DATE;
                else
                    DATE = DateTime.Now.Date;



                //, , today, today, today, today.ToString("M", US), today.ToString("Y", US) };
                switch (DATA.FORMAT)
                {
                    case 0: strDate = DATE.ToString("yyyy/MM/dd"); break;
                    case 1: strDate = DATE.ToString("d"); break;
                    case 2: strDate = DATE.ToString("D", TW); break;
                    case 3: strDate = DATE.ToString("M", TW); break;
                    case 4: strDate = DATE.ToString("Y", TW); break;
                    case 5: strDate = DATE.ToString("D", US); break;
                    case 6: strDate = DATE.ToString("M", US); break;
                    case 7: strDate = DATE.ToString("Y", US); break;

                }





                string[] C1 = DATA.COLOR.Split(',');
                string[] C2 = DATA.COLOR2.Split(',');
                MyOBJText addOBJ = new MyOBJText(ERInum, "日期", strDate, Color.FromArgb(Convert.ToByte(C1[0]), Convert.ToByte(C1[1]), Convert.ToByte(C1[2]), Convert.ToByte(C1[3]))
                                                , DATA.CTYPE, Color.FromArgb(Convert.ToByte(C2[0]), Convert.ToByte(C2[1]), Convert.ToByte(C2[2]), Convert.ToByte(C2[3]))
                                                , DATA.CTYPE2);


                addOBJ.TformX = scrollPhoto.HorizontalOffset + 20;
                addOBJ.TformY = scrollPhoto.VerticalOffset + 20;

                addOBJ.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(addOBJText_ManipulationStarted);
                addOBJ.Hold += addOBJText_Hold;
                addOBJ.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(addOBJText_ManipulationCompleted);

                PHOTO.Children.Add(addOBJ);
            }else

                if (btn.CTYPE == 2)
                {
                    //照片


                    ObjPhotoTable[] DATA = (from table in MainPage.tDBHandler.ObjPhotoTable
                                            where btn.ERI == table.MASTERI
                                            orderby table.ORD
                                            select table).ToArray();

                    if(DATA.Count()==0){

                        BitmapImage tempBimg = new BitmapImage(new Uri("images/nullIMG.png", UriKind.RelativeOrAbsolute));
                        MyOBJ addOBJ2 = new MyOBJ(ERInum, tempBimg, 120, 120);

                        addOBJ2.TformX = scrollPhoto.HorizontalOffset + 20;
                        addOBJ2.TformY = scrollPhoto.VerticalOffset + 20;

                        addOBJ2.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(addOBJ_ManipulationStarted);
                        addOBJ2.Hold += addOBJ_Hold;
                        addOBJ2.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(addOBJ_ManipulationCompleted);

                        PHOTO.Children.Add(addOBJ2);

                        return;
                    }


                    WriteableBitmap bitmap;

                    List<byte> temp = new List<byte>();

                    for (int i = 0; i < DATA.Count(); i++)
                    {
                        temp.AddRange(DATA[i].Photo);
                    }




                        bitmap = new WriteableBitmap(btn.WIDTH, btn.HEIGHT);

                        int j = 0;
                        for (int i = 0; i < bitmap.Pixels.Count(); i++)
                        {
                            byte[] pixBytes = new byte[4];

                            pixBytes[0] = temp[j + 0];
                            pixBytes[1] = temp[j + 1];
                            pixBytes[2] = temp[j + 2];
                            pixBytes[3] = temp[j + 3];


                            bitmap.Pixels[i] = BitConverter.ToInt32(pixBytes, 0);
                            j += 4;
                        }


                        tempB = TARY_Library_Silverlight.Photo.PhotoEdit.SaveBitmap(bitmap, 100);



                        MyOBJ addOBJ = new MyOBJ(ERInum, tempB, btn.WIDTH, btn.HEIGHT);


                        addOBJ.TformX = scrollPhoto.HorizontalOffset + 20;
                        addOBJ.TformY = scrollPhoto.VerticalOffset + 20;

                        addOBJ.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(addOBJ_ManipulationStarted);
                        addOBJ.Hold += addOBJ_Hold;
                        addOBJ.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(addOBJ_ManipulationCompleted);

                        PHOTO.Children.Add(addOBJ);

                }





        }







        private void CANCEL_Click(object sender, RoutedEventArgs e)
        {
            MSG.Close();
        }
        private void CANCEL2_Click(object sender, RoutedEventArgs e)
        {
            MSG2.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //離開．．
            AppBarSave = false;
            MainPage.ClosePhoto = true;
            NavigationService.GoBack();
        }

        private void Exit2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        void photoMake(BitmapImage M){

            //載入圖片

            BGbrush.ImageSource = M;
            PHOTO.Background = BGbrush;
            PHOTO.Width = M.PixelWidth;
            PHOTO.Height = M.PixelHeight;
            SaveImage = new WriteableBitmap(M.PixelWidth, M.PixelHeight);

            setDef();
        }


        private void makephoto_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            obj B = sender as obj;


            MyOBJ addOBJ = new MyOBJ(ERInum, B.Bimg, B.myWidth, B.myHeight);


            addOBJ.TformX = scrollPhoto.HorizontalOffset+ 20;
            addOBJ.TformY = scrollPhoto.VerticalOffset + 20;

            addOBJ.ManipulationStarted +=new EventHandler<ManipulationStartedEventArgs>(addOBJ_ManipulationStarted);
            addOBJ.Hold+=addOBJ_Hold;
            addOBJ.ManipulationCompleted +=new EventHandler<ManipulationCompletedEventArgs>(addOBJ_ManipulationCompleted);

            PHOTO.Children.Add(addOBJ);
        }

        private void addOBJ_Hold(object sender, GestureEventArgs e)
        {

            //刪除物件
            MyOBJ A = sender as MyOBJ;
            PHOTO2.Children.Remove(A);
            PHOTO2.Background = null;
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
            DrawBox.Back();
        }




        public static MemoryStream Sendms;
        private void VIEW_Click(object sender, EventArgs e)
        {
            DrawIng = false;
            if(!AppBarSave){



                try
                {
                    SaveImage.Render(PHOTO, null);
                    SaveImage.Invalidate();

                    MemoryStream ms = new MemoryStream();
                    SaveImage.SaveJpeg(ms, SaveImage.PixelWidth, SaveImage.PixelHeight, 0, 100);
                    ms.Seek(0, SeekOrigin.Begin);
                    BitmapImage B = new BitmapImage();
                    B.SetSource(ms);
                    viewImage.Source = B;
                    ms.Dispose();








                    AppBarSave = true;
                    body.Visibility = System.Windows.Visibility.Collapsed;
                    ViewPhoto.Visibility = System.Windows.Visibility.Visible;
                }
                catch
                {

                }
            }else{
                //儲存檔案
                try
                {


                    SaveImage.Render(PHOTO, null);
                    SaveImage.Invalidate();

                    Sendms = new MemoryStream();
                    SaveImage.SaveJpeg(Sendms, SaveImage.PixelWidth, SaveImage.PixelHeight, 0, 100);
                    Sendms.Seek(0, SeekOrigin.Begin);


                    
                    MediaLibrary MLib = new MediaLibrary();
                    SaveImage.Render(PHOTO, null);
                    SaveImage.Invalidate();
                    MemoryStream ms = new MemoryStream();
                    SaveImage.SaveJpeg(ms, SaveImage.PixelWidth, SaveImage.PixelHeight, 0, 100);
                    ms.Seek(0, SeekOrigin.Begin);
                    MediaLibrary l = new MediaLibrary();
                    l.SavePicture("J_" + DateTime.Now.ToString("yyyyMMdd"), ms);
                    l.Dispose();
                    ms.Dispose();
                   



                    MSG.Show();

                }
                catch
                {
                    MessageBox.Show("很抱歉,儲存失敗!");
                }
            }
        }



        private void facebook_Click(object sender, EventArgs e)
        {



            SaveImage.Render(PHOTO, null);
            SaveImage.Invalidate();

            Sendms = new MemoryStream();
            SaveImage.SaveJpeg(Sendms, SaveImage.PixelWidth, SaveImage.PixelHeight, 0, 100);
            Sendms.Seek(0, SeekOrigin.Begin);


            NavigationService.Navigate(new Uri("/Pages/FacebookLoginPage.xaml", UriKind.Relative));
        }


        public bool AppBarSave
        {
            get{
                return AppBarsave;
            }
            set{
                AppBarsave = value;

                if (AppBarsave)
                {
                    
                    B1 = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                    B2 = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
                    B3 = (ApplicationBarIconButton)ApplicationBar.Buttons[2];
                    B4 = (ApplicationBarIconButton)ApplicationBar.Buttons[3];

                    ApplicationBar.Buttons.Clear();


                    ApplicationBar.Buttons.Add(B4);




                    ApplicationBar.MenuItems.Clear();
                    ApplicationBar.MenuItems.Add(C4);






                }
                else
                {
                    ApplicationBar.Buttons.Clear();
                    
                    ApplicationBar.Buttons.Add(B1);
                    ApplicationBar.Buttons.Add(B2);
                    ApplicationBar.Buttons.Add(B3);
                    ApplicationBar.Buttons.Add(B4);



                    ApplicationBar.MenuItems.Clear();

                    ApplicationBar.MenuItems.Add(C1);
                    ApplicationBar.MenuItems.Add(C2);
                    ApplicationBar.MenuItems.Add(C3);
                }
            }

        }



        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MSG.isShow || MSG2.isShow)
            {
                e.Cancel = true;
                return;
            }

            if (AppBarSave)
            {
                AppBarSave = false;
                body.Visibility = System.Windows.Visibility.Visible;

                ViewPhoto.Visibility = System.Windows.Visibility.Collapsed;
                e.Cancel = true;
            }
            else
            {
                MSG2.Show();
                e.Cancel = true;
            }
                            

        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {


            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {

                PHOTO3.Width = screenWidthP;
                PHOTO3.Height = screenHeightP;
                DrawBox.Width = screenWidthP;
                DrawBox.Height = screenHeightP;




                scrollPhoto.Width = screenWidthP;
                scrollPhoto.Height = screenHeightP;
                PHOTO2.Width = screenWidthP;
                PHOTO2.Height = screenHeightP;


                G_Tool.Width = screenWidthP;
                G_Draw.Width = screenWidthP;
                G_Image.Width = screenWidthP;

            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                PHOTO3.Width = screenWidthL;
                PHOTO3.Height = screenHeightL;
                DrawBox.Width = screenWidthL;
                DrawBox.Height = screenHeightL;

                scrollPhoto.Width = screenWidthL ;
                scrollPhoto.Height = screenHeightL;
                PHOTO2.Width = screenWidthL;
                PHOTO2.Height = screenHeightL;



                G_Tool.Width = screenWidthL;
                G_Draw.Width = screenWidthL;
                G_Image.Width = screenWidthL;
            }
            setDef();
        }





        private void Tool_Click(object sender, EventArgs e)
        {
            DrawIng = false;
            G_Tool.Visibility = System.Windows.Visibility.Visible;
            G_Image.Visibility = System.Windows.Visibility.Collapsed;
            G_Draw.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            DrawIng = false;
            G_Tool.Visibility = System.Windows.Visibility.Collapsed;
            G_Image.Visibility = System.Windows.Visibility.Collapsed;
            G_Draw.Visibility = System.Windows.Visibility.Visible;
        }

        private void Image_Click(object sender, EventArgs e)
        {
            DrawIng = false;
            G_Tool.Visibility = System.Windows.Visibility.Collapsed;
            G_Image.Visibility = System.Windows.Visibility.Visible;
            G_Draw.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void backDIV_Click(object sender, EventArgs e)
        {
            //重回合併圖
            DrawIng = false;
            PHOTO.Children.Clear();
            photoMake(MainPage.Bimg2);
        }


        private void DIV_Click(object sender, EventArgs e)
        {
            DrawIng = false;


            SaveImage.Render(PHOTO, null);
            SaveImage.Invalidate();


            MemoryStream ms = new MemoryStream();
            SaveImage.SaveJpeg(ms, SaveImage.PixelWidth, SaveImage.PixelHeight, 0, 100);
            ms.Seek(0, SeekOrigin.Begin);

            BitmapImage B = new BitmapImage();
            B.SetSource(ms);
            MainPage.Bimg2 = B;
            ms.Dispose();

            PHOTO.Children.Clear();
            photoMake(MainPage.Bimg2);




            //啟動重回合併圖 機制
            M1 = (ApplicationBarMenuItem)ApplicationBar.MenuItems[1];
            M1.IsEnabled = true;
        }

        private void replay_Click(object sender, EventArgs e)
        {
            //重頭開始
            DrawIng = false;
            PHOTO.Children.Clear();
            photoMake(MainPage.Bimg);
        }




        private void text_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/addOBJtext.xaml", UriKind.Relative));
        }


        MyOBJText TEMPtext;
        private void addOBJText_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {

            StopH = scrollPhoto.HorizontalOffset;
            StopV = scrollPhoto.VerticalOffset;


            scrollPhoto.ScrollToHorizontalOffset(StopH);
            scrollPhoto.ScrollToVerticalOffset(StopV);

            TEMPtext = sender as MyOBJText;
            TEMPtext.TformX -= StopH;
            TEMPtext.TformY -= StopV;


            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                XXX = (int)(TEMPtext.TformX / screenWidthP);
                YYY = (int)(TEMPtext.TformY / screenHeightP);
                TEMPtext.TformX = TEMPtext.TformX % screenWidthP;
                TEMPtext.TformY = TEMPtext.TformY % screenHeightP;
            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                XXX = (int)(TEMPtext.TformX / screenWidthL);
                YYY = (int)(TEMPtext.TformY / screenHeightL);
                TEMPtext.TformX = TEMPtext.TformX % screenWidthL;
                TEMPtext.TformY = TEMPtext.TformY % screenHeightL;
            }

            TEMPtext.TformX += defX;
            TEMPtext.TformY += defY;


            PHOTO.Children.Remove(TEMPtext);
            PHOTO2.Children.Add(TEMPtext);
            PHOTO2.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));


        }


        public static int ERI{
            get{
                ERInum++;
                return ERInum;
            } 
        }



        private void addOBJText_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {



            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                TEMPtext.TformX += XXX * screenWidthP;
                TEMPtext.TformY += YYY * screenHeightP;

            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                TEMPtext.TformX += XXX * screenWidthL;
                TEMPtext.TformY += YYY * screenHeightL;
            }


            TEMPtext.TformX += StopH;
            TEMPtext.TformY += StopV;

            TEMPtext.TformX -= defX;
            TEMPtext.TformY -= defY;
            //--------------------

            PHOTO2.Children.Clear();
            PHOTO.Children.Add(TEMPtext);
            PHOTO2.Background = null;




            scrollPhoto.ScrollToHorizontalOffset(scrollPhoto.HorizontalOffset);


        }



        private void addOBJText_Hold(object sender, GestureEventArgs e)
        {

            //刪除物件
            MyOBJText A = sender as MyOBJText;
            PHOTO2.Children.Remove(A);
            PHOTO2.Background = null;
        }

        private void date_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/addOBJdate.xaml", UriKind.Relative));
        }


        private void ImageButton_Loaded(object sender, RoutedEventArgs e)
        {

            
            ImageUpdate();
        }



        
        private void DrawColor_Loaded(object sender, RoutedEventArgs e)
        {
            //改變畫筆顏色
            
                    
            DrawBox.penColor = ((SolidColorBrush)(DrawColor.Background)).Color;
        }



         private void DrawFontSize_Loaded(object sender, RoutedEventArgs e)
         {
             switch (DrawFontSize.Index)
             { 
                 case 0: DrawBox.LineSize = 72; break;
                 case 1: DrawBox.LineSize = 64; break;
                 case 2: DrawBox.LineSize = 56; break;
                 case 3: DrawBox.LineSize = 48; break;
                 case 4: DrawBox.LineSize = 32; break;
                 case 5: DrawBox.LineSize = 28; break;
                 case 6: DrawBox.LineSize = 24; break;
                 case 7: DrawBox.LineSize = 18; break;
                 case 8: DrawBox.LineSize = 12; break;
                 case 9: DrawBox.LineSize = 8; break;
                 case 10: DrawBox.LineSize = 4; break;
                 case 11: DrawBox.LineSize = 2; break;
             }

         }





        public static BitmapImage BufferObjPhoto;//照片專用
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (BufferObjText!=null)
            {

                MyOBJText addOBJ = BufferObjText;


                addOBJ.TformX = scrollPhoto.HorizontalOffset + 20;
                addOBJ.TformY = scrollPhoto.VerticalOffset + 20;

                addOBJ.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(addOBJText_ManipulationStarted);
                addOBJ.Hold += addOBJText_Hold;
                addOBJ.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(addOBJText_ManipulationCompleted);

                PHOTO.Children.Add(addOBJ);

                BufferObjText = null;
            }



            if (BufferObjPhoto!=null)
            {

                MyOBJ addOBJ = new MyOBJ(ERInum, BufferObjPhoto, BufferObjPhoto.PixelWidth, BufferObjPhoto.PixelHeight);


                addOBJ.TformX = scrollPhoto.HorizontalOffset + 20;
                addOBJ.TformY = scrollPhoto.VerticalOffset + 20;

                addOBJ.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(addOBJ_ManipulationStarted);
                addOBJ.Hold += addOBJ_Hold;
                addOBJ.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(addOBJ_ManipulationCompleted);

                PHOTO.Children.Add(addOBJ);

                BufferObjPhoto = null;
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
                    DrawBox.penColor = ((SolidColorBrush)(DrawColor.Background)).Color;
                    

                    DrawBox.DrawT= true;
                    pointSwitch.Content = "停止";
                    DrawBack.IsEnabled = true;

                    PHOTO2.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                }
                else
                {
                    //MessageBox.Show(DrawBox.ink.Strokes.Count().ToString());

                    if (DrawBox.ink.Strokes.Count()> 0 )
                    {
                        
                        //取得原點值

                        double diffX=0;
                        double diffY=0;
                        
                        if(SaveImage.PixelWidth/screenWidth < 1){
                            diffX = (screenWidth - SaveImage.PixelWidth) / 2;
                        }

                        if (SaveImage.PixelHeight / screenHeight < 1)
                        {
                            diffY = (screenHeight - SaveImage.PixelHeight) / 2;
                        }


                        MyOBJdraw DrawObj = new MyOBJdraw(ERInum, DrawBox.ink.Strokes.ToArray(), scrollPhoto.HorizontalOffset, scrollPhoto.VerticalOffset, diffX, diffY, DrawBox.LineSize, DrawBox.penColor);

                        DrawObj.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(addOBJdraw_ManipulationStarted);
                        DrawObj.Hold += addOBJdraw_Hold;
                        DrawObj.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(addOBJdraw_ManipulationCompleted);

                        PHOTO.Children.Add(DrawObj);


                        DrawBox.Clear();
                    }

                    DrawBox.DrawT = false;
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

        private void myphoto_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/addOBJphoto.xaml", UriKind.Relative));
        }


        private void myImage_Click(object sender, RoutedEventArgs e)
        {
            if (!VopenPhoto)
            {
                VopenPhoto = true;

                photoChooserTask.Show();
            }
        }






        BitmapImage tempB;
        void PhotoChooserTaskCompleted(object sender, PhotoResult e)
        {

            switch (e.TaskResult)
            {
                case TaskResult.OK:
                    tempB = new BitmapImage(new Uri(e.OriginalFileName));

                   
                    IMG.Source = tempB;

                    break;
            }


            
        }

        private void IMG_ImageOpened_1(object sender, RoutedEventArgs e)
        {

            if (tempB.PixelWidth > 1000 || tempB.PixelHeight > 1000)
            {

                Point P = TARY_Library_Silverlight.Photo.PhotoEdit.BestSize2(tempB, 1000, 1000);

                tempB = TARY_Library_Silverlight.Photo.PhotoEdit.Size(tempB, (int)P.X, (int)P.Y);

            }




            MyOBJ addOBJ = new MyOBJ(ERInum, tempB, tempB.PixelWidth, tempB.PixelHeight);


            addOBJ.TformX = scrollPhoto.HorizontalOffset + 20;
            addOBJ.TformY = scrollPhoto.VerticalOffset + 20;

            addOBJ.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(addOBJ_ManipulationStarted);
            addOBJ.Hold += addOBJ_Hold;
            addOBJ.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(addOBJ_ManipulationCompleted);

            PHOTO.Children.Add(addOBJ);

        }

        private void PhoneApplicationPage_LayoutUpdated(object sender, EventArgs e)
        {
            VopenPhoto = false;
        }












    }
}