using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;

namespace PhotoJ
{
    //實作INotifyPropertyChanged與INotifyPropertyChanging介面，做為屬性(欄位)值變更時的事件觸發。
    [Table(Name = "FastTable")]
    public class FastTable : INotifyPropertyChanged, INotifyPropertyChanging
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




        private DateTime gDATE;
        [Column(DbType = "DATETIME NULL", CanBeNull = false, Storage = "DATE")]
        public DateTime DATE
        {
            //@ #  AAA ABC ABB 
            get
            {
                return gDATE;
            }
            set
            {
                NotifyPropertyChanging("DATE");
                gDATE = value;
                NotifyPropertyChanging("DATE");
            }
        }





        private int gCTYPE;
        [Column(DbType = "int NULL", CanBeNull = false, Storage = "CTYPE")]
        public int CTYPE
        {
            //@ #  AAA ABC ABB 
            get
            {
                return gCTYPE;
            }
            set
            {
                NotifyPropertyChanging("CTYPE");
                gCTYPE = value;
                NotifyPropertyChanging("CTYPE");
            }
        }

    
        private string gTitle;
        [Column(DbType = "NVarChar(30) NULL", CanBeNull = false, Storage = "Title")]
        public string Title
        {
            get
            {
                return gTitle;
            }
            set
            {
                NotifyPropertyChanging("Title");
                gTitle = value;
                NotifyPropertyChanging("Title");
            }
        }




        private int gWidth;
        [Column(DbType = "int NULL", CanBeNull = false, Storage = "Width")]
        public int Width
        {
            //@ #  AAA ABC ABB 
            get
            {
                return gWidth;
            }
            set
            {
                NotifyPropertyChanging("Width");
                gWidth = value;
                NotifyPropertyChanging("Width");
            }
        }



        private int gHeight;
        [Column(DbType = "int NULL", CanBeNull = false, Storage = "Height")]
        public int Height
        {
            //@ #  AAA ABC ABB 
            get
            {
                return gHeight;
            }
            set
            {
                NotifyPropertyChanging("Height");
                gHeight = value;
                NotifyPropertyChanging("Height");
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
