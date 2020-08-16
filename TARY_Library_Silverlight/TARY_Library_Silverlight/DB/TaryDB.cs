using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;

namespace TARY_Library_Silverlight
{
    //實作INotifyPropertyChanged與INotifyPropertyChanging介面，做為屬性(欄位)值變更時的事件觸發。
    [Table(Name = "TaryDB")]
    public class TaryDB : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int gID;
        [Column(IsPrimaryKey = true, IsDbGenerated = true,
                DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get
            {
                return gID;
            }
            set
            {
                NotifyPropertyChanging("ID");
                gID = value;
                NotifyPropertyChanged("ID");
            }
        }






        private string gWriterXML;
        [Column(DbType = "NVarChar(4000) NULL", CanBeNull = true, Storage = "WriterXML")]
        public string WriterXML
        {
            get
            {
                return gWriterXML;
            }
            set
            {
                NotifyPropertyChanging("WriterXML");
                gWriterXML = value;
                NotifyPropertyChanging("WriterXML");
            }
        }






        private DateTime gLastDate;
        [Column(DbType = "datetime NULL", CanBeNull = true, Storage = "LastDate")]
        public DateTime LastDate
        {
            get
            {
                return gLastDate;
            }
            set
            {
                NotifyPropertyChanging("LastDate");
                gLastDate = value;
                NotifyPropertyChanging("LastDate");
            }
        }






        //此產品是否允許 通過微軟不購買 就可以以完整版方式使用
        private int gFreeProd;
        [Column(DbType = "int NULL", CanBeNull = true, Storage = "FreeProd")]
        public int FreeProd
        {
            get
            {
                return gFreeProd;
            }
            set
            {
                NotifyPropertyChanging("FreeProd");
                gFreeProd = value;
                NotifyPropertyChanging("FreeProd");
            }
        }




        //此產品當使用了破解後~多少時間內要恢復正常狀態
        //7天   15天   30天   60天   90天  365天
        private DateTime gProdLifeTime;
        [Column(DbType = "datetime NULL", CanBeNull = true, Storage = "ProdLifeTime")]
        public DateTime ProdLifeTime
        {
            get
            {
                return gProdLifeTime;
            }
            set
            {
                NotifyPropertyChanging("ProdLifeTime");
                gProdLifeTime = value;
                NotifyPropertyChanging("ProdLifeTime");
            }
        }

        #region INotifyPropertyChanging觸發事件
        public event PropertyChangingEventHandler PropertyChanging;

        private void NotifyPropertyChanging(string pPropertyName){
            if (PropertyChanging!=null){
                PropertyChanging(this, new PropertyChangingEventArgs(pPropertyName));
            }
        }
        #endregion

        #region INotifyPropertyChanged觸發事件
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string pPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
            }
        }
        #endregion
    }
}
