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
using Microsoft.Phone.Shell;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Phone.Tasks;

namespace TARY_Library_Silverlight
{
    public partial class TaryPage : PhoneApplicationPage
    {
        public static string KeyWordMonth = "";//產品金鑰 本月試用序號 到本月底
        public static string KeyWordMonth001 = "";//產品金鑰 試用序號 1天
        public static string KeyWordMonth003 = "";//產品金鑰 試用序號 3天
        public static string KeyWordMonth007 = "";//產品金鑰 試用序號 7天
        public static string KeyWordMonth015 = "";//產品金鑰 試用序號 15天
        public static string KeyWordMonth030 = "";//產品金鑰 試用序號 30天
        public static string KeyWordMonth090 = "";//產品金鑰 試用序號 90天
        public static string KeyWordMonth180 = "";//產品金鑰 試用序號 180天
        public static string KeyWordMonth365 = "";//產品金鑰 試用序號 365天


        public static string KeyWord001 = "";//產品金鑰 1天試用
        public static string KeyWord003 = "";//產品金鑰 3天試用
        public static string KeyWord007 = "";//產品金鑰 7天試用
        public static string KeyWord015 = "";//產品金鑰 15天試用
        public static string KeyWord030 = "";//產品金鑰 30天試用
        public static string KeyWord090 = "";//產品金鑰 90天試用
        public static string KeyWord180 = "";//產品金鑰 180天試用
        public static string KeyWord365 = "";//產品金鑰 365天試用

        string[] ProdSort = new string[] { myLanguage.getValue("遊戲小品"), myLanguage.getValue("休閒娛樂"), myLanguage.getValue("學習助理"), myLanguage.getValue("實用工具"), myLanguage.getValue("書籍部落"), myLanguage.getValue("其他語系"), myLanguage.getValue("商業軟體"), myLanguage.getValue("其他") };
        string[] ProdSortV = new string[]{"1","2","3","4","5","6","7","8"};

        WebClient onLine = new WebClient();
        XElement XML;
        public static Uri updateURI;
        ApplicationBarIconButton btn1,btn2,btn3,btn4;
        ApplicationBarMenuItem appItem1;
        public static TaryLibHandler tTaryLibHandler = new TaryLibHandler(TaryLibHandler.DBConnection);

        TextBoxR inputKeyWord;


        string target = "關於作者";//目前點選的位置
        public TaryPage()
        {
            InitializeComponent();

            ApplicationTitle.Text = myLanguage.getValue("關於作者");

            //更新資料
            onLine.DownloadStringCompleted += new DownloadStringCompletedEventHandler(onLine_DownloadStringCompleted);


            //判斷是否建立資料庫
            if (tTaryLibHandler.DatabaseExists() == false)
            {
                CreateDB();
                onLine.DownloadStringAsync(updateURI);
            }
            else
            {
                //讀取時間判定 若3天內沒更新,系統自我更新...
                var Data = from TaryDB in tTaryLibHandler.TaryDB
                           select TaryDB;

                TaryDB tData = Data.First();

                double D = new TimeSpan(DateTime.Now.Ticks - tData.LastDate.Ticks).TotalDays;
                if (D > 3 || tData.WriterXML == "")
                {
                    //需要重新更新
                    onLine.DownloadStringAsync(updateURI);
                }else{
                    ReadDbXML();
                }
            }










            ApplicationBar = new ApplicationBar();
            ApplicationBar.IsVisible = true;
            btn1 = new ApplicationBarIconButton(new Uri("/ImagesLib/TaryPage/people.png", UriKind.Relative));
            btn2 = new ApplicationBarIconButton(new Uri("/ImagesLib/TaryPage/star2.png", UriKind.Relative));
            btn3 = new ApplicationBarIconButton(new Uri("/ImagesLib/TaryPage/star.png", UriKind.Relative));
            btn4 = new ApplicationBarIconButton(new Uri("/ImagesLib/TaryPage/unlock.png", UriKind.Relative));
            btn1.Click += new EventHandler(ApplicationBarIconButton1_Click);
            btn2.Click += new EventHandler(ApplicationBarIconButton2_Click);
            btn3.Click += new EventHandler(ApplicationBarIconButton3_Click);
            btn4.Click += new EventHandler(ApplicationBarIconButton4_Click);
            btn1.Text = myLanguage.getValue("關於作者");
            btn2.Text = myLanguage.getValue("其他作品");
            btn3.Text = myLanguage.getValue("作者推薦");
            btn4.Text = myLanguage.getValue("解鎖APP");
            ApplicationBar.Buttons.Add(btn1);
            ApplicationBar.Buttons.Add(btn2);
            ApplicationBar.Buttons.Add(btn3);



            //使APP是否為付費用的APP  若付費用的APP 才有解鎖選項
            if (KeyWord001.Length != 0)
            {
                ApplicationBar.Buttons.Add(btn4);
            }

            appItem1 = new ApplicationBarMenuItem();
            appItem1.Text =  myLanguage.getValue("更新資料");
            appItem1.Click += new EventHandler(Update_Click);
            ApplicationBar.MenuItems.Add(appItem1);






            //破解app
            inputKeyWord = new TextBoxR(15,"請輸入序號");
            inputKeyWord.Width = 300;
            inputKeyWord.KeyDown +=new KeyEventHandler(inputKeyWord_KeyDown);
            stackPanel1.Children.Add(inputKeyWord);


            //解鎖app說明
            memo.Text = "說明：\n\t 解鎖APP是為了讓使用者在短期間內，體驗完整版的APP使用。\n\n\t 只要您獲有作者給予的授權序號，並在此輸入該序號內容，系統將會為您在一定的期間內開通完整版的服務。\n\n\t 請注意解鎖服務僅為使用者體驗使用，系統將在體驗天數結束後，再次進行上鎖！若想繼續使用此完整版的APP服務，還請您直接購買正式版本。";

            GVisibility();
        }



        void onLine_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //一開始載入XML發生異常＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
            try
            {
                XElement P = XElement.Parse(e.Result);

                var Data = from TaryDB in tTaryLibHandler.TaryDB
                         select TaryDB;

                TaryDB tData = Data.First();

                tData.LastDate = DateTime.Now;
                tData.WriterXML = e.Result;//將讀取的xml寫進資料庫中
                tTaryLibHandler.SubmitChanges();
                ReadDbXML();
            }
            catch
            {
                MessageBox.Show(myLanguage.getValue("更新失敗"));
                ReadDbXML();//讀取舊資料
            }
            //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊一開始載入XML發生異常
        }



        void ReadDbXML()
        {
            //將資料從資料庫中讀取到XML中
            var Data = from TaryDB in tTaryLibHandler.TaryDB
                       select TaryDB;

            TaryDB tData = Data.First();

            try
            {
                XML = XElement.Parse(tData.WriterXML);
            }
            catch
            {
                MessageBox.Show(myLanguage.getValue("讀取失敗"));
                return;
            }





            G1_Init();
            G2_Init();
            G3_Init();
        }


        void G1_Init()
        {


            try
            {
                Uri dir = new Uri(XML.Elements("INFO").ElementAt(0).Attribute("PIC").Value);
                ImageSource ImgS = new System.Windows.Media.Imaging.BitmapImage(dir);
                Image Img = new Image();
                Img.Width = Convert.ToInt32(XML.Elements("INFO").ElementAt(0).Attribute("PICWidth").Value);
                Img.Source = ImgS;
                WriterBody.Children.Add(Img);
            }
            catch
            {

            }


            //支持/贊助 
            try
            {
                if (XML.Elements("INFO").ElementAt(0).Attribute("SupportCID").Value.Length >= 10)
                {
                    SupportWriter Supports = new SupportWriter(XML.Elements("INFO").ElementAt(0).Attribute("SupportCID").Value, XML.Elements("INFO").ElementAt(0).Attribute("SupportTitle").Value);
                    WriterBody.Children.Add(Supports);
                }
            }
            catch
            {

            }



            for (int i = 0; i < XML.Elements("Writer").Count();i++ )
            {
                try
                {
                    TextBlock w1 = new TextBlock();
                    w1.FontSize = 28;
                    w1.Text = XML.Elements("Writer").ElementAt(i).Attribute("Title").Value;
                    WriterBody.Children.Add(w1);
                }
                catch
                {

                }
            }







        }




        void G2_Init()
        {

            for (int i = 0; i < ProdSortV.Count(); i++)
            {
                int Num = 0;
                TextBlock w1 = new TextBlock();
                w1.FontSize = 40;
                
                ProductList.Children.Add(w1);



                for (int J = 0; J < XML.Elements("Product").Count(); J++)
                {
                    if (ProdSortV[i] == XML.Elements("Product").ElementAt(J).Attribute("Sort").Value)
                    {
                      
                            try
                            {

                                string appName = APP_CNAME(XML.Elements("Product").ElementAt(J).Attribute("Title").Value, XML.Elements("Product").ElementAt(J).Attribute("TitleCN").Value, XML.Elements("Product").ElementAt(J).Attribute("TitleUS").Value);
                                string appCID = XML.Elements("Product").ElementAt(J).Attribute("CID").Value;
                                //
                                AppProduct Prods = new AppProduct(appCID,appName);
                                ProductList.Children.Add(Prods);
                                Num++;
                            }
                            catch
                            {
                                continue;
                            }
                    }//if
                }//for XML




                w1.Text = ProdSort[i]+" ("+Num.ToString()+")";
            }//for 分類


        }






        void G3_Init()
        {

            TextBlock w1 = new TextBlock();
            w1.FontSize = 40;
            w1.Text =  myLanguage.getValue("熱門遊戲");
            HotProductList.Children.Add(w1);
            for (int i = 0; i < XML.Elements("HotGameProduct").Count(); i++)
            {
                try
                {
                    string appName = APP_CNAME(XML.Elements("HotGameProduct").ElementAt(i).Attribute("Title").Value, XML.Elements("HotGameProduct").ElementAt(i).Attribute("TitleCN").Value, XML.Elements("HotGameProduct").ElementAt(i).Attribute("TitleUS").Value);
                    string appCID = XML.Elements("HotGameProduct").ElementAt(i).Attribute("CID").Value;
                    AppProduct Prods = new AppProduct(appCID,appName);
                    HotProductList.Children.Add(Prods);
                }
                catch
                {

                }
            }



            TextBlock w2 = new TextBlock();
            w2.FontSize = 40;
            w2.Text =  myLanguage.getValue("熱門工具");
            HotProductList.Children.Add(w2);
            for (int i = 0; i < XML.Elements("HotToolProduct").Count(); i++)
            {
                try
                {
                    string appName = APP_CNAME(XML.Elements("HotToolProduct").ElementAt(i).Attribute("Title").Value, XML.Elements("HotToolProduct").ElementAt(i).Attribute("TitleCN").Value, XML.Elements("HotToolProduct").ElementAt(i).Attribute("TitleUS").Value);
                    string appCID = XML.Elements("HotToolProduct").ElementAt(i).Attribute("CID").Value;
                    AppProduct Prods = new AppProduct(appCID, appName);
                    
                    HotProductList.Children.Add(Prods);
                }
                catch
                {

                }
            }


            TextBlock w = new TextBlock();
            w.FontSize = 40;
            w.Text =  myLanguage.getValue("自我推薦");
            HotProductList.Children.Add(w);
            for (int J = 0; J < XML.Elements("Product").Count(); J++)
            {
                if (XML.Elements("Product").ElementAt(J).Attribute("Hot").Value == "1")
                {
                    try
                    {
                        string appName = APP_CNAME(XML.Elements("Product").ElementAt(J).Attribute("Title").Value, XML.Elements("Product").ElementAt(J).Attribute("TitleCN").Value, XML.Elements("Product").ElementAt(J).Attribute("TitleUS").Value);
                        string appCID = XML.Elements("Product").ElementAt(J).Attribute("CID").Value;
                        AppProduct Prods = new AppProduct(appCID, appName);
                        HotProductList.Children.Add(Prods);
                    }
                    catch
                    {
                        continue;
                    }
                }//if
            }//for XML

        }
        



        void GVisibility()
        {
            switch (target)
            {
                case "關於作者":
                    G1.Visibility = Visibility.Visible;
                    G2.Visibility = Visibility.Collapsed;
                    G3.Visibility = Visibility.Collapsed;
                    G4.Visibility = Visibility.Collapsed;
                    G5.Visibility = Visibility.Collapsed;
                    ; break;
                case "其他作品":
                    G1.Visibility = Visibility.Collapsed;
                    G2.Visibility = Visibility.Visible;
                    G3.Visibility = Visibility.Collapsed;
                    G4.Visibility = Visibility.Collapsed;
                    G5.Visibility = Visibility.Collapsed;
                    ; break;
                case "作者推薦":
                    G1.Visibility = Visibility.Collapsed;
                    G2.Visibility = Visibility.Collapsed;
                    G3.Visibility = Visibility.Visible;
                    G4.Visibility = Visibility.Collapsed;
                    G5.Visibility = Visibility.Collapsed;
                    ; break;
                case "解鎖APP":
                    G1.Visibility = Visibility.Collapsed;
                    G2.Visibility = Visibility.Collapsed;
                    G3.Visibility = Visibility.Collapsed;

                    if(ProdKey.ProdLife()){
                        MESSAGE.Text = "使用期限： " + ProdKey.GetProdLifeDate();
                        G5.Visibility = Visibility.Visible;
                        G4.Visibility = Visibility.Collapsed;

                    }else{
                        G4.Visibility = Visibility.Visible;
                        G5.Visibility = Visibility.Collapsed;
                    }
                    ; break;
            }
        }




        private void Update_Click(object sender, EventArgs e)
        {
            WriterBody.Children.Clear();//清空資料
            ProductList.Children.Clear();//清空資料
            HotProductList.Children.Clear();//清空資料
            onLine.DownloadStringAsync(updateURI);
        }

        private void ApplicationBarIconButton1_Click(object sender, EventArgs e)
        {
            //關於作者
            target = "關於作者";
            ApplicationBarIconButton btn = sender as ApplicationBarIconButton;
            ApplicationTitle.Text = btn.Text;
            GVisibility();
        }


        private void ApplicationBarIconButton2_Click(object sender, EventArgs e)
        {
            //其他作品
            target = "其他作品";
            ApplicationBarIconButton btn = sender as ApplicationBarIconButton;
            ApplicationTitle.Text = btn.Text;
            GVisibility();
        }


        private void ApplicationBarIconButton3_Click(object sender, EventArgs e)
        {
            //作者推薦
            target = "作者推薦";
            ApplicationBarIconButton btn = sender as ApplicationBarIconButton;
            ApplicationTitle.Text = btn.Text;
            GVisibility();
        }



        private void ApplicationBarIconButton4_Click(object sender, EventArgs e)
        {
            //解鎖APP
            target = "解鎖APP";
            ApplicationBarIconButton btn = sender as ApplicationBarIconButton;
            ApplicationTitle.Text = btn.Text;
            GVisibility();
        }
        
        string CSORT(string STR)
        {
            for (int i = 0; i < ProdSortV.Count();i++ )
            {
                if (ProdSortV[i]==STR)
                {
                    return ProdSort[i];
                }
            }

            return "查無分類...";
        }



        void chkKeyWord()
        {
            button1.Focus();

            if (inputKeyWord.Text.ToUpper() == KeyWord001)
            {
                ProdKey.ProdKeyCorrect(1);
                MessageBox.Show("恭喜您！您享有1天完整版的APP服務。");
            }else if (inputKeyWord.Text.ToUpper() == KeyWord003)
            {
                ProdKey.ProdKeyCorrect(3);
                MessageBox.Show("恭喜您！您享有3天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWord007)
            {
                ProdKey.ProdKeyCorrect(7);
                MessageBox.Show("恭喜您！您享有7天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWord015)
            {
                ProdKey.ProdKeyCorrect(15);
                MessageBox.Show("恭喜您！您享有15天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWord030)
            {
                ProdKey.ProdKeyCorrect(30);
                MessageBox.Show("恭喜您！您享有30天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWord090)
            {
                ProdKey.ProdKeyCorrect(90);
                MessageBox.Show("恭喜您！您享有90天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWord180)
            {
                ProdKey.ProdKeyCorrect(180);
                MessageBox.Show("恭喜您！您享有180天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWord365)
            {
                ProdKey.ProdKeyCorrect(365);
                MessageBox.Show("恭喜您！您享有365天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWordMonth)
            {
                ProdKey.ProdKeyCorrect(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - DateTime.Now.Day);
                MessageBox.Show("恭喜您！您享有本月完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWordMonth001)
            {
                ProdKey.ProdKeyCorrect(1);
                MessageBox.Show("恭喜您！您享有1天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWordMonth003)
            {
                ProdKey.ProdKeyCorrect(3);
                MessageBox.Show("恭喜您！您享有3天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWordMonth007)
            {
                ProdKey.ProdKeyCorrect(7);
                MessageBox.Show("恭喜您！您享有7天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWordMonth015)
            {
                ProdKey.ProdKeyCorrect(15);
                MessageBox.Show("恭喜您！您享有15天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWordMonth030)
            {
                ProdKey.ProdKeyCorrect(30);
                MessageBox.Show("恭喜您！您享有30天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWordMonth090)
            {
                ProdKey.ProdKeyCorrect(90);
                MessageBox.Show("恭喜您！您享有90天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWordMonth180)
            {
                ProdKey.ProdKeyCorrect(180);
                MessageBox.Show("恭喜您！您享有180天完整版的APP服務。");
            }
            else if (inputKeyWord.Text.ToUpper() == KeyWordMonth365)
            {
                ProdKey.ProdKeyCorrect(365);
                MessageBox.Show("恭喜您！您享有365天完整版的APP服務。");
            }
            else
            {
                MessageBox.Show("很抱歉！您輸入的序號不正確！");
            }

            GVisibility();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            chkKeyWord();
        }

        private void inputKeyWord_KeyDown(object sender, KeyEventArgs e)
        {
            //TEXTBOX焦點狀態 按下ENTER 搜尋
            if (e.Key == Key.Enter)
            {
                chkKeyWord();
            }
        }
        



        public static void CreateDB(){

            if (tTaryLibHandler.DatabaseExists() == false)
            {
                tTaryLibHandler.CreateDatabase();
                TaryDB Data = new TaryDB();
                Data.FreeProd = 0;
                Data.WriterXML = "";
                Data.ProdLifeTime = DateTime.Now;
                Data.LastDate = DateTime.Now;
                tTaryLibHandler.TaryDB.InsertOnSubmit(Data);
                tTaryLibHandler.SubmitChanges();
            }
        }



        string APP_CNAME(string TW, string CN, string US)
        {
            if (myLanguage.properLanguage() == "US" && US.Length >= 1)
            {
                return US;
            }
            else if (myLanguage.properLanguage() == "CN" && CN.Length >= 1)
            {
                return CN;
            }
            else
            {
                return TW;
            }
        }

        string APP_CID(string TW, string CN, string US)
        {
            if (myLanguage.properLanguage() == "US" && US.Length >= 1)
            {
                return US;
            }
            else if (myLanguage.properLanguage() == "CN" && CN.Length >= 1)
            {
                return CN;
            }
            else
            {
                return TW;
            }
        }

    }





    public class AppProduct : Grid
    {
        public Button Title;
        public string ProductCID = "";


        public AppProduct(string CID, string title)
        {
            ProductCID = CID;




            Title = new Button();//顯示產品
            Title.Content = title;
            Title.FontSize = 32;
            Title.BorderThickness = new Thickness(0, 0, 0, 0);
            Title.Click +=new RoutedEventHandler(Title_Click);
            
            this.Children.Add(Title);
        }


        public void Title_Click(object sender, EventArgs e)
        {

            MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();

            marketplaceDetailTask.ContentIdentifier = ProductCID;
            marketplaceDetailTask.ContentType = MarketplaceContentType.Applications;

            marketplaceDetailTask.Show();
        }
    }



    class SupportWriter : AppProduct
    {


        public SupportWriter(string CID, string title) : base(CID,title)
        {
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            Title.FontSize = 28;
        }
    }
}