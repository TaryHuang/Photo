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

using TARY_Library_Silverlight;

namespace PhotoJ
{

    public partial class FastOBJtext : PhoneApplicationPage
    {
        TextBoxR TEXT;
        ButtonColor ColorBtn, ColorBtn2;

        ButtonList TypeBtn, TypeBtn2;
        List<object> obj = new List<object>();
        ObjTextTable DATA;
        public FastOBJtext()
        {
            InitializeComponent();

            Init();

        }


        public void Init()
        {

            DATA = (from table in MainPage.tDBHandler.ObjTextTable
                      where FAST.BOXptr == table.MASTERI
                      select table).First();






            TEXT = new TextBoxR(200, "請輸入文字");
            TEXT.myText = DATA.TEXT;
            TEXT.Margin = new Thickness(50, 0, 50, 0);
            TEXT.KeyDown += TEXT_KeyDown;
            BOX.Children.Add(TEXT);




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
            TypeBtn2.Loaded +=TypeBtn2_Loaded;
            BBB.Children.Add(TypeBtn2);



            string[] C2 = DATA.COLOR2.Split(',');
            ColorBtn2 = new ButtonColor(this, Color.FromArgb(Convert.ToByte(C2[0]), Convert.ToByte(C2[1]), Convert.ToByte(C2[2]), Convert.ToByte(C2[3])));
            ColorBtn2.FontSize = 32;
            ColorBtn2.Width = 200;
            ColorBtn2.Visibility = System.Windows.Visibility.Collapsed;
            BBB.Children.Add(ColorBtn2);
            BOX.Children.Add(BBB);


            //表情符號-----------------------

            ScrollViewer Sign = new ScrollViewer();
            Sign.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            Sign.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            StackPanel SignBox = new StackPanel();
            SignBox.Orientation = System.Windows.Controls.Orientation.Horizontal;
            string[] signList = SignList.Box();

            for (int i = 0; i < signList.Count(); i++)
            {
                Button btn = new Button();
                btn.Content = signList[i];
                btn.Click += new RoutedEventHandler(addText_Click);
                SignBox.Children.Add(btn);
            }

            Sign.Content = SignBox;
            BOX.Children.Add(Sign);

            //-----------------------表情符號

            updateSample();
        }

        private void addText_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            TEXT.myText += btn.Content.ToString();

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



        private void TEXT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                ColorBtn.Focus();
            }
        }


        private void OK_Click(object sender, RoutedEventArgs e)
        {

            makephoto.BufferObjText = new MyOBJText(makephoto.ERI, "文字", TEXT.Text, ColorBtn.Index, TypeBtn.Index, ColorBtn2.Index, TypeBtn2.Index);
            NavigationService.GoBack();
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            updateSample();
        }


        void updateSample(){

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
            DATA.TEXT = TEXT.myText;

            DATA.CTYPE = TypeBtn.Index;
            DATA.CTYPE2 = TypeBtn2.Index;
            DATA.COLOR = ColorBtn.Index.A.ToString() + "," + ColorBtn.Index.R.ToString() + "," + ColorBtn.Index.G.ToString() + "," + ColorBtn.Index.B.ToString();
            DATA.COLOR2 = ColorBtn2.Index.A.ToString() + "," + ColorBtn2.Index.R.ToString() + "," + ColorBtn2.Index.G.ToString() + "," + ColorBtn2.Index.B.ToString();


            MainPage.tDBHandler.SubmitChanges();
        }
    }
}