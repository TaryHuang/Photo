using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;


namespace PhotoJ
{
    public class imgList
    {

        List<bgImg> list = new List<bgImg>();

        public imgList()
        {
            Init();
        }
        public void Init()
        {
            ADD(0, "background/null.png", 200, 200);


            //可愛圖片@@@@@@@@@@@@@@@@@@@@@@@
            ADD(0, "background/a01.png", 200, 200);
            ADD(0, "background/a02.png", 200, 200);
            ADD(0, "background/a03.png", 200, 200);
            ADD(0, "background/a04.png", 200, 200);
            ADD(0, "background/a05.png", 200, 200);
            ADD(0, "background/a06.png", 200, 200);
            ADD(0, "background/a07.png", 200, 200);
            ADD(0, "background/a08.png", 200, 200);
            ADD(0, "background/a09.png", 200, 200);
            ADD(0, "background/a10.png", 200, 200);
            ADD(0, "background/a11.png", 200, 200);
            ADD(0, "background/a12.jpg", 200, 200);

            ADD(0, "background/a20.png", 200, 200);
            ADD(0, "background/a21.png", 200, 200);
            ADD(0, "background/a22.png", 200, 200);
            ADD(0, "background/a23.png", 200, 200);
            ADD(0, "background/a24.png", 200, 200);
            ADD(0, "background/a25.png", 200, 200);
            ADD(0, "background/a26.jpg", 200, 200);



            ADD(0, "background/b01.png", 200, 200);
            ADD(0, "background/b02.png", 200, 200);
            ADD(0, "background/b03.png", 200, 200);
            ADD(0, "background/b04.png", 200, 200);
            ADD(0, "background/c01.png", 200, 200);
            ADD(0, "background/c02.png", 200, 200);
            ADD(0, "background/c03.png", 200, 200);
            ADD(0, "background/c04.png", 200, 200);
            ADD(0, "background/c05.png", 200, 200);
            ADD(0, "background/c06.png", 200, 200); 
            ADD(0, "background/c07.png", 200, 200);
            ADD(0, "background/c08.png", 200, 200);



            ADD(0, "background/D01.jpg", 200, 200);
            ADD(0, "background/D02.jpg", 200, 200);
            ADD(0, "background/D03.jpg", 200, 200);
            ADD(0, "background/D04.jpg", 200, 200);
            ADD(0, "background/D05.jpg", 200, 200);
            ADD(0, "background/D06.jpg", 200, 200);
            ADD(0, "background/D07.jpg", 200, 200);
            ADD(0, "background/D08.jpg", 200, 200);
            ADD(0, "background/D09.jpg", 200, 200);
            ADD(0, "background/D10.jpg", 200, 200);
            ADD(0, "background/D11.jpg", 200, 200);

            ADD(0, "background/E01.jpg", 200, 200);
            ADD(0, "background/E02.jpg", 200, 200);
        }


        public List<bgImg> List()
        {
            return (from table in list
                    select table).ToList();
        }



        public void ADD(int sort, string cname, double W, double H)
        {
            bgImg A = new bgImg();

            A.SORT = sort;
            A.myWidth = W;
            A.myHeight = H;
            A.CNAME = cname;
            list.Add(A);
        }


    }


    public class bgImg : StackPanel
    {

        public int SORT;
        public string cname;
        public double myWidth;
        public double myHeight;
        public Image IMG = new Image();
        public BitmapImage Bimg = new BitmapImage();


        public bgImg()
        {
            this.Margin = new Thickness(0, 0, 10, 0);
            Children.Add(this.IMG);
        }
        public string CNAME
        {
            get
            {
                return cname;
            }

            set
            {
                cname = value;
                Bimg = new BitmapImage();
                Bimg.UriSource = new Uri("/PhotoJ;component/Images/" + cname, UriKind.RelativeOrAbsolute);
                IMG.Source = Bimg;
                IMG.Height = 55;




                //交叉相乘

                double H = 55;
                double W = (H * myWidth) / myHeight;

                if (W > 150)
                {
                    //限制大小

                    IMG.Width = W;

                    this.Width = 150;
                    this.Height = 55;
                }

            }
        }
    }

}
