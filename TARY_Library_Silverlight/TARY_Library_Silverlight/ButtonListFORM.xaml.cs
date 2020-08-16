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
    partial class ButtonListFORM : PhoneApplicationPage
    {
        public static string[] box;
        public static string title="";
        static int token = -1;//目前號碼牌

        string ptrName;//目前的btn指標
        static List<int> INDEX = new List<int>();
        static List<string> CNAME  = new List<string>();        

        public ButtonListFORM()
        {
            InitializeComponent();

        }




        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = title;
            int KIndex = Convert.ToInt32(NavigationContext.QueryString["Index"]);
            int SIndex = -1;
            for (int i = 0; i < box.Length; i++)
            {
                Button AAA = new Button();
                AAA.BorderThickness = new Thickness(0,0,0,0);
                AAA.Name = i.ToString();
                AAA.FontSize = 36;
                AAA.Content = box[i];
                AAA.Click+=new RoutedEventHandler(AAA_Click);



                
                if (i == KIndex)
                {
                    AAA.Foreground = new SolidColorBrush(Color.FromArgb(255,255,0,0));
                    SIndex = i;
                }
                
                myBox.Items.Add(AAA);



            }
            myBox.SelectedIndex = SIndex;


            ptrName = NavigationContext.QueryString["ptrName"];
            if (ptr(NavigationContext.QueryString["ptrName"]) == -1)
            {
                ADD(NavigationContext.QueryString["ptrName"]);
            }
            
          
       }


        private void AAA_Click(object sender, RoutedEventArgs e)
        {
            Button text = sender as Button;
            int R = Convert.ToInt32(text.Name);


            if (ptr(ptrName) != -1)
            {
                INDEX[ptr(ptrName)] = R;
            }

            NavigationService.GoBack();   
        }




        void ADD(string str)
        {
            CNAME.Add(str);
            INDEX.Add(-1);
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


        public static void setIndex(string STR,int ANS)
        {
            for (int i = 0; i < CNAME.Count; i++)
            {
                if (CNAME[i] == STR)
                {
                    INDEX[i] = ANS;
                }
            }
        }


        public static int ptrIndex(string STR)
        {
            for (int i = 0; i < CNAME.Count; i++)
            {
                if (CNAME[i] == STR)
                {
                    return INDEX[i];
                }
            }
            return -1;
        }



        public static int getToken
        {
            get
            {
                token++;
                return token;//給予號碼牌
                
            }
        }

        private void PhoneApplicationPage_OrientationChanged_1(object sender, OrientationChangedEventArgs e)
        {


            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                myBox.Width = 450;
                myBox.Height = 660;
            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                myBox.Height = 375;
                myBox.Width = 718;
            }
        }



    }


}