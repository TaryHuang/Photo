using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Diagnostics;

namespace PhotoJ
{
    public class MyOBJ : Grid
    {
        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer dtAphia = new DispatcherTimer();
        public int ERI;//目前是幾次
        //只能使用在正方形
        int v = 0;//目前是幾次
        int V_SIZE = 5;//固定放大縮小寬度高度+多少
        public int V_MaxBAN = 0;//只能放大幾次
        public int V_MinBAN = 0;//只能縮小幾次

        bool MFour = false;
        bool MThree = false;
        bool Mboth = false;
        double L, Lx, Ly, L2, Lx2, Ly2,m,m2;



        bool RecT = false;//是否已經按下
        double Rotation = 0;
        
        
        Canvas Bg =new Canvas();//移動控制專用 (因為圖片要用旋轉)   選轉跟移動不能同事並存
        public Image Img=new Image();
        TranslateTransform BgTform=new TranslateTransform();


        Rectangle Rec = new Rectangle();
        TranslateTransform RecTform = new TranslateTransform();


        double V_WIDTH, V_HEIGHT;//原大小

        public MyOBJ(int eri,BitmapImage Bmg, double width,double height)
        {
            ERI = eri;

            

            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);

            Bmg.CreateOptions = BitmapCreateOptions.None;

            dt.Interval = TimeSpan.FromMilliseconds(30);
            dt.Tick +=new EventHandler(dt_Tick);
            dt.Stop();


            dtAphia.Interval = TimeSpan.FromMilliseconds(90);
            dtAphia.Tick += new EventHandler(dtAphia_Tick);
            dtAphia.Stop();


            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;



            Img.Source = Bmg;
            Img.Width = width;
            Img.Height = height;


            Bg.Children.Add(Img);
            Bg.RenderTransform = BgTform;
            Children.Add(Bg);



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
                }
                else
                {
                    Img.Opacity += 0.05f;
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



                    m = (touchPoints[0].Position.Y - touchPoints[1].Position.Y) / touchPoints[0].Position.X - touchPoints[1].Position.X;


                    m2 = m;



                    dtAphia.Stop();
                    dt.Stop();
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







                /*
                m =  (touchPoints[0].Position.Y - touchPoints[1].Position.Y) / (touchPoints[0].Position.X - touchPoints[1].Position.X);

                Debug.WriteLine((Math.Abs(m - m2)).ToString());
                 if (Math.Abs(m - m2) > 0.02)
                 {
                   //  if (touchPoints[0].Position.Y > touchPoints[1].Position.Y)
                   // {

                     if (m > m2)
                     {
                         if (Math.Abs(m - m2) < 0.02)
                         {
                             Angle -= 1;

                         }
                         else if (Math.Abs(m - m2) < 0.03)
                         {
                             Angle -= 2;
                         }
                         else if (Math.Abs(m - m2) < 0.04)
                         {
                             Angle -= 3;
                         }
                         else if (Math.Abs(m - m2) < 0.05)
                         {
                             Angle -= 4;
                         }
                         
                     }
                     else
                     {
                         if (Math.Abs(m - m2) < 0.02)
                         {
                             Angle += 1;

                         }
                         else if (Math.Abs(m - m2) < 0.03)
                         {
                             Angle += 2;
                         }
                         else if (Math.Abs(m - m2) < 0.04)
                         {
                             Angle += 3;
                         }
                         else if (Math.Abs(m - m2) < 0.05)
                         {
                             Angle += 4;
                         }
                     }
                    //}
                     
                }


                m2=m;
               */
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
                    dtAphia.Start();
                    dt.Stop();
                }
            }
            else
            {
               
                dt.Stop();
                dtAphia.Stop();
                Mboth = false;
                MThree = false;
                MFour = false;
            }

        }


        private void Rec_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            
            RecT = true;
            Rec.Fill = new SolidColorBrush(Color.FromArgb(50, 255, 0, 0));            
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
            }
        }

        void setSize(double W,double H)
        {
            V_WIDTH = W;
            V_HEIGHT = H;


            int R=8;




            if (V_WIDTH >= 50 && V_HEIGHT >= 50)
            {
                if (V_WIDTH > V_HEIGHT)
                {
                    R = (int)(V_WIDTH / 50) + 8;


                    V_MinBAN = -1 * (int)((V_HEIGHT - (V_HEIGHT / R)) / V_SIZE);

                    V_MaxBAN = (int)((V_HEIGHT * R) - V_HEIGHT) / V_SIZE;
                }
                else
                {
                    R = (int)(V_HEIGHT / 50) + 8;


                    V_MinBAN = -1 * (int)((V_WIDTH - (V_WIDTH / R)) / V_SIZE);

                    V_MaxBAN = (int)((V_WIDTH * R) - V_WIDTH) / V_SIZE;

                }
            }


            //Debug.WriteLine(V_MinBAN.ToString()+","+V_MaxBAN.ToString());
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
                double H ;
                double W ;

                if (V_WIDTH >= V_HEIGHT)
                {
                    H = V_HEIGHT + (v * V_SIZE);
                    W = (H * V_WIDTH) / V_HEIGHT;
                }
                else
                {
                    W = V_WIDTH + (v * V_SIZE);
                    H = (W * V_HEIGHT) / V_WIDTH;
                }
                
                myWidth = W;
                myHeight = H;


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
                Img.Width = value;
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
                Img.Height = value;
                Rec.Height = value;
            }
        }

    }
}
