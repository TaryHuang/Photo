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
using TARY_Library_Silverlight;
using TARY_Library_Silverlight.Popup;
namespace PhotoJ
{
    public partial class FastAdd : PhoneApplicationPage
    {
        public FastAdd()
        {
            InitializeComponent();

            Init();
        }

        ButtonListR Fctype;
        TextBoxR2 Title;
        Button OK;
        PopupMessageForm Msg;
        public void Init()
        {



            Title = new TextBoxR2(12, "請輸入文字", "命  名 : ");
            Title.TextBoxR.Width = 320;
            Title.Margin = new Thickness(10, 0, 0, 0);
            Title.KeyDown+=Title_KeyDown;
            Box.Children.Add(Title);

            string[] strCtype = new string[] { "文  字","日  期","圖  片"};
            Fctype = new ButtonListR("屬  性 : ", this, strCtype, 0);
            Fctype.Margin = new Thickness(10, 0, 0, 0);
            Box.Children.Add(Fctype);



            OK = new Button();
            
            OK.Content = "新 增";
            OK.FontSize = 36;
            OK.BorderThickness = new Thickness(0, 0, 0, 0);
            OK.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            OK.Click+=new RoutedEventHandler(OK_Click);
            Box.Children.Add(OK);


        }
        private void Title_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OK.Focus();
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

            if (Title.myText.Length==0)
            {
                MessageBox.Show("您尚未填入資料!");
                //Msg = new PopupMessageForm("系統訊息", "您輸入的資料不符合!");
                //LayoutRoot.Children.Add(Msg);
                //Msg.Show();
                return;
            }





            DateTime Now;
            Now = DateTime.Now;
            FastTable AAA = new FastTable();
            AAA.CTYPE = Fctype.Index;
            AAA.Title = Title.myText;
            AAA.DATE = Now;
            MainPage.tDBHandler.FastTable.InsertOnSubmit(AAA);
            MainPage.tDBHandler.SubmitChanges();

            int ERI = (from TABLE in MainPage.tDBHandler.FastTable
                       where Now == TABLE.DATE
                       select TABLE.ID).First();

            if(Fctype.Index == 0){




                ObjTextTable BBB = new ObjTextTable();
                BBB.MASTERI = ERI;
                BBB.TEXT = "我的文字";
                BBB.CTYPE = 0;
                BBB.COLOR = "255,255,0,0";
                BBB.CTYPE2 = 0;
                BBB.COLOR2 = "255,255,0,0";

                MainPage.tDBHandler.ObjTextTable.InsertOnSubmit(BBB);
                MainPage.tDBHandler.SubmitChanges();
            }
            else if (Fctype.Index == 1)
            {

                ObjDateTable BBB = new ObjDateTable();
                BBB.MASTERI = ERI;
                BBB.DATETYPE = 0;
                BBB.DATE = DateTime.Now.Date;
                BBB.CTYPE = 0;
                BBB.COLOR = "255,255,0,0";
                BBB.CTYPE2 = 0;
                BBB.COLOR2 = "255,255,0,0";
                BBB.FORMAT = 0;
                MainPage.tDBHandler.ObjDateTable.InsertOnSubmit(BBB);
                MainPage.tDBHandler.SubmitChanges();
            }
            else if (Fctype.Index == 2)
            {
                AAA.Width = 0;
                AAA.Height = 0;
                MainPage.tDBHandler.SubmitChanges();
            }

            



            NavigationService.GoBack();

        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {

                Box.Width = 480-20;

            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                Box.Width = 800 - 20;

            }
        }
    }
}