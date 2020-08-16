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
    public class objList
    {

        List<obj> list = new List<obj>();
        int ERINO = 0;
        public  objList()
        {
            Init();
        }
        public void Init()
        {

            //可愛圖片@@@@@@@@@@@@@@@@@@@@@@@
            ADD(1, "cute/love0.png", 197, 179);
            ADD(1, "cute/love1.png", 100, 100);
            ADD(1, "cute/love2.png", 100, 100);
            ADD(1, "cute/love3.png", 128, 128);
            ADD(1, "cute/love4.png", 128, 128);
            ADD(1, "cute/love5.png", 256, 256);
            ADD(1, "cute/love6.png", 256, 256);
            ADD(1, "cute/love7.png", 256, 256);
            ADD(1, "cute/love10.png", 173, 103);




            ADD(1, "cute/a001.png", 200, 200);
            ADD(1, "cute/a002.png", 200, 200);
            ADD(1, "cute/a003.png", 200, 200);

            ADD(1, "cute/star1.png", 171, 171);
            ADD(1, "cute/star2.png", 171, 171);
            ADD(1, "cute/star3.png", 171, 171);
            ADD(1, "cute/star4.png", 171, 171);
            ADD(1, "cute/star5.png", 171, 171);
            ADD(1, "cute/star6.png", 171, 171);
            ADD(1, "cute/star7.png", 171, 171);
            ADD(1, "cute/star8.png", 171, 171);

            ADD(1, "cute/knot00.png", 150, 126);
            ADD(1, "cute/knot01.png", 150, 126);
            ADD(1, "cute/knot02.png", 150, 126);
            ADD(1, "cute/knot03.png", 150, 126);
            ADD(1, "cute/knot04.png", 150, 126);
            
            ADD(1, "cute/b1.png", 171, 171);
            ADD(1, "cute/b2.png", 171, 171);






            ADD(1, "cute/C1.png", 343, 221);
            ADD(1, "cute/C2.png", 343, 221);
            ADD(1, "cute/C3.png", 343, 221);
            ADD(1, "cute/C4.png", 343, 221);






            ADD(1, "cute/pin1.png", 223, 359);
            ADD(1, "cute/pin2.png", 223, 359);
            ADD(1, "cute/pin3.png", 223, 359);
            ADD(1, "cute/pin4.png", 223, 359);
            ADD(1, "cute/pin5.png", 223, 359);
            ADD(1, "cute/pin6.png", 223, 359);




            ADD(1, "cute/z1.png", 128, 128);
            ADD(1, "cute/z2.png", 128, 128);
            ADD(1, "cute/z3.png", 128, 128);
            ADD(1, "cute/z4.png", 129, 113);
            ADD(1, "cute/z5.png", 256, 256);
            ADD(1, "cute/P1.png", 241, 318);





            //表情符號@@@@@@@@@@@@@@@@@@@@@@@




            ADD(0, "0/LIKE01.png", 305, 286);
            ADD(0, "0/LIKE02.png", 305, 286);
            ADD(0, "0/LIKE03.png", 305, 286);


            ADD(0, "0/loser.png", 231, 270);
            ADD(0, "0/ok.png", 123, 109);
            


            ADD(0, "0/SIGN01.png", 194, 109);
            ADD(0, "0/SIGN02.png", 194, 109);
            ADD(0, "0/SIGN03.png", 194, 109);

            ADD(0, "0/SIGN04.png", 102, 69);
            ADD(0, "0/SIGN05.png", 144, 145);
            ADD(0, "0/SIGN06.png", 164, 145);






            ADD(0, "0/S1.png", 300, 305);
            ADD(0, "0/S2.png", 300, 254);
            ADD(0, "0/S3.png", 164, 145);

            ADD(0, "0/S4.png", 300, 320);
            ADD(0, "0/S5.png", 302, 238);
            ADD(0, "0/S6.png", 250, 149);


            ADD(0, "0/t1.png", 108, 73);
            ADD(0, "0/t2.png", 108, 73);


            ADD(0, "0/01.png", 256, 256);
            ADD(0, "0/02.png", 256, 256);
            ADD(0, "0/03.png", 256, 256);
            ADD(0, "0/04.png", 256, 256);
            ADD(0, "0/05.png", 256, 256);
            ADD(0, "0/06.png", 256, 256);
            ADD(0, "0/07.png", 256, 256);
            ADD(0, "0/08.png", 256, 256);
            ADD(0, "0/09.png", 256, 256);
            ADD(0, "0/10.png", 256, 256);
            ADD(0, "0/11.png", 256, 256);
            ADD(0, "0/12.png", 256, 256);





            //裝飾用品@@@@@@@@@@@@@@@@@@@@@@@
            int thing = 2;

            ADD(thing, "thing/t1.png", 341, 270);
            ADD(thing, "thing/t2.png", 341, 270);
            ADD(thing, "thing/t3.png", 341, 270);
            ADD(thing, "thing/t4.png", 341, 270);
            ADD(thing, "thing/t5.png", 341, 270);
            ADD(thing, "thing/p1.png", 214, 123);
            ADD(thing, "thing/p2.png", 256, 256);
            ADD(thing, "thing/p3.png", 323, 300);

            ADD(thing, "thing/01.png", 318, 293);
            ADD(thing, "thing/02.png", 318, 293);
            ADD(thing, "thing/03.png", 318, 293);
            ADD(thing, "thing/Lip01.png", 161, 159);
            ADD(thing, "thing/Lip02.png", 161, 159);
            ADD(thing, "thing/Lips01.png", 280, 210);
            ADD(thing, "thing/Lips02.png", 280, 210);



            //水果食物@@@@@@@@@@@@@@@@@@@@@@@
            int food =3;
            ADD(food, "FOOD/a01.png", 128, 128);
            ADD(food, "FOOD/a02.png", 128, 128);
            ADD(food, "FOOD/a03.png", 128, 128);
            ADD(food, "FOOD/a04.png", 256, 256);
            ADD(food, "FOOD/a05.png", 128, 128);
            ADD(food, "FOOD/a06.png", 128, 128);
            ADD(food, "FOOD/a07.png", 256, 256);
            ADD(food, "FOOD/a08.png", 200, 198);
            ADD(food, "FOOD/a09.png", 250, 255);


            ADD(food, "FOOD/b01.png", 256, 256);
            ADD(food, "FOOD/b02.png", 200, 359);
            ADD(food, "FOOD/b03.png", 300, 192);

            ADD(food, "FOOD/c01.png", 128, 128);
            ADD(food, "FOOD/c02.png", 128, 128);
            ADD(food, "FOOD/c03.png", 128, 128);
            ADD(food, "FOOD/c04.png", 128, 128);
            ADD(food, "FOOD/c05.png", 300, 146);
            ADD(food, "FOOD/c06.png", 300, 146);
            ADD(food, "FOOD/c07.png", 300, 146);
            ADD(food, "FOOD/c08.png", 300, 146);
            ADD(food, "FOOD/c09.png", 200, 220);
            ADD(food, "FOOD/c10.png", 233, 196);
            ADD(food, "FOOD/c11.png", 297, 168);





            //花草樹木@@@@@@@@@@@@@@@@@@@@@@@
            int flower =4;
            ADD(flower, "flower/a00.png", 181, 349);
            ADD(flower, "flower/a01.png", 256, 256);
            ADD(flower, "flower/a02.png", 256, 256);
            ADD(flower, "flower/a03.png", 256, 256);
            ADD(flower, "flower/a04.png", 256, 256);
            ADD(flower, "flower/a05.png", 256, 256);
            ADD(flower, "flower/a06.png", 256, 256);
            ADD(flower, "flower/a07.png", 92, 50);


            ADD(flower, "flower/b01.png", 209, 204);

            ADD(flower, "flower/c01.png", 313, 505);
            ADD(flower, "flower/c02.png", 200, 200);
            ADD(flower, "flower/c03.png", 200, 189);
            ADD(flower, "flower/c04.png", 338, 306);


            //生日@@@@@@@@@@@@@@@@@@@@@@@
            int birth = 5;
            ADD(birth, "birthday/cake01.png", 256, 256);
            ADD(birth, "birthday/cake02.png", 256, 256);
            ADD(birth, "birthday/cake03.png", 64, 64);
            ADD(birth, "birthday/cake04.png", 256, 256);
            ADD(birth, "birthday/cake05.png", 128, 128);
            ADD(birth, "birthday/cake06.png", 128, 128);
            ADD(birth, "birthday/cake07.png", 256, 256);

            ADD(birth, "birthday/gift01.png", 128, 128);
            ADD(birth, "birthday/gift02.png", 256, 256);
            ADD(birth, "birthday/gift03.png", 256, 256);
            ADD(birth, "birthday/gift04.png", 256, 256);
            ADD(birth, "birthday/gift05.png", 256, 256);



            //標語節慶@@@@@@@@@@@@@@@@@@
            int sign = 6;

            ADD(sign, "sign/V1.png", 343, 221);
            ADD(sign, "sign/V2.png", 343, 221);
            ADD(sign, "sign/V3.png", 343, 221);


            ADD(sign, "sign/V4.png", 343, 221);
            ADD(sign, "sign/V5.png", 343, 221);
            ADD(sign, "sign/V6.png", 343, 221);


            ADD(sign, "sign/wL1.png", 500, 180);
            ADD(sign, "sign/wL2.png", 500, 180);
            ADD(sign, "sign/wL3.png", 500, 180);

            ADD(sign, "sign/wM1.png", 500, 180);
            ADD(sign, "sign/wM2.png", 500, 180);
            ADD(sign, "sign/wM3.png", 500, 180);


            ADD(sign, "sign/wS1.png", 500, 180);
            ADD(sign, "sign/wS2.png", 500, 180);
            ADD(sign, "sign/wS3.png", 500, 180);






            //搞鬼@@@@@@@@@@@@@@@@@@
            int ghost = 7;


            ADD(ghost, "ghost/A1.png", 250, 270);
            ADD(ghost, "ghost/A2.png", 250, 270);
            ADD(ghost, "ghost/A3.png", 231, 252);
            ADD(ghost, "ghost/A4.png", 231, 252);
            ADD(ghost, "ghost/B1.png", 148, 168);
            ADD(ghost, "ghost/B2.png", 148, 168);
            ADD(ghost, "ghost/B3.png", 241, 253);
            ADD(ghost, "ghost/B4.png", 241, 253);

            ADD(ghost, "ghost/P1.png", 146, 388);
            ADD(ghost, "ghost/P2.png", 139, 251);
            ADD(ghost, "ghost/P3.png", 105, 304);
            ADD(ghost, "ghost/P4.png", 87, 64);
            ADD(ghost, "ghost/P5.png", 293, 262);
            ADD(ghost, "ghost/P6.png", 293, 262);
            ADD(ghost, "ghost/P7.png", 200, 291);
            ADD(ghost, "ghost/P8.png", 200, 291);
            ADD(ghost, "ghost/P9.png", 186, 180);
            ADD(ghost, "ghost/P10.png", 186, 180);

            ADD(ghost, "ghost/P12.png", 99, 158);
            ADD(ghost, "ghost/P13.png", 271, 217);
            ADD(ghost, "ghost/P14.png", 347, 473);
            ADD(ghost, "ghost/P15.png", 400, 400);


            ADD(ghost, "ghost/C1.png", 300, 342);
            ADD(ghost, "ghost/C2.png", 300, 342);
            ADD(ghost, "ghost/C3.png", 300, 342);


            ADD(ghost, "ghost/V1.png", 73, 84);
            ADD(ghost, "ghost/V2.png", 132, 253);
            ADD(ghost, "ghost/V3.png", 94, 349);
            ADD(ghost, "ghost/V4.png", 54, 214);
            ADD(ghost, "ghost/V5.png", 412, 519);
            ADD(ghost, "ghost/V6.png", 132, 177);
            ADD(ghost, "ghost/V7.png", 500, 483);
            ADD(ghost, "ghost/V8.png", 472, 500);
            ADD(ghost, "ghost/V9.png", 275, 183);



            ADD(ghost, "ghost/Z1.png", 512, 344);
            ADD(ghost, "ghost/Z2.png", 400, 396);

            ADD(ghost, "ghost/Z3.png", 75, 275);
            ADD(ghost, "ghost/Z4.png", 90, 342);


            //紋身造型@@@@@@@@@@@@@@@@@@
            int mark = 8;

            ADD(mark, "mark/a01.png", 139, 139);
            ADD(mark, "mark/a02.png", 139, 139);
            ADD(mark, "mark/a03.png", 254, 422);
            ADD(mark, "mark/a04.png", 254, 422);
            ADD(mark, "mark/a05.png", 377, 377);
            ADD(mark, "mark/a06.png", 377, 377);
            ADD(mark, "mark/a07.png", 259, 360);
            ADD(mark, "mark/a08.png", 259, 360);

            ADD(mark, "mark/h01.png", 422, 419);
            ADD(mark, "mark/h02.png", 422, 419);
            ADD(mark, "mark/h03.png", 422, 419);
            ADD(mark, "mark/h04.png", 506, 498);
            ADD(mark, "mark/h05.png", 506, 498);
            ADD(mark, "mark/h06.png", 459, 454);
            ADD(mark, "mark/h07.png", 459, 454);
            ADD(mark, "mark/h08.png", 459, 454);
            ADD(mark, "mark/h09.png", 484, 474);
            ADD(mark, "mark/h10.png", 484, 474);
            ADD(mark, "mark/h11.png", 484, 474);
            ADD(mark, "mark/h12.png", 177, 176);
            ADD(mark, "mark/h13.png", 177, 176);
            ADD(mark, "mark/h14.png", 177, 176);
            ADD(mark, "mark/Z01.png", 483, 51);




            //煙火雲霧@@@@@@@@@@@@@@@@@@
            int firework = 9;

            ADD(firework, "Firework/a01.png", 276, 392);
            ADD(firework, "Firework/a02.png", 276, 392);
            ADD(firework, "Firework/a03.png", 276, 392);
            ADD(firework, "Firework/a04.png", 276, 392);

            ADD(firework, "Firework/a05.png", 248, 225);
            ADD(firework, "Firework/a06.png", 290, 299);
            ADD(firework, "Firework/a07.png", 260, 269);
            ADD(firework, "Firework/a08.png", 285, 312);
            ADD(firework, "Firework/a09.png", 230, 222);
            ADD(firework, "Firework/a10.png", 508, 438);
            ADD(firework, "Firework/a11.png", 286, 255);
            ADD(firework, "Firework/a12.png", 265, 241);
            ADD(firework, "Firework/a13.png", 573, 543);

            ADD(firework, "Firework/b01.png", 547, 352);
            ADD(firework, "Firework/b02.png", 511, 408);
            ADD(firework, "Firework/b03.png", 507, 768);
            ADD(firework, "Firework/b04.png", 659, 478);

        }


        public List<obj> List(int sort)
        {
            return (from table in list
                    where table.SORT == sort
                    orderby table.ID 
                    select table).ToList();
        }

        

        public void ADD(int sort, string cname, double W,double H)
        {
            obj A = new obj();
            A.ID = ERINO++;
            A.SORT = sort;
            A.myWidth = W;
            A.myHeight = H;
            A.CNAME = cname;
            list.Add(A);
        }


    }


    public class obj : StackPanel
    {
            public int ID;
            public int SORT;
            public string cname;
            public double myWidth;
            public double myHeight;
            public Image IMG = new Image();
            public BitmapImage Bimg = new BitmapImage();


            public obj()
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
                    Bimg.UriSource = new Uri("/PhotoJ;component/image/" + cname, UriKind.RelativeOrAbsolute);
                    IMG.Source = Bimg;
                    IMG.Height = 55;
                    



                    //交叉相乘

                    double H = 55;
                    double W = (H * myWidth) / myHeight;

                    if(W>150){
                        //限制大小

                        IMG.Width = W;

                        this.Width = 150;
                        this.Height = 55;
                    }
                    
                }
            }
    }
}
