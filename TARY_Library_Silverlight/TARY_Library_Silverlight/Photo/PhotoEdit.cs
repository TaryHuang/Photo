using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;
using System.Diagnostics;
namespace TARY_Library_Silverlight.Photo
{
    public class PhotoEdit
    {

        public static Point BestSize(BitmapImage PHOTO,double X,double Y )
        {



            //最佳圖示尺寸運算

            double xxx, yyy;
            xxx = X;
            yyy = Y;

            Point P =new Point();
            P.X = PHOTO.PixelWidth;
            P.Y = PHOTO.PixelHeight;




            //16:9
            if (P.X==480 && (P.X==2048 && P.Y==1152 ||  P.X==3552 && P.Y==1998 ))
            {
                P.X=480;
                P.Y=270;
                return P;
            }else if (P.X==640 && (P.X==2048 && P.Y==1152 ||  P.X==3552 && P.Y==1998 ))
            {
                P.X=640;
                P.Y=360;
                return P;
            }


            //4:3
            if (P.X==480 && (P.X==2048 && P.Y==1536 ||  P.X==3264 && P.Y==2448 ))
            {
                P.X=480;
                P.Y=360;
                return P;
            }else if (P.X==640 && (P.X==2048 && P.Y==1536 ||  P.X==3264 && P.Y==2448 ))
            {
                P.X=640;
                P.Y=480;
                return P;
            }


            //********************************


            //小於尺吋 直接回傳
            if (P.X <= X && P.Y <= Y)
            {
                return P;
            }


            double tempHeight;
            int i = 5000;
            while(i>=0){
                tempHeight = (P.Y * X) / P.X;

                
                if (tempHeight <= Y)
                {
                    P.X = X;
                    P.Y = tempHeight;

                    return P;
                }
                else
                {
                    X -= 1;
                    i--;
                }
                
            }


            if (i<0)
            {
                P.X = xxx;
                P.Y = yyy;
            }


            return P;
        }



        public static Point BestSize2(BitmapImage PHOTO, double X, double Y)
        {



            //最佳圖示尺寸運算

            double xxx, yyy;
            xxx = X;
            yyy = Y;

            Point P = new Point();
            P.X = PHOTO.PixelWidth;
            P.Y = PHOTO.PixelHeight;



            //小於尺吋 直接回傳
            if (P.X <= X && P.Y <= Y)
            {
                return P;
            }


            double tempHeight;
            int i = 5000;
            while (i >= 0)
            {
                tempHeight = (P.Y * X) / P.X;


                if (tempHeight <= Y)
                {
                    P.X = X;
                    P.Y = tempHeight;

                    return P;
                }
                else
                {
                    X -= 1;
                    i--;
                }

            }


            if (i < 0)
            {
                P.X = xxx;
                P.Y = yyy;
            }


            return P;
        }







        public static BitmapImage Size(BitmapImage PHOTO, int W,int H)
        {

            PHOTO.CreateOptions = BitmapCreateOptions.None;
            Grid maskPhoto = new Grid();//遮罩用







            Image IMG = new Image();
            IMG.Source = PHOTO;
            IMG.Width = W;
            IMG.Height = H;
            maskPhoto.Children.Add(IMG);

            WriteableBitmap SaveImage = new WriteableBitmap(W, H);



            SaveImage.Render(maskPhoto, null);
            SaveImage.Invalidate();


            return SaveBitmap(SaveImage, 100);

        }



        public static BitmapImage Size(BitmapImage PHOTO, int Num)
        {

            PHOTO.CreateOptions = BitmapCreateOptions.None;
            Grid maskPhoto = new Grid();//遮罩用



            //交叉相乘
            int W = (PHOTO.PixelWidth/Num);
            int H = (W * PHOTO.PixelHeight) / PHOTO.PixelWidth;
            



            Image IMG = new Image();
            IMG.Source = PHOTO;
            IMG.Width = W;
            IMG.Height = H;
            maskPhoto.Children.Add(IMG);

            WriteableBitmap SaveImage = new WriteableBitmap(W, H);



            SaveImage.Render(maskPhoto, null);
            SaveImage.Invalidate();


            return SaveBitmap(SaveImage, 100);
        }









        public static BitmapImage ChgBg2(BitmapImage PHOTO,int N)
        {
            //rbg 顏色互換

            //讀入欲轉換的圖片並轉成為WritableBitmap
            WriteableBitmap bitmap = new WriteableBitmap(PHOTO);


            for (int y = 0; y < bitmap.PixelHeight; y++)
            {
                
                for (int x = 0; x < bitmap.PixelWidth; x++)
                {
                    //取得每一個pixel
                    int pixelLocation = bitmap.PixelWidth * y + x;
                    int pixel = bitmap.Pixels[pixelLocation];



                    byte[] pixBytes = BitConverter.GetBytes(pixel);



                    if (N == 0)
                    {
                        byte temp = pixBytes[0];//暫存
                        pixBytes[0] = pixBytes[1];
                        pixBytes[1] = temp;
                    }else if (N == 1)
                    {
                        byte temp = pixBytes[0];//暫存
                        pixBytes[0] = pixBytes[2];
                        pixBytes[2] = temp;
                    }
                    else if (N == 2)
                    {
                        byte temp = pixBytes[1];//暫存
                        pixBytes[1] = pixBytes[2];
                        pixBytes[2] = temp;
                    }
                    else if (N == 3)
                    {
                        byte temp = pixBytes[0];//暫存

                        pixBytes[0] = pixBytes[1];
                        pixBytes[1] = pixBytes[2];
                        pixBytes[2] = temp;
                    }

                    //將處理後的pixel置回
                    bitmap.Pixels[pixelLocation] = BitConverter.ToInt32(pixBytes, 0);
                }


            }
            //顯示結果

            return SaveBitmap(bitmap,100);
        }





        //黑白
        public static BitmapImage ChgBg1(BitmapImage PHOTO)
        {
            //讀入欲轉換的圖片並轉成為WritableBitmap
            WriteableBitmap bitmap = new WriteableBitmap(PHOTO);


            for (int y = 0; y < bitmap.PixelHeight; y++)
            {
                for (int x = 0; x < bitmap.PixelWidth; x++)
                {
                    //取得每一個pixel
                    int pixelLocation = bitmap.PixelWidth * y + x;
                    int pixel = bitmap.Pixels[pixelLocation];

                    byte[] pixBytes = BitConverter.GetBytes(pixel);
                    //每一個都除3


                    byte bnwPixel = (byte)(.3 * pixBytes[2]
                                        + .59 * pixBytes[1]
                                        + .11 * pixBytes[0]);
                    pixBytes[0] = bnwPixel;//b
                    pixBytes[1] = bnwPixel;//g
                    pixBytes[2] = bnwPixel;//r

                    //位置3是alpha 
                    //排列真是詭異阿..>< 剛好反過來s

                    //將處理後的pixel置回
                    bitmap.Pixels[pixelLocation] = BitConverter.ToInt32(pixBytes, 0);
                }


            }
            //顯示結果

            return SaveBitmap(bitmap, 100);
        }






        //負片
        public static BitmapImage ConvertToInvert(BitmapImage PHOTO)
        {
            //讀入欲轉換的圖片並轉成為WritableBitmap
            WriteableBitmap bitmap = new WriteableBitmap(PHOTO);


            for (int y = 0; y < bitmap.PixelHeight; y++)
            {
                for (int x = 0; x < bitmap.PixelWidth; x++)
                {
                    //取得每一個pixel
                    int pixelLocation = bitmap.PixelWidth * y + x;
                    int pixel = bitmap.Pixels[pixelLocation];

                    byte[] pixBytes = BitConverter.GetBytes(pixel);
                    //每一個都除3


                    pixBytes[0] = (byte)(255 - pixBytes[0]);
                    pixBytes[1] = (byte)(255 - pixBytes[1]);
                    pixBytes[2] = (byte)(255 - pixBytes[2]);

                    //位置3是alpha 
                    //排列真是詭異阿..>< 剛好反過來s

                    //將處理後的pixel置回
                    bitmap.Pixels[pixelLocation] = BitConverter.ToInt32(pixBytes, 0);
                }


            }
            //顯示結果

            return SaveBitmap(bitmap, 100);
        }




        public static BitmapImage Contrast(BitmapImage PHOTO, double r, double g, double b)
        {
            //讀入欲轉換的圖片並轉成為WritableBitmap
            WriteableBitmap bitmap = new WriteableBitmap(PHOTO);


            /*
            // 判斷是不是在0.2~5 之間
            r = Math.Min(Math.Max(0.2, r), 5);
            g = Math.Min(Math.Max(0.2, g), 5);
            b = Math.Min(Math.Max(0.2, b), 5);
            */


            
            for (int y = 0; y < bitmap.PixelHeight; y++)
            {
                for (int x = 0; x < bitmap.PixelWidth; x++)
                {
                    //取得每一個pixel
                    int pixelLocation = bitmap.PixelWidth * y + x;
                    int pixel = bitmap.Pixels[pixelLocation];

                    byte[] pixBytes = BitConverter.GetBytes(pixel);

                    /*
                    pixBytes[0] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(pixBytes[0] / 255.0, g))));//b
                    pixBytes[1] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(pixBytes[1] / 255.0, b))));//b
                    pixBytes[2] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(pixBytes[2] / 255.0, r))));//b
                    */

                    double N;
                    


                    N=  Math.Min(Math.Max(0,(((((pixBytes[0] / 255.0) - 0.5) * b) + 0.5) * 255.0)),255);
                    pixBytes[0] = (byte)N;//b


                    N = Math.Min(Math.Max(0, (((((pixBytes[1] / 255.0) - 0.5) * g) + 0.5) * 255.0)), 255);
                    pixBytes[1] = (byte)N;//b


                    N = Math.Min(Math.Max(0, (((((pixBytes[2] / 255.0) - 0.5) * r) + 0.5) * 255.0)), 255);
                    pixBytes[2] = (byte)N;//b


                    //位置3是alpha 
                    //排列真是詭異阿..>< 剛好反過來s

                    //將處理後的pixel置回
                    bitmap.Pixels[pixelLocation] = BitConverter.ToInt32(pixBytes, 0);
                }


            }
            //顯示結果

            return SaveBitmap(bitmap, 100);
        }










        //色彩調色
        public static BitmapImage RGB(BitmapImage PHOTO, int ValR, int ValB, int ValG)
        {
            //讀入欲轉換的圖片並轉成為WritableBitmap
            WriteableBitmap bitmap = new WriteableBitmap(PHOTO);


            for (int y = 0; y < bitmap.PixelHeight; y++)
            {
                for (int x = 0; x < bitmap.PixelWidth; x++)
                {
                    //取得每一個pixel
                    int pixelLocation = bitmap.PixelWidth * y + x;
                    int pixel = bitmap.Pixels[pixelLocation];

                    byte[] pixBytes = BitConverter.GetBytes(pixel);
                    //每一個都除3


                    int bnwPixel = 5 ;










                    if (pixBytes[0] > pixBytes[1] && pixBytes[0] > pixBytes[2])
                    {
                        bnwPixel += 5;
                    }

                    if (ValG > 0)
                        pixBytes[0] = (pixBytes[0] + bnwPixel * ValG <= (byte)(255)) ? (byte)(pixBytes[0] + bnwPixel * ValG) : (byte)255;//b
                    else
                        pixBytes[0] = (pixBytes[0] + bnwPixel * ValG >= (byte)(0)) ? (byte)(pixBytes[0] + bnwPixel * ValG) : (byte)0;//b









                    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    bnwPixel = 5;
                    if (pixBytes[1] > pixBytes[0] && pixBytes[1] > pixBytes[2])
                    {
                        bnwPixel += 5;
                    }
                    if (ValB > 0)
                        pixBytes[1] = (pixBytes[1] + bnwPixel * ValB <= (byte)(255)) ? (byte)(pixBytes[1] + bnwPixel * ValB) : (byte)255;//b
                    else
                        pixBytes[1] = (pixBytes[1] + bnwPixel * ValB >= (byte)(0)) ? (byte)(pixBytes[1] + bnwPixel * ValB) : (byte)0;//b


                    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    bnwPixel = 5;
                    if (pixBytes[2] > pixBytes[0] && pixBytes[2] > pixBytes[1])
                    {
                        bnwPixel += 5;
                    }
                    if (ValR > 0)
                        pixBytes[2] = (pixBytes[2] + bnwPixel * ValR <= (byte)(255)) ? (byte)(pixBytes[2] + bnwPixel * ValR) : (byte)255;//b
                    else
                        pixBytes[2] = (pixBytes[2] + bnwPixel * ValR >= (byte)(0)) ? (byte)(pixBytes[2] + bnwPixel * ValR) : (byte)0;//b
                    


                    //位置3是alpha 
                    //排列真是詭異阿..>< 剛好反過來s

                    //將處理後的pixel置回
                    bitmap.Pixels[pixelLocation] = BitConverter.ToInt32(pixBytes, 0);
                }


            }
            //顯示結果

            return SaveBitmap(bitmap, 100);
        }












        public static byte[] RGBadd(byte[] pixBytes,int num)
        {

            pixBytes[0] = (int)(pixBytes[0] + num) > 255 ? (byte)255 : (byte)(pixBytes[0] + num);


            pixBytes[1] = (int)(pixBytes[1] + num) > 255 ? (byte)255 : (byte)(pixBytes[1] + num);


            pixBytes[2] = (int)(pixBytes[2] + num) > 255 ? (byte)255 : (byte)(pixBytes[2] + num);
            return pixBytes;
        }







        //風化效果
        public static BitmapImage MASK2(BitmapImage PHOTO, int locX, int locY, int EndX, int EndY, int Size)
        {

            int tempX, tempY;//暫存用
            if (EndY < locY)
            {
                tempY = EndY;
                // tempX = EndX;


                EndY = locY;
                //EndX = locX;

                locY = tempY;
                //locX = tempX;
            }
            else if (EndY == locY)
            {
                return PHOTO;
            }



            if (EndX < locX)
            {
                //tempY = EndY;
                tempX = EndX;


                //EndY = locY;
                EndX = locX;

                //locY = tempY;
                locX = tempX;
            }
            else if (EndX == locX)
            {
                return PHOTO;
            }






            locX = locX < 0 ? 0 : locX;
            locX = locX > PHOTO.PixelWidth ? PHOTO.PixelWidth : locX;
            locY = locY < 0 ? 0 : locY;
            locY = locY > PHOTO.PixelHeight ? PHOTO.PixelHeight : locY;
            int loc = (int)(PHOTO.PixelWidth * locY) + locX;



            EndX = EndX < 0 ? 0 : EndX;
            EndX = EndX > PHOTO.PixelWidth ? PHOTO.PixelWidth : EndX;
            EndY = EndY < 0 ? 0 : EndY;
            EndY = EndY > PHOTO.PixelHeight ? PHOTO.PixelHeight : EndY;
            int locE = (int)(PHOTO.PixelWidth * EndY) + EndX;
            int RunW = Math.Abs(EndX - locX);
            int RunH = Math.Abs(EndY - locY);
            //讀入欲轉換的圖片並轉成為WritableBitmap
            WriteableBitmap bitmap = new WriteableBitmap(PHOTO);
            int Max = (bitmap.PixelWidth * bitmap.PixelHeight) - 1;


            int N = Size;//範圍直



            for (int H = 0; H < RunH; H++)
            {


                for (int W = 0; W < RunW; W++)
                {


                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;
                    for (int y = H; (y < H + N && y < bitmap.PixelHeight); y++)
                    {
                        for (int x = W; (x < W + N && x < bitmap.PixelWidth); x++)
                        {

                            int L = loc + (y * bitmap.PixelWidth) + x;
                            int Lpixel = bitmap.Pixels[L];
                            byte[] LpixBytes = BitConverter.GetBytes(Lpixel);
                            avgR += LpixBytes[0];
                            avgG += LpixBytes[1];
                            avgB += LpixBytes[2];

                            blurPixelCount++;
                        }
                    }

                    // 計算範圍平均
                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;





                    int pixelLocation = loc + (H * bitmap.PixelWidth) + W;
                    int pixel = bitmap.Pixels[pixelLocation];

                    byte[] pixBytes = BitConverter.GetBytes(pixel);

                    pixBytes[0] = (byte)avgR;
                    pixBytes[1] = (byte)avgG;
                    pixBytes[2] = (byte)avgB;

                    bitmap.Pixels[pixelLocation] = BitConverter.ToInt32(pixBytes, 0);
                }
            }

            return SaveBitmap(bitmap, 100);
        }






        //馬賽克
        public static BitmapImage MASK(BitmapImage PHOTO, int locX,int locY,int EndX,int EndY,int Size)
        {


            int tempX, tempY;//暫存用
            if (EndY < locY)
            {
                tempY = EndY;
               // tempX = EndX;


                EndY = locY;
                //EndX = locX;

                locY = tempY;
                //locX = tempX;
            }
            else if (EndY == locY)
            {
                return PHOTO;
            }



            if (EndX < locX)
            {
                //tempY = EndY;
                tempX = EndX;


                //EndY = locY;
                EndX = locX;

                //locY = tempY;
                locX = tempX;
            }
            else if (EndX == locX)
            {
                return PHOTO;
            }






            locX = locX < 0 ? 0 : locX;
            locX = locX > PHOTO.PixelWidth ? PHOTO.PixelWidth : locX;
            locY = locY < 0 ? 0 : locY;
            locY = locY > PHOTO.PixelHeight ? PHOTO.PixelHeight : locY;
            int loc = (int)(PHOTO.PixelWidth * locY) + locX;


            
            EndX = EndX < 0 ? 0 : EndX;
            EndX = EndX > PHOTO.PixelWidth ? PHOTO.PixelWidth : EndX;
            EndY = EndY < 0 ? 0 : EndY;
            EndY = EndY > PHOTO.PixelHeight ? PHOTO.PixelHeight : EndY;
            int locE = (int)(PHOTO.PixelWidth * EndY) + EndX;
            int RunW = Math.Abs(EndX - locX);
            int RunH = Math.Abs(EndY - locY) ;
            //讀入欲轉換的圖片並轉成為WritableBitmap
            WriteableBitmap bitmap = new WriteableBitmap(PHOTO);
            int Max = (bitmap.PixelWidth * bitmap.PixelHeight) - 1;


            int N = Size;//範圍直
            int C = 5;//亮度

            int pixelF;
            int locF;
            byte[] pixBytesF;
            pixelF = bitmap.Pixels[loc];
            pixBytesF = RGBadd(BitConverter.GetBytes(pixelF), C);

            int WWW=0, HHH = 0;

            for (int H = 0; H < RunH; H++)
            {

                if (H % N == 0)
                {
                    HHH+=N;
                }
                WWW = 0;
                for (int W = 0; W < RunW; W++)
                {


                    if (W % N == 0 )
                    {
                        //**************************************************
                        locF = loc + (HHH * bitmap.PixelWidth) + WWW;
                        pixelF = bitmap.Pixels[locF];
                        pixBytesF = RGBadd(BitConverter.GetBytes(pixelF), C);
                        //**************************************************

                        WWW += N;
                    }

                    


                    int pixelLocation = loc + (H * bitmap.PixelWidth) + W;
                    int pixel = bitmap.Pixels[pixelLocation];

                    byte[] pixBytes = BitConverter.GetBytes(pixel);

                    pixBytes[0] = pixBytesF[0];
                    pixBytes[1] = pixBytesF[1];
                    pixBytes[2] = pixBytesF[2];

                    bitmap.Pixels[pixelLocation] = BitConverter.ToInt32(pixBytes, 0);
                }
            }

            return SaveBitmap(bitmap, 100);
        }










        //亮度 Val -25 ~ 25     0代表不動
        public static BitmapImage Light(BitmapImage PHOTO,int Val)
        {

            //代表回原圖像
            if (Val == 0) return PHOTO;




            //讀入欲轉換的圖片並轉成為WritableBitmap
            WriteableBitmap bitmap = new WriteableBitmap(PHOTO);


            for (int y = 0; y < bitmap.PixelHeight; y++)
            {
                for (int x = 0; x < bitmap.PixelWidth; x++)
                {
                    //取得每一個pixel
                    int pixelLocation = bitmap.PixelWidth * y + x;
                    int pixel = bitmap.Pixels[pixelLocation];

                    byte[] pixBytes = BitConverter.GetBytes(pixel);


                    int bnwPixel = 8*Val;

                    if (Val > 0)
                    {
                        pixBytes[0] = (pixBytes[0] + bnwPixel <= (byte)(255)) ? (byte)(pixBytes[0] + bnwPixel) : (byte)255;//b
                        pixBytes[1] = (pixBytes[1] + bnwPixel <= (byte)(255)) ? (byte)(pixBytes[1] + bnwPixel) : (byte)255;//b
                        pixBytes[2] = (pixBytes[2] + bnwPixel <= (byte)(255)) ? (byte)(pixBytes[2] + bnwPixel) : (byte)255;//b
                    }else if(Val < 0 ){
                        pixBytes[0] = (pixBytes[0] + bnwPixel >= (byte)(0)) ? (byte)(pixBytes[0] + bnwPixel) : (byte)0;//b
                        pixBytes[1] = (pixBytes[1] + bnwPixel >= (byte)(0)) ? (byte)(pixBytes[1] + bnwPixel) : (byte)0;//b
                        pixBytes[2] = (pixBytes[2] + bnwPixel >= (byte)(0)) ? (byte)(pixBytes[2] + bnwPixel) : (byte)0;//b

                    }


                    //排列真是詭異阿..>< 剛好反過來s

                    //將處理後的pixel置回
                    bitmap.Pixels[pixelLocation] = BitConverter.ToInt32(pixBytes, 0);
                }


            }
            //顯示結果

            return SaveBitmap(bitmap, 100);
        }


        public static BitmapImage AdjustTobBlur(BitmapImage PHOTO, int effectRradius)
        {
            //rbg 顏色互換

            //讀入欲轉換的圖片並轉成為WritableBitmap
            WriteableBitmap bitmap = new WriteableBitmap(PHOTO);



            // 整體圖片跑 Pixel 迴圈
            for (int heightOffset = 0; heightOffset < bitmap.PixelHeight; heightOffset++)
            {
                for (int widthOffset = 0; widthOffset < bitmap.PixelWidth; widthOffset++)
                {





                    // 負責計算平均值
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;






                    // 計算傳入影響範圍內 的 RGB 平均
                    for (int x = heightOffset; (x < heightOffset + effectRradius && x < bitmap.PixelHeight); x++)
                    {
                        for (int y = widthOffset; (y < widthOffset + effectRradius && y < bitmap.PixelWidth); y++)
                        {


                            int pixelLocation = bitmap.PixelWidth * x + y;



                            if (pixelLocation > bitmap.Pixels.Length - 1)
                                continue;


                            int pixel = bitmap.Pixels[pixelLocation];
                            byte[] pixBytes = BitConverter.GetBytes(pixel);


                            avgB += (int)pixBytes[0];
                            avgG += (int)pixBytes[1];
                            avgR += (int)pixBytes[2];

                            blurPixelCount++;
                        }
                    }



                    // 計算個別平均


                    if (blurPixelCount == 0)
                    {
                        blurPixelCount = 1;
                    }
                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;


                    // 寫回入新圖片
                    // 計算傳入影響範圍內 的 RGB 平均
                    for (int x = heightOffset; (x < heightOffset + effectRradius && x < bitmap.PixelHeight); x++)
                    {
                        for (int y = widthOffset; (y < widthOffset + effectRradius && y < bitmap.PixelWidth); y++)
                        {

                            int pixelLocation = bitmap.PixelWidth * x + y;


                            if (pixelLocation > bitmap.Pixels.Length - 1)
                                continue;




                            int pixel = bitmap.Pixels[pixelLocation];
                            byte[] pixBytes = BitConverter.GetBytes(pixel);


                            pixBytes[0] = (byte)avgB;
                            pixBytes[1] = (byte)avgG;
                            pixBytes[2] = (byte)avgR;

                            bitmap.Pixels[pixelLocation] = BitConverter.ToInt32(pixBytes, 0);

                        }
                    }

                }
            }
            //顯示結果

            return SaveBitmap(bitmap, 100);
        }







        /*顛倒
        public static BitmapImage AdjustTobBlur(BitmapImage PHOTO, int effectRradius)
        {
            //rbg 顏色互換

            //讀入欲轉換的圖片並轉成為WritableBitmap
            WriteableBitmap bitmap = new WriteableBitmap(PHOTO);



            // 整體圖片跑 Pixel 迴圈
            for (int heightOffset = 0; heightOffset < bitmap.PixelHeight; heightOffset++)
            {
                for (int widthOffset = 0; widthOffset < bitmap.PixelWidth; widthOffset++)
                {





                    // 負責計算平均值
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 1;






                    // 計算傳入影響範圍內 的 RGB 平均
                    for (int x = heightOffset; (x < heightOffset + effectRradius && x < bitmap.PixelHeight); x++)
                    {
                        for (int y = widthOffset; (y < widthOffset + effectRradius && y < bitmap.PixelWidth); y++)
                        {


                                int pixelLocation = bitmap.PixelWidth * x + y;



                                if (pixelLocation > bitmap.Pixels.Length - 1)
                                    continue;


                                int pixel = bitmap.Pixels[pixelLocation];
                                byte[] pixBytes = BitConverter.GetBytes(pixel);


                                avgB += (int)pixBytes[0];
                                avgG += (int)pixBytes[1];
                                avgR += (int)pixBytes[2];

                                blurPixelCount++;
                        }
                    }



                    // 計算個別平均
                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;


                    // 寫回入新圖片
                    // 計算傳入影響範圍內 的 RGB 平均
                    for (int x = widthOffset; (x < widthOffset + effectRradius && x < bitmap.PixelWidth); x++)
                    {
                        for (int y = heightOffset; (y < heightOffset + effectRradius && y < bitmap.PixelHeight); y++)
                        {

                                int pixelLocation = bitmap.PixelWidth * x + y;


                                if (pixelLocation > bitmap.Pixels.Length-1)
                                    continue;

                                    


                                int pixel = bitmap.Pixels[pixelLocation];
                                byte[] pixBytes = BitConverter.GetBytes(pixel);


                                pixBytes[0] = (byte)avgB;
                                pixBytes[1] = (byte)avgG;
                                pixBytes[2] = (byte)avgR;

                                bitmap.Pixels[pixelLocation] = BitConverter.ToInt32(pixBytes, 0);

                        }
                    }

                }
            }
            //顯示結果

            return SaveBitmap(bitmap, 100);
        }
        */








        //轉換
        public static BitmapImage SaveBitmap(WriteableBitmap bitmap,int N )
        {

            MemoryStream ms = new MemoryStream();
            bitmap.SaveJpeg(ms, bitmap.PixelWidth, bitmap.PixelHeight, 0, N);
            ms.Seek(0, SeekOrigin.Begin);
            BitmapImage B = new BitmapImage();
            B.SetSource(ms);
            ms.Dispose();
            ms.Close();
            return B;
        }




        //反轉  CounterclockwiseAngle:度數  目前支援 90 180...等
        public static BitmapImage Turn(BitmapImage PHOTO, int CounterclockwiseAngle)
        {

            WriteableBitmap wb = new WriteableBitmap(PHOTO);


            int[,] wb_arr = new int[wb.PixelWidth, wb.PixelHeight];
            //导致许多缺页中断的初始化循环
            //for (int r = 0; r < wb.PixelHeight; r++)// r=row    c=column
            //{
            //    for (int c = 0; c < wb.PixelWidth; c++)
            //    {
            //        wb_arr[c, r] = wb.Pixels[wb.PixelWidth * r + c];
            //    }
            //}
            //导致较少缺页中断的初始化循环 对上面代码的简单优化
            for (int c = 0; c < wb.PixelWidth; c++)// r=row    c=column
            {
                for (int r = 0; r < wb.PixelHeight; r++)
                {
                    wb_arr[c, r] = wb.Pixels[wb.PixelWidth * r + c];
                }
            }

            WriteableBitmap wb2;
            int[,] wb_arr_2;

            if (CounterclockwiseAngle == 0 || CounterclockwiseAngle == 360 || CounterclockwiseAngle == -360)//0度 360度
            {
                wb2 = new WriteableBitmap(wb.PixelWidth, wb.PixelHeight);
                wb_arr_2 = new int[wb.PixelWidth, wb.PixelHeight];
                wb_arr_2 = wb_arr;
            }
            else if (CounterclockwiseAngle == 90 || CounterclockwiseAngle == -270)//90 -270//Math.Sin(
            {
                wb2 = new WriteableBitmap(wb.PixelHeight, wb.PixelWidth);
                wb_arr_2 = new int[wb.PixelHeight, wb.PixelWidth];
                for (int c = 0; c < wb_arr.GetLength(0); c++)//width  i
                {
                    for (int r = 0; r < wb_arr.GetLength(1); r++)//height j
                    {
                        wb_arr_2[r, wb_arr.GetLength(0) - c - 1] = wb_arr[c, r]; //90 Out[j, Right-i-1] = In[i, j]  Right代表真个宽度
                    }
                }
            }
            else if (CounterclockwiseAngle == 180 || CounterclockwiseAngle == -180)//180 -180
            {
                wb2 = new WriteableBitmap(wb.PixelWidth, wb.PixelHeight);
                wb_arr_2 = new int[wb.PixelWidth, wb.PixelHeight];
                for (int c = 0; c < wb_arr.GetLength(0); c++)//width  i
                {
                    for (int r = 0; r < wb_arr.GetLength(1); r++)//height j
                    {
                        wb_arr_2[wb_arr.GetLength(0) - c - 1, wb_arr.GetLength(1) - r - 1] = wb_arr[c, r]; //180 Out[Right-i-1, Bottom-j-1] = In[i, j]  
                    }
                }
            }
            else if (CounterclockwiseAngle == 270 || CounterclockwiseAngle == -90)//270 -90
            {
                wb2 = new WriteableBitmap(wb.PixelHeight, wb.PixelWidth);
                wb_arr_2 = new int[wb.PixelHeight, wb.PixelWidth];
                for (int c = 0; c < wb_arr.GetLength(0); c++)//width  i
                {
                    for (int r = 0; r < wb_arr.GetLength(1); r++)//height j
                    {
                        wb_arr_2[wb_arr.GetLength(1) - r - 1, c] = wb_arr[c, r]; //270 Out[Bottom-j-1,i] = In[i, j] 
                    }
                }
            }
            else
            {
                return null;//如果是其他角度 就直接返回null
            }
            //将二位数组转换成Pixels
            for (int r = 0; r < wb_arr_2.GetLength(1); r++)// r=row    c=column 
            {
                for (int c = 0; c < wb_arr_2.GetLength(0); c++)
                {
                    wb2.Pixels[wb2.PixelWidth * r + c] = wb_arr_2[c, r];
                }
            }




            return SaveBitmap(wb2,100);
        }








        //剪裁
        public static BitmapImage Cut(BitmapImage PHOTO, int X1, int X2,int X3, int X4)
        {
            BitmapImage BBB=new BitmapImage();
            BBB = PhotoEdit.CutX1(PHOTO, X1, X2);

            return PhotoEdit.CutX2(BBB, X3, X4);
        }




        static BitmapImage CutX1(BitmapImage PHOTO, int X1, int Y1)
        {


            PHOTO.CreateOptions = BitmapCreateOptions.None;
            Grid maskPhoto = new Grid();//遮罩用


            Image IMG = new Image();

            IMG.Source = PHOTO;
            IMG.Margin = new Thickness(-X1, -Y1, 0, 0);
            maskPhoto.Children.Add(IMG);

            WriteableBitmap SaveImage = new WriteableBitmap(PHOTO.PixelWidth - X1, PHOTO.PixelHeight - Y1);



            SaveImage.Render(maskPhoto, null);
            SaveImage.Invalidate();


            return SaveBitmap(SaveImage, 100);




        }

        static BitmapImage CutX2(BitmapImage PHOTO, int X1, int Y1)
        {


            PHOTO.CreateOptions = BitmapCreateOptions.None;
            Grid maskPhoto = new Grid();//遮罩用



            Image IMG = new Image();

            IMG.Source = PHOTO;
            IMG.Stretch = Stretch.Fill;
            IMG.Width = PHOTO.PixelWidth;
            IMG.Height = PHOTO.PixelHeight;
            IMG.Margin = new Thickness(0, 0, 0, 0);

            IMG.VerticalAlignment = VerticalAlignment.Top;
            IMG.HorizontalAlignment = HorizontalAlignment.Left;


            maskPhoto.Children.Add(IMG);


            maskPhoto.VerticalAlignment = VerticalAlignment.Top;
            maskPhoto.HorizontalAlignment = HorizontalAlignment.Left;
            maskPhoto.Width = PHOTO.PixelWidth - X1;
            maskPhoto.Height = PHOTO.PixelHeight - Y1;

            WriteableBitmap SaveImage = new WriteableBitmap((int)maskPhoto.Width, (int)maskPhoto.Height);
            SaveImage.Render(maskPhoto, null);
            SaveImage.Invalidate();


            return SaveBitmap(SaveImage, 100);

        }








        public static BitmapImage ChgBg3(BitmapImage PHOTO, BitmapImage PHOTO2)
        {

            PHOTO.CreateOptions = BitmapCreateOptions.None;
            Grid maskPhoto = new Grid();//遮罩用





            Image IMG = new Image();
            IMG.Source = PHOTO;
            maskPhoto.Children.Add(IMG);


            Image IMG2 = new Image();
            IMG2.Source = PHOTO2;
            IMG2.Stretch = Stretch.Fill;
            IMG2.Width = PHOTO.PixelWidth;
            IMG2.Height = PHOTO.PixelHeight;
            maskPhoto.Children.Add(IMG2);

            WriteableBitmap SaveImage = new WriteableBitmap((int)PHOTO.PixelWidth, (int)PHOTO.PixelHeight);
            SaveImage.Render(maskPhoto, null);
            SaveImage.Invalidate();


            return SaveBitmap(SaveImage, 100);
        }

    }
}
