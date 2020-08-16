using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using TARY_Library_Silverlight;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Windows.Threading;

using System.Windows.Ink;


namespace PhotoJ
{
    public class MyOBJdraw : Grid
    {
        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer dtAphia = new DispatcherTimer();





        //畫板專用**************
        double Rx, Ry;
        //**************畫板專用





        public int ERI;//目前是幾次
        //只能使用在正方形
        int v = 0;//目前是幾次
        int V_SIZE = 8;//固定放大縮小寬度高度+多少
        public int V_MaxBAN = 0;//只能放大幾次
        public int V_MinBAN = 0;//只能縮小幾次

        bool MFour = false;
        bool MThree = false;
        bool Mboth = false;
        double L, Lx, Ly, L2, Lx2, Ly2;



        bool RecT = false;//是否已經按下
        double Rotation = 0;


        List<double> ListX = new List<double>();
        List<double> ListY = new List<double>();
        List<int> ListStop = new List<int>();//筆畫斷點

        public Color penColor;//顏色
        public int LineSize;//線的大小


        
        Canvas Bg =new Canvas();//移動控制專用 (因為圖片要用旋轉)   選轉跟移動不能同事並存
        public InkPresenter Img = new InkPresenter();
        TranslateTransform BgTform=new TranslateTransform();


        Rectangle Rec = new Rectangle();
        TranslateTransform RecTform = new TranslateTransform();

        Stroke[] Strokes;


        double V_WIDTH, V_HEIGHT;//原大小

        public MyOBJdraw(int eri, Stroke[] strokes, double HorizontalOffset, double VerticalOffset, double diffX, double diffY, int DrawSize, Color DrawColor)
        {
            Strokes = strokes;
            penColor = DrawColor;
            LineSize = DrawSize;
            ERI = eri;

            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);


            List<StylusPoint> StylusPoints=new List<StylusPoint>();


            for(int i=0;i<Strokes.Count();i++){
                StylusPointCollection StylusPointCollection =Strokes[i].StylusPoints;
                StylusPoints.AddRange(StylusPointCollection);
            }






            double[] StylusPointsX = (from table in StylusPoints
                                      select table.X).ToArray();


            double[] StylusPointsY = (from table in StylusPoints
                                   select table.Y).ToArray();

            double XXX = StylusPointsX.Min();
            double YYY = StylusPointsY.Min();


            double width = StylusPointsX.Max() - StylusPointsX.Min();
            double height = StylusPointsY.Max() - StylusPointsY.Min();



            for (int i = 0; i < Strokes.Count(); i++)
            {
                for (int j = 0; j < Strokes[i].StylusPoints.Count;j++ )
                    Strokes[i].StylusPoints[j] = new StylusPoint(Strokes[i].StylusPoints[j].X - XXX, Strokes[i].StylusPoints[j].Y - YYY);
                
            }



            TformX = XXX - diffX + HorizontalOffset;
            TformY = YYY - diffY + VerticalOffset;



            dt.Interval = TimeSpan.FromMilliseconds(30);
            dt.Tick +=new EventHandler(dt_Tick);
            dt.Stop();
            dtAphia.Interval = TimeSpan.FromMilliseconds(90);
            dtAphia.Tick += new EventHandler(dtAphia_Tick);
            dtAphia.Stop();

            
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;


            for (int i = 0; i < Strokes.Count(); i++)
            {
                Img.Strokes.Add(Strokes[i]);

            }




            
            Img.Height =height;
            Img.Width = width;
            Img.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            Img.Margin = new Thickness(0, 0, 0, 0);
            Img.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Img.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;


            Bg.RenderTransform = BgTform;
            Bg.Children.Add(Img);
            Bg.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Bg.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            /*
            Bg.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Bg.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Bg.Margin = new Thickness(0, 0, 0, 0);
            Bg.Width = 100;
            Bg.Height = 100;
            */

            //this.Width = width;
            //this.Height = height;
            //this.Background = new SolidColorBrush(Color.FromArgb(50, 255, 0, 0)); ;
            //Bg.Background  = new SolidColorBrush(Color.FromArgb(50,255,0,0));

            Children.Add(Bg);



            Rec.Width = width;
            Rec.Height = height;
            Rec.RenderTransform = RecTform;
            Rec.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            Rec.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(Rec_ManipulationStarted);
            Rec.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(Rec_ManipulationDelta);
            Rec.ManipulationCompleted +=new EventHandler<ManipulationCompletedEventArgs>(Rec_ManipulationCompleted);
            Children.Add(Rec);

            Rec.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Rec.VerticalAlignment = System.Windows.VerticalAlignment.Top;
           
            setSize(width, height);




            Draw();
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
            if (V_WIDTH >= 50 && V_HEIGHT >= 50)
            {
                if (V_WIDTH > V_HEIGHT)
                {
                    V_MinBAN = -1 * (int)((V_HEIGHT - (V_HEIGHT / 3)) / V_SIZE);

                    V_MaxBAN = (int)((V_HEIGHT * 5) - V_HEIGHT) / V_SIZE;
                }
                else
                {
                    V_MinBAN = -1 * (int)((V_WIDTH - (V_WIDTH / 3)) / V_SIZE);

                    V_MaxBAN = (int)((V_WIDTH * 5) - V_WIDTH) / V_SIZE;

                }
            }


        }



        CompositeTransform Com = new CompositeTransform();
        public int V
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
                /*
                //交叉相乘
                double H = V_HEIGHT+(v * V_SIZE);
                double W = (H * V_WIDTH) / V_HEIGHT;


                myWidth = W;
                myHeight = H;
                */
                /*
                Com.CenterX = V_WIDTH/2;
                Com.CenterY = V_HEIGHT / 2;

                Com.ScaleX = (v* 0.01)+1;
                Com.ScaleY = (v* 0.01)+1;
                    

                this.RenderTransform = Com;



                diffScaleX = (V_WIDTH - ((Com.ScaleX/3) * V_WIDTH))/2;
                diffScaleY = (V_HEIGHT -((Com.ScaleY/4) * V_HEIGHT))/2;

                */
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






        public void Draw()
        {
            Img.Children.Clear();
            int Stop = 0;

            if (ListX.Count() >= 2)
            {
                //兩點成一線 所以至少需要兩個元素
                Rx = ListX[0];
                Ry = ListY[0];

                for (int i = 1; i < ListX.Count(); i++)
                {
                    if (ListStop[Stop] == i)
                    {
                        Rx = ListX[i];
                        Ry = ListY[i];
                        Rline(ListX[i], ListY[i]);
                        if (Stop < ListStop.Count())
                        {
                            Stop++;
                        }
                    }
                    else
                    {
                        Rline(ListX[i], ListY[i]);

                    }
                }
            }

        }

        //點與點之間連起來
        public void Rline(double Px, double Py)
        {

            Line line = new Line();
            line.StrokeThickness = LineSize;

            line.X1 = Rx;
            line.Y1 = Ry;
            line.X2 = Px;
            line.Y2 = Py;


            line.Stroke = new SolidColorBrush(penColor);
            Img.Children.Add(line);


            Rx = Px;
            Ry = Py;
        }

    }
}
