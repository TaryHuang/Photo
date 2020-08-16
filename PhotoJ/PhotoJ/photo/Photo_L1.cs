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

    


    class Photo_L1A : PhotoViewer
    {



        public override void Init()
        {
            setKey("L");
            PhotoView A =new PhotoView();
            A.WIDTH=420;
            A.HEIGHT=351;
            A.Margin = new Thickness((this.Width-A.WIDTH)/2,15,0,0);


            PHOTOS.Children.Add(A);
        }

    }




    class Photo_L1B : PhotoViewer
    {



        public override void Init()
        {
            setKey("L");
            PhotoView A = new PhotoView();
            A.WIDTH = 360;
            A.HEIGHT = 351;
            A.Margin = new Thickness(20, 15, 0, 0);


            PHOTOS.Children.Add(A);
        }

    }





    class Photo_L1C : PhotoViewer
    {



        public override void Init()
        {
            setKey("L");

            PhotoView A = new PhotoView();
            A.WIDTH = 680;
            A.HEIGHT = 340;

            CompositeTransform Com = new CompositeTransform();
            //Com.CenterX = A.WIDTH / 2;

            Com.Rotation = -25;

            A.RenderTransform = Com;


            A.Margin = new Thickness(-120, 150, 0, 0);

            PHOTOS.Children.Add(A);
        }

    }







    class Photo_L1D : PhotoViewer
    {



        public override void Init()
        {
            setKey("L");


            PhotoView A = new PhotoView();
            A.WIDTH = 680;
            A.HEIGHT = 380;

            CompositeTransform Com = new CompositeTransform();
            //Com.CenterX = A.WIDTH / 2;

            Com.Rotation = -25;

            A.RenderTransform = Com;


            A.Margin = new Thickness(-160, 65, 0, 0);

            PHOTOS.Children.Add(A);
        }

    }







    class Photo_L1E : PhotoViewer
    {



        public override void Init()
        {
            setKey("L");

            PhotoView A = new PhotoView();
            A.WIDTH = 200;
            A.HEIGHT = 200;

            //CompositeTransform Com = new CompositeTransform();
            //Com.CenterX = A.WIDTH / 2;

            //Com.Rotation = -25;

           // A.RenderTransform = Com;


            A.Margin = new Thickness(20, 20, 0, 0);

            PHOTOS.Children.Add(A);
        }

    }







    class Photo_L1F : PhotoViewer
    {


        public override void Init()
        {
            setKey("L");

            PhotoView A = new PhotoView();
            A.WIDTH = 300;
            A.HEIGHT = 200;

            //CompositeTransform Com = new CompositeTransform();
            //Com.CenterX = A.WIDTH / 2;

            //Com.Rotation = -25;

            // A.RenderTransform = Com;


            A.Margin = new Thickness(220, 20, 0, 0);

            PHOTOS.Children.Add(A);
        }

    }
}
