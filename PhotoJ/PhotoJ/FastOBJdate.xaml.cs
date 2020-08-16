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

    public partial class FastOBJdate : PhoneApplicationPage
    {
        ButtonDate DateBtn;
        ButtonColor ColorBtn, ColorBtn2;
        ButtonList TypeBtn,TypeBtn2, DateTypeBtn;
        List<object> obj = new List<object>();
        DateTime today = DateTime.Now.Date;
        DateTime sampleDay;


        CultureInfo TW = new CultureInfo("zh-TW");
        CultureInfo US = new CultureInfo("en-US");



        ObjDateTable DATA;

        CheckBox DATETYPE = new CheckBox();
        public FastOBJdate()
        {
            InitializeComponent();
            sampleDay = Convert.ToDateTime((today.Year.ToString()+"/01/01"));
            Init();

        }


        public void Init()
        {

            DATA = (from table in MainPage.tDBHandler.ObjDateTable
                    where FAST.BOXptr == table.MASTERI
                    select table).First();



            DATETYPE.Click+=new RoutedEventHandler(DATETYPE_Click);
            DATETYPE.Content = "指定日期";
            if (DATA.DATETYPE == 0)
            {
                DATETYPE.IsChecked = false;//當下日期時間

            }
            else
            {
                DATETYPE.IsChecked = true;
            }

            StackPanel CCC = new StackPanel();
            CCC.Margin = new Thickness(50, 0, 50, 0);
            CCC.Orientation = System.Windows.Controls.Orientation.Horizontal;
            DateBtn = new ButtonDate(this, DATA.DATE.Date);
            DateBtn.FontSize = 32;

            CCC.Children.Add(DATETYPE);

            CCC.Children.Add(DateBtn);
            BOX.Children.Add(CCC);










            StackPanel AAA = new StackPanel();
            AAA.Margin = new Thickness(50, 0, 50, 0);
            AAA.Orientation = System.Windows.Controls.Orientation.Horizontal;
            string[] Types = new string[] { "一般字體", "粗      體", "斜      體", "粗體+斜體" };
            TypeBtn = new ButtonList(this, Types, DATA.CTYPE);
            TypeBtn.FontSize = 32;
            AAA.Children.Add(TypeBtn);




            string[] C1 = DATA.COLOR.Split(',');
            ColorBtn = new ButtonColor(this, Color.FromArgb(Convert.ToByte(C1[0]), Convert.ToByte(C1[1]), Convert.ToByte(C1[2]), Convert.ToByte(C1[3])));
            ColorBtn.FontSize = 32;
            ColorBtn.Width = 200;
            AAA.Children.Add(ColorBtn);
            BOX.Children.Add(AAA);





            StackPanel BBB = new StackPanel();
            BBB.Margin = new Thickness(50, 0, 50, 0);
            BBB.Orientation = System.Windows.Controls.Orientation.Horizontal;
            string[] Types2 = new string[] { "無特效", "重疊字", "重疊字2" };
            TypeBtn2 = new ButtonList(this, Types2, DATA.CTYPE2);
            TypeBtn2.FontSize = 32;
            TypeBtn2.Loaded += TypeBtn2_Loaded;
            BBB.Children.Add(TypeBtn2);



            string[] C2 = DATA.COLOR2.Split(',');
            ColorBtn2 = new ButtonColor(this, Color.FromArgb(Convert.ToByte(C2[0]), Convert.ToByte(C2[1]), Convert.ToByte(C2[2]), Convert.ToByte(C2[3])));
            ColorBtn2.FontSize = 32;
            ColorBtn2.Width = 200;
            ColorBtn2.Visibility = System.Windows.Visibility.Collapsed;
            BBB.Children.Add(ColorBtn2);
            BOX.Children.Add(BBB);




            string[] DateTypes = new string[] { sampleDay.ToString("yyyy/MM/dd"), sampleDay.ToString("d"), sampleDay.ToString("D", TW), sampleDay.ToString("M", TW), sampleDay.ToString("Y", TW), sampleDay.ToString("D", US), sampleDay.ToString("M", US), sampleDay.ToString("Y", US) };
            DateTypeBtn = new ButtonList(this, DateTypes,DATA.FORMAT);
            DateTypeBtn.FontSize = 32;
            DateTypeBtn.Margin = new Thickness(50, 0, 50, 0);
            BOX.Children.Add(DateTypeBtn);



            updateDATETYPE();
            //updateSample();
        }


        public void updateDATETYPE()
        {
            if (DATETYPE.IsChecked == true)
            {
                DateBtn.IsEnabled = true;
            }
            else
            {
                DateBtn.IsEnabled = false;
            }
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
        private void DATETYPE_Click(object sender, RoutedEventArgs e)
        {
            updateDATETYPE();
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

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //DATA.TEXT = TEXT.myText;


            DATA.DATE = DateBtn.Date;
            DATA.DATETYPE = DATETYPE.IsChecked==true ? 1 : 0;
            DATA.FORMAT = DateTypeBtn.Index;
            DATA.CTYPE = TypeBtn.Index;
            DATA.CTYPE2 = TypeBtn2.Index;
            DATA.COLOR = ColorBtn.Index.A.ToString() + "," + ColorBtn.Index.R.ToString() + "," + ColorBtn.Index.G.ToString() + "," + ColorBtn.Index.B.ToString();
            DATA.COLOR2 = ColorBtn2.Index.A.ToString() + "," + ColorBtn2.Index.R.ToString() + "," + ColorBtn2.Index.G.ToString() + "," + ColorBtn2.Index.B.ToString();


            MainPage.tDBHandler.SubmitChanges();
        }






    }
}