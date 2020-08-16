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
using System.Windows.Ink;
namespace PhotoJ
{

    public class DrawBoard : Grid
    {

        bool drawT;


        public InkPresenter ink;
        Stroke stroke;
        public Color penColor;//顏色
        public int LineSize;//線的大小



 
        public bool DrawT
        {
            get
            {
                return drawT;
            }
            set
            {
                drawT = value;
                ACTION();
            }

        }


        public DrawBoard(Color pen, int size)
        {


            ink = new InkPresenter();
            ink.MouseMove += new MouseEventHandler(DrawBox_MouseMove);
            ink.MouseLeftButtonUp += new MouseButtonEventHandler(DrawBox_MouseLeftButtonUp);
            ink.MouseLeftButtonDown += DrawBox_MouseLeftButtonDown;
            ink.LostMouseCapture += new MouseEventHandler(DrawBox_LostMouseCapture);

            ink.Width = 1000;
            ink.Height = 1000;
            ink.Background = new System.Windows.Media.SolidColorBrush(Color.FromArgb(0,0,0,0));
            this.Children.Add(ink);

            penColor = pen;
            LineSize = size;

            DrawT = false;
        }




        void DrawBox_LostMouseCapture(object sender, MouseEventArgs e)
        {
            stroke = null;
        }



        private void DrawBox_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!drawT) return;


            ink.CaptureMouse();
            StylusPointCollection MyStylusPointCollection = new StylusPointCollection();
            MyStylusPointCollection.Add(e.StylusDevice.GetStylusPoints(ink));
            stroke = new Stroke(MyStylusPointCollection);
            stroke.DrawingAttributes.Color = penColor;
            stroke.DrawingAttributes.Width = LineSize;
            stroke.DrawingAttributes.Height = LineSize;
            ink.Strokes.Add(stroke);


            

        }

        private void DrawBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*
            StylusPointCollection MyStylusPointCollection = new StylusPointCollection();
            MyStylusPointCollection.Add(e.StylusDevice.GetStylusPoints(ink));
            stroke = new Stroke(MyStylusPointCollection);
            stroke.DrawingAttributes.Color = penColor;
            ink.Strokes.Add(stroke);

            
            */

        }




        private void DrawBox_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (stroke != null && drawT)
                stroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(ink));

        }







        public void ACTION()
        {
            //判定是否要開啟[簽名板]
            if (DrawT)
            {
                ink.Visibility = System.Windows.Visibility.Visible;
                
            }
            else
            {
                ink.Visibility = System.Windows.Visibility.Collapsed;

            }

        }


        public void Back()
        {
            if (ink.Strokes.Count>0)
            {
                //回上一步動作
                ink.Strokes.Remove(ink.Strokes.Last());

            }
        }

        public void Clear()
        {
            ink.Strokes.Clear();
            ACTION();
        }




    }
}
