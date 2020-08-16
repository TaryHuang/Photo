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
    public class maskList
    {

        List<mask> list = new List<mask>();
        int ERINO = 0;
        public maskList()
        {
            Init();
        }
        public void Init()
        {


            ADD(0, "null.png", "0", 100, 75);
            
            ADD(0, "mask/M/L1.png", "1", 100, 75);
            ADD(0, "mask/M/L2.png", "2", 100, 75);
            ADD(0, "mask/M/L3.png", "3", 100, 75);
            ADD(0, "mask/M/L4.png", "4", 100, 75);
            ADD(0, "mask/M/L5.png", "5", 100, 75);
            //ADD(0, "mask/M/L4.png", "6", 100, 75);
            ADD(0, "mask/M/L7.png", "7", 100, 75);
            
            ADD(1, "mask/M/L18.png", "mask/V18.png", 100, 75);
            ADD(1, "mask/M/L19.png", "mask/V19.png", 100, 75);
            ADD(1, "mask/M/L20.png", "mask/V20.png", 100, 75);
            ADD(1, "mask/M/L21.png", "mask/V21.png", 100, 75);
            ADD(1, "mask/M/L22.png", "mask/V22.png", 100, 75);
            ADD(1, "mask/M/L23.png", "mask/V23.png", 100, 75);
            ADD(1, "mask/M/L24.png", "mask/V24.png", 100, 75);
            ADD(1, "mask/M/L25.png", "mask/V25.png", 100, 75);
            ADD(1, "mask/M/L26.png", "mask/V26.png", 100, 75);
            ADD(1, "mask/M/L27.png", "mask/V27.png", 100, 75);
            ADD(1, "mask/M/L28.png", "mask/V28.png", 100, 75);




            ADD(1, "mask/M/L29.png", "mask/V29.png", 100, 75);
            ADD(1, "mask/M/L30.png", "mask/V30.png", 100, 75);
            ADD(1, "mask/M/L31.png", "mask/V31.png", 100, 75);
            ADD(1, "mask/M/L32.png", "mask/V32.png", 100, 75);
            ADD(1, "mask/M/L33.png", "mask/V33.png", 100, 75);
            ADD(1, "mask/M/L34.png", "mask/V34.png", 100, 75);

            ADD(1, "mask/M/L35.png", "mask/V35.png", 100, 75);
            ADD(1, "mask/M/L36.png", "mask/V36.png", 100, 75);






            ADD(1, "mask/M/L37.png", "mask/V37.png", 100, 75);
            ADD(1, "mask/M/L38.png", "mask/V38.png", 100, 75);

            ADD(1, "mask/M/L39.png", "mask/V39.png", 100, 75);
            ADD(1, "mask/M/L40.png", "mask/V40.png", 100, 75);

            ADD(1, "mask/M/L41.png", "mask/V41.png", 100, 75);
            ADD(1, "mask/M/L42.png", "mask/V42.png", 100, 75);


        }


        public List<mask> List()
        {
            return (from table in list
                    orderby table.SORT ,table.ID 
                    select table).ToList();
        }



        public void ADD(int sort, string cname, string bg, double W, double H)
        {
            mask A = new mask();
            A.ID = ERINO++;
            A.SORT = sort;

            A.BG = A.SORT == 1 ? "/PhotoJ;component/image/" + bg : bg;
            A.myWidth = W;
            A.myHeight = H;
            A.CNAME = cname;
            list.Add(A);
        }


    }


    public class mask : StackPanel
    {
            public int ID;
            public int SORT;
            public string cname;
            public string BG;//
            public double myWidth;
            public double myHeight;
            public Image IMG = new Image();
            public BitmapImage Bimg = new BitmapImage();


            public mask()
            {
                this.Margin = new Thickness(5, 0, 10, 0);
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
                    Bimg.UriSource = new Uri("/PhotoJ;component/image/" + cname, UriKind.RelativeOrAbsolute);
                    IMG.Source = Bimg;
                    IMG.Height = 75;
                    



                    //交叉相乘

                    double H = 75;
                    double W = (H * myWidth) / myHeight;

                    if(W>150){
                        //限制大小

                        IMG.Width = W;

                        this.Width = 100;
                        this.Height = 75;
                    }
                    
                }
            }
    }
}
