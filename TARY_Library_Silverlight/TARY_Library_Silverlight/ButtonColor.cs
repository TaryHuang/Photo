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
using Microsoft.Phone.Controls;
namespace TARY_Library_Silverlight
{

    public class ButtonColor : Button
    {
        PhoneApplicationPage Page;
        public String Title = myLanguage.getValue("請選取：");
        Color index = Colors.Transparent, index2 = Colors.Transparent;

        bool changeBool = false, BanLoad=false;//是否異動 及 禁止load兩次


        public ButtonColor(PhoneApplicationPage PG,Color IndexDefault)
        {


            this.Name = "ButtonColor" + ButtonColorFORM.getToken.ToString();

            //MessageBox.Show(IndexDefault.R.ToString() + "," + IndexDefault.B.ToString() + "," + IndexDefault.G.ToString());
            this.Page = PG;
            index = IndexDefault;

            this.Content = " ";
            this.Background = new SolidColorBrush(index);

            this.BorderThickness = new Thickness(3, 3, 3, 3);
            this.Loaded += new RoutedEventHandler(ButtonColor_Loaded);

        }



        private void ButtonColor_Loaded(object sender, RoutedEventArgs e)
        {
            if (BanLoad)
                return;

            if (ButtonColorFORM.ptrIndex(this.Name) != Colors.Transparent)
            {

                index2 = ButtonColorFORM.ptrIndex(this.Name);

                //判定資料是否異動
                if (index != index2)
                {
                    changeBool = true;
                }

                index=index2;

                this.Background = new SolidColorBrush(index);

                BanLoad = true;
            }
            
        }   


        protected override void OnClick()
        {
            base.OnClick();
            ButtonColorFORM.title = Title;
            changeBool = false;
            BanLoad = false;
            Page.NavigationService.Navigate(new Uri("/TARY_Library_Silverlight;component/ButtonColorFORM.xaml?ptrName=" + this.Name + "&Index=" + Index.A.ToString()
                + "&R=" + Index.R.ToString() + "&B=" + Index.B.ToString() + "&G=" + Index.G.ToString(), UriKind.Relative));

        }


        public Color Index
        {
            get
            {
                return index;
            }
        }

        public bool ChangeBool
        {
            get
            {
                return changeBool;
            }
        }
    }
}
