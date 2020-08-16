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

    


    class Photo_P5A : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");






            PhotoView A =new PhotoView();
            A.WIDTH=206;
            A.HEIGHT=240;
            A.Margin = new Thickness(16, 27, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 206;
            B.HEIGHT = 240;
            B.Margin = new Thickness(229, 27, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 135;
            C.HEIGHT = 330;
            C.Margin = new Thickness(16, 275, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 135;
            D.HEIGHT = 330;
            D.Margin = new Thickness(156, 275, 0, 0);
            PHOTOS.Children.Add(D);




            PhotoView E = new PhotoView();
            E.WIDTH = 139;
            E.HEIGHT = 330;
            E.Margin = new Thickness(296, 275, 0, 0);
            PHOTOS.Children.Add(E);
        }

    }







    class Photo_P5B : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");






            PhotoView A = new PhotoView();
            A.WIDTH = 206;
            A.HEIGHT = 240;
            A.Margin = new Thickness(16, 365, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 206;
            B.HEIGHT = 240;
            B.Margin = new Thickness(229, 365, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 135;
            C.HEIGHT = 330;
            C.Margin = new Thickness(16, 27, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 135;
            D.HEIGHT = 330;
            D.Margin = new Thickness(156, 27, 0, 0);
            PHOTOS.Children.Add(D);




            PhotoView E = new PhotoView();
            E.WIDTH = 139;
            E.HEIGHT = 330;
            E.Margin = new Thickness(296, 27, 0, 0);
            PHOTOS.Children.Add(E);
        }

    }











    class Photo_P5C : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");








            PhotoView C = new PhotoView();
            C.WIDTH = 175;
            C.HEIGHT = 300;
            C.Margin = new Thickness(16, 325, 0, 0);
            PHOTOS.Children.Add(C);




            PhotoView A = new PhotoView();
            A.WIDTH = 175;
            A.HEIGHT = 300;
            A.Margin = new Thickness(16, 17, 0, 0);
            PHOTOS.Children.Add(A);





            PhotoView B = new PhotoView();

            B.WIDTH = 240;
            B.HEIGHT = 200;
            B.Margin = new Thickness(200, 17, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView D = new PhotoView();
            D.WIDTH = 240;
            D.HEIGHT = 200;
            D.Margin = new Thickness(200, 220, 0, 0);
            PHOTOS.Children.Add(D);


            PhotoView E = new PhotoView();
            E.WIDTH = 240;
            E.HEIGHT = 200;
            E.Margin = new Thickness(200, 425, 0, 0);
            PHOTOS.Children.Add(E);
        }

    }








    class Photo_P5D : PhotoViewer
    {





        public override void Init()
        {

            setKey("P");




            PhotoView C = new PhotoView();
            C.WIDTH = 175;
            C.HEIGHT = 300;
            C.Margin = new Thickness(265, 325, 0, 0);
            PHOTOS.Children.Add(C);




            PhotoView A = new PhotoView();
            A.WIDTH = 175;
            A.HEIGHT = 300;
            A.Margin = new Thickness(265, 17, 0, 0);
            PHOTOS.Children.Add(A);





            PhotoView B = new PhotoView();

            B.WIDTH = 240;
            B.HEIGHT = 200;
            B.Margin = new Thickness(16, 17, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView D = new PhotoView();
            D.WIDTH = 240;
            D.HEIGHT = 200;
            D.Margin = new Thickness(16, 220, 0, 0);
            PHOTOS.Children.Add(D);


            PhotoView E = new PhotoView();
            E.WIDTH = 240;
            E.HEIGHT = 200;
            E.Margin = new Thickness(16, 425, 0, 0);
            PHOTOS.Children.Add(E);
        }
    }











    class Photo_P5E : PhotoViewer
    {





        public override void Init()
        {

            setKey("P");




            PhotoView C = new PhotoView();
            C.WIDTH = 210;
            C.HEIGHT = 300;
            C.Margin = new Thickness(220, 325, 0, 0);
            PHOTOS.Children.Add(C);




            PhotoView A = new PhotoView();
            A.WIDTH = 210;
            A.HEIGHT = 300;
            A.Margin = new Thickness(220, 17, 0, 0);
            PHOTOS.Children.Add(A);





            PhotoView B = new PhotoView();

            B.WIDTH = 200;
            B.HEIGHT = 200;
            B.Margin = new Thickness(16, 17, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView D = new PhotoView();
            D.WIDTH = 200;
            D.HEIGHT = 200;
            D.Margin = new Thickness(16, 220, 0, 0);
            PHOTOS.Children.Add(D);


            PhotoView E = new PhotoView();
            E.WIDTH = 200;
            E.HEIGHT = 200;
            E.Margin = new Thickness(16, 425, 0, 0);
            PHOTOS.Children.Add(E);
        }
    }





    class Photo_P5F : PhotoViewer
    {





        public override void Init()
        {

            setKey("P");




            PhotoView C = new PhotoView();
            C.WIDTH = 210;
            C.HEIGHT = 300;
            C.Margin = new Thickness(16, 325, 0, 0);
            PHOTOS.Children.Add(C);




            PhotoView A = new PhotoView();
            A.WIDTH = 210;
            A.HEIGHT = 300;
            A.Margin = new Thickness(16, 17, 0, 0);
            PHOTOS.Children.Add(A);





            PhotoView B = new PhotoView();

            B.WIDTH = 200;
            B.HEIGHT = 200;
            B.Margin = new Thickness(230, 17, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView D = new PhotoView();
            D.WIDTH = 200;
            D.HEIGHT = 200;
            D.Margin = new Thickness(230, 220, 0, 0);
            PHOTOS.Children.Add(D);


            PhotoView E = new PhotoView();
            E.WIDTH = 200;
            E.HEIGHT = 200;
            E.Margin = new Thickness(230, 425, 0, 0);
            PHOTOS.Children.Add(E);
        }
    }
}
