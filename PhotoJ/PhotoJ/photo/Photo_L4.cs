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

    


    class Photo_L4A : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");






            PhotoView A =new PhotoView();
            A.WIDTH=250;
            A.HEIGHT = 180;
            A.Margin = new Thickness(24, 10, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 250;
            B.HEIGHT = 180;
            B.Margin = new Thickness(284, 10, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 250;
            C.HEIGHT = 180;
            C.Margin = new Thickness(24, 200, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 250;
            D.HEIGHT = 180;
            D.Margin = new Thickness(284, 200, 0, 0);
            PHOTOS.Children.Add(D);
        }

    }













    class Photo_L4B : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");


            PhotoView A = new PhotoView();
            A.WIDTH = 180;
            A.HEIGHT = 180;
            A.Margin = new Thickness(24, 10, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 320;
            B.HEIGHT = 180;
            B.Margin = new Thickness(215, 10, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 180;
            C.HEIGHT = 180;
            C.Margin = new Thickness(24, 200, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 320;
            D.HEIGHT = 180;
            D.Margin = new Thickness(215, 200, 0, 0);
            PHOTOS.Children.Add(D);
        }
    }



    class Photo_L4C : PhotoViewer
    {
        public override void Init()
        {

            setKey("L");






            PhotoView A = new PhotoView();
            A.WIDTH = 320;
            A.HEIGHT = 180;
            A.Margin = new Thickness(24, 10, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 180;
            B.HEIGHT = 180;
            B.Margin = new Thickness(354, 10, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 320;
            C.HEIGHT = 180;
            C.Margin = new Thickness(24, 200, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 180;
            D.HEIGHT = 180;
            D.Margin = new Thickness(354, 200, 0, 0);
            PHOTOS.Children.Add(D);
        }

    }














    class Photo_L4D : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");


            CompositeTransform Com = new CompositeTransform();
            //Com.CenterX = A.WIDTH / 2;

            Com.Rotation = 5;



            PhotoView A = new PhotoView();
            A.WIDTH = 250;
            A.HEIGHT = 180;
            A.Margin = new Thickness(24, 3, 0, 0);
            A.RenderTransform = Com;
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 250;
            B.HEIGHT = 180;
            B.Margin = new Thickness(284, 3, 0, 0);
            B.RenderTransform = Com;
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 250;
            C.HEIGHT = 180;
            C.Margin = new Thickness(24, 193, 0, 0);
            C.RenderTransform = Com;
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 250;
            D.HEIGHT = 180;
            D.Margin = new Thickness(284, 193, 0, 0);
            D.RenderTransform = Com;
            PHOTOS.Children.Add(D);
        }

    }












    class Photo_L4E : PhotoViewer
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



            /*
            PhotoView F = new PhotoView();
            F.WIDTH = 170;
            F.HEIGHT = 180;
            F.Margin = new Thickness(190 + 180, 200, 0, 0);
            PHOTOS.Children.Add(F);
            */
        }
    }






    class Photo_L4F : PhotoViewer
    {



        public override void Init()
        {




            setKey("L");








            PhotoView A = new PhotoView();
            A.WIDTH = 350;
            A.HEIGHT = 180;
            A.Margin = new Thickness(10, 10, 0, 0);
            PHOTOS.Children.Add(A);


            PhotoView B = new PhotoView();

            B.WIDTH = 170;
            B.HEIGHT = 180;
            B.Margin = new Thickness(10, 200, 0, 0);
            PHOTOS.Children.Add(B);



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
            E.HEIGHT = 370;
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




    class Photo_L4G : PhotoViewer
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





    class Photo_L4H : PhotoViewer
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
