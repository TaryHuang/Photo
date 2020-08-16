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
using System.Windows.Input;
namespace PhotoJ
{
    public class PhotoView : Grid
    {
        Border BODY = new Border();
        ScrollViewer VIEW = new ScrollViewer();
        public Canvas PHOTO = new Canvas();
        BitmapImage Bimg;
        Image IMG = new Image();
        Image IMG2 = new Image();
        MyOBJ Obj;


        //**********************************************
        //2013.06.07 
        bool VopenPhoto = false;// 初始化
        PhotoChooserTask photoChooserTask = new PhotoChooserTask();
        //**********************************************



        public PhotoView()
        {
            IMG.ImageOpened += IMG_ImageOpened;
            IMG.Visibility = System.Windows.Visibility.Collapsed;
            IMG2.Visibility = System.Windows.Visibility.Collapsed;
            this.Children.Add(IMG);
            this.Children.Add(IMG2);

            VIEW.Content = PHOTO;
            VIEW.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            VIEW.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            BODY.BorderBrush = new SolidColorBrush(Colors.Gray);
            BODY.BorderThickness = new Thickness(1, 1, 1, 1);
            BODY.Child = VIEW;

            this.Children.Add(BODY);
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.LayoutUpdated += new EventHandler(PhotoView_LayoutUpdated);
            
            VIEW.MouseLeftButtonUp += VIEW_MouseLeftButtonUp;

            photoChooserTask.Completed += photoChooserTask_Completed;
        }

        void PhotoView_LayoutUpdated(object sender, EventArgs e)
        {
            VopenPhoto = false;
        }



        void VIEW_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Obj==null)
            {

                if (!VopenPhoto)
                {
                    VopenPhoto = true;
                    photoChooserTask.Show();
                }
            }
            
        }

        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            switch (e.TaskResult)
            {
                case TaskResult.OK:
                    Bimg = new BitmapImage(new Uri(e.OriginalFileName));
                    IMG.Source = Bimg; 
                    break;

                //**********************************************
                //2013.06.07  為了修改 連續按兩下執行PhotoChooserTaskCompleted 使app跳出程式
                default:
                    BitmapImage bbb = new BitmapImage(new Uri("/PhotoJ;component/Images/BG1.png"));
                    IMG2.Source = bbb; break;
                //**********************************************
            }

        }


        void IMG_ImageOpened(object sender, RoutedEventArgs e)
        {


            if (Bimg.PixelWidth >= 1000 || Bimg.PixelHeight >= 1000)
            {

                Point P = TARY_Library_Silverlight.Photo.PhotoEdit.BestSize2(Bimg, 1000, 1000);

                Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.Size(Bimg, (int)P.X, (int)P.Y);
            }






            Obj = new MyOBJ(0, Bimg, Bimg.PixelWidth, Bimg.PixelHeight);
            Obj.Hold += Obj_Hold;
            Obj.V = (int)((Obj.V_MinBAN)/2);

            PHOTO.Children.Add(Obj);

        }
        private void Obj_Hold(object sender, GestureEventArgs e)
        {

            //刪除物件
            MyOBJ A = sender as MyOBJ;
            PHOTO.Children.Remove(A);

            //刪除物件
            Obj = null;
        }

        public double HEIGHT
        {
            get
            {
                return this.Height;
            }
            set
            {
                PHOTO.Height = value;
                VIEW.Height = value;
                this.Height = value;
            }
        }



        public double WIDTH
        {
            get
            {
                return this.Width;
            }
            set
            {
                PHOTO.Width = value;
                VIEW.Width = value;
                this.Width = value;
            }
        }
    }
}
