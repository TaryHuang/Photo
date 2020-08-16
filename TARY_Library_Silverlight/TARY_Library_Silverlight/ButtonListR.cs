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
    public class ButtonListR : StackPanel
    {
        public TextBlock Title=new TextBlock();
        public ButtonList ButtonList;
        public ButtonListR(string title, PhoneApplicationPage PG, string[] List, int IndexDefault)
        {


            Title.Text = title;
            Title.FontSize = 36;
            Title.VerticalAlignment = System.Windows.VerticalAlignment.Center;




            ButtonList = new ButtonList(PG, List, IndexDefault);
           
            ButtonList.FontSize = 36;
            ButtonList.BorderThickness = new Thickness(0, 0, 0, 0);
            this.Orientation = System.Windows.Controls.Orientation.Horizontal;
            this.Children.Add(Title);
            this.Children.Add(ButtonList);
        }


        public int Index{
            get
            {
                return ButtonList.Index;
            }
        }
    }
}
