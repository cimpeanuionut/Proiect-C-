using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Situaţii_note_studenţi.Clase
{
    class AccessConnection
    {
        private static readonly string databasePath = @"C:\Users\Gabi\Desktop\Situaţii_note_studenţi\Situaţii_note_studenţi\bin\Debug\Database1.accdb";
        private static OleDbConnection conn = null;

        private AccessConnection()
        {
        }

        public static OleDbConnection GetConnection()
        {
            if (conn == null)
            {
                conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Database1.mdb");
                conn.Open();
            }
            return conn;
        }

        ~AccessConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
