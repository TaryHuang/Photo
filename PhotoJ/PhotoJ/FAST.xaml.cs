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

namespace PhotoJ
{
    public partial class FAST : PhoneApplicationPage
    {

        public static int BOXptr = -1;

        public FAST()
        {
            InitializeComponent();





        }


        public void Update()
        {
             Box.Items.Clear();


             var FastDB = (from TABLE in MainPage.tDBHandler.FastTable
                           orderby TABLE.Title
                           select TABLE);


            foreach (FastTable AAA in FastDB)
            {
                myTextBlock M = new myTextBlock(AAA.ID, AAA.CTYPE, AAA.Title);
                //M.TextBlock.MouseLeftButtonUp+=new MouseButtonEventHandler(TextBlock_MouseLeftButtonUp);

                Box.Items.Add(M);
                if(BOXptr == AAA.ID){
                    Box.SelectedItem = M;
                }
            }

           // Box.SelectedIndex = BOXptr;
        }




        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }



        private void ADD_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FastADD.xaml", UriKind.Relative));
        }

        private void DEL_Click(object sender, EventArgs e)
        {
            if ( Box.SelectedIndex == -1)
            {
                return;
            }
            else
            {

               myTextBlock M = Box.Items[Box.SelectedIndex] as myTextBlock;

               FastTable VAR = (from TABLE in MainPage.tDBHandler.FastTable
                         where TABLE.ID == M.ERI
                         select TABLE).First();



               MainPage.tDBHandler.FastTable.DeleteOnSubmit(VAR);
               MainPage.tDBHandler.SubmitChanges();

               Update();
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            Update();
        }

        private void Box_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (Box.SelectedIndex==-1)
            {
                return ;
            }


            myTextBlock M = Box.Items[Box.SelectedIndex] as myTextBlock;
            if (M.ERI== BOXptr)
            {
                
                switch (M.CTYPE)
                {
                    case 0: NavigationService.Navigate(new Uri("/FastOBJtext.xaml", UriKind.Relative)); break;
                    case 1: NavigationService.Navigate(new Uri("/FastOBJdate.xaml", UriKind.Relative)); break;
                    case 2: NavigationService.Navigate(new Uri("/FastOBJphoto.xaml", UriKind.Relative)); break;
                }
            }
            else
            {
                BOXptr = M.ERI;
            }
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {

                Box.Width = 480 - 20;

            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                Box.Width = 800 - 20;

            }
        }
}


    public class myButton : Button
    {
        public int ERI;//熱建ｋｅｙ值
        public int CTYPE;
        public int WIDTH;
        public int HEIGHT;
        public myButton(int ERI, int CTYPE, string title)
        {
            this.ERI = ERI;
            this.CTYPE = CTYPE;


            this.Content = title;

        }
    }
        public class myTextBlock : StackPanel
        {
            public int ERI;//熱建ｋｅｙ值
            public int CTYPE;
            public TextBlock TextBlock = new TextBlock();


            public myTextBlock(int ERI,int CTYPE,string title)
            {
                this.ERI = ERI;
                this.CTYPE = CTYPE;


                TextBlock.Text = title;
                TextBlock.FontSize = 48;
                this.Children.Add(TextBlock);
            }

        }



}