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

    


    class Photo_L6A : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");








            PhotoView A = new PhotoView();
            A.WIDTH = 170;
            A.HEIGHT = 180;
            A.Margin = new Thickness(10, 10, 0, 0);
            PHOTOS.Children.Add(A);



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


            PhotoView D = new PhotoView();
            D.WIDTH = 170;
            D.HEIGHT = 180;
            D.Margin = new Thickness(190, 200, 0, 0);
            PHOTOS.Children.Add(D);







            PhotoView E = new PhotoView();
            E.WIDTH = 170;
            E.HEIGHT = 180;
            E.Margin = new Thickness(190+180, 10, 0, 0);
            PHOTOS.Children.Add(E);


            PhotoView F = new PhotoView();
            F.WIDTH = 170;
            F.HEIGHT = 180;
            F.Margin = new Thickness(190 + 180, 200, 0, 0);
            PHOTOS.Children.Add(F);
        }

    }





    class Photo_L6B : PhotoViewer
    {


        public override void Init()
        {

            setKey("L");








            PhotoView A = new PhotoView();
            A.WIDTH = 200;
            A.HEIGHT = 185;
            A.Margin = new Thickness(15, 15, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 200;
            B.HEIGHT = 185;
            B.Margin = new Thickness(15, 195, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 200;
            C.HEIGHT = 185;
            C.Margin = new Thickness(185, 15, 0, 0);
            PHOTOS.Children.Add(C);







            PhotoView D = new PhotoView();
            D.WIDTH = 200;
            D.HEIGHT = 185;
            D.Margin = new Thickness(185, 195, 0, 0);
            PHOTOS.Children.Add(D);







            PhotoView E = new PhotoView();
            E.WIDTH = 170;
            E.HEIGHT = 185;
            E.Margin = new Thickness(185+185, 15, 0, 0);
            PHOTOS.Children.Add(E);


            PhotoView F = new PhotoView();
            F.WIDTH = 170;
            F.HEIGHT = 185;
            F.Margin = new Thickness(185 + 185, 195, 0, 0);
            PHOTOS.Children.Add(F);
        }
    }







    class Photo_L6C : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");









            PhotoView E = new PhotoView();
            E.WIDTH = 180;
            E.HEIGHT = 185;
            E.Margin = new Thickness(360, 15, 0, 0);
            PHOTOS.Children.Add(E);




            PhotoView C = new PhotoView();
            C.WIDTH = 230;
            C.HEIGHT = 185;
            C.Margin = new Thickness(175, 15, 0, 0);
            PHOTOS.Children.Add(C);

            PhotoView A = new PhotoView();
            A.WIDTH = 230;
            A.HEIGHT = 185;
            A.Margin = new Thickness(15, 15, 0, 0);
            PHOTOS.Children.Add(A);




            PhotoView B = new PhotoView();

            B.WIDTH = 220;
            B.HEIGHT = 185;
            B.Margin = new Thickness(15, 195, 0, 0);
            PHOTOS.Children.Add(B);





            PhotoView D = new PhotoView();
            D.WIDTH = 260;
            D.HEIGHT = 185;
            D.Margin = new Thickness(140, 195, 0, 0);
            PHOTOS.Children.Add(D);









            PhotoView F = new PhotoView();
            F.WIDTH = 170;
            F.HEIGHT = 185;
            F.Margin = new Thickness(185 + 185, 195, 0, 0);
            PHOTOS.Children.Add(F);
        }

    }











}
