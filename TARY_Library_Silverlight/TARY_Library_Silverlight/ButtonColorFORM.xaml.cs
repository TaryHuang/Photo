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

namespace TARY_Library_Silverlight
{
    partial class ButtonColorFORM : PhoneApplicationPage
    {
        public static string[] box;
        public static string title="";
        static int token = -1;//目前號碼牌

        string ptrName;//目前的btn指標
        static List<Color> INDEX = new List<Color>();
        static List<string> CNAME  = new List<string>();


        string[] AphiaStr = new string[]{"100%","90%","80%","70%","60%","50%","40%","30%","20%","10%"};
        ListNext Aphia;

        public ButtonColorFORM()
        {
            InitializeComponent();

        }




        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = title;
            int KIndex = Convert.ToInt32(NavigationContext.QueryString["Index"]);
            byte R = Convert.ToByte(NavigationContext.QueryString["R"]);
            byte B = Convert.ToByte(NavigationContext.QueryString["B"]);
            byte G = Convert.ToByte(NavigationContext.QueryString["G"]);
            myA.Background = new SolidColorBrush(Color.FromArgb((byte)KIndex, R, G, B));




            KIndex = (255 - KIndex) / 25;

            Aphia = new ListNext(AphiaStr, KIndex);
            Aphia.AutoBack = true;
            Aphia.Text.FontSize = 32;
            Aphia.NextBtn.Click += new RoutedEventHandler(AphiaNextBtn_Click);
            Aphia.PrevBtn.Click += new RoutedEventHandler(AphiaPrevBtn_Click);


            AphiaGrid.Children.Add(Aphia);

            ptrName = NavigationContext.QueryString["ptrName"];
            if (ptr(NavigationContext.QueryString["ptrName"]) == -1)
            {
                ADD(NavigationContext.QueryString["ptrName"]);
            }

            updateAphia();
       }



        private void AphiaNextBtn_Click(object sender, RoutedEventArgs e)
        {

            updateAphia();
        }

        private void AphiaPrevBtn_Click(object sender, RoutedEventArgs e)
        {

            updateAphia();
        }



        void updateAphia()
        {
            Border[] B = new Border[] { B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, 
                                        B11, B12, B13, B14,B15,B16,B17,B18,B19,B20,
                                        B21, B22, B23, B24,B25,B26,B27,B28,B29,B30};


            for (int i = 0; i < B.Count();i++ )
            {
                Color C = ((SolidColorBrush)(B[i].Background)).Color;


                int NUM = 255-(Aphia.Index * 25);
                C.A = Convert.ToByte(NUM);

                B[i].Background = new SolidColorBrush(C);

            }


            int n = 255 - (Aphia.Index * 25);
            Color c = ((SolidColorBrush)(myA.Background)).Color;
            c.A = Convert.ToByte(n);
            myB.Background = new SolidColorBrush(c);



        }


        void ADD(string str)
        {
            CNAME.Add(str);
            INDEX.Add(Colors.Transparent);
        }







        public static int ptr(string STR)
        {
            for (int i = 0; i < CNAME.Count;i++ )
            {
                if(CNAME[i]==STR){
                    return i;
                }
            }
            return -1;
        }





        public static Color ptrIndex(string STR)
        {
            for (int i = 0; i < CNAME.Count; i++)
            {
                if (CNAME[i] == STR)
                {
                    return INDEX[i];
                }
            }
            return Colors.Transparent;
        }




        public static int getToken
        {
            get
            {
                token++;
                return token;//給予號碼牌
                
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border btn = sender as Border;


            Color myColor;
            SolidColorBrush B = new SolidColorBrush();
            myColor  = ((SolidColorBrush)btn.Background).Color;

            
            if (ptr(ptrName) != -1)
            {
                INDEX[ptr(ptrName)] = myColor;
            }



            NavigationService.GoBack();
        }

        private void PhoneApplicationPage_OrientationChanged_1(object sender, OrientationChangedEventArgs e)
        {

            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                my.Margin = new Thickness(285,40,0,0);
                my.SetValue(Grid.RowProperty, 2);
                AphiaGrid.SetValue(Grid.RowProperty,  2);
                AphiaGrid.Margin = new Thickness(0, 0, 0, 0);
            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                my.Margin = new Thickness(485,150,0,0);
                my.SetValue(Grid.RowProperty, 1);
                AphiaGrid.SetValue(Grid.RowProperty, 1);
                AphiaGrid.Margin = new Thickness(450, 0, 0, 0);
            }
            
        }


    }


}