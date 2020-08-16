using Microsoft.Phone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using TARY_Library_Silverlight;
using TARY_Library_Silverlight.Photo;
using TARY_Library_Silverlight.Popup;
using System.Linq;
namespace PhotoJ
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 建構函式
        bool OpenFile = false;
        
        public static bool ClosePhoto = false;
        
        public static BitmapImage Bimg;//原始圖
        public static BitmapImage Bimg2;//暫存VIEW 用
        public static BitmapImage Bimg3;//暫存用
        ApplicationBarIconButton TEMP_CUT;
        public static PhotoBoard Board;

        CameraCaptureTask ccTask;
        PopupMessageForm MSG,MSG2;
        public static DBHandler tDBHandler = new DBHandler(DBHandler.DBConnection);

        public static SetupTable SetupDB;



        ButtonList ChgColorList, ChgLightList;
        PhotoChooserTask photoChooserTask = new PhotoChooserTask();
        int PhotoSize;
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public MainPage()
        {

            if (tDBHandler.DatabaseExists() == false)
            {

                tDBHandler.CreateDatabase();

                SetupTable AAA = new SetupTable();
                AAA.CTYPE = 5;
                tDBHandler.SetupTable.InsertOnSubmit(AAA);
                tDBHandler.SubmitChanges();

                

            }
            InitializeComponent();



             SetupDB = (from TABLE in tDBHandler.SetupTable
                                  select TABLE).First();

             







            //----------------------
            Button Exit = new Button();
            Exit.Content = "離 開";
            Exit.Click += Exit_Click;
            Button CANCEL = new Button();
            CANCEL.Click += Cancel_Click;
            CANCEL.Content = "繼 續";
            MSG = new PopupMessageForm(this,"系統訊息", "您的相片已儲存！\n是否繼續編輯？", Exit, CANCEL);
            LayoutRoot.Children.Add(MSG);
            //----------------------



            ccTask = new CameraCaptureTask();
            ccTask.Completed += ccTaskCompleted;



            
            Board = new PhotoBoard(this,480,730);


            //色系調整用@@@@@@@@@@@@@@
            string[] StrChgColorList = new string[] { "不調整", "風 格1", "風 格2", "風 格3", "風 格4", "黑白色系" };
            ChgColorList = new ButtonList(this, StrChgColorList, 0);
            //ChgColorList.Loaded+=new RoutedEventHandler(ChgColorList_Loaded);
            ChgColorList.Visibility = System.Windows.Visibility.Collapsed;
            PHOTO.Children.Add(ChgColorList);
            //@@@@@@@@@@@@@@色系調整用




            //亮度調整用@@@@@@@@@@@@@@
            string[] StrChgLightList = new string[] { "+20", "+19", "+18", "+17", "+16", "+15", "+14", "+13", "+12", "+11", "+10", "+9", "+8", "+7", "+6", "+5", "+4", "+3", "+2", "+1", "0", "-1", "-2", "-3", "-4", "-5", "-6", "-7", "-8", "-9", "-10", "-11", "-12", "-13", "-14", "-15", "-16", "-17", "-18", "-19", "-20" };
            ChgLightList = new ButtonList(this, StrChgLightList, 20);
            //ChgLightList.Loaded += new RoutedEventHandler(ChgLightList_Loaded);
            ChgLightList.Visibility = System.Windows.Visibility.Collapsed;
            PHOTO.Children.Add(ChgLightList);
            //@@@@@@@@@@@@@@亮度調整用





            PHOTO.Children.Add(Board);


           

            photoChooserTask.Completed += PhotoChooserTaskCompleted;
        }


        private void M_LIGHT_Click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/setLight.xaml", UriKind.Relative));



            //ChgLightList.Show();
        }


 



        private void author_Click(object sender, RoutedEventArgs e)
        {
            CallPage.CallTaryPage(this);

        }


        void PhotoChooserTaskCompleted(object sender, PhotoResult e)
        {

            switch (e.TaskResult)
            {
                case TaskResult.OK:
                    Bimg =  new BitmapImage(new Uri(e.OriginalFileName));
                    image1.Source= Bimg;
                    break;

                //**********************************************
                //2013.06.07  為了修改 連續按兩下執行PhotoChooserTaskCompleted 使app跳出程式
                default :
                    BitmapImage bbb = new BitmapImage(new Uri("/PhotoJ;component/Images/BG1.png"));
                    image2.Source= bbb;break;
                //**********************************************
            }



        }





        //**********************************************
        //2013.06.07 
        bool VopenPhoto = false;// 初始化
        //**********************************************



        private void openPhoto_Click(object sender, RoutedEventArgs e)
        {
            if (!VopenPhoto)
            {
                VopenPhoto = true;

                photoChooserTask.Show();
            }
        }

        private void image1_ImageOpened(object sender, RoutedEventArgs e)
        {

            updateBimg();


            
            Board.Clear();
            Board.Source = Bimg;
            OpenFile = true;
            OpenFileUpdate();
            ClosePhoto = false;
            
            
            TEMP_CUT = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
            TEMP_CUT.IsEnabled = false;         
        }


        public void OpenFileUpdate()
        {
            if (OpenFile)
            {
                PHOTO.Visibility = System.Windows.Visibility.Visible;
                MENU.Visibility = System.Windows.Visibility.Collapsed;
                ApplicationBar.IsVisible = true;
            }
            else
            {
                PHOTO.Visibility = System.Windows.Visibility.Collapsed;
                MENU.Visibility = System.Windows.Visibility.Visible;
                ApplicationBar.IsVisible = false;
               
            }
        }



        private void M_SAVE_Click(object sender, EventArgs e)
        {
            //直接儲存
            //儲存檔案
            try
            {



                MediaLibrary MLib = new MediaLibrary();
                WriteableBitmap SaveImage = new WriteableBitmap(Board.Source);


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

        private void M_EDIT_Click(object sender, EventArgs e)
        {
            //開始編輯照片
            Bimg = Board.Source;//將裁切或全景的照片回傳
            NavigationService.Navigate(new Uri("/makephoto.xaml", UriKind.Relative));
        }


        private void A_CTYPE_Click(object sender, EventArgs e)
        {
            Board.MaskSwitch = !Board.MaskSwitch;

            TEMP_CUT = (ApplicationBarIconButton)ApplicationBar.Buttons[1];


            if (Board.MaskSwitch)
            {
                //裁切模式
                TEMP_CUT.IsEnabled = true;
            }
            else
            {
                //全景模式
                TEMP_CUT.IsEnabled = false;
                Board.Reload();
                ChgColorList.Index = 0;
                ChgLightList.Index = 20;
            }
            
        }









        private void PhoneApplicationPage_BackKeyPress_1(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (!MSG.isShow && OpenFile)
            {
                OpenFile = false;
                OpenFileUpdate();
                ChgColorList.Index = 0;
                ChgLightList.Index = 20;
                e.Cancel = true;
            }


        }














        bool CameraOrientationP;
        private void btnCamera_Click(object sender, RoutedEventArgs e)
        {

            if (!VopenPhoto)
            {
                VopenPhoto = true;
                ccTask.Show();
            }
            

        }

        private void ccTaskCompleted(object sender, PhotoResult pr)
        {

            //判斷相機方向
            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp || this.Orientation == PageOrientation.Portrait)
            {
                CameraOrientationP = true;
            }
            else
            {
                CameraOrientationP = false;
            }



            byte[] imgLocal;
            if (pr.ChosenPhoto != null)
            {

                imgLocal = new byte[(int)pr.ChosenPhoto.Length];
                pr.ChosenPhoto.Read(imgLocal, 0, imgLocal.Length);
                pr.ChosenPhoto.Seek(0, System.IO.SeekOrigin.Begin);
                var SaveImage = PictureDecoder.DecodeJpeg(pr.ChosenPhoto);
                pr.ChosenPhoto.Dispose();





                Bimg = new BitmapImage();

                Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.SaveBitmap(SaveImage, 100);


                if (CameraOrientationP)
                {
                    Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.Turn(Bimg, -90);
                }




                updateBimg();
                Board.Clear();
                Board.Source = Bimg;
                OpenFile = true;
                OpenFileUpdate();
            }
            else
            {
                ClosePhoto = true;
            }
        }

        void updateBimg(){
            switch (MainPage.SetupDB.CTYPE)
            {
                case 0: PhotoSize = 10000; break;
                case 1: PhotoSize = 1920; break;
                case 2: PhotoSize = 1600; break;
                case 3: PhotoSize = 1366; break;
                case 4: PhotoSize = 1280; break;
                case 5: PhotoSize = 1024; break;
                case 6: PhotoSize = 800; break;
                case 7: PhotoSize = 600; break;
            }




            if (Bimg.PixelWidth > PhotoSize || Bimg.PixelHeight > PhotoSize)
            {

                Point P = TARY_Library_Silverlight.Photo.PhotoEdit.BestSize2(Bimg, PhotoSize, PhotoSize);

                Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.Size(Bimg, (int)P.X, (int)P.Y);

            }

        }






        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            //存檔離開．．
            MSG.CloseAppBarShow = false;
            OpenFile = false;
            OpenFileUpdate();
            ChgColorList.Index = 0;
        }



        public void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //開啟檔案後離開的
            MSG.Close();
        }




        private void A_CUT_Click(object sender, EventArgs e)
        {
            Board.Cut();
        }

        private void M_TURN_Click(object sender, EventArgs e)
        {
            Board.Turn();
        }

        private void A_CHGBK_Click(object sender, EventArgs e)
        {
            
        }





        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (ClosePhoto)
            {
                //MSG.CloseAppBaShow = false;
                OpenFile = false;
                OpenFileUpdate();
                ClosePhoto = false;
                ChgColorList.Index = 0;
            }
        }

        private void setupBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/setup.xaml", UriKind.Relative));
        }

        private void Fbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FAST.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                ImageBrush Brush = new ImageBrush();
                BitmapImage B=new BitmapImage(new Uri("Images/BG1.png",UriKind.RelativeOrAbsolute));

                Brush.ImageSource = B;

                MENU.Background = Brush;


                MENU1.Margin = new Thickness(180,300,0,0);
                MENU2.Margin = new Thickness(180, 550, 0, 0);
            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                ImageBrush Brush = new ImageBrush();
                BitmapImage B = new BitmapImage(new Uri("Images/BG2.png", UriKind.RelativeOrAbsolute));

                Brush.ImageSource = B;

                MENU.Background = Brush;


                MENU1.Margin = new Thickness(100, 220, 0, 0);
                MENU2.Margin = new Thickness(380, 220, 0, 0);
            }
        }



        private void M_COLOR_Click(object sender, EventArgs e)
        {
            //ChgColorList.Show();setStyle
            NavigationService.Navigate(new Uri("/setStyle.xaml", UriKind.Relative));
        }



        private void ChgColorList_Loaded(object sender, RoutedEventArgs e)
        {


            Board.ChangeBgNum= ChgColorList.Index;
        }









        private void test_Click(object sender, RoutedEventArgs e)
        {
            //test.OBJ =new test.OBJ


            //Window.OBJ = new Photo_L7D();
            NavigationService.Navigate(new Uri("/selectType.xaml", UriKind.Relative));
            //NavigationService.Navigate(new Uri("/Window.xaml", UriKind.Relative));
        }



        private void M_FB_Click(object sender, EventArgs e)
        {
            
            WriteableBitmap WBimg =new WriteableBitmap(Board.Source);
             

            makephoto.Sendms = new MemoryStream();

            WBimg.SaveJpeg(makephoto.Sendms, WBimg.PixelWidth, WBimg.PixelHeight, 0, 100);
            makephoto.Sendms.Seek(0, SeekOrigin.Begin);

            NavigationService.Navigate(new Uri("/Pages/FacebookLoginPage.xaml", UriKind.Relative));
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {

            BitmapImage B = new BitmapImage(new Uri("Image/3.png", UriKind.RelativeOrAbsolute));

            MyOBJ R = new MyOBJ(1,B,100,100);

            LayoutRoot.Children.Add(R);
        }

        private void PhoneApplicationPage_LayoutUpdated(object sender, EventArgs e)
        {
            VopenPhoto = false;
        }


        void ChgLightList_Loaded(object sender, RoutedEventArgs e)
        {

            if (OpenFile)
            {
                Board.ValLight = (ChgLightList.Index*-1) + 20;
            }
        }

        private void M_RGB_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/setRgb.xaml", UriKind.Relative));
        }


        private void M_Contrast_Click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/setContrast.xaml", UriKind.Relative));

        }

        private void button1_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/test.xaml", UriKind.Relative));
        }

        private void M_MASK_Click(object sender, EventArgs e)
        {
            Bimg = Board.Source;//將裁切或全景的照片回傳
            NavigationService.Navigate(new Uri("/MASK.xaml", UriKind.Relative));
        }





    }
}