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
    public partial class ButtonDateFORM : PhoneApplicationPage
    {


        static int token = -1;//目前號碼牌

        string ptrName;//目前的btn指標
        static List<DateTime> INDEX = new List<DateTime>();
        static List<string> CNAME = new List<string>();

        bool openYear = false;//是否開啟年份清單塗層
        Button btnYear =new Button();

        DateTime Rdate;//給定的日期
        DateTime Fdate;//回傳Rdate該月1號  (用途:計算當天是星期幾)
        Btn[] titleBox = new Btn[7];
        Btn[] DayBox;//月份的幾號

        string Day, Month, Year;

        string[] strMonth = new string[] { "1 月", "2 月", "3 月", "4 月", "5 月", "6 月", "7 月", "8 月", "9 月", "10 月", "11 月", "12 月" };
        ListNext MonthBar;


        string[] strYear;
        ListNext YearBar;


        public ButtonDateFORM()
        {
            InitializeComponent();  
        }


        public void Init(){

            //範圍1900年到2399年(可使用五百年)
            strYear =new string[500];
            int defYear = 0;//初始化的INDEX
            for(int i=0;i<strYear.Count();i++){
                strYear[i] = (1900+i).ToString();


                if (Year == (1900 + i).ToString())
                {
                    defYear = i;
                }


                YearBtn BBB = new YearBtn();
                BBB.ptr = i;
                BBB.Content = (1900 + i).ToString();
                BBB.Click+=new RoutedEventHandler(BBB_Click);
                yearBox.Items.Add(BBB);

            }


            YearBar = new ListNext(strYear, defYear);
            YearBar.Text.FontSize = 70;
            YearBar.NextBtn.Click +=new RoutedEventHandler(YearNextBtn_Click);
            YearBar.PrevBtn.Click += new RoutedEventHandler(YearPrevBtn_Click);



            btnYear.Content = "";
            btnYear.Click +=new RoutedEventHandler(btnYear_Click);
            btnYear.Width = 200;
            btnYear.BorderBrush = new SolidColorBrush(Color.FromArgb(0,0,0,0));

            Grid_Year.Children.Add(YearBar);
            Grid_Year.Children.Add(btnYear);



            MonthBar = new ListNext(strMonth, MonthIndex);
            MonthBar.AutoBack = true;
            MonthBar.NextBtn.Click += new RoutedEventHandler(MonthNextBtn_Click);
            MonthBar.PrevBtn.Click += new RoutedEventHandler(MonthPrevBtn_Click);
            Grid_Month.Children.Add(MonthBar);


            update();
        }




        private void BBB_Click(object sender, RoutedEventArgs e)
        {
            YearBtn btn = sender as YearBtn;

            YearBar.Index = btn.ptr;
            Year = YearBar.StrList[YearBar.Index];

            setFdate(Year, Month);
            update();
            openYear = false;
            openYear_Action();
        }

        private void btnYear_Click(object sender, RoutedEventArgs e)
        {

            openYear = true;
            openYear_Action();
        }


        public void openYear_Action(){


            if (openYear)
            {

                titleYear.Text = "請選擇年份：";

                yearBox.SelectedIndex = YearBar.Index;
                

                titleYear.Visibility = System.Windows.Visibility.Visible;
                yearBox.Visibility = System.Windows.Visibility.Visible;
                Grid_Month.Visibility = System.Windows.Visibility.Collapsed;
                Grid_Year.Visibility = System.Windows.Visibility.Collapsed;
                BOX.Visibility = System.Windows.Visibility.Collapsed;


                                
            }
            else
            {

                titleYear.Visibility = System.Windows.Visibility.Collapsed;
                yearBox.Visibility = System.Windows.Visibility.Collapsed;

                Grid_Month.Visibility = System.Windows.Visibility.Visible;
                Grid_Year.Visibility = System.Windows.Visibility.Visible;
                BOX.Visibility = System.Windows.Visibility.Visible;
            }
        }
        


        private void YearNextBtn_Click(object sender, RoutedEventArgs e)
        {
            Year = YearBar.StrList[YearBar.Index];
            setFdate(Year, Month);
            update();
        }



        private void YearPrevBtn_Click(object sender, RoutedEventArgs e)
        {
            Year = YearBar.StrList[YearBar.Index];
            setFdate(Year, Month);
            update();
        }



        private void MonthNextBtn_Click(object sender, RoutedEventArgs e)
        {

            string V = Month;
            Month = IndexToMonth;


            if (V == "12" && Month=="1")
            {
                //判斷是否為12月 to 1月  若是的話 year+1 

                YearBar.Index++;
                Year = YearBar.StrList[YearBar.Index];
            }




            setFdate(Year, Month);
            update();
        }



        private void MonthPrevBtn_Click(object sender, RoutedEventArgs e)
        {
            string V = Month;
            Month = IndexToMonth;


            if (V == "1" && Month == "12")
            {
                //判斷是否為12月 to 1月  若是的話 year+1 

                YearBar.Index--;
                Year = YearBar.StrList[YearBar.Index];
            }




            setFdate(Year, Month);
            update();
        }    


        void update(){

            BOX.Children.Clear();

            for (int i = 0; i < titleBox.Count(); i++)
            {

                string str = "";
                switch (i)
                {
                    case 0: str = "日"; break;
                    case 1: str = "一"; break;
                    case 2: str = "二"; break;
                    case 3: str = "三"; break;
                    case 4: str = "四"; break;
                    case 5: str = "五"; break;
                    case 6: str = "六"; break;
                }

                titleBox[i] = new Btn(str, 0, i);

                BOX.Children.Add(titleBox[i]);
            }


            //一個月有幾天
            int V = DateTime.DaysInMonth(Convert.ToInt32(Year), Convert.ToInt32(Month));
            DayBox = new Btn[V];


            int row = 1;
            int col = 0;
            switch (Fdate.DayOfWeek)
            {
                case DayOfWeek.Sunday: col = 0; break;
                case DayOfWeek.Monday: col = 1; break;
                case DayOfWeek.Tuesday: col = 2; break;
                case DayOfWeek.Wednesday: col = 3; break;
                case DayOfWeek.Thursday: col = 4; break;
                case DayOfWeek.Friday: col = 5; break;
                case DayOfWeek.Saturday: col = 6; break;
            }

            for (int i = 0; i < DayBox.Count(); i++)
            {

                DateTime btnDate = Convert.ToDateTime(Year+"/"+Month+"/"+ (i + 1).ToString());



                DayBox[i] = new Btn(btnDate, (i + 1).ToString(), row, col);
                DayBox[i].MouseLeftButtonDown +=new MouseButtonEventHandler(ButtonDateFORM_MouseLeftButtonDown);

                if (btnDate == Rdate)
                {

                    DayBox[i].border.Background = new SolidColorBrush(Color.FromArgb(255, 255, 140, 200));
                }

                BOX.Children.Add(DayBox[i]);


                col++;
                if (col == 7)
                {
                    row++;
                    col = 0;
                }
            }

        }



        private void ButtonDateFORM_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Btn btn = sender as Btn;


            DateTime R = btn.date;


            if (ptr(ptrName) != -1)
            {
                INDEX[ptr(ptrName)] = R;
            }



            NavigationService.GoBack();
        }


        public static int ptr(string STR)
        {
            for (int i = 0; i < CNAME.Count; i++)
            {
                if (CNAME[i] == STR)
                {
                    return i;
                }
            }
            return -1;
        }



        public static DateTime ptrIndex(string STR)
        {
            for (int i = 0; i < CNAME.Count; i++)
            {
                if (CNAME[i] == STR)
                {
                    return INDEX[i];
                }
            }
            return Convert.ToDateTime("1899/01/01");
        }


        public static int getToken
        {
            get
            {
                token++;
                return token;//給予號碼牌

            }
        }



        public int YearIndex{
            get
            {
                int ptr = 0;


                for (int i = 0; i < YearBar.StrList.Count();i++ )
                {
                    if (YearBar.StrList[i] == Year)
                    {
                        return i;
                    }
                }

                return ptr;
            }
        }



        public int MonthIndex
        {
            get
            {
                switch(Month){
                    case "1": return 0; 
                    case "2": return 1; 
                    case "3": return 2; 
                    case "4": return 3; 
                    case "5": return 4; 
                    case "6": return 5; 
                    case "7": return 6; 
                    case "8": return 7; 
                    case "9": return 8; 
                    case "10": return 9; 
                    case "11": return 10; 
                    case "12": return 11; 
                }
                return 0;
            }
        }

        public string IndexToMonth
        {
            get
            {
                switch (MonthBar.Index)
                {
                    case 0: return "1";
                    case 1: return "2";
                    case 2: return "3";
                    case 3: return "4";
                    case 4: return "5";
                    case 5: return "6";
                    case 6: return "7";
                    case 7: return "8";
                    case 8: return "9";
                    case 9: return "10";
                    case 10: return "11";
                    case 11: return "12";
                }
                return "1";
            }
        }

        public void setDay(DateTime D)
        {
            Year = D.Year.ToString();
            Month = D.Month.ToString();
            Day = D.Day.ToString();


            Rdate = D.Date;
            setFdate(Year, Month);
        }



        public void setFdate(string Year,string Month)
        {

            Fdate = Convert.ToDateTime(Year+"/"+Month+"/01");
        }



        void ADD(string str)
        {
            CNAME.Add(str);
            INDEX.Add(Convert.ToDateTime("1899/01/01"));
        }







        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //給定 Day year Month 值

            setDay(Convert.ToDateTime(NavigationContext.QueryString["Date"]));
            Init();



            ptrName = NavigationContext.QueryString["ptrName"];
            if (ptr(NavigationContext.QueryString["ptrName"]) == -1)
            {
                ADD(NavigationContext.QueryString["ptrName"]);
            }


            openYear = false;
            openYear_Action();

        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (openYear)
            {
                openYear = false;
                openYear_Action();
                e.Cancel = true;
            }
        }




        class YearBtn : Button
        {
            public int ptr;

            public YearBtn()
            {
                this.FontSize=40;
                this.BorderBrush = new SolidColorBrush(Color.FromArgb(0,0,0,0));
            }
        }




        class Btn: Grid
        {
            public TextBlock text=new TextBlock();
            public int col, row;
            public DateTime date;

            public Border border;

            public Btn(string nText, int nRow, int nCol)
            {
                Init();
                this.Text = nText;
                this.Row = nRow;
                this.Col = nCol;

                border.Background = new SolidColorBrush(Color.FromArgb(255, 100, 185, 255));//#FF1788D9
            }


            public Btn(DateTime nDate,string nText, int nRow, int nCol)
            {
                Init();
                this.Text = nText;
                this.Row = nRow;
                this.Col = nCol;
                this.date = nDate;

                border.Background = new SolidColorBrush(Color.FromArgb(255, 255, 180, 120));

            }


            void Init(){


                border = new Border();
                border.Width = 67;
                border.Height = 67;
                border.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                border.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                this.Children.Add(border);

                this.text.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                this.text.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                //this.text.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                this.text.FontSize = 32;
                this.Children.Add(text);

            }




            public int Col
            {
                get
                {
                    return col;
                }
                set
                {

                    col = value;
                    this.SetValue(Grid.ColumnProperty, col);
                }
            }
            public int Row
            {
                get
                {
                    return row;
                }
                set
                {

                    row = value;
                    this.SetValue(Grid.RowProperty, row);
                }
            }


            public string Text
            {
                get
                {
                    return text.Text;
                }
                set
                {
                    text.Text = value;
                }
            }

            /*
            public class btn : Button {
                public int ptr;

                public btn(){
                    this.Width = 65;
                    this.Height = 65;
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    this.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                }
            }
             */
        }

        private void PhoneApplicationPage_OrientationChanged_1(object sender, OrientationChangedEventArgs e)
        {
            if (this.Orientation == PageOrientation.PortraitDown || this.Orientation == PageOrientation.PortraitUp)
            {
                BOX.Margin = new Thickness(0, 246, 0, 0);
                Grid_Year.Margin = new Thickness(0, 10, 0, 0);
                Grid_Month.Margin = new Thickness(0, 130, 0, 0);
                Grid_Year.Width = 480;
                Grid_Month.Width = 480;
                yearBox.Width = 480;
            }
            else if (this.Orientation == PageOrientation.LandscapeLeft || this.Orientation == PageOrientation.LandscapeRight)
            {
                BOX.Margin = new Thickness(15, 15, 0, 0);
                Grid_Year.Margin = new Thickness(500,0,0,0);
                Grid_Year.Width = 300;
                Grid_Month.Margin = new Thickness(500, 120, 0, 0);
                Grid_Month.Width = 300;

                yearBox.Width = 800;
            }
            
        }




    }
}