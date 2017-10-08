using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Configuration;

namespace SqliteEF6
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Init()
        {
            using (var db = new EF6Context())
            {
                var name = _vtbName.Text;

                var user = new User
                {
                    Data = new byte[] { 1, 2, 3, 4 },
                    Name = name,
                    Time = DateTime.Now,
                    Val = 2.2,
                    TestE = User.TestENUM.B
                };
                db.Users.Add(user);
                db.SaveChanges();

                var query = from b in db.Users
                            orderby b.Name
                            select b;

                try
                {
                    _vdgShow.ItemsSource = query.ToList();
                }
                catch { }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Init();
        }
    }
}
