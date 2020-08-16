using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using Microsoft.Phone.Tasks;
using TARY_Library_Silverlight.Photo;
namespace PhotoJ
{

    public partial class FastOBJphoto : PhoneApplicationPage
    {

        BitmapImage Bimg;
        FastTable DataM;
        ObjPhotoTable[] DATA;
        WriteableBitmap bitmap;
        int W, H;
        bool tUpdate = false;//是否更新
        public FastOBJphoto()
        {
            InitializeComponent();

            Init();

        }


        public void Init()
        {

             DataM = (from table in MainPage.tDBHandler.FastTable
                               where FAST.BOXptr == table.ID
                               select table).First();


             DATA = (from table in MainPage.tDBHandler.ObjPhotoTable
                     where FAST.BOXptr == table.MASTERI
                     orderby table.ORD
                     select table).ToArray();


             List<byte> temp = new List<byte>();

             for (int i = 0; i < DATA.Count();i++ )
             {
                 temp.AddRange(DATA[i].Photo);
             }


            try
            {


                bitmap = new WriteableBitmap(DataM.Width, DataM.Height);

                int j = 0;
                for (int i = 0; i < bitmap.Pixels.Count(); i++)
                {
                    byte[] pixBytes = new byte[4];

                    pixBytes[0] = temp[j + 0];
                    pixBytes[1] = temp[j + 1];
                    pixBytes[2] = temp[j + 2];
                    pixBytes[3] = temp[j + 3];


                    bitmap.Pixels[i] = BitConverter.ToInt32(pixBytes,0);
                    j += 4;
                }


                Bimg = PhotoEdit.SaveBitmap(bitmap, 100);


                image1.Source = Bimg;

                W = Bimg.PixelWidth;
                H = Bimg.PixelHeight;


            }
            catch
            {
            }
        }












        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            var photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += PhotoChooserTaskCompleted;
            photoChooserTask.Show();

        }




        void PhotoChooserTaskCompleted(object sender, PhotoResult e)
        {

            switch (e.TaskResult)
            {
                case TaskResult.OK:
                    Bimg = new BitmapImage(new Uri(e.OriginalFileName));








                    image1.Source = Bimg;
                    break;
            }



        }

        private void PhoneApplicationPage_BackKeyPress_1(object sender, System.ComponentModel.CancelEventArgs e)
        {


            if (Bimg == null || tUpdate==false)
            {
                return;
            }



            bitmap = new WriteableBitmap(Bimg);

            List<byte> BBB =new List<byte>();
            int j = 0;
            for (int i = 0; i < bitmap.Pixels.Count();i++)
            {
                byte[] pixBytes = BitConverter.GetBytes(bitmap.Pixels[i]);

                BBB.Add(pixBytes[0]);
                BBB.Add(pixBytes[1]);
                BBB.Add(pixBytes[2]);
                BBB.Add(pixBytes[3]);

                j += 4;
            }


            DataM.Width = W;
            DataM.Height = H;



            //刪除資料------------------------------------
            
            ObjPhotoTable[] VAR = (from table in MainPage.tDBHandler.ObjPhotoTable
                      where table.MASTERI == FAST.BOXptr
                      select table).ToArray();

            if (VAR.Count()!=0)
                MainPage.tDBHandler.ObjPhotoTable.DeleteAllOnSubmit(VAR);



            //儲存分割處理--------------------------
            int BOX_INDEX = (BBB.Count()/1000)==0 ? (BBB.Count()/1000) : (BBB.Count()/1000)+1;
            ObjPhotoTable[] BOX= new ObjPhotoTable[BOX_INDEX];

            for (int i = 0; i < BOX.Count(); i++)
            {
                BOX[i] = new ObjPhotoTable();
                BOX[i].MASTERI = FAST.BOXptr;
                BOX[i].ORD = i;

                byte[] bbb;
                if(i == BOX.Count()-1)
                    bbb = (BBB.GetRange(i * 1000, BBB.Count()%1000)).ToArray();
                else
                    bbb = (BBB.GetRange(i * 1000,1000)).ToArray();

                    //(((from table in BBB
                    //            select table).Skip(i*1000).Take(1000))).ToArray(); 慢
                BOX[i].Photo = bbb;

                
            }


            MainPage.tDBHandler.ObjPhotoTable.InsertAllOnSubmit(BOX);

            MainPage.tDBHandler.SubmitChanges();

        }

        private void image1_ImageOpened(object sender, RoutedEventArgs e)
        {

            tUpdate = true;//back的時候 就更新



            if (Bimg.PixelWidth >= 480 || Bimg.PixelHeight >= 480)
            {

                Point P = TARY_Library_Silverlight.Photo.PhotoEdit.BestSize2(Bimg, 480, 480);

                Bimg = TARY_Library_Silverlight.Photo.PhotoEdit.Size(Bimg, (int)P.X, (int)P.Y);
            }
            W = Bimg.PixelWidth;
            H = Bimg.PixelHeight;



            image1.Width = W;
            image1.Height = H;



        }



    }
}