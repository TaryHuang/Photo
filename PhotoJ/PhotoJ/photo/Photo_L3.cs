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

    


    class Photo_L3A : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");
            PhotoView C = new PhotoView();
            C.WIDTH = 530;
            C.HEIGHT =200;
            C.Margin = new Thickness(10, 185, 0, 0);
            PHOTOS.Children.Add(C);





            PhotoView A =new PhotoView();
            A.WIDTH=260;
            A.HEIGHT=160;
            A.Margin = new Thickness(10, 15, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 260;
            B.HEIGHT = 160;
            B.Margin = new Thickness(280, 15, 0, 0);
            PHOTOS.Children.Add(B);

        }

    }






    class Photo_L3B : PhotoViewer
    {


        public override void Init()
        {

            setKey("L");
            PhotoView C = new PhotoView();
            C.WIDTH = 530;
            C.HEIGHT = 200;
            C.Margin = new Thickness(10, 15, 0, 0);
            PHOTOS.Children.Add(C);





            PhotoView A = new PhotoView();
            A.WIDTH = 260;
            A.HEIGHT = 160;
            A.Margin = new Thickness(10, 225, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 260;
            B.HEIGHT = 160;
            B.Margin = new Thickness(280, 225, 0, 0);
            PHOTOS.Children.Add(B);

        }

    }



    class Photo_L3C : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");
            PhotoView C = new PhotoView();
            C.WIDTH = 240;
            C.HEIGHT = 180;
            C.Margin = new Thickness(33, 205, 0, 0);
            PHOTOS.Children.Add(C);




            //base.Init();
            //450*600
            PhotoView A = new PhotoView();
            A.WIDTH = 240;
            A.HEIGHT = 180;
            A.Margin = new Thickness(33, 15, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 240;
            B.HEIGHT = 180;
            B.Margin = new Thickness(282, 15, 0, 0);
            PHOTOS.Children.Add(B);


        }
    }





    class Photo_L3D : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");

            PhotoView C = new PhotoView();
            C.WIDTH = 240;
            C.HEIGHT = 180;
            C.Margin = new Thickness(33, 205, 0, 0);
            PHOTOS.Children.Add(C);




            //base.Init();
            //450*600
            PhotoView A = new PhotoView();
            A.WIDTH = 240;
            A.HEIGHT = 180;
            A.Margin = new Thickness(282, 205, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 240;
            B.HEIGHT = 180;
            B.Margin = new Thickness(282, 15, 0, 0);
            PHOTOS.Children.Add(B);


        }
    }









    class Photo_L3E : PhotoViewer
    {




        public override void Init()
        {

            setKey("L");
            PhotoView C = new PhotoView();
            C.WIDTH = 240;
            C.HEIGHT = 180;
            C.Margin = new Thickness(33, 205, 0, 0);
            PHOTOS.Children.Add(C);




            //base.Init();
            //450*600
            PhotoView A = new PhotoView();
            A.WIDTH = 240;
            A.HEIGHT = 180;
            A.Margin = new Thickness(33, 15, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 240;
            B.HEIGHT = 370;
            B.Margin = new Thickness(282, 15, 0, 0);
            PHOTOS.Children.Add(B);


        }
    }



    class Photo_L3F : PhotoViewer
    {


        public override void Init()
        {

            setKey("L");
            PhotoView C = new PhotoView();
            C.WIDTH = 240;
            C.HEIGHT = 180;
            C.Margin = new Thickness(283, 205, 0, 0);
            PHOTOS.Children.Add(C);




            //base.Init();
            //450*600
            PhotoView A = new PhotoView();
            A.WIDTH = 240;
            A.HEIGHT = 180;
            A.Margin = new Thickness(283, 15, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 240;
            B.HEIGHT = 370;
            B.Margin = new Thickness(33, 15, 0, 0);
            PHOTOS.Children.Add(B);


        }
    }





    class Photo_L3G : PhotoViewer
    {



        public override void Init()
        {




            setKey("L");







            /*
            PhotoView A = new PhotoView();
            A.WIDTH = 170;
            A.HEIGHT = 180;
            A.Margin = new Thickness(10, 10, 0, 0);
            PHOTOS.Children.Add(A);
            */

            /*
            PhotoView B = new PhotoView();

            B.WIDTH = 170;
            B.HEIGHT = 180;
            B.Margin = new Thickness(10, 200, 0, 0);
            PHOTOS.Children.Add(B);
            */

            /*
            PhotoView C = new PhotoView();
            C.WIDTH = 170;
            C.HEIGHT = 180;
            C.Margin = new Thickness(190, 10, 0, 0);
            PHOTOS.Children.Add(C);
            */


            PhotoView D = new PhotoView();
            D.WIDTH = 170;
            D.HEIGHT = 180;
            D.Margin = new Thickness(190, 200, 0, 0);
            PHOTOS.Children.Add(D);







            PhotoView E = new PhotoView();
            E.WIDTH = 170;
            E.HEIGHT = 180;
            E.Margin = new Thickness(190 + 180, 10, 0, 0);
            PHOTOS.Children.Add(E);




            PhotoView F = new PhotoView();
            F.WIDTH = 170;
            F.HEIGHT = 180;
            F.Margin = new Thickness(190 + 180, 200, 0, 0);
            PHOTOS.Children.Add(F);

        }
    }





    class Photo_L3H : PhotoViewer
    {



        public override void Init()
        {




            setKey("L");







            /*
            PhotoView A = new PhotoView();
            A.WIDTH = 170;
            A.HEIGHT = 180;
            A.Margin = new Thickness(10, 10, 0, 0);
            PHOTOS.Children.Add(A);
            */

            
            PhotoView B = new PhotoView();
            B.WIDTH = 170;
            B.HEIGHT = 180;
            B.Margin = new Thickness(10, 200, 0, 0);
            PHOTOS.Children.Add(B);
            


            PhotoView C = new PhotoView();
            C.WIDTH = 170;
            C.HEIGHT = 180;
            C.Margin = new Thickness(190, 10, 0, 0);
            PHOTOS.Children.Add(C);


            /*
            PhotoView D = new PhotoView();
            D.WIDTH = 170;
            D.HEIGHT = 180;
            D.Margin = new Thickness(190, 200, 0, 0);
            PHOTOS.Children.Add(D);
            */






            PhotoView E = new PhotoView();
            E.WIDTH = 170;
            E.HEIGHT = 180;
            E.Margin = new Thickness(190 + 180, 10, 0, 0);
            PHOTOS.Children.Add(E);



            /*
            PhotoView F = new PhotoView();
            F.WIDTH = 170;
            F.HEIGHT = 180;
            F.Margin = new Thickness(190 + 180, 200, 0, 0);
            PHOTOS.Children.Add(F);
            */
        }
    }
}
