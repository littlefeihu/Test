using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSqliteDBByPwd
{
    class Program
    {
        static void Main(string[] args)
        {

            string DB_PATH = "Data Source=EncryptedDB.db3; Password=1111";


            using (SQLiteConnection con = new SQLiteConnection(DB_PATH))
            {
                con.Open();
                string sqlStr = @"INSERT INTO Customer(CUST_NO,CUSTOMER)
                                  VALUES
                                  (
                                      3000,
                                      'Allen'
                                  )";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlStr, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
