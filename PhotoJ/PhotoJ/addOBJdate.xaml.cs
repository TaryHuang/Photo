using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Globalization;
using TARY_Library_Silverlight;

namespace PhotoJ
{

    public partial class addOBJdate : PhoneApplicationPage
    {
        ButtonDate DateBtn;
        ButtonColor ColorBtn, ColorBtn2;
        ButtonList TypeBtn,TypeBtn2, DateTypeBtn;
        Button OK;
        List<object> obj = new List<object>();
        DateTime today = DateTime.Now.Date;
        DateTime sampleDay;


        CultureInfo TW = new CultureInfo("zh-TW");
        CultureInfo US = new CultureInfo("en-US");

        public addOBJdate()
        {
            InitializeComponent();
            sampleDay = Convert.ToDateTime((today.Year.ToString()+"/01/01"));
            Init();

        }


        public void Init()
        {

            DateBtn = new ButtonDate(this, DateTime.Now.Date);
            DateBtn.FontSize = 32;
            DateBtn.Margin = new Thickness(50, 0, 50, 0);
            DateBtn.BorderBrush = myStyle.ButtonColor;
            DateBtn.Foreground = myStyle.ButtonColor;
            BOX.Children.Add(DateBtn);



            StackPanel AAA = new StackPanel();
            AAA.Margin = new Thickness(50, 0, 50, 0);
            AAA.Orientation = System.Windows.Controls.Orientation.Horizontal;
            string[] Types = new string[] { "一般字體", "粗      體", "斜      體", "粗體+斜體" };
            TypeBtn = new ButtonList(this, Types, 0);
            TypeBtn.FontSize = 32;
            TypeBtn.BorderBrush = myStyle.ButtonColor;
            TypeBtn.Foreground = myStyle.ButtonColor;

            AAA.Children.Add(TypeBtn);


            ColorBtn = new ButtonColor(this, Color.FromArgb(255, 255, 0, 0));
            ColorBtn.FontSize = 32;
            ColorBtn.Width = 200;
            ColorBtn.BorderBrush = myStyle.ButtonColor;
            ColorBtn.Foreground = myStyle.ButtonColor;
            AAA.Children.Add(ColorBtn);
            BOX.Children.Add(AAA);


            StackPanel BBB = new StackPanel();
            BBB.Margin = new Thickness(50, 0, 50, 0);
            BBB.Orientation = System.Windows.Controls.Orientation.Horizontal;
            string[] Types2 = new string[] { "無特效", "重疊字", "重疊字2" };
            TypeBtn2 = new ButtonList(this, Types2, 0);
            TypeBtn2.FontSize = 32;
            TypeBtn2.Loaded += TypeBtn2_Loaded;
            TypeBtn2.BorderBrush = myStyle.ButtonColor;
            TypeBtn2.Foreground = myStyle.ButtonColor;
            BBB.Children.Add(TypeBtn2);


            ColorBtn2 = new ButtonColor(this, Color.FromArgb(255, 255, 0, 0));
            ColorBtn2.FontSize = 32;
            ColorBtn2.Width = 200;
            ColorBtn2.Visibility = System.Windows.Visibility.Collapsed;
            ColorBtn2.BorderBrush = myStyle.ButtonColor;
            ColorBtn2.Foreground = myStyle.ButtonColor;
            BBB.Children.Add(ColorBtn2);
            BOX.Children.Add(BBB);




            string[] DateTypes = new string[] { sampleDay.ToString("yyyy/MM/dd"), sampleDay.ToString("d"), sampleDay.ToString("D", TW), sampleDay.ToString("M", TW), sampleDay.ToString("Y", TW), sampleDay.ToString("D", US), sampleDay.ToString("M", US), sampleDay.ToString("Y", US) };
            DateTypeBtn = new ButtonList(this, DateTypes,0);
            DateTypeBtn.FontSize = 32;
            DateTypeBtn.Margin = new Thickness(50, 0, 50, 0);
            DateTypeBtn.BorderBrush = myStyle.ButtonColor;
            DateTypeBtn.Foreground = myStyle.ButtonColor;
            BOX.Children.Add(DateTypeBtn);


            OK = new Button();
            OK.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            OK.FontSize = 36;
            OK.Content = "新 增";
            OK.BorderBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            OK.Click += OK_Click;
            OK.BorderBrush = myStyle.ButtonColor;
            OK.Foreground = myStyle.ButtonColor;
            BOX.Children.Add(OK);

        }

        private void TypeBtn2_Loaded(object sender, RoutedEventArgs e)
        {
            if (TypeBtn2.Index == 1 || TypeBtn2.Index == 2)
            {
                ColorBtn2.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ColorBtn2.Visibility = System.Windows.Visibility.Collapsed;
            }
        }



        private void OK_Click(object sender, RoutedEventArgs e)
        {

            string strDate="";
            //, , today, today, today, today.ToString("M", US), today.ToString("Y", US) };
            switch(DateTypeBtn.Index){
                case 0: strDate= DateBtn.Date.ToString("yyyy/MM/dd"); break;
                case 1: strDate = DateBtn.Date.ToString("d"); break;
                case 2: strDate = DateBtn.Date.ToString("D", TW); break;
                case 3: strDate = DateBtn.Date.ToString("M", TW); break;
                case 4: strDate = DateBtn.Date.ToString("Y", TW); break;
                case 5: strDate = DateBtn.Date.ToString("D", US); break;
                case 6: strDate = DateBtn.Date.ToString("M", US); break;
                case 7: strDate = DateBtn.Date.ToString("Y", US); break;

            }

            makephoto.BufferObjText = new MyOBJText(makephoto.ERI, "日期", strDate, ColorBtn.Index, TypeBtn.Index, ColorBtn2.Index, TypeBtn2.Index);
            NavigationService.GoBack();
        }







        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            updateSample();
        }


        void updateSample()
        {


            string strDate = "";
            //, , today, today, today, today.ToString("M", US), today.ToString("Y", US) };
            switch (DateTypeBtn.Index)
            {
                case 0: strDate = DateBtn.Date.ToString("yyyy/MM/dd"); break;
                case 1: strDate = DateBtn.Date.ToString("d"); break;
                case 2: strDate = DateBtn.Date.ToString("D", TW); break;
                case 3: strDate = DateBtn.Date.ToString("M", TW); break;
                case 4: strDate = DateBtn.Date.ToString("Y", TW); break;
                case 5: strDate = DateBtn.Date.ToString("D", US); break;
                case 6: strDate = DateBtn.Date.ToString("M", US); break;
                case 7: strDate = DateBtn.Date.ToString("Y", US); break;

            }

            sample1.Text = strDate;
            sample2.Text = strDate;


            if (TypeBtn2.Index == 0)
            {
                sample2.Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (TypeBtn2.Index == 1)
            {
                sample2.Visibility = System.Windows.Visibility.Visible;
                sample2.Margin = new Thickness(MyOBJText.MarginNum, MyOBJText.MarginNum, 0, 0);
            }
            else if (TypeBtn2.Index == 2)
            {
                sample2.Visibility = System.Windows.Visibility.Visible;
                sample2.Margin = new Thickness(-MyOBJText.MarginNum, -MyOBJText.MarginNum, 0, 0);
            }


            sample1.Foreground = new SolidColorBrush(ColorBtn.Index);
            sample2.Foreground = new SolidColorBrush(ColorBtn2.Index);


            //粗體斜體判斷
            switch (TypeBtn.Index)
            {
                case 0: sample1.FontWeight = FontWeights.Normal; sample2.FontWeight = FontWeights.Normal; break;
                case 1: sample1.FontWeight = FontWeights.Bold; sample2.FontWeight = FontWeights.Bold; break;

                case 2: sample1.FontStyle = FontStyles.Italic; sample2.FontStyle = FontStyles.Italic; break;

                case 3: sample1.FontWeight = FontWeights.Bold;
                    sample1.FontStyle = FontStyles.Italic;
                    sample2.FontWeight = FontWeights.Bold;
                    sample2.FontStyle = FontStyles.Italic; break;
            }
        }
    }
}