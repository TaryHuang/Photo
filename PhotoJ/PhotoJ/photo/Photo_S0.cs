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




    class Photo_S0A : PhotoViewer
    {



        public override void Init()
        {
            setKey("S0A");
            PhotoKeyS = "P";
            this.Margin = new Thickness(0, 10, 0, 0);   
            this.WIDTH = 450;
            this.HEIGHT = 640;
        }

    }





    class Photo_S0B : PhotoViewer
    {



        public override void Init()
        {
            setKey("S0B");
            PhotoKeyS = "L";
            this.Margin = new Thickness(0, 0, 0, 0);   
            this.WIDTH = 560;
            this.HEIGHT = 400;

        }

    }









    class Photo_S0C : PhotoViewer
    {



        public override void Init()
        {
            setKey("S0C");
            PhotoKeyS = "P";
            this.Margin = new Thickness(0, 10, 0, 0);  
            //手機螢幕背景
            this.WIDTH = 384;//*1.2  = 480
            this.HEIGHT = 640;//*1.2  = 800
        }

    }



    class Photo_S0D : PhotoViewer
    {


        public override void Init()
        {
            setKey("S0E");
            PhotoKeyS = "L";
            this.Margin = new Thickness(0, 0, 0, 0);
            //this.WIDTH = 560;
            //this.HEIGHT = 400;

            this.WIDTH = 790;
            this.HEIGHT = 400;


        }


    }





    class Photo_S0E : PhotoViewer
    {

        public override void Init()
        {
            setKey("S0D");
            PhotoKeyS = "P";
            this.Margin = new Thickness(0, 0, 0, 0);
            //this.WIDTH = 450;
            //this.HEIGHT = 640;
            this.WIDTH = 475;
            this.HEIGHT = 680;
        }



    }

}
