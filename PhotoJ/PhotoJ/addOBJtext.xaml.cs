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

    public partial class addOBJtext : PhoneApplicationPage
    {
        TextBoxR TEXT;
        ButtonColor ColorBtn, ColorBtn2;

        ButtonList TypeBtn, TypeBtn2;
        Button OK;
        List<object> obj = new List<object>();

        public addOBJtext()
        {
            InitializeComponent();

            Init();

        }


        public void Init()
        {

            TEXT = new TextBoxR(200, "請輸入文字");
            TEXT.Margin = new Thickness(50, 0, 50, 0);
            TEXT.KeyDown += TEXT_KeyDown;
            TEXT.BorderBrush = myStyle.ButtonColor;
            TEXT.Foreground = myStyle.ButtonColor;
            BOX.Children.Add(TEXT);




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
            TypeBtn2.Loaded +=TypeBtn2_Loaded;
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







            //表情符號-----------------------

            ScrollViewer Sign = new ScrollViewer();
            Sign.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            Sign.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            StackPanel SignBox =new StackPanel();
            SignBox.Orientation = System.Windows.Controls.Orientation.Horizontal;
            string[] signList = SignList.Box();

            for (int i = 0; i < signList.Count(); i++)
            {
                Button btn =new Button();
                btn.Content = signList[i];
                btn.Click +=new RoutedEventHandler(addText_Click);
                btn.BorderBrush = myStyle.ButtonColor;
                btn.Foreground = myStyle.ButtonColor;
                SignBox.Children.Add(btn);
            }

            Sign.Content = SignBox;
            BOX.Children.Add(Sign);

            //-----------------------表情符號
            OK = new Button();
            OK.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            OK.FontSize = 36;
            OK.Content = "新 增";
            OK.BorderBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            OK.Click += OK_Click;
            OK.BorderBrush = myStyle.ButtonColor;
            OK.Foreground = myStyle.ButtonColor;
            BOX.Children.Add(OK);
            updateSample();
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
                OK.Focus();
            }
        }

        private void addText_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            TEXT.myText += btn.Content.ToString();

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

    }




}