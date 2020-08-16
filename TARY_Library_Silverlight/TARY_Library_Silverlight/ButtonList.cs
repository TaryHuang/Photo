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

    public class ButtonList : Button
    {
        PhoneApplicationPage Page;
        public String Title = myLanguage.getValue("請選取：");
        int index = -1, index2=-1;

        bool changeBool = false, BanLoad=false;//是否異動 及 禁止load兩次
        string[] List;

        public ButtonList(PhoneApplicationPage PG,string[] List,int IndexDefault)
        {


            this.Name = "ButtonList"+ButtonListFORM.getToken.ToString();


            this.Page = PG;
            this.List = List;

            this.Content = List[IndexDefault];
            index = IndexDefault;
            this.Loaded +=new RoutedEventHandler(ButtonList_Loaded);

        }



        private void ButtonList_Loaded(object sender, RoutedEventArgs e)
        {
            if (BanLoad)
                return;

            if (ButtonListFORM.ptrIndex(this.Name) != -1)
            {

                index2=ButtonListFORM.ptrIndex(this.Name);
                //判定資料是否異動
                if (index != index2)
                {
                    changeBool = true;
                }
                index=index2;

                this.Content = List[ButtonListFORM.ptrIndex(this.Name)];
                BanLoad = true;
            }

            
        }   


        protected override void OnClick()
        {
            base.OnClick();
            ButtonListFORM.box = List;
            ButtonListFORM.title = Title;
            changeBool = false;
            BanLoad = false;
            Page.NavigationService.Navigate(new Uri("/TARY_Library_Silverlight;component/ButtonListFORM.xaml?ptrName=" + this.Name + "&Index=" + Index.ToString(), UriKind.Relative));

        }

        public void Show()
        {
            OnClick();
        }

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
                this.Content = List[index];
                ButtonListFORM.setIndex(this.Name, index);
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
