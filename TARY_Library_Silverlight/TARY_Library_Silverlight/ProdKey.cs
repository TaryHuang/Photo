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
using System.Linq;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Marketplace;
namespace TARY_Library_Silverlight
{
    public class ProdKey
    {

        static LicenseInformation gLicenseInfo = new LicenseInformation();//產品是否為正式版

        static string[] M0 = new String[36] { "T", "P", "M", "F", "H", "K", "R", "3", "W", "V", "5", "Y", "Z", "1", "D", "X", "L", "8", "4", "E", "J", "C", "6", "2", "I", "Q", "A", "7", "N", "9", "O", "U", "S", "G", "B", "0"};
        static string[] M1 = new String[36] { "O", "9", "3", "L", "H", "7", "V", "D", "A", "M", "J", "Z", "C", "P", "G", "Y", "0", "R", "Q", "8", "6", "5", "B", "E", "T", "S", "U", "I", "N", "X", "2", "1", "F", "4", "W", "K"};
        static string[] M2 = new String[36] { "5", "U", "8", "I", "C", "2", "K", "A", "P", "L", "S", "3", "O", "Q", "9", "D", "E", "1", "H", "Z", "R", "X", "7", "N", "0", "B", "F", "J", "G", "6", "W", "V", "Y", "T", "4", "M"};
        static string[] M3 = new String[36] { "P", "9", "V", "X", "Q", "8", "N", "4", "Z", "3", "T", "L", "U", "0", "5", "S", "J", "I", "A", "E", "Y", "O", "G", "7", "D", "W", "R", "F", "K", "B", "C", "M", "6", "1", "H", "2"};
        static string[] M4 = new String[36] { "N", "Q", "J", "K", "G", "D", "9", "I", "P", "S", "1", "H", "V", "8", "C", "A", "2", "6", "3", "M", "T", "5", "Y", "U", "7", "E", "4", "0", "W", "Z", "L", "O", "R", "B", "F", "X" };
        static string[] M5 = new String[36] { "6", "M", "L", "0", "A", "C", "S", "E", "O", "R", "Q", "Y", "3", "W", "N", "7", "9", "X", "Z", "J", "2", "D", "I", "5", "4", "H", "P", "K", "F", "8", "T", "1", "B", "U", "G", "V" };
        static string[] M6 = new String[36] { "1", "H", "D", "C", "T", "V", "F", "L", "2", "J", "8", "Z", "W", "K", "M", "P", "I", "R", "B", "G", "N", "5", "6", "3", "Q", "E", "4", "0", "X", "U", "O", "7", "A", "9", "Y", "S" };
        static string[] M7 = new String[36] { "A", "H", "L", "O", "7", "4", "8", "5", "C", "Q", "F", "1", "2", "G", "X", "W", "S", "B", "N", "I", "P", "R", "3", "9", "M", "U", "J", "0", "E", "Y", "D", "V", "Z", "6", "K", "T" };
        static string[] M8 = new String[36] { "L", "K", "0", "Z", "W", "Q", "B", "1", "P", "F", "9", "Y", "H", "J", "G", "O", "D", "6", "T", "S", "N", "4", "5", "C", "I", "V", "7", "3", "E", "R", "U", "8", "X", "A", "2", "M" };
        static string[] M9 = new String[36] { "E", "4", "S", "Y", "9", "I", "M", "U", "H", "X", "O", "T", "F", "2", "W", "7", "Q", "K", "0", "5", "J", "N", "A", "6", "V", "1", "8", "Z", "R", "L", "B", "3", "G", "D", "C", "P" };
        static string[] M10 = new String[36] { "K", "V", "4", "N", "W", "I", "D", "O", "S", "E", "H", "Y", "T", "P", "U", "3", "A", "B", "X", "7", "J", "8", "L", "9", "R", "6", "Q", "F", "0", "G", "M", "C", "5", "2", "Z", "1" };
        static string[] M11 = new String[36] { "8", "7", "H", "W", "A", "N", "K", "U", "J", "2", "X", "0", "6", "1", "5", "S", "E", "D", "R", "Z", "9", "B", "G", "V", "C", "F", "P", "M", "4", "Q", "O", "3", "L", "Y", "I", "T" };
        static string[] M12 = new String[36] { "9", "V", "G", "Z", "3", "1", "F", "W", "O", "D", "Y", "N", "L", "8", "H", "U", "B", "X", "P", "5", "K", "C", "4", "R", "A", "7", "J", "0", "T", "6", "2", "E", "M", "S", "Q", "I" };
        static string[] M13 = new String[36] { "C", "P", "I", "U", "E", "D", "9", "H", "X", "W", "V", "F", "7", "J", "6", "Z", "S", "M", "0", "K", "4", "N", "2", "T", "O", "R", "3", "5", "Y", "A", "1", "Q", "G", "8", "L", "B" };
        static string[] M14 = new String[36] { "S", "6", "5", "I", "D", "X", "3", "H", "C", "Y", "P", "K", "V", "Q", "M", "A", "E", "0", "T", "2", "W", "U", "7", "O", "9", "R", "4", "Z", "8", "N", "F", "G", "L", "B", "J", "1" };
        static string[] M15 = new String[36] { "V", "2", "F", "N", "6", "C", "1", "0", "5", "A", "R", "M", "J", "Q", "D", "H", "3", "7", "G", "S", "X", "Y", "9", "4", "8", "T", "W", "E", "O", "K", "B", "Z", "I", "P", "U", "L" };
        static string[] M16 = new String[36] { "N", "W", "0", "Y", "I", "4", "A", "Z", "B", "6", "F", "9", "S", "O", "R", "7", "2", "E", "V", "K", "U", "8", "G", "Q", "X", "3", "L", "P", "J", "D", "T", "H", "5", "C", "1", "M"};
        static string[] M17 = new String[36] { "X", "0", "S", "K", "C", "G", "L", "1", "4", "V", "Z", "I", "R", "O", "9", "5", "2", "A", "3", "Q", "F", "U", "E", "D", "Y", "J", "T", "8", "6", "P", "W", "H", "B", "M", "7", "N" };
        static string[] M18 = new String[36] { "R", "C", "4", "M", "8", "U", "2", "W", "T", "L", "J", "6", "E", "A", "7", "5", "S", "B", "9", "0", "I", "P", "Z", "H", "Y", "N", "V", "3", "1", "F", "D", "K", "Q", "G", "O", "X"};
        static string[] M19 = new String[36] { "C", "U", "5", "M", "S", "K", "Q", "Y", "X", "P", "3", "D", "W", "6", "V", "H", "F", "G", "1", "9", "B", "R", "J", "T", "A", "L", "7", "4", "O", "8", "2", "E", "0", "N", "I", "Z" };
        static string[] M20 = new String[36] { "Q", "K", "8", "9", "2", "U", "X", "L", "A", "5", "T", "Z", "V", "N", "J", "D", "O", "1", "H", "C", "M", "E", "P", "R", "4", "I", "W", "G", "S", "3", "0", "B", "F", "7", "6", "Y" };
        static string[] M21 = new String[36] { "3", "F", "R", "H", "B", "V", "5", "Q", "E", "7", "G", "W", "0", "6", "D", "T", "P", "2", "S", "O", "I", "N", "C", "8", "J", "Z", "1", "9", "Y", "U", "X", "4", "K", "L", "M", "A"};
        static string[] M22 = new String[36] { "L", "U", "R", "1", "N", "B", "6", "9", "H", "X", "O", "D", "2", "0", "7", "W", "A", "T", "F", "S", "V", "5", "P", "K", "E", "G", "Q", "Z", "I", "M", "Y", "J", "8", "C", "4", "3" };
        static string[] M23 = new String[36] { "C", "N", "R", "K", "5", "B", "2", "X", "A", "O", "6", "S", "1", "D", "G", "Z", "F", "J", "W", "T", "9", "4", "Q", "P", "V", "Y", "3", "8", "H", "U", "7", "0", "E", "M", "L", "I"};
        static string[] M24 = new String[36] { "9", "R", "W", "Q", "N", "V", "M", "H", "I", "2", "Y", "P", "K", "A", "C", "1", "4", "S", "Z", "J", "0", "D", "B", "7", "5", "L", "O", "6", "T", "E", "3", "U", "X", "8", "F", "G" };
    
        public static void Register(int key)
        {
            TaryPage.CreateDB();//判定該資料庫是否存在

            if (LicensePass())
            {
                return;//此為正式版本無須給予 解鎖app
            }


            //判定已輸入的序號產品是否有過期
            var Data = from TaryDB in TaryPage.tTaryLibHandler.TaryDB
                       select TaryDB;
            TaryDB tData = Data.First();


            if (tData.FreeProd== 1 &&  DateTime.Now.Date > tData.ProdLifeTime.Date)
            {
                tData.FreeProd = 0;//使用期限已過期
                TaryPage.tTaryLibHandler.SubmitChanges();//存檔
            }



            


            //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
            int K = makeK(key);
            //註冊APP產品號
            TaryPage.KeyWord001 = MKey(K + 1000);
            TaryPage.KeyWord003 = MKey(K + 1111);
            TaryPage.KeyWord007 = MKey(K + 2222);
            TaryPage.KeyWord015 = MKey(K + 3333);
            TaryPage.KeyWord030 = MKey(K + 4444);
            TaryPage.KeyWord090 = MKey(K + 5555);
            TaryPage.KeyWord180 = MKey(K + 6666);
            TaryPage.KeyWord365 = MKey(K + 7777);


            //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
            int KMonth = makeKMonth(key);
            //註冊APP產品號
            TaryPage.KeyWordMonth = MKey(KMonth);
            TaryPage.KeyWordMonth001 = MKey(KMonth + 10000);
            TaryPage.KeyWordMonth003 = MKey(KMonth + 11111);
            TaryPage.KeyWordMonth007 = MKey(KMonth + 22222);
            TaryPage.KeyWordMonth015 = MKey(KMonth + 33333);
            TaryPage.KeyWordMonth030 = MKey(KMonth + 44444);
            TaryPage.KeyWordMonth090 = MKey(KMonth + 55555);
            TaryPage.KeyWordMonth180 = MKey(KMonth + 66666);
            TaryPage.KeyWordMonth365 = MKey(KMonth + 77777);

        }




        //＊判定app是否已購買或是使用體驗版
        public static bool ProdPass()
        {
            if (!gLicenseInfo.IsTrial())
            {
                return true;//正式版本
            }
            else
            {
                if (ProdLife())
                {
                    return true;//1~365天 體驗完整版
                }
                else
                {
                    return false;//尚未 購買或擁有體驗完整版
                }
            }
        }





        public static bool ProdLife()
        {

            var Data = from TaryDB in TaryPage.tTaryLibHandler.TaryDB
                       select TaryDB;

            TaryDB tData = Data.First();


            if (tData.FreeProd == 1)
            {
                return true;//產品已開通服務
            }
            else
            {
                return false;//產品未開通服務
            }

        }



        public static string GetProdLifeDate()
        {
            var Data = from TaryDB in TaryPage.tTaryLibHandler.TaryDB
                       select TaryDB;

            TaryDB tData = Data.First();

            string D = "";

            D = tData.ProdLifeTime.Year.ToString() + "/" + tData.ProdLifeTime.Month.ToString() + "/" + tData.ProdLifeTime.Day.ToString();

            return D;
        }



        //產生密鑰
        public static string MKey(int num)
        {
            switch(num%25){
                case 0: return MR(M0,num);
                case 1: return MR(M1, num);
                case 2: return MR(M2, num);
                case 3: return MR(M3, num);
                case 4: return MR(M4, num);
                case 5: return MR(M5, num);
                case 6: return MR(M6, num);
                case 7: return MR(M7, num);
                case 8: return MR(M8, num);
                case 9: return MR(M9, num);
                case 10: return MR(M10, num);
                case 11: return MR(M11, num);
                case 12: return MR(M12, num);
                case 13: return MR(M13, num);
                case 14: return MR(M14, num);
                case 15: return MR(M15, num);
                case 16: return MR(M16, num);
                case 17: return MR(M17, num);
                case 18: return MR(M18, num);
                case 19: return MR(M19, num);
                case 20: return MR(M20, num);
                case 21: return MR(M21, num);
                case 22: return MR(M22, num);
                case 23: return MR(M23, num);
                case 24: return MR(M24, num);
            }

            return MR(M0, num);
        }



        static string MR(string[] M, int num)
        {
            string SR = "";//準備回傳的值
            string S = num.ToString();
            int totalPtr = 0;
            for (int i = 0; i < S.Length;i++ )
            {
                if (switchInt(S[i].ToString()) == 0)
                {
                    totalPtr += 10;
                }
                else
                {
                    totalPtr += switchInt(S[i].ToString());
                }
                
                SR += M[totalPtr%36];
            }
            return SR;

        }



        public static void ProdKeyCorrect(int day)
        {
            //體驗序號 是否正確輸入
            //讀取時間判定 若3天內沒更新,系統自我更新...
            var Data = from TaryDB in TaryPage.tTaryLibHandler.TaryDB
                       select TaryDB;

            TaryDB tData = Data.First();

            tData.FreeProd = 1;
            tData.ProdLifeTime = DateTime.Now.Date.AddDays(day);

            TaryPage.tTaryLibHandler.SubmitChanges();
        }







        //判定是否為正式版(消費者已購買)
        public static bool LicensePass()
        {

            //請注意:此地方與passProd()無關!!!
            //return false;
            if (!gLicenseInfo.IsTrial())
            {
                return true;//正式版本
            }
            else
            {
                return false;//試用版本
            }

        }



        public static void ShowAppMarketplace()
        {
            //跳出購買 正式版本之訊息
            MarketplaceDetailTask gDetailTask = new MarketplaceDetailTask();
            gDetailTask.Show();
        }




       static int switchInt(string str){
           switch (str)
           {
               case "0": return 0;
               case "1": return 1;
               case "2": return 2;
               case "3": return 3;
               case "4": return 4;
               case "5": return 5;
               case "6": return 6;
               case "7": return 7;
               case "8": return 8;
               case "9": return 9;
           }


           return 0;
       }





       public static int makeK(int key)
       {
           //製造金鑰
           return DateTime.Now.Year + ((DateTime.Now.Month + DateTime.Now.Day + key) * 1000) + DateTime.Now.Day + key;
       }



       public static int makeKMonth(int key)
       {
           //製造金鑰
           return DateTime.Now.Year + ((DateTime.Now.Month + key) * 10000);
       }
    }
}
