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

    public class PhotoViewer : Grid
    {
        public string PhotoKey;
        public string PhotoKeyS;
        public ScrollViewer VIEW = new ScrollViewer();
        public Canvas PHOTOS = new Canvas();



        public PhotoViewer()
        {

            VIEW.BorderBrush = new SolidColorBrush(Colors.Black);
            VIEW.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            VIEW.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            VIEW.Content = PHOTOS;


            this.Children.Add(VIEW);

            

            this.Background = new SolidColorBrush(Colors.White);
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            


            Init();        
            
        }

        



        public int BorderThickness{
            set
            {

                //影子
                if (value == 1)
                {


                    VIEW.BorderThickness = new Thickness(1, 1, 1, 1);
                }
                else if (value == 2)
                {
                    VIEW.BorderThickness = new Thickness(1, 1, 4, 4);

                }
                else if (value == 3)
                {

                    VIEW.BorderThickness = new Thickness(4, 1, 1, 4);
                }

                else if (value == 4)
                {
                    VIEW.BorderThickness = new Thickness(2, 2, 2, 2);

                }

                else if (value == 5)
                {

                    VIEW.BorderThickness = new Thickness(2, 2, 5, 5);
                }

                else if (value == 6)
                {
                    VIEW.BorderThickness = new Thickness(5, 2, 2, 5);

                }
                else
                {
                    VIEW.BorderThickness = new Thickness(0, 0, 0, 0);
                }





            }
        }

        public void setKey(string KEY)
        {
            PhotoKey = KEY;

            if (KEY[0] == 'P')
            {
                this.WIDTH = 450;
                this.HEIGHT = 640;
                this.Margin = new Thickness(0, 10, 0, 0);
            }
            else if (KEY[0] == 'L')
            {
                //this.WIDTH = 640;
                //this.HEIGHT = 360;
                this.WIDTH = 560;
                this.HEIGHT = 400;
                this.Margin = new Thickness(0, 0, 0, 0);
            }
            else if (KEY[0] == 'S')
            {
                    
            }
        }

        public double HEIGHT
        {
            get
            {
                return this.Height;
            }
            set
            {
                PHOTOS.Height = value;
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
                PHOTOS.Width = value;
                VIEW.Width = value;
                this.Width = value;
            }
        }

        public virtual void Init()
        {

        }

        public SolidColorBrush BorderBush
        {
            set
            {
                for (int i = 0; i < PHOTOS.Children.Count;i++ )
                {
                    PhotoView P = PHOTOS.Children[i] as PhotoView;
                    P.Background = value ;

                }
            }
        }
    }

}

