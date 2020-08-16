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




    class Photo_L2A : PhotoViewer
    {



        public override void Init()
        {
            setKey("L");
            PhotoView A = new PhotoView();
            A.WIDTH = 460;
            A.HEIGHT = 175;
            A.Margin = new Thickness((this.Width - A.WIDTH) / 2, 15, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 460;
            B.HEIGHT = 175;
            B.Margin = new Thickness((this.Width - A.WIDTH) / 2, 200, 0, 0);
            PHOTOS.Children.Add(B);


        }

    }









    class Photo_L2B : PhotoViewer
    {





        public override void Init()
        {
            setKey("L");
            PhotoView A = new PhotoView();
            A.WIDTH = 250;
            A.HEIGHT = 341;
            A.Margin = new Thickness(25,20, 0, 0);

            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 250;
            B.HEIGHT = 341;
            B.Margin = new Thickness(280, 20, 0, 0);
            PHOTOS.Children.Add(B);


        }


    }









    class Photo_L2C : PhotoViewer
    {



        public override void Init()
        {
            setKey("L");



            CompositeTransform Com = new CompositeTransform();
            Com.Rotation = -25;



            PhotoView A = new PhotoView();
            A.WIDTH = 670;
            A.HEIGHT = 300;

            A.RenderTransform = Com;
            A.Margin = new Thickness(-150, 65, 0, 0);
            PHOTOS.Children.Add(A);








            PhotoView B = new PhotoView();
            B.WIDTH = 670;
            B.HEIGHT = 300;
            B.RenderTransform = Com;
            B.Margin = new Thickness(-50, 350, 0, 0);
            PHOTOS.Children.Add(B);
        }


    }





    class Photo_L2D : PhotoViewer
    {



        public override void Init()
        {
            setKey("L");



            CompositeTransform Com = new CompositeTransform();
            Com.Rotation = -25;



            PhotoView A = new PhotoView();
            A.WIDTH = 195;
            A.HEIGHT = 330;

            A.RenderTransform = Com;
            A.Margin = new Thickness(10, 90, 0, 0);
            PHOTOS.Children.Add(A);








            PhotoView B = new PhotoView();
            B.WIDTH = 195;
            B.HEIGHT = 330;
            B.RenderTransform = Com;
            B.Margin = new Thickness(235, 90, 0, 0);
            PHOTOS.Children.Add(B);
        }
    }






    class Photo_L2E : PhotoViewer
    {




        public override void Init()
        {
            setKey("L");
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








    class Photo_L2F : PhotoViewer
    {


        public override void Init()
        {

            setKey("L");
            PhotoView C = new PhotoView();
            C.WIDTH = 240;
            C.HEIGHT = 180;
            C.Margin = new Thickness(283, 205, 0, 0);
            PHOTOS.Children.Add(C);



            /*
            //base.Init();
            //450*600
            PhotoView A = new PhotoView();
            A.WIDTH = 240;
            A.HEIGHT = 180;
            A.Margin = new Thickness(283, 15, 0, 0);
            PHOTOS.Children.Add(A);
            */


            PhotoView B = new PhotoView();

            B.WIDTH = 240;
            B.HEIGHT = 370;
            B.Margin = new Thickness(33, 15, 0, 0);
            PHOTOS.Children.Add(B);


        }
    }





}
