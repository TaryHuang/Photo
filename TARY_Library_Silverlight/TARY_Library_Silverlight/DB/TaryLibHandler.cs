using System;
using System.Data.Linq;
using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace TARY_Library_Silverlight
{
    public class TaryLibHandler : DataContext
    {
        public static string DBConnection = "Data Source=isostore:/TaryDB.sdf";

        public TaryLibHandler(string pDBConnection) : base(pDBConnection) { }

        public Table<TaryDB> TaryDB;
    }
}
