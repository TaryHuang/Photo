using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace TARY_Library_Silverlight
{
    public class MyIMG : Grid
    {
        DispatcherTimer dt = new DispatcherTimer();

        //只能使用在正方形
        int V = 0;//目前是幾次
        int V_SIZE = 10;//固定放大縮小寬度高度+多少
        public int V_MaxBAN = 0;//只能放大幾次
        public int V_MinBAN = -0;//只能縮小幾次


        bool MThree = false;
        bool Mboth = false;
        double L, Lx, Ly, L2, Lx2, Ly2;



        bool RecT = false;//是否已經按下
        double Rotation = 0;
        
        
        Canvas Bg =new Canvas();//移動控制專用 (因為圖片要用旋轉)   選轉跟移動不能同事並存
        Image Img=new Image();
        TranslateTransform BgTform=new TranslateTransform();


        Rectangle Rec = new Rectangle();
        TranslateTransform RecTform = new TranslateTransform();

 
        public MyIMG(BitmapImage Bmg,int SIZE)
        {


            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);



            dt.Interval = TimeSpan.FromMilliseconds(30);

            dt.Tick +=new EventHandler(dt_Tick);
            dt.Stop();



            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            Img.Source = Bmg;
            Img.Width = SIZE;
            Img.Height = SIZE;
            Bg.Children.Add(Img);
            Bg.RenderTransform = BgTform;
            Children.Add(Bg);



            Rec.Width = SIZE;
            Rec.Height = SIZE;
            
            Rec.RenderTransform = RecTform;
            Rec.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            Rec.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(Rec_ManipulationStarted);
            Rec.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(Rec_ManipulationDelta);
            Rec.ManipulationCompleted +=new EventHandler<ManipulationCompletedEventArgs>(Rec_ManipulationCompleted);
            Children.Add(Rec);

            setSize(SIZE);
        }

        

        private void dt_Tick(object sender, EventArgs e)
        {
            Angle += 5;
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
                        myWidth -= V_SIZE;
                        myHeight -= V_SIZE;
                    }

                }
                else if (L < L2)
                {
                    if (V < V_MaxBAN)
                    {
                        V++;
                        myWidth += V_SIZE;
                        myHeight += V_SIZE;

                    }
                }
                Angle = Angle;
                L = L2;
                Lx = Lx2;
                Ly = Ly2;
            }
            else if (RecT && touchPoints.Count > 3)
            {
                //三點觸控 旋轉
                if (!MThree)
                {
                    MThree = true;
                    Mboth = false;
                    dt.Start();
                }
            }
            else
            {
               
                dt.Stop();
                Mboth = false;
                MThree = false;
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

        void setSize(int N)
        {
            if (N >= 50)
            {
                V_MinBAN = -((N - (N / 3)) / V_SIZE);

                V_MaxBAN = ((N * 3) - N) / V_SIZE;
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
