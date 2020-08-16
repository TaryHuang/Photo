using System;
using System.Collections.Generic;
using System.Windows;
using System.Globalization;

namespace TARY_Library_Silverlight
{
    
    
    public class myLanguage
    {
        static List<string> zh_TW = new List<string>();//台灣
        static List<string> nl_NL = new List<string>();//荷蘭
        static List<string> zh_CN = new List<string>();//中國
        static List<string> de_DE = new List<string>();//德國
        static List<string> en_US = new List<string>();//美國
        static List<string> th_TH = new List<string>();//泰國
        static List<string> ja_JP = new List<string>();//日本
        static List<string> vi_VN = new List<string>();//越南
        static List<string> ko_KR = new List<string>();//韓國
        static List<string> fr_FR = new List<string>();//法文

        
        static void Loading()
        {
            //ADD(繁體, 荷蘭, 簡體, 德國,美國,泰文,日本,越南,韓國,法文)
            ADD("請選取：", "kiezen", "请选取：", "wählen", "Select item：", "เลือก：", "選択する：", "chọn", "항목을 선택", "sélectionner");





            //TARY_PAGE＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
            ADD("關於作者", "关于作者", "Author");
            ADD("其他作品", "其他作品", "Other APP");
            ADD("作者推薦", "作者推荐", "Recommendation");
            ADD("解鎖APP", "解锁APP", "Unlock APP");


            ADD("熱門遊戲", "热门游戏", "Hot Games");
            ADD("熱門工具", "热门工具", "Hot Tools");
            ADD("自我推薦", "自我推荐", "Self referral");
            ADD("更新資料", "刷新资料", "Update");
            ADD("更新失敗", "刷新失败", "Update Failed");
            ADD("讀取失敗", "读取失败", "Failed");



            ADD("遊戲小品", "游戏小品", "Games");
            ADD("休閒娛樂", "休闲娱乐", "Entertainment");
            ADD("學習助理", "学习助理", "Learning Tools");
            ADD("實用工具", "实用工具", "Tools");
            ADD("書籍部落", "书籍部落", "Books");
            ADD("其他語系", "其他语系", "Other Languages");
            ADD("商業軟體", "商业软体", "Business APP");
            ADD("其他", "其他", "Other");
            
        }

        static void ADD(string tw, string cn , string us)
        {
            zh_TW.Add(tw);//台灣
            zh_CN.Add(cn);//中國
            en_US.Add(us);//美國


            ja_JP.Add("");//日本
            nl_NL.Add("");//荷蘭
            de_DE.Add("");//德國
            th_TH.Add("");//泰國
            vi_VN.Add("");//越南
            ko_KR.Add("");//韓國
            fr_FR.Add("");//法文
        }

        static void ADD(string tw, string nl, string cn, string de, string us, string th, string jp, string vn, string kr, string fr)
        {
            zh_TW.Add(tw);//台灣
            nl_NL.Add(nl);//荷蘭
            zh_CN.Add(cn);//中國
            de_DE.Add(de);//德國
            en_US.Add(us);//美國
            th_TH.Add(th);//泰國
            ja_JP.Add(jp);//日本
            vi_VN.Add(vn);//越南
            ko_KR.Add(kr);//韓國
            fr_FR.Add(fr);//法文
        }

        public static string getValue(string Search)
        {
            if(zh_TW.Count==0){
                Loading();//第一次匯入程式
            }

            int F=-1;//是否找到元素
            for (int i = 0; i < zh_TW.Count; i++)
            {
                if (zh_TW[i] == Search)
                {
                    F = i;//找到對應的元素
                    break;
                }
            }



            if(F==-1){
                return "---";
            }else{
                string R_STR="";
                switch (CultureInfo.CurrentCulture.Name)
                {
                    case "zh-TW": R_STR = zh_TW[F]; break;//繁體
                    case "nl-NL": R_STR = nl_NL[F]; break;//芬蘭
                    case "zh-CN": R_STR = zh_CN[F]; break;//中國
                    case "ja-JP": R_STR = ja_JP[F]; break;//日本
                    case "de-DE": R_STR = de_DE[F]; break;//德國
                    case "vi-VN": R_STR = vi_VN[F]; break;//越南
                    case "th-TH": R_STR = th_TH[F]; break;//泰文
                    case "ko-KR": R_STR = ko_KR[F]; break;//韓文
                    case "fr-FR": R_STR = fr_FR[F]; break;//法文
                    default: R_STR = en_US[F]; break;
                }

                if (R_STR == "")
                {
                    return en_US[F];//若是沒有該國家的翻譯 就回傳英文版
                }
                else
                {
                    return R_STR;
                }
            }
        }

        public static string properLanguage()
        {
            //回傳適合的語言
            //目前只支援三種
            //繁體   簡體   英文

            string R_STR = "";
            switch (CultureInfo.CurrentCulture.Name)
            {
                case "zh-TW": R_STR = "TW"; break;//繁體
                case "zh-CN": R_STR = "CN"; break;//簡體
                default: R_STR = "US"; break;//英文
            }
            return R_STR;
        }

    }
}
