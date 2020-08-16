using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TARY_Library_Silverlight
{


    public class TextBoxR : TextBox
    {

        string nullText = "";
        string text = "";
        public TextBoxR(int maxlen, string str)
        {
            this.MaxLength = maxlen;
            nullText = str;
            myText = "";
        }



        public string myText
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
                isNulltext();
            }
        }


        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            if (myText == "")
            {
                this.Text = "";//轉為空空
            }

            this.Foreground = new SolidColorBrush(Colors.Black);
        }









        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            Text = Text.Trim();//去前後空白

            if (Text.Length > MaxLength)
            {
                Text = Text.Substring(0, MaxLength);
            }



            myText = Text;
            isNulltext();
        }






         void isNulltext()
        {
            if (myText == "")
            {
                this.Text = nullText; //空值輸入
                this.Foreground = new SolidColorBrush(Colors.Gray);
            }
            else
            {
                this.Text = myText;//有值輸入
                this.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

    }
}
