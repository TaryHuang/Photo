using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TARY_Library_Silverlight
{
    public class makeBitmap
    {
        Canvas BG=new Canvas();
        WriteableBitmap Btable;
        BitmapImage Bimg;//準備回傳的的圖
        TextBox text;
        public makeBitmap(string STR)
        {
            text = new TextBox();
            text.Text = STR;
            text.FontSize = 48;
            text.TextAlignment = TextAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.HorizontalAlignment = HorizontalAlignment.Center;

            BG.Children.Add(text);


            int W = STR.Length * 10 + 30;
            Btable = new WriteableBitmap(W, 100);
            Btable.Render(BG, null);
            Btable.Invalidate();




            save(W, 100);
        }

        void save(int width, int height)
        {

            MemoryStream ms = new MemoryStream();
            Btable.SaveJpeg(ms, width, height, 0, 100);
            ms.Seek(0, SeekOrigin.Begin);
            BitmapImage B = new BitmapImage();
            B.SetSource(ms);
            Bimg = B;
            ms.Dispose();
        }


        public BitmapImage Bitmap
        {
            get{
               return Bimg;
            }


        }
    }
}
