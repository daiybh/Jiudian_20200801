using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
            
            
            //8/3/2020 10:27:17 AM"

            InitializeComponent();

            this.topButton.exitBtn.Click += exit;
            {
                string sqlConnectStr = "Data Source=192.168.0.243,1439;Initial Catalog=property;User ID=sa;Password=123456";

                sqlCon = new SqlConnection(sqlConnectStr);//
                sqlCon.Open();
            }
            ConnectDB();
            updateKongweishu();

            dataGrid1.SelectedIndex = 1;
            
           
        }
        private void updateKongweishu()
        {
            globalData.kongweishu -= dataSet.Tables.Count;
            this.kongweishu.Text = "空位数:" + globalData.kongweishu;
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (globalData.kongweishu == 0) return;
            AddDialog ad = new AddDialog();
            ad.ShowDialog();
            if (ad.bSavebtn)
            {
               
                addDB(ad.chepaihao.Text, ad.kaishiSHijian.DateTime.ToString(),ad.jiesuSHijian.DateTime.ToString());
            }

            updateKongweishu();
        }


        SqlConnection sqlCon;
        DataSet dataSet = new DataSet();

        void ConnectDB()
        {
            string sql1 = "select [list_id] as Id,[plate] as 车牌号,[starttime] as 开始时间,[endtime] as 结束时间 from zk_platelist";
            SqlDataAdapter sqlada = new SqlDataAdapter(sql1, sqlCon);

            dataSet.Clear();
            sqlada.Fill(dataSet, "table1");
            dataGrid1.DataContext = dataSet;
            
        }
        void addDB(string plate,string startTime,string endtime)
        {
            string sqladd = "insert into dbo.zk_platelist(plate,starttime,endtime) values('"+plate+"','"+startTime+"','"+endtime+"')";
            SqlCommand sqlcmd = new SqlCommand(sqladd, sqlCon);
            sqlcmd.ExecuteNonQuery();
            //MessageBox.Show("插入成功");
            ConnectDB();
        }
        void updateDB(string id,string plate, string startTime, string endtime)
        {
            string sqlUpdate = "UPDATE dbo.zk_platelist set plate='"+ plate + "',starttime='"+startTime+"',endtime='"+endtime+ "' where [list_id]="+id;
            
            SqlCommand sqlcmd = new SqlCommand(sqlUpdate, sqlCon);
            sqlcmd.ExecuteNonQuery();
            //MessageBox.Show("插入成功");
            ConnectDB();
        }
        void deleteDB(string id)
        {
            /*DELETE FROM [dbo].[zk_platelist]
      WHERE <Search Conditions,,>
GO*/
            string sqlDel = "DELETE FROM [dbo].[zk_platelist] where [list_id]=" + id;

            SqlCommand sqlcmd = new SqlCommand(sqlDel, sqlCon);
            sqlcmd.ExecuteNonQuery();
            //MessageBox.Show("插入成功");
            ConnectDB();
        }


        private void exit(object sender, RoutedEventArgs e)
        {
            this.topButton.infoTextBox.Text = "aaaaa" + DateTime.Now.ToString();
            ConnectDB();

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var rr = dataGrid1.SelectedIndex;
            if (rr == -1) return;
            string listID = (dataGrid1.Columns[0].GetCellContent(dataGrid1.Items[rr]) as TextBlock).Text;
            deleteDB(listID);            
            updateKongweishu();
        }

        private void modBtn_Click(object sender, RoutedEventArgs e)
        {
            
            var rr = dataGrid1.SelectedIndex;
            if (rr == -1) return;
 
            string listID = (dataGrid1.Columns[0].GetCellContent(dataGrid1.Items[rr]) as TextBlock).Text;
            string plateNO = (dataGrid1.Columns[1].GetCellContent(dataGrid1.Items[rr]) as TextBlock).Text;
            string strstartTime = (dataGrid1.Columns[2].GetCellContent(dataGrid1.Items[rr]) as TextBlock).Text;
            string strendTime = (dataGrid1.Columns[3].GetCellContent(dataGrid1.Items[rr]) as TextBlock).Text;

            AddDialog addDialog = new AddDialog();
            addDialog.chepaihao.Text = plateNO;

            //8/3/2020 10:27:17 AM"
            
            addDialog.kaishiSHijian.DateTime = DateTime.ParseExact(strstartTime, "yyyy-MM-dd HH:mm:ss",null);
            addDialog.jiesuSHijian.DateTime = DateTime.ParseExact(strendTime, "yyyy-MM-dd HH:mm:ss", null);

            addDialog.ShowDialog();
            if (!addDialog.bSavebtn) return;
            updateDB(listID, addDialog.chepaihao.Text, addDialog.kaishiSHijian.DateTime.ToString(),addDialog.jiesuSHijian.DateTime.ToString());

        }
    }
}
