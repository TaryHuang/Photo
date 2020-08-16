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

    


    class Photo_P3A : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");
            PhotoView C = new PhotoView();
            C.WIDTH = 419;
            C.HEIGHT = 290;
            C.Margin = new Thickness(16, 334, 0, 0);
            PHOTOS.Children.Add(C);





            PhotoView A =new PhotoView();
            A.WIDTH=206;
            A.HEIGHT=309;
            A.Margin = new Thickness(16, 17, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 206;
            B.HEIGHT = 309;
            B.Margin = new Thickness(229, 17, 0, 0);
            PHOTOS.Children.Add(B);

        }

    }






    class Photo_P3B : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");

            PhotoView C = new PhotoView();
            C.WIDTH = 419;
            C.HEIGHT = 290;
            C.Margin = new Thickness(16, 17, 0, 0);
            PHOTOS.Children.Add(C);




            //base.Init();
            //450*600
            PhotoView A = new PhotoView();
            A.WIDTH = 206;
            A.HEIGHT = 309;
            A.Margin = new Thickness(16, 316, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 206;
            B.HEIGHT = 309;
            B.Margin = new Thickness(229, 316, 0, 0);
            PHOTOS.Children.Add(B);

        }

    }



    class Photo_P3C : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");
            PhotoView C = new PhotoView();
            C.WIDTH = 420;
            C.HEIGHT = 400;
            C.Margin = new Thickness((this.Width - C.WIDTH) / 2, 195, 0, 0);
            PHOTOS.Children.Add(C);




            //base.Init();
            //450*600
            PhotoView A = new PhotoView();
            A.WIDTH = 204;
            A.HEIGHT = 153;
            A.Margin = new Thickness((this.Width - C.WIDTH) / 2, 30, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 204;
            B.HEIGHT = 153;
            B.Margin = new Thickness(A.WIDTH + 12 + (this.Width - C.WIDTH) / 2, 30, 0, 0);
            PHOTOS.Children.Add(B);


        }
    }





    class Photo_P3D : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");

            PhotoView C = new PhotoView();
            C.WIDTH = 420;
            C.HEIGHT = 400;
            C.Margin = new Thickness((this.Width - C.WIDTH) / 2, 30, 0, 0);
            PHOTOS.Children.Add(C);




            //base.Init();
            //450*600
            PhotoView A = new PhotoView();
            A.WIDTH = 204;
            A.HEIGHT = 153;
            A.Margin = new Thickness((this.Width - C.WIDTH) / 2, 442, 0, 0);
            PHOTOS.Children.Add(A);



            PhotoView B = new PhotoView();

            B.WIDTH = 204;
            B.HEIGHT = 153;
            B.Margin = new Thickness(A.WIDTH + 12 + (this.Width - C.WIDTH) / 2, 442, 0, 0);
            PHOTOS.Children.Add(B);


        }
    }









    class Photo_P3E : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 430;
            A.HEIGHT = 196;
            A.Margin = new Thickness(10, 15, 0, 0);
            PHOTOS.Children.Add(A);




            PhotoView B = new PhotoView();
            B.WIDTH = 430;
            B.HEIGHT = 196;
            B.Margin = new Thickness(10, A.Margin.Top + A.HEIGHT + 10, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView C = new PhotoView();
            C.WIDTH = 430;
            C.HEIGHT = 196;
            C.Margin = new Thickness(10, B.Margin.Top+B.HEIGHT + 10, 0, 0);
            PHOTOS.Children.Add(C);

        }
    }



    class Photo_P3F : PhotoViewer
    {



        public override void Init()
        {
            setKey("P");

            PhotoView A = new PhotoView();
            A.WIDTH = 300;
            A.HEIGHT = 196;
            A.Margin = new Thickness(25, 15, 0, 0);
            PHOTOS.Children.Add(A);




            PhotoView B = new PhotoView();
            B.WIDTH = 300;
            B.HEIGHT = 196;
            B.Margin = new Thickness(25, A.Margin.Top + A.HEIGHT + 10, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView C = new PhotoView();
            C.WIDTH = 300;
            C.HEIGHT = 196;
            C.Margin = new Thickness(25, B.Margin.Top + B.HEIGHT + 10, 0, 0);
            PHOTOS.Children.Add(C);

        }
    }








    class Photo_P3G : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 300;
            A.HEIGHT = 196;
            A.Margin = new Thickness(25, 15, 0, 0);
            PHOTOS.Children.Add(A);




            PhotoView B = new PhotoView();
            B.WIDTH = 300;
            B.HEIGHT = 196;
            B.Margin = new Thickness(130, A.Margin.Top + A.HEIGHT + 10, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView C = new PhotoView();
            C.WIDTH = 300;
            C.HEIGHT = 196;
            C.Margin = new Thickness(25, B.Margin.Top + B.HEIGHT + 10, 0, 0);
            PHOTOS.Children.Add(C);

        }
    }




    class Photo_P3H : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 200;
            A.HEIGHT = 610;
            A.Margin = new Thickness(20, 15, 0, 0);
            PHOTOS.Children.Add(A);




            PhotoView B = new PhotoView();
            B.WIDTH = 200;
            B.HEIGHT = 300;
            B.Margin = new Thickness(230, 15, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView C = new PhotoView();
            C.WIDTH = 200;
            C.HEIGHT = 300;
            C.Margin = new Thickness(230, B.Margin.Top + B.HEIGHT + 10, 0, 0);
            PHOTOS.Children.Add(C);

        }
    }



    class Photo_P3I : PhotoViewer
    {



        public override void Init()
        {

            setKey("P");
            PhotoView A = new PhotoView();
            A.WIDTH = 200;
            A.HEIGHT = 610;
            A.Margin = new Thickness(230, 15, 0, 0);
            PHOTOS.Children.Add(A);




            PhotoView B = new PhotoView();
            B.WIDTH = 200;
            B.HEIGHT = 300;
            B.Margin = new Thickness(20, 15, 0, 0);
            PHOTOS.Children.Add(B);




            PhotoView C = new PhotoView();
            C.WIDTH = 200;
            C.HEIGHT = 300;
            C.Margin = new Thickness(20, B.Margin.Top + B.HEIGHT + 10, 0, 0);
            PHOTOS.Children.Add(C);

        }
    }
}
