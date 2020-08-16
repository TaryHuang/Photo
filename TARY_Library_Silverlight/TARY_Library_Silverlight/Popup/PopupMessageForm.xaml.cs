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
using System.Diagnostics;
using System.Windows.Media.Imaging;

using System.IO;

using Microsoft.Phone.Shell;

namespace TARY_Library_Silverlight.Popup
{
    public partial class PopupMessageForm : UserControl
    {
        bool show = false;
        Button Closebtn = new Button();

        public PhoneApplicationPage page;
        public bool CloseAppBarShow = true;//appbar在．．關閉視窗後　執行APPBAR開啟

        public bool isShow
        {
            get
            {
                return show;
               
            }

            
        }

        


         public PopupMessageForm(PhoneApplicationPage Page,string TITLE, string TEXT,Button OKbtn,Button Cancelbtn)
         {
             this.page = Page;
             this.page.BackKeyPress += page_BackKeyPress;
             InitializeComponent();
             Init();
   
             OKbtn.FontSize = 32;
             OKbtn.Click += Close_Click;
             Bottom.Children.Add(OKbtn);


             Cancelbtn.FontSize = 32;
             Cancelbtn.Click += Close_Click;
             Bottom.Children.Add(Cancelbtn);
             ACTION.Completed += ACTION_Completed;

             Title = TITLE;
             Text = TEXT;
         }

         void ACTION_Completed(object sender, System.EventArgs e)
         {
             show = true;
         }



         void page_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
         {
             if(isShow){
                 Close();
                 e.Cancel = true;

             }

         }







         void Init()
         {
             this.Visibility = System.Windows.Visibility.Collapsed;
             CloseStory.Completed += CloseStory_Completed;
         }
        
        public void Show(){
            
            CloseAppBarShow = true;
            if (page != null)
            {
                page.ApplicationBar.IsVisible = false;
            }

           this.Visibility = System.Windows.Visibility.Visible;
           


            ACTION.Begin();
            


        }


        public string Title{
            get{
                return title.Text;
            }

            set
            {
                title.Text = value;
            }  
        }



        public string Text
        {
            get
            {
                return MsgText.Text;
            }

            set
            {
                MsgText.Text = value;
            }
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Close()
        {
            //特效
            CloseStory.Begin();
        }

        private void CloseStory_Completed(object sender, System.EventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
            show = false;

            if (CloseAppBarShow)
            {
                if (page != null)
                {
                    page.ApplicationBar.IsVisible = true;
                }
            }
            else
            {
                if (page != null)
                {
                    page.ApplicationBar.IsVisible = false;
                }

            }
        }


    }
}
