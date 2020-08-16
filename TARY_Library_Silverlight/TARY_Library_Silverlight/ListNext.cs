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
using System.Xml;
using System.Xml.Linq;
using TARY_Library_Silverlight;
using System.Globalization;
namespace TARY_Library_Silverlight
{
    public class ListNext : Grid
    {
        public List<string> StrList = new List<string>();
        int index;//目前選取指標
        public Button PrevBtn = new Button();
        public Button NextBtn = new Button();
        public TextBlock Text = new TextBlock();


        bool autoBack=false;//是否自動回第一筆


        public ListNext(string[] str,int index)
        {
            Init();

            

            StrList = str.ToList();



            this.Index = index;
            UpdateBtn();
        }

        public void Init(){
            PrevBtn.Content = "﹤";
            PrevBtn.BorderBrush = new SolidColorBrush(Color.FromArgb(0,0,0,0));
            PrevBtn.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            PrevBtn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            PrevBtn.Click += new RoutedEventHandler(PrevBtn_Click);
            this.Children.Add(PrevBtn);
            
            NextBtn.Content = "﹥";
            NextBtn.BorderBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            NextBtn.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            NextBtn.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            NextBtn.Click += new RoutedEventHandler(NextBtn_Click);
            this.Children.Add(NextBtn);






            Text.FontSize = 48;
            Text.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Text.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            this.Children.Add(Text);

        }

        void UpdateBtn()
        {
            if (AutoBack)
            {
                NextBtn.Visibility = Visibility.Visible;
                PrevBtn.Visibility = Visibility.Visible;
                return;
            }

            //判定是否顯示此BUTTON
            if (this.Index == StrList.Count()-1)
            {
                NextBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                NextBtn.Visibility = Visibility.Visible;
            }



            //判定是否顯示此BUTTON
            if (this.Index == 0)
            {
                PrevBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                PrevBtn.Visibility = Visibility.Visible;
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.Index + 1 < StrList.Count())
            {
                this.Index += 1;
            }
            else
            {
                this.Index = 0;
            }

        }


        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {

            if (this.Index - 1 >= 0)
            {
                this.Index -= 1;
            }
            else
            {
                this.Index = StrList.Count()-1;
            }

        }




        public bool AutoBack
        {
            get
            {
                return autoBack;
            }
            set
            {
                autoBack = value;
                UpdateBtn();
            }
        }


        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                //代表可以++ 或--
                if (value >= 0 && value < StrList.Count())
                {
                    index = value;
                    Text.Text = StrList[index];
                }
                UpdateBtn();
            }
        }
    }
}
