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

    


    class Photo_P8A : PhotoViewer
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
            C.WIDTH = 137;
            C.HEIGHT = 165;
            C.Margin = new Thickness(16, 275, 0, 0);
            PHOTOS.Children.Add(C);

            PhotoView D = new PhotoView();
            D.WIDTH = 137;
            D.HEIGHT = 165;
            D.Margin = new Thickness(16, 446, 0, 0);
            PHOTOS.Children.Add(D);






            PhotoView E = new PhotoView();
            E.WIDTH = 137;
            E.HEIGHT = 165;
            E.Margin = new Thickness(298, 275, 0, 0);
            PHOTOS.Children.Add(E);


            PhotoView F = new PhotoView();
            F.WIDTH = 137;
            F.HEIGHT = 165;
            F.Margin = new Thickness(298, 446, 0, 0);
            PHOTOS.Children.Add(F);









            PhotoView G = new PhotoView();
            G.WIDTH = 137;
            G.HEIGHT = 165;
            G.Margin = new Thickness(157, 275, 0, 0);
            PHOTOS.Children.Add(G);


            PhotoView H = new PhotoView();
            H.WIDTH = 137;
            H.HEIGHT = 165;
            H.Margin = new Thickness(157, 446, 0, 0);
            PHOTOS.Children.Add(H);



        }

    }





    class Photo_P8B : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");






            PhotoView A = new PhotoView();
            A.WIDTH = 206;
            A.HEIGHT = 240;
            A.Margin = new Thickness(16, 369, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 206;
            B.HEIGHT = 240;
            B.Margin = new Thickness(229, 369, 0, 0);
            PHOTOS.Children.Add(B);







            PhotoView C = new PhotoView();
            C.WIDTH = 137;
            C.HEIGHT = 165;
            C.Margin = new Thickness(16, 27, 0, 0);
            PHOTOS.Children.Add(C);

            PhotoView D = new PhotoView();
            D.WIDTH = 137;
            D.HEIGHT = 165;
            D.Margin = new Thickness(16, 198, 0, 0);
            PHOTOS.Children.Add(D);






            PhotoView E = new PhotoView();
            E.WIDTH = 137;
            E.HEIGHT = 165;
            E.Margin = new Thickness(298, 27, 0, 0);
            PHOTOS.Children.Add(E);


            PhotoView F = new PhotoView();
            F.WIDTH = 137;
            F.HEIGHT = 165;
            F.Margin = new Thickness(298, 198, 0, 0);
            PHOTOS.Children.Add(F);









            PhotoView G = new PhotoView();
            G.WIDTH = 137;
            G.HEIGHT = 165;
            G.Margin = new Thickness(157, 27, 0, 0);
            PHOTOS.Children.Add(G);


            PhotoView H = new PhotoView();
            H.WIDTH = 137;
            H.HEIGHT = 165;
            H.Margin = new Thickness(157, 198, 0, 0);
            PHOTOS.Children.Add(H);



        }

    }

}
