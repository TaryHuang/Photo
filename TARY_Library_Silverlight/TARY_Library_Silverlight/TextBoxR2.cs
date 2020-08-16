using System.Windows.Controls;

namespace TARY_Library_Silverlight
{
    public class TextBoxR2 : StackPanel
    {
        public TextBlock Title=new TextBlock();
        public TextBoxR TextBoxR;
        public TextBoxR2(int maxlen, string str,string title)
        {


            Title.Text = title;
            Title.FontSize = 36;
            Title.VerticalAlignment = System.Windows.VerticalAlignment.Center;



           
            TextBoxR = new TextBoxR(maxlen,str);
            TextBoxR.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            TextBoxR.FontSize = 36;
            this.Orientation = System.Windows.Controls.Orientation.Horizontal;


            this.Children.Add(Title);
            this.Children.Add(TextBoxR);
        }


        public string myText{
            get
            {
                return TextBoxR.myText;
            }
        }
    }
}
