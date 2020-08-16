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

    public class ButtonDate : Button
    {
        PhoneApplicationPage Page;
        public String Title = myLanguage.getValue("請選擇：");
        DateTime index = Convert.ToDateTime("1899/01/01");
        DateTime index2 = Convert.ToDateTime("1899/01/01");

        bool changeBool = false, BanLoad=false;//是否異動 及 禁止load兩次


        public DateTime Date;


        public ButtonDate(PhoneApplicationPage PG,DateTime date)
        {
            this.Date = date;

            this.Name = "ButtonDate" + ButtonDateFORM.getToken.ToString();


            this.Page = PG;


            this.Content = this.Date.ToString("yyyy/MM/dd");
            this.Loaded +=new RoutedEventHandler(ButtonList_Loaded);

        }



        private void ButtonList_Loaded(object sender, RoutedEventArgs e)
        {
            if (BanLoad)
                return;


            if (ButtonDateFORM.ptrIndex(this.Name) != Convert.ToDateTime("1899/01/01"))
            {

                index2 = ButtonDateFORM.ptrIndex(this.Name);
                //判定資料是否異動
                if (index != index2)
                {
                    changeBool = true;
                }
                index=index2;

                Date = index;
                this.Content = index.ToString("yyyy/MM/dd");
                BanLoad = true;
            }

            
        }   


        protected override void OnClick()
        {
            base.OnClick();


            changeBool = false;
            BanLoad = false;
            Page.NavigationService.Navigate(new Uri("/TARY_Library_Silverlight;component/ButtonDateFORM.xaml?ptrName="+this.Name+"&Date="+this.Date.ToString("yyyy/MM/dd"), UriKind.Relative));

        }


        public DateTime getDate
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
