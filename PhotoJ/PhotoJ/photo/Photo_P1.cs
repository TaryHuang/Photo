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

    


    class Photo_P1A : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");
            PhotoView A =new PhotoView();
            A.WIDTH=400;
            A.HEIGHT=460;
            A.Margin = new Thickness((this.Width-A.WIDTH)/2,15,0,0);


            PHOTOS.Children.Add(A);
        }

    }




    class Photo_P1B : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 420;
            A.HEIGHT = 315;
            A.Margin = new Thickness((this.Width - A.WIDTH) / 2, 15, 0, 0);



            PHOTOS.Children.Add(A);
        }

    }





    class Photo_P1C : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");

            PhotoView A = new PhotoView();
            A.WIDTH = 650;
            A.HEIGHT = 340;

            CompositeTransform Com = new CompositeTransform();
            //Com.CenterX = A.WIDTH / 2;

            Com.Rotation = -25;

            A.RenderTransform = Com;


            A.Margin = new Thickness(-150, 150, 0, 0);

            PHOTOS.Children.Add(A);
        }

    }







    class Photo_P1D : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");

            PhotoView A = new PhotoView();
            A.WIDTH = 650;
            A.HEIGHT = 380;

            CompositeTransform Com = new CompositeTransform();
            //Com.CenterX = A.WIDTH / 2;

            Com.Rotation = -25;

            A.RenderTransform = Com;


            A.Margin = new Thickness(-200, 80, 0, 0);

            PHOTOS.Children.Add(A);
        }

    }







    class Photo_P1E : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");

            PhotoView A = new PhotoView();
            A.WIDTH = 310;
            A.HEIGHT = 560;

            //CompositeTransform Com = new CompositeTransform();
            //Com.CenterX = A.WIDTH / 2;

            //Com.Rotation = -25;

           // A.RenderTransform = Com;


            A.Margin = new Thickness(20, 20, 0, 0);

            PHOTOS.Children.Add(A);
        }

    }







    class Photo_P1F : PhotoViewer
    {


        public override void Init()
        {
            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 660;
            A.HEIGHT = 390;

            CompositeTransform Com = new CompositeTransform();
            //Com.CenterX = A.WIDTH / 2;

            Com.Rotation = -20;

            A.RenderTransform = Com;


            A.Margin = new Thickness(-150, 270, 0, 0);

            PHOTOS.Children.Add(A);
        }

    }








    class Photo_P1G : PhotoViewer
    {


        public override void Init()
        {
            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 420;
            A.HEIGHT = 470;
            A.Margin = new Thickness((this.Width - A.WIDTH) / 2, 70, 0, 0);



            PHOTOS.Children.Add(A);
        }

    }
}
