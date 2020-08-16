using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows;
namespace PhotoJ
{
    public class MyOBJText : Grid
    {
        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer dtAphia = new DispatcherTimer();
        public int ERI;//目前是幾次

        static double marginNum=2;
        public static double MarginNum
        {
            get{
                return marginNum;
            }
        }


        public string CTYPE;//0等於文字  1等於字串
        public int FTYPE;//特效  0=無特效  1=重疊字



        //只能使用在正方形
        int v = 0;//目前是幾次
        int V_SIZE = 3;//固定放大縮小寬度高度+多少
        public int V_MaxBAN = 0;//只能放大幾次
        public int V_MinBAN = 0;//只能縮小幾次

        bool MFour = false;
        bool MThree = false;
        bool Mboth = false;
        double L, Lx, Ly, L2, Lx2, Ly2;

        

        bool RecT = false;//是否已經按下
        double Rotation = 0;
        
        
        Canvas Bg =new Canvas();//移動控制專用 (因為圖片要用旋轉)   選轉跟移動不能同事並存
        public TextBlock Img = new TextBlock();
        TranslateTransform BgTform=new TranslateTransform();


        //重疊字用
        TextBlock Img2 = new TextBlock();
        TranslateTransform ImgTform = new TranslateTransform();



        Rectangle Rec = new Rectangle();
        TranslateTransform RecTform = new TranslateTransform();


        double V_WIDTH, V_HEIGHT;//原大小

        public MyOBJText(int eri,string ctype, string str, Color color, int Font, Color color2,int ftype)
        {
            FTYPE = ftype;
            CTYPE = ctype;
            ERI = eri;
            Init();






            //粗體斜體判斷
            switch(Font){
                case 1: Img.FontWeight = FontWeights.Bold; Img2.FontWeight = FontWeights.Bold; break;
                
                case 2: Img.FontStyle = FontStyles.Italic; Img2.FontStyle = FontStyles.Italic; break;
                
                case 3: Img.FontWeight = FontWeights.Bold; 
                        Img.FontStyle = FontStyles.Italic;
                        Img2.FontWeight = FontWeights.Bold ;
                        Img2.FontStyle = FontStyles.Italic ;break;
            }






            
            //基本字串
            Img.Text = str;
            Img.Foreground = new SolidColorBrush(color);
            Img.FontSize = 34;
            Img.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Img.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            double width = StrWidth(str);
            double height = 60;
            Img.Height = height;


            //重疊字****************
            Img2.Text = str;
            Img2.Foreground = new SolidColorBrush(color2);
            Img2.FontSize = 34;
            Img2.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Img2.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Img2.Height = height;

            if (FTYPE == 0)
            {
                //代表無須重疊 隱藏重疊字
                Img2.Foreground = new SolidColorBrush(Colors.Transparent);
            }else if(FTYPE == 1){
                Img2.Margin = new Thickness(MarginNum, MarginNum, 0, 0);
            }
            else if (FTYPE == 2)
            {
                Img2.Margin = new Thickness(-MarginNum, -MarginNum, 0, 0);
            }

            //***************重疊字


            //底層Canvas
            Bg.Children.Add(Img2);
            Bg.Children.Add(Img);
            Bg.RenderTransform = BgTform;
            Children.Add(Bg);


            //方形感應器
            Rec.Width = width;
            Rec.Height = height;
            Rec.RenderTransform = RecTform;
            Rec.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            Rec.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(Rec_ManipulationStarted);
            Rec.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(Rec_ManipulationDelta);
            Rec.ManipulationCompleted +=new EventHandler<ManipulationCompletedEventArgs>(Rec_ManipulationCompleted);
            Children.Add(Rec);


            setSize(width, height);
        }



        public void Init()
        {
            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
            dt.Interval = TimeSpan.FromMilliseconds(30);
            dt.Tick += new EventHandler(dt_Tick);
            dt.Stop();




            dtAphia.Interval = TimeSpan.FromMilliseconds(90);
            dtAphia.Tick += new EventHandler(dtAphia_Tick);
            dtAphia.Stop();



            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Center;

        }

        int StrWidth(string str)
        {
            int num=0;

            for (int i = 0; i < str.Length;i++ )
            {

                if (str[i] < 10000)
                {
                    num += 20;
                }
                else
                {
                    num += 36;
                }
            }

            return num;
        }


        private void dt_Tick(object sender, EventArgs e)
        {
            if (MThree)
            {
                Angle += 5;
            }
            //else if(MFour)
            // {
            //     Angle -= 5;
            // }
        }




        private void dtAphia_Tick(object sender, EventArgs e)
        {
            if (MFour)
            {

                if (Img.Opacity >= 1.3f)
                {
                    Img.Opacity = 0.1f;
                    Img2.Opacity = 0.1f;
                }
                else
                {
                    Img.Opacity += 0.05f;
                    Img2.Opacity += 0.05f;
                }
            }

        }

        void Touch_FrameReported(object sender, TouchFrameEventArgs args)
        {


            TouchPointCollection touchPoints = args.GetTouchPoints(null);
            if (RecT && touchPoints.Count == 2)
            {
                //兩點觸控 放大縮小
                if (!Mboth)
                {
                    Lx = touchPoints[0].Position.X - touchPoints[1].Position.X;
                    Ly = touchPoints[0].Position.Y - touchPoints[1].Position.Y;
                    L = Math.Sqrt(Lx * Lx + Ly * Ly);
                    Mboth = true;
                    MThree = false;
                    MFour = false;
                    dt.Stop();
                    dtAphia.Stop();
                    return;
                }




                Lx2 = touchPoints[0].Position.X - touchPoints[1].Position.X;
                Ly2 = touchPoints[0].Position.Y - touchPoints[1].Position.Y;
                L2 = Math.Sqrt(Lx2 * Lx2 + Ly2 * Ly2);

                if (L > L2)
                {

                    if (V > V_MinBAN)
                    {
                        V--;

                    }

                }
                else if (L < L2)
                {
                    if (V < V_MaxBAN)
                    {
                        V++;
                    }
                }
                Angle = Angle;
                L = L2;
                Lx = Lx2;
                Ly = Ly2;
            }
            else if (RecT && touchPoints.Count == 3)
            {
                //三點觸控 順時針旋轉
                if (!MThree)
                {
                    MThree = true;
                    Mboth = false;
                    MFour = false;
                    dt.Start();
                    dtAphia.Stop();
                }
            }
            else if (RecT && touchPoints.Count == 4)
            {
                //四點觸控 逆時針旋轉
                if (!MFour)
                {
                    MThree = false;
                    Mboth = false;
                    MFour = true;
                    dt.Stop();
                    dtAphia.Start();
                }
            }
            else
            {
                dtAphia.Stop();
                dt.Stop();
                Mboth = false;
                MThree = false;
                MFour = false;
            }

        }


        private void Rec_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            
            RecT = true;
            Rec.Fill = new SolidColorBrush(Color.FromArgb(30, 255, 0, 0));            
        }


        private void Rec_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            if (RecT)
            {
                this.RecTform.X += e.DeltaManipulation.Translation.X;
                this.RecTform.Y += e.DeltaManipulation.Translation.Y;
                this.BgTform.X += e.DeltaManipulation.Translation.X;
                this.BgTform.Y += e.DeltaManipulation.Translation.Y;
            }
        }


        private void Rec_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

            RecT = false;
            Rec.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }



        public double TformX
        {
            get
            {
                return this.RecTform.X;

            }
            set
            {
                this.RecTform.X = value;
                this.BgTform.X = value;

            }
        }

        public double TformY
        {

            get
            {
                return this.RecTform.Y;

            }
            set
            {
                this.RecTform.Y = value;
                this.BgTform.Y = value;
            }
        }


        public double Angle
        {

            get{
                return Rotation;
            }
            set
            {
                Rotation = value;

                

                RotateTransform R = new RotateTransform();
                R.CenterX = myWidth / 2;
                R.CenterY = myHeight / 2;
                R.Angle = Rotation;

                
                Img.RenderTransform = R;
                Img2.RenderTransform = R;
            }
        }

        void setSize(double W,double H)
        {
            V_WIDTH = W;
            V_HEIGHT = H;
            /*
            if (V_WIDTH >= 50)
            {
                V_MinBAN = -3;
                V_MaxBAN = 18;
            }
            else
            {
                V_MinBAN = 0;
                V_MaxBAN = 18;

            }*/
            V_MinBAN = -12;
            V_MaxBAN = 200;
        }




        public int V
        {
            get
            {
                return v;
            }
            set
            {
                v = value;

                //交叉相乘
                double H = V_HEIGHT+(v * V_SIZE);
                double W = (H * V_WIDTH) / V_HEIGHT;

                myWidth = W;
                myHeight = H;


                Img.FontSize = 40 + v * 2;
                Img2.FontSize = 40 + v * 2;

                /*
                switch(v){
                    case -3: Img.FontSize = 18; Img2.FontSize = 18; break;
                    case -2: Img.FontSize = 26; Img2.FontSize = 26; break;
                    case -1: Img.FontSize = 34; Img2.FontSize = 34; break;
                    case 0: Img.FontSize = 40; Img2.FontSize = 40; break;
                    case 1: Img.FontSize = 48; Img2.FontSize = 48; break;
                    case 2: Img.FontSize = 56; Img2.FontSize = 56; break;
                    case 3: Img.FontSize = 64; Img2.FontSize = 64; break;
                    case 4: Img.FontSize = 72; Img2.FontSize = 72; break;
                    case 5: Img.FontSize = 80; Img2.FontSize = 80; break;
                    case 6: Img.FontSize = 88; Img2.FontSize = 88; break;
                    case 7: Img.FontSize = 96; Img2.FontSize = 96; break;
                    case 8: Img.FontSize = 108; Img2.FontSize = 108; break;
                    case 9: Img.FontSize = 116; Img2.FontSize = 116; break;
                    case 10: Img.FontSize = 124; Img2.FontSize = 124 ;break;
                    case 11: Img.FontSize = 132; Img2.FontSize = 132 ;break;
                    case 12: Img.FontSize = 140; Img2.FontSize = 140; break;
                    case 13: Img.FontSize = 148; Img2.FontSize = 148; break;
                    case 14: Img.FontSize = 156; Img2.FontSize = 156; break;
                    case 15: Img.FontSize = 164; Img2.FontSize = 164; break;
                    case 16: Img.FontSize = 172; Img2.FontSize = 172; break;
                    case 17: Img.FontSize = 180; Img2.FontSize = 180; break;
                    case 18: Img.FontSize = 188; Img2.FontSize = 188; break;
                }
                */



                //Debug.WriteLine(W.ToString() + "," + H.ToString());
            }


        }




        public double myWidth
        {
            get
            {
                return Rec.Width;
            }
            set
            {
                //Img.Width = value;
                Rec.Width = value;
            }
        }


        public double myHeight
        {
            get
            {
                return Rec.Height;
            }
            set
            {
                //Img.Height = value;
                Rec.Height = value;
            }
        }

    }
}
