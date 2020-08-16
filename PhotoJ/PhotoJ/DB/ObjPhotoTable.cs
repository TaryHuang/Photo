using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;

namespace PhotoJ
{
    //實作INotifyPropertyChanged與INotifyPropertyChanging介面，做為屬性(欄位)值變更時的事件觸發。
    [Table(Name = "ObjPhotoTable")]
    public class ObjPhotoTable : INotifyPropertyChanged, INotifyPropertyChanging
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



        private int gORD;
        [Column(DbType = "int NULL", CanBeNull = false, Storage = "ORD")]
        public int ORD
        {
            //@ #  AAA ABC ABB 
            get
            {
                return gORD;
            }
            set
            {
                NotifyPropertyChanging("ORD");
                gORD = value;
                NotifyPropertyChanging("ORD");
            }
        }




        private byte[] gPhoto;
        [Column(DbType = "varbinary(8000) NULL", CanBeNull = true, Storage = "Photo")]
        public byte[] Photo
        {
            //@ #  AAA ABC ABB 
            get
            {
                return gPhoto;
            }
            set
            {
                NotifyPropertyChanging("Photo");
                gPhoto = value;
                NotifyPropertyChanging("Photo");
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
