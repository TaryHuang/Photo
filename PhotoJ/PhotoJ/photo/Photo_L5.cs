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

    


    class Photo_L5A : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");






            PhotoView A = new PhotoView();
            A.WIDTH = 250;
            A.HEIGHT = 150;
            A.Margin = new Thickness(24, 10, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 250;
            B.HEIGHT = 150;
            B.Margin = new Thickness(284, 10, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 165;
            C.HEIGHT = 210;
            C.Margin = new Thickness(24, 170, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 165;
            D.HEIGHT = 210;
            D.Margin = new Thickness(197, 170, 0, 0);
            PHOTOS.Children.Add(D);



            PhotoView E = new PhotoView();
            E.WIDTH = 165;
            E.HEIGHT = 210;
            E.Margin = new Thickness(369, 170, 0, 0);
            PHOTOS.Children.Add(E);
        }

    }







    class Photo_L5B : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");






            PhotoView A = new PhotoView();
            A.WIDTH = 250;
            A.HEIGHT = 150;
            A.Margin = new Thickness(24, 230, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 250;
            B.HEIGHT = 150;
            B.Margin = new Thickness(284, 230, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 165;
            C.HEIGHT = 210;
            C.Margin = new Thickness(24, 10, 0, 0);
            PHOTOS.Children.Add(C);


            PhotoView D = new PhotoView();
            D.WIDTH = 165;
            D.HEIGHT = 210;
            D.Margin = new Thickness(197, 10, 0, 0);
            PHOTOS.Children.Add(D);



            PhotoView E = new PhotoView();
            E.WIDTH = 165;
            E.HEIGHT = 210;
            E.Margin = new Thickness(369, 10, 0, 0);
            PHOTOS.Children.Add(E);
        }

    }











    class Photo_L5C : PhotoViewer
    {



        public override void Init()
        {

            setKey("L");








            PhotoView A = new PhotoView();
            A.WIDTH = 180;
            A.HEIGHT = 180;
            A.Margin = new Thickness(15, 10, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 180;
            B.HEIGHT = 180;
            B.Margin = new Thickness(205, 10, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView C = new PhotoView();
            C.WIDTH = 180;
            C.HEIGHT = 180;
            C.Margin = new Thickness(15, 200, 0, 0);
            PHOTOS.Children.Add(C);




            PhotoView D = new PhotoView();
            D.WIDTH = 180;
            D.HEIGHT = 180;
            D.Margin = new Thickness(205, 200, 0, 0);
            PHOTOS.Children.Add(D);





            PhotoView E = new PhotoView();
            E.WIDTH = 145;
            E.HEIGHT = 370;
            E.Margin = new Thickness(395, 10, 0, 0);
            PHOTOS.Children.Add(E);


        }

    }








    class Photo_L5D : PhotoViewer
    {




        public override void Init()
        {

            setKey("L");








            PhotoView A = new PhotoView();
            A.WIDTH = 180;
            A.HEIGHT = 180;
            A.Margin = new Thickness(170, 10, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 180;
            B.HEIGHT = 180;
            B.Margin = new Thickness(360, 10, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView C = new PhotoView();
            C.WIDTH = 180;
            C.HEIGHT = 180;
            C.Margin = new Thickness(170, 200, 0, 0);
            PHOTOS.Children.Add(C);




            PhotoView D = new PhotoView();
            D.WIDTH = 180;
            D.HEIGHT = 180;
            D.Margin = new Thickness(360, 200, 0, 0);
            PHOTOS.Children.Add(D);





            PhotoView E = new PhotoView();
            E.WIDTH = 145;
            E.HEIGHT = 370;
            E.Margin = new Thickness(15, 10, 0, 0);
            PHOTOS.Children.Add(E);


        }
    }









    class Photo_L5E : PhotoViewer
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


            PhotoView F = new PhotoView();
            F.WIDTH = 170;
            F.HEIGHT = 180;
            F.Margin = new Thickness(190 + 180, 200, 0, 0);
            PHOTOS.Children.Add(F);

        }
    }








    class Photo_L5F : PhotoViewer
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






    class Photo_L5G : PhotoViewer
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



            
            PhotoView F = new PhotoView();
            F.WIDTH = 170;
            F.HEIGHT = 180;
            F.Margin = new Thickness(190 + 180, 200, 0, 0);
            PHOTOS.Children.Add(F);
            
        }
    }
}
