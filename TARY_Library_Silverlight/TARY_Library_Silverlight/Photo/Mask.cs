using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace TARY_Library_Silverlight.Photo
{
    public class Mask : Grid
    {

        //只能使用在正方形

        
        bool RecT = false;//是否已經按下
        int W = 20;
        int H = 20;
        double diffX = 8, diffY = 8;

        //小框框
        SolidColorBrush Stk = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        SolidColorBrush Bg = new SolidColorBrush(Color.FromArgb(170, 0, 0, 0));
        SolidColorBrush BgCange = new SolidColorBrush(Color.FromArgb(170, 0, 0, 0));
        int RecBoxStrokeThickness = 20;

        //主要框框
        SolidColorBrush RecStk = new SolidColorBrush(Color.FromArgb(120, 0, 0, 0));
        SolidColorBrush RecBg = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        SolidColorBrush RecBgCange = new SolidColorBrush(Color.FromArgb(50, 255, 0, 0));
        int RecStrokeThickness = 2;






        Rectangle Rec = new Rectangle();
        TranslateTransform RecTform = new TranslateTransform();




        Rectangle RecLT = new Rectangle();//left top
        TranslateTransform RecLTform = new TranslateTransform();

        Rectangle RecLC = new Rectangle();//left CENTER
        TranslateTransform RecLCform = new TranslateTransform();


        Rectangle RecLB = new Rectangle();//left BOTTOM
        TranslateTransform RecLBform = new TranslateTransform();



        Rectangle RecCT = new Rectangle();//center top
        TranslateTransform RecCTform = new TranslateTransform();

        Rectangle RecCB = new Rectangle();//center BOTTOM
        TranslateTransform RecCBform = new TranslateTransform();

        Rectangle RecRT = new Rectangle();//RIGHT top
        TranslateTransform RecRTform = new TranslateTransform();

        Rectangle RecRC = new Rectangle();//RIGHT center
        TranslateTransform RecRCform = new TranslateTransform();


        Rectangle RecRB = new Rectangle();//RIGHT BOTTOM
        TranslateTransform RecRBform = new TranslateTransform();





        double addx=0, addy=0;//增加邊界


        public double addX
        {
            get{
                return addx;
            }
            
            set{
                addx = value;
            }
        }


        public double addY
        {
            get
            {
                return addy;
            }

            set
            {
                addy = value;
            }
        }

        public Mask(double width, double height)
        {



            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;





            Rec.Width = width;
            Rec.Height = height;
            Rec.RenderTransform = RecTform;
            Rec.StrokeThickness = RecStrokeThickness;
            Rec.Stroke = RecStk;
            Rec.Fill = RecBg;
            Rec.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(Rec_ManipulationStarted);
            Rec.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(Rec_ManipulationDelta);
            Rec.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(Rec_ManipulationCompleted);
            Children.Add(Rec);
            RecBox();
        }



        void RecBox()
        {



            RecLT.Name = "LeftTop";
            RecLT.Width = W;
            RecLT.Height = H;
            RecLT.Stroke = Stk;
            RecLT.Fill = Bg;
            RecLT.StrokeThickness = RecBoxStrokeThickness;
            RecLT.Margin = new System.Windows.Thickness(-diffX, -diffY, 0, 0);
            RecLT.ManipulationStarted +=RecBox_ManipulationStarted;
            RecLT.ManipulationDelta += RecBox_ManipulationDelta;
            RecLT.ManipulationCompleted += RecBox_ManipulationCompleted;
            RecLT.RenderTransform = RecLTform;
            RecLT.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            RecLT.HorizontalAlignment =  System.Windows.HorizontalAlignment.Left;
            Children.Add(RecLT);


            RecLC.Name = "LeftCenter";
            RecLC.Width = W;
            RecLC.Height = H;
            RecLC.Stroke = Stk;
            RecLC.Fill = Bg;
            RecLC.StrokeThickness = RecBoxStrokeThickness;
            RecLC.Margin = new System.Windows.Thickness(-diffX, 0, 0, 0);
            RecLC.ManipulationStarted += RecBox_ManipulationStarted;
            RecLC.ManipulationDelta += RecBox_ManipulationDelta;
            RecLC.ManipulationCompleted += RecBox_ManipulationCompleted;
            RecLC.RenderTransform = RecLCform;
            RecLC.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            RecLC.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Children.Add(RecLC);



            RecLB.Name = "LeftBottom";
            RecLB.Width = W;
            RecLB.Height = H;
            RecLB.Stroke = Stk;
            RecLB.Fill = Bg;
            RecLB.StrokeThickness = RecBoxStrokeThickness;
            RecLB.Margin = new System.Windows.Thickness(-diffX, 0, 0, -diffY);
            RecLB.ManipulationStarted += RecBox_ManipulationStarted;
            RecLB.ManipulationDelta += RecBox_ManipulationDelta;
            RecLB.ManipulationCompleted += RecBox_ManipulationCompleted;
            RecLB.RenderTransform = RecLBform;
            RecLB.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            RecLB.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Children.Add(RecLB);



            RecCT.Name = "CenterTop";
            RecCT.Width = W;
            RecCT.Height = H;
            RecCT.Stroke = Stk;
            RecCT.Fill = Bg;
            RecCT.StrokeThickness = RecBoxStrokeThickness;
            RecCT.Margin = new System.Windows.Thickness(0, -diffY, 0, 0);
            RecCT.ManipulationStarted += RecBox_ManipulationStarted;
            RecCT.ManipulationDelta += RecBox_ManipulationDelta;
            RecCT.ManipulationCompleted += RecBox_ManipulationCompleted;
            RecCT.RenderTransform = RecCTform;
            RecCT.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            RecCT.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Children.Add(RecCT);


            RecCB.Name = "CenterBottom";
            RecCB.Width = W;
            RecCB.Height = H;
            RecCB.Stroke = Stk;
            RecCB.Fill = Bg;
            RecCB.StrokeThickness = RecBoxStrokeThickness;
            RecCB.Margin = new System.Windows.Thickness(0, 0, 0, -diffY);
            RecCB.ManipulationStarted += RecBox_ManipulationStarted;
            RecCB.ManipulationDelta += RecBox_ManipulationDelta;
            RecCB.ManipulationCompleted += RecBox_ManipulationCompleted;
            RecCB.RenderTransform = RecCBform;
            RecCB.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            RecCB.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Children.Add(RecCB);





            RecRT.Name = "RightTop";
            RecRT.Width = W;
            RecRT.Height = H;
            RecRT.Stroke = Stk;
            RecRT.Fill = Bg;
            RecRT.StrokeThickness = RecBoxStrokeThickness;
            RecRT.Margin = new System.Windows.Thickness(0, -diffY, -diffX, 0);
            RecRT.ManipulationStarted += RecBox_ManipulationStarted;
            RecRT.ManipulationDelta += RecBox_ManipulationDelta;
            RecRT.ManipulationCompleted += RecBox_ManipulationCompleted;
            RecRT.RenderTransform = RecRTform;
            RecRT.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            RecRT.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            Children.Add(RecRT);



            RecRC.Name = "RightCenter";
            RecRC.Width = W;
            RecRC.Height = H;
            RecRC.Stroke = Stk;
            RecRC.Fill = Bg;
            RecRC.StrokeThickness = RecBoxStrokeThickness;
            RecRC.Margin = new System.Windows.Thickness(0, 0, -diffX , 0);
            RecRC.ManipulationStarted += RecBox_ManipulationStarted;
            RecRC.ManipulationDelta += RecBox_ManipulationDelta;
            RecRC.ManipulationCompleted += RecBox_ManipulationCompleted;
            RecRC.RenderTransform = RecRCform;
            RecRC.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            RecRC.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            Children.Add(RecRC);


            RecRB.Name = "RightBottom";
            RecRB.Width = W;
            RecRB.Height = H;
            RecRB.Stroke = Stk;
            RecRB.Fill = Bg;
            RecRB.StrokeThickness = RecBoxStrokeThickness;
            RecRB.Margin = new System.Windows.Thickness(0, 0, -diffX, -diffY);
            RecRB.ManipulationStarted += RecBox_ManipulationStarted;
            RecRB.ManipulationDelta += RecBox_ManipulationDelta;
            RecRB.ManipulationCompleted += RecBox_ManipulationCompleted;
            RecRB.RenderTransform = RecRBform;
            RecRB.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            RecRB.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            Children.Add(RecRB);

        }




        private void Rec_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            RecT = true;
            Rec.Fill = RecBgCange;
        }


        private void Rec_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            if (RecT)
            {
                TformX += e.DeltaManipulation.Translation.X;
                TformY += e.DeltaManipulation.Translation.Y;
            }
        }


        private void Rec_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

            RecT = false;
            Rec.Fill = RecBg;
        }









        private void RecBox_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            RecT = true;

            Rectangle R = sender as Rectangle;
            R.Fill = BgCange;


        }


        private void RecBox_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            if (RecT)
            {
                Rectangle R = sender as Rectangle;
                double TempW = myWidth, TempH = myHeight;

                switch(R.Name){
                    case "LeftTop":

                        myWidth -= e.DeltaManipulation.Translation.X;

                        TformX += e.DeltaManipulation.Translation.X;



                        myHeight -= e.DeltaManipulation.Translation.Y;

                        TformY += e.DeltaManipulation.Translation.Y;

                    break;

                    case "LeftCenter":
                        myWidth -= e.DeltaManipulation.Translation.X;

                        TformX += e.DeltaManipulation.Translation.X;
   
                    break;

                    case "LeftBottom":
                        myWidth -= e.DeltaManipulation.Translation.X;

                        TformX += e.DeltaManipulation.Translation.X;

                        myHeight += e.DeltaManipulation.Translation.Y;
                    break;



                    case "CenterTop"://OK

                        myHeight -= e.DeltaManipulation.Translation.Y;

                        TformY += e.DeltaManipulation.Translation.Y; 

                    break;


                    case "CenterBottom"://ok
                        myHeight += e.DeltaManipulation.Translation.Y; 
                        
                    break;


                    case "RightTop"://OK
                        myWidth += e.DeltaManipulation.Translation.X;

                        myHeight -= e.DeltaManipulation.Translation.Y;

                        TformY += e.DeltaManipulation.Translation.Y;

                    break;


                    case "RightCenter"://ok
                        myWidth += e.DeltaManipulation.Translation.X;break;


                    case "RightBottom"://ok
                        myWidth += e.DeltaManipulation.Translation.X;
                        myHeight += e.DeltaManipulation.Translation.Y; break;
                }
            }
        }


        private void RecBox_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

            RecT = false;

            Rectangle R = sender as Rectangle;
            R.Fill = Bg;
        }






        public double myWidth
        {
            get
            {
                return Rec.Width;
            }
            set
            {


                if (value < 20)
                {
                    return;
                }


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
                if (value < 20)
                {
                    return;
                }


                Rec.Height = value;
            }
        }



        public double TformX
        {
            get
            {
                return this.RecTform.X - addX;

            }
            set
            {
                value += addX;

                this.RecTform.X = value;

                this.RecLTform.X = value;
                this.RecLCform.X = value;
                this.RecLBform.X = value;
                this.RecCTform.X = value;
                this.RecCBform.X = value;
                this.RecRTform.X = value;
                this.RecRCform.X = value;
                this.RecRBform.X = value;
            }
        }

        public double TformY
        {

            get
            {
                return this.RecTform.Y-addY;

            }
            set
            {

                value += addY;

                this.RecTform.Y = value;

                this.RecLTform.Y = value;
                this.RecLCform.Y = value;
                this.RecLBform.Y = value;
                this.RecCTform.Y = value;
                this.RecCBform.Y = value;
                this.RecRTform.Y = value;
                this.RecRCform.Y = value;
                this.RecRBform.Y = value;
            }
        }


    }
}
