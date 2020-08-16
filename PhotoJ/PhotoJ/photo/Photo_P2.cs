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

    


    class Photo_P2A : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");
            PhotoView A =new PhotoView();
            A.WIDTH=420;
            A.HEIGHT=275;
            A.Margin = new Thickness((this.Width-A.WIDTH)/2,15,0,0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 420;
            B.HEIGHT = 275;
            B.Margin = new Thickness((this.Width - A.WIDTH) / 2, 308, 0, 0);
            PHOTOS.Children.Add(B);


        }

    }









    class Photo_P2B : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 420;
            A.HEIGHT = 460;
            A.Margin = new Thickness((this.Width - A.WIDTH) / 2,40, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 300;
            B.HEIGHT = 200;
            CompositeTransform Com = new CompositeTransform();
            //Com.CenterX = A.WIDTH / 2;

            Com.Rotation = -10;
            B.RenderTransform = Com;
            B.Margin = new Thickness(115, 400, 0, 0);
            PHOTOS.Children.Add(B);


        }

    }









    class Photo_P2C : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 420;
            A.HEIGHT = 360;
            A.Margin = new Thickness((this.Width - A.WIDTH) / 2, 25, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 420;
            B.HEIGHT = 180;
            B.Margin = new Thickness((this.Width - A.WIDTH) / 2, 395, 0, 0);
            PHOTOS.Children.Add(B);


        }


    }





    class Photo_P2D : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 420;
            A.HEIGHT = 180;
            A.Margin = new Thickness((this.Width - A.WIDTH) / 2, 25, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 420;
            B.HEIGHT = 360;
            B.Margin = new Thickness((this.Width - A.WIDTH) / 2, 220, 0, 0);
            PHOTOS.Children.Add(B);


        }


    }






    class Photo_P2E : PhotoViewer
    {




        public override void Init()
        {
            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 225;
            A.HEIGHT = 530;
            A.Margin = new Thickness(10, 40, 0, 0);

            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 200;
            B.HEIGHT = 357;
            B.Margin = new Thickness(A.WIDTH + 15, 40, 0, 0);
            PHOTOS.Children.Add(B);


        }

    }









    class Photo_P2F : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 225;
            A.HEIGHT = 357;
            A.Margin = new Thickness(10, this.Height - A.HEIGHT-30, 0, 0);
            
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 200;
            B.HEIGHT = 530;
            B.Margin = new Thickness(A.WIDTH + 15, 40, 0, 0);
            PHOTOS.Children.Add(B);


        }


    }








}
