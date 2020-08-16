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

    


    class Photo_P4A : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");






            PhotoView A =new PhotoView();
            A.WIDTH=206;
            A.HEIGHT=300;
            A.Margin = new Thickness(16, 17, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 206;
            B.HEIGHT = 300;
            B.Margin = new Thickness(229, 17, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 206;
            C.HEIGHT = 300;
            C.Margin = new Thickness(16, 325, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 206;
            D.HEIGHT = 300;
            D.Margin = new Thickness(229, 325, 0, 0);
            PHOTOS.Children.Add(D);
        }

    }













    class Photo_P4B : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");






            PhotoView A = new PhotoView();
            A.WIDTH = 410;
            A.HEIGHT = 145;
            A.Margin = new Thickness(20, 20, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 410;
            B.HEIGHT = 145;
            B.Margin = new Thickness(20, 170, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 410;
            C.HEIGHT = 145;
            C.Margin = new Thickness(20, 320, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 410;
            D.HEIGHT = 145;
            D.Margin = new Thickness(20, 470, 0, 0);
            PHOTOS.Children.Add(D);
        }

    }



    class Photo_P4C : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");






            PhotoView A = new PhotoView();
            A.WIDTH = 410;
            A.HEIGHT = 185;
            A.Margin = new Thickness(20, 20, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 180;
            B.HEIGHT = 400;
            B.Margin = new Thickness(20, 215, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 220;
            C.HEIGHT = 195;
            C.Margin = new Thickness(210, 215, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 220;
            D.HEIGHT = 195;
            D.Margin = new Thickness(210, 420, 0, 0);
            PHOTOS.Children.Add(D);
        }

    }














    class Photo_P4D : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");






            PhotoView A = new PhotoView();
            A.WIDTH = 410;
            A.HEIGHT = 185;
            A.Margin = new Thickness(20, 20, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 180;
            B.HEIGHT = 400;
            B.Margin = new Thickness(250, 215, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 220;
            C.HEIGHT = 195;
            C.Margin = new Thickness(20, 215, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 220;
            D.HEIGHT = 195;
            D.Margin = new Thickness(20, 420, 0, 0);
            PHOTOS.Children.Add(D);
        }

    }









    class Photo_P4E : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");

            CompositeTransform Com = new CompositeTransform();
            Com.Rotation = 0;

            PhotoView B = new PhotoView();

            B.WIDTH = 250;
            B.HEIGHT = 250;
            B.Margin = new Thickness(190, 25, 0, 0);
            B.RenderTransform = Com;
            PHOTOS.Children.Add(B);


            PhotoView A = new PhotoView();
            A.WIDTH = 250;
            A.HEIGHT = 250;
            A.Margin = new Thickness(10, 25, 0, 0);
            A.RenderTransform = Com;
            PHOTOS.Children.Add(A);






            PhotoView C = new PhotoView();
            C.WIDTH = 250;
            C.HEIGHT = 250;
            C.Margin = new Thickness(10, 270, 0, 0);
            C.RenderTransform = Com;
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 250;
            D.HEIGHT = 250;
            D.Margin = new Thickness(190, 270, 0, 0);
            D.RenderTransform = Com;
            PHOTOS.Children.Add(D);
        }

    }



    class Photo_P4F : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");

            CompositeTransform Com = new CompositeTransform();
            Com.Rotation = 12;

            PhotoView B = new PhotoView();

            B.WIDTH = 220;
            B.HEIGHT = 220;
            B.Margin = new Thickness(235, 25, 0, 0);
            B.RenderTransform = Com;
            PHOTOS.Children.Add(B);


            PhotoView A = new PhotoView();
            A.WIDTH = 220;
            A.HEIGHT = 220;
            A.Margin = new Thickness(50, 45, 0, 0);
            A.RenderTransform = Com;
            PHOTOS.Children.Add(A);






            PhotoView C = new PhotoView();
            C.WIDTH = 220;
            C.HEIGHT = 220;
            C.Margin = new Thickness(50, 270, 0, 0);
            C.RenderTransform = Com;
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 220;
            D.HEIGHT = 220;
            D.Margin = new Thickness(220, 240, 0, 0);
            D.RenderTransform = Com;
            PHOTOS.Children.Add(D);
        }

    }
}
