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

    


    class Photo_P7A : PhotoViewer
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
            C.HEIGHT = 338;
            C.Margin = new Thickness(16, 275, 0, 0);
            PHOTOS.Children.Add(C);








            PhotoView E = new PhotoView();
            E.WIDTH = 139;
            E.HEIGHT = 165;
            E.Margin = new Thickness(296, 275, 0, 0);
            PHOTOS.Children.Add(E);


            PhotoView F = new PhotoView();
            F.WIDTH = 139;
            F.HEIGHT = 165;
            F.Margin = new Thickness(296, 446, 0, 0);
            PHOTOS.Children.Add(F);









            PhotoView G = new PhotoView();
            G.WIDTH = 135;
            G.HEIGHT = 165;
            G.Margin = new Thickness(156, 275, 0, 0);
            PHOTOS.Children.Add(G);


            PhotoView H = new PhotoView();
            H.WIDTH = 135;
            H.HEIGHT = 165;
            H.Margin = new Thickness(156, 446, 0, 0);
            PHOTOS.Children.Add(H);



        }

    }
















    class Photo_P7B: PhotoViewer
    {



        public override void Init()
        {

            setKey("P");






            PhotoView A = new PhotoView();
            A.WIDTH = 206;
            A.HEIGHT = 240;
            A.Margin = new Thickness(16, 375, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 206;
            B.HEIGHT = 240;
            B.Margin = new Thickness(229, 375, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 135;
            C.HEIGHT = 338;
            C.Margin = new Thickness(16, 27, 0, 0);
            PHOTOS.Children.Add(C);








            PhotoView E = new PhotoView();
            E.WIDTH = 139;
            E.HEIGHT = 165;
            E.Margin = new Thickness(296, 27, 0, 0);
            PHOTOS.Children.Add(E);


            PhotoView F = new PhotoView();
            F.WIDTH = 139;
            F.HEIGHT = 165;
            F.Margin = new Thickness(296, 198, 0, 0);
            PHOTOS.Children.Add(F);









            PhotoView G = new PhotoView();
            G.WIDTH = 135;
            G.HEIGHT = 165;
            G.Margin = new Thickness(156, 27, 0, 0);
            PHOTOS.Children.Add(G);


            PhotoView H = new PhotoView();
            H.WIDTH = 135;
            H.HEIGHT = 165;
            H.Margin = new Thickness(156, 198, 0, 0);
            PHOTOS.Children.Add(H);



        }

    }









    class Photo_P7C : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");



            PhotoView A = new PhotoView();
            A.WIDTH = 206;
            A.HEIGHT = 200;
            A.Margin = new Thickness(16, 212, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 206;
            B.HEIGHT = 200;
            B.Margin = new Thickness(229, 212, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 206;
            C.HEIGHT = 200;
            C.Margin = new Thickness(16, 423, 0, 0);
            PHOTOS.Children.Add(C);





            PhotoView D = new PhotoView();
            D.WIDTH = 206;
            D.HEIGHT = 200;
            D.Margin = new Thickness(229, 423, 0, 0);
            PHOTOS.Children.Add(D);











            PhotoView F = new PhotoView();
            F.WIDTH = 136;
            F.HEIGHT = 190;
            F.Margin = new Thickness(16, 17, 0, 0);
            PHOTOS.Children.Add(F);





            PhotoView G = new PhotoView();
            G.WIDTH = 136;
            G.HEIGHT = 190;
            G.Margin = new Thickness(158, 17, 0, 0);
            PHOTOS.Children.Add(G);




            PhotoView H = new PhotoView();
            H.WIDTH = 136;
            H.HEIGHT = 190;
            H.Margin = new Thickness(300, 17, 0, 0);
            PHOTOS.Children.Add(H);
        }

    }










    class Photo_P7D : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");



            PhotoView A = new PhotoView();
            A.WIDTH = 206;
            A.HEIGHT = 200;
            A.Margin = new Thickness(16, 17, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();
            B.WIDTH = 206;
            B.HEIGHT = 200;
            B.Margin = new Thickness(229, 17, 0, 0);
            PHOTOS.Children.Add(B);



            PhotoView C = new PhotoView();
            C.WIDTH = 206;
            C.HEIGHT = 200;
            C.Margin = new Thickness(16, 222, 0, 0);
            PHOTOS.Children.Add(C);





            PhotoView D = new PhotoView();
            D.WIDTH = 206;
            D.HEIGHT = 200;
            D.Margin = new Thickness(229, 222, 0, 0);
            PHOTOS.Children.Add(D);











            PhotoView F = new PhotoView();
            F.WIDTH = 136;
            F.HEIGHT = 190;
            F.Margin = new Thickness(16, 427, 0, 0);
            PHOTOS.Children.Add(F);





            PhotoView G = new PhotoView();
            G.WIDTH = 136;
            G.HEIGHT = 190;
            G.Margin = new Thickness(158, 427, 0, 0);
            PHOTOS.Children.Add(G);




            PhotoView H = new PhotoView();
            H.WIDTH = 136;
            H.HEIGHT = 190;
            H.Margin = new Thickness(300, 427, 0, 0);
            PHOTOS.Children.Add(H);
        }

    }
}
