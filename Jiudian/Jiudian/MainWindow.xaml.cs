using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Jiudian
{
    public class GlobalData
    {
        public int kongweishu = 15;
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GlobalData globalData = new GlobalData();
        public MainWindow()
        {
            InitializeComponent();

            this.topButton.exitBtn.Click += exit;
            updateKongweishu();
        }
        private void updateKongweishu()
        {
            this.kongweishu.Text = "空位数:" + globalData.kongweishu;
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (globalData.kongweishu == 0) return;

            globalData.kongweishu--;
            updateKongweishu();
        }

        void ConnectDB()
        {
            string sql = "Data Source=DESKTOP-HMVR0JT;Initial Catalog=property;User ID=sa;Password=123456";

                       //string sql = "server=JOY;database=VofinePearl;uid=sa;pwd=123456";//连接字符串
            SqlConnection sqlcon = new SqlConnection(sql);//
            string sql1 = "select parked_id from zk_platelist";
            SqlDataAdapter sqlada = new SqlDataAdapter(sql1, sqlcon);
            DataSet ds = new DataSet();
            ds.Clear();
            DataTable table1 = new DataTable();
            sqlada.Fill(ds, "table1");
            dataGrid1.DataContext = ds;
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            this.topButton.infoTextBox.Text = "aaaaa"+DateTime.Now.ToString();
            ConnectDB();

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            
            globalData.kongweishu++;
            updateKongweishu();
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
