using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;

namespace PhotoJ
{
    //實作INotifyPropertyChanged與INotifyPropertyChanging介面，做為屬性(欄位)值變更時的事件觸發。
    [Table(Name = "ObjTextTable")]
    public class ObjTextTable : INotifyPropertyChanged, INotifyPropertyChanging
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





        private int gMASTERI;
        [Column(DbType = "int NULL", CanBeNull = false, Storage = "MASTERI")]
        public int MASTERI
        {
            //@ #  AAA ABC ABB 
            get
            {
                return gMASTERI;
            }
            set
            {
                NotifyPropertyChanging("MASTERI");
                gMASTERI = value;
                NotifyPropertyChanging("MASTERI");
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



        private int gCTYPE2;
        [Column(DbType = "int NULL", CanBeNull = false, Storage = "CTYPE2")]
        public int CTYPE2
        {
            //@ #  AAA ABC ABB 
            get
            {
                return gCTYPE2;
            }
            set
            {
                NotifyPropertyChanging("CTYPE2");
                gCTYPE2 = value;
                NotifyPropertyChanging("CTYPE2");
            }
        }
  







        private string gTEXT;
        [Column(DbType = "NVarChar(200) NULL", CanBeNull = false, Storage = "TEXT")]
        public string TEXT
        {
            get
            {
                return gTEXT;
            }
            set
            {
                NotifyPropertyChanging("TEXT");
                gTEXT = value;
                NotifyPropertyChanging("TEXT");
            }
        }


        private string gCOLOR;
        [Column(DbType = "NVarChar(20) NULL", CanBeNull = false, Storage = "COLOR")]
        public string COLOR
        {
            get
            {
                return gCOLOR;
            }
            set
            {
                NotifyPropertyChanging("COLOR");
                gCOLOR = value;
                NotifyPropertyChanging("COLOR");
            }
        }




        private string gCOLOR2;
        [Column(DbType = "NVarChar(20) NULL", CanBeNull = false, Storage = "COLOR2")]
        public string COLOR2
        {
            get
            {
                return gCOLOR2;
            }
            set
            {
                NotifyPropertyChanging("COLOR2");
                gCOLOR2 = value;
                NotifyPropertyChanging("COLOR2");
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
