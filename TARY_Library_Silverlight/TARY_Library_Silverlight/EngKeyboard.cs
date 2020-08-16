using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TARY_Library_Silverlight
{
    public class EngKeyboard : Grid
    {

        Button LOCK;//切換大小寫
        public bool tLOCK;//true大寫  false小寫
        Button[] ABC = new Button[26];
        int ABC_X = 0;
        int ABC_Y = 50;
        string[] L1 = new string[] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" };
        string[] L2 = new string[] { "A", "S", "D", "F", "G", "H", "J", "K", "L" };
        string[] L3 = new string[] { "Z", "X", "C", "V", "B", "N", "M"};
        public EngKeyboard()
        {
            this.Width = 800;
            this.Height = 300;
            tLOCK = false;
            makeABC();
        }


        void makeABC(){
            for (int i = 0; i < ABC.Length;i++ )
            {
                ABC[i] = new Button();
                ABC[i].Width = 70;
                ABC[i].Height = 70;
                ABC[i].VerticalAlignment = VerticalAlignment.Top;//靠上方
                ABC[i].HorizontalAlignment = HorizontalAlignment.Left;//靠左邊
                ABC[i].Padding = new Thickness(0, 0, 0, 0);
                this.Children.Add(ABC[i]);
            }


            for (int i = 0;i< L1.Length;i++)
            {
                ABC[i].Content = L1[i];
                ABC[i].Margin = new Thickness(60 * i + 20+ABC_X, ABC_Y, 0, 0);
            }



            for (int i = 0; i < L2.Length; i++)
            {
                ABC[i + L1.Length].Content = L2[i];
                ABC[i + L1.Length].Margin = new Thickness(60 * i + 60 + ABC_X, 60 + ABC_Y, 0, 0);
            }


            for (int i = 0; i < L3.Length; i++)
            {
                ABC[i + L1.Length + L2.Length].Content = L3[i];
                ABC[i + L1.Length + L2.Length].Margin = new Thickness(60 * i + 100 + ABC_X, 120 + ABC_Y, 0, 0);
            }




            //切換大小寫鍵
            LOCK = new Button();
            LOCK.Width = 100;
            LOCK.Height = 70;
            LOCK.VerticalAlignment = VerticalAlignment.Top;//靠上方
            LOCK.HorizontalAlignment = HorizontalAlignment.Left;//靠左邊
            LOCK.Content = "切換";
            LOCK.Click+=new RoutedEventHandler(LOCK_Click);
            LOCK.Margin = new Thickness(0+ABC_X, 120+ABC_Y, 0, 0);
            this.Children.Add(LOCK);
            changeABC();
        }


        private void LOCK_Click(object sender, RoutedEventArgs e)
        {
            changeABC();
        }


        void changeABC(){
            tLOCK=!tLOCK;


            if(tLOCK){
                //轉大寫
                string Estr;
                for (int i = 0; i < ABC.Length;i++ )
                {
                    Estr = ABC[i].Content.ToString();
                    ABC[i].Content = Estr.ToUpper();
                }
            }else{
                //轉小寫
                string Estr;
                for (int i = 0; i < ABC.Length; i++)
                {
                    Estr = ABC[i].Content.ToString();
                    ABC[i].Content = Estr.ToLower();
                }

            }
        }
    }
}
