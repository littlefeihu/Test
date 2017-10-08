using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;

namespace SqliteEF6
{
    public class EF6Context : DbContext
    {
        public EF6Context(string databaseName = "SqlliteEF6")
            : base(databaseName)
        {
        }

        public DbSet<User> Users { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.SQLite.SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder(this.Database.Connection.ConnectionString);
            string path = AppDomain.CurrentDomain.BaseDirectory + connstr.DataSource;
            System.IO.FileInfo fi = new System.IO.FileInfo(path);
            if (System.IO.File.Exists(fi.FullName) == false)
            {
                if (System.IO.Directory.Exists(fi.DirectoryName) == false)
                {
                    System.IO.Directory.CreateDirectory(fi.DirectoryName);
                }
                SQLiteConnection.CreateFile(fi.FullName);

                connstr.DataSource = path;
                //connstr.Password = "admin";//设置密码，SQLite ADO.NET实现了数据库密码保护
                using (SQLiteConnection conn = new SQLiteConnection(connstr.ConnectionString))
                {
                    string sql = @" CREATE TABLE User (
   Id INTEGER PRIMARY KEY AUTOINCREMENT,
   Name varchar (20),
   Time timestamp,
   Data blob,
   Val real,
   TestE int);";
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            //添加创建代码
            //modelBuilder.Configurations.Add(new Blog());
        }
    }

    [Table("User")]
    public class User
    {
        public enum TestENUM : long { A, B, C };

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        [StringLength(30), Display(Name = "名称")]
        public string Name { get; set; }

        public byte[] Data { get; set; }

        public double Val { get; set; }

        public DateTime Time { get; set; }
        public TestENUM TestE { get; set; }

    }
}
