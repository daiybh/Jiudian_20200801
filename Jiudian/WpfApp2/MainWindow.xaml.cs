using IniParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
public class GlobalData
    {
        public int kongweishu = 15;
        public string sqlConnectStr = "Data Source=192.168.0.243,1439;Initial Catalog=property;User ID=sa;Password=123456";

        public GlobalData()
        {
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string configFilePath = str+"Config.ini";

            if(!System.IO.File.Exists(configFilePath)){
                //write
                var parser1 = new FileIniDataParser();
                IniData data1 = new IniData();
                data1["GENERAL_CONFIG"]["MaxCount"] = "15";
                data1["DB"]["source"] = "192.168.0.243,1439";
                data1["DB"]["user"] = "sa";
                data1["DB"]["pwd"] = "123456";

                parser1.WriteFile(configFilePath, data1);


            }

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(configFilePath);

            try
            {
                kongweishu = Int32.Parse(data["GENERAL_CONFIG"]["MaxCount"]);
                sqlConnectStr = String.Format("Data Source={0};Initial Catalog=property;User ID={1};Password={2}",
                    data["DB"]["source"],
                    data["DB"]["user"],
                    data["DB"]["pwd"]);
            }
            catch (Exception e)
            {
                kongweishu = 15;
            }
        }
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
        }
        private void updateKongweishu()
        {
            globalData.kongweishu -= dataSet.Tables.Count;
            this.kongweishu.Text = "空位数:" + globalData.kongweishu;
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (globalData.kongweishu == 0) return;
           /* AddDialog ad = new AddDialog();
            ad.ShowDialog();
            if (ad.bSavebtn)
            {
                addDB(ad.chepaihao.Text, ad.kaishiSHijian.DateTime.ToString(), ad.jiesuSHijian.DateTime.ToString());
            }

            updateKongweishu();/**/
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
/*
            var rr = dataGrid1.SelectedIndex;
            if (rr == -1) return;

            string listID = (dataGrid1.Columns[0].GetCellContent(dataGrid1.Items[rr]) as TextBlock).Text;
            string plateNO = (dataGrid1.Columns[1].GetCellContent(dataGrid1.Items[rr]) as TextBlock).Text;
            string strstartTime = (dataGrid1.Columns[2].GetCellContent(dataGrid1.Items[rr]) as TextBlock).Text;
            string strendTime = (dataGrid1.Columns[3].GetCellContent(dataGrid1.Items[rr]) as TextBlock).Text;

            AddDialog addDialog = new AddDialog();
            addDialog.chepaihao.Text = plateNO;

            //8/3/2020 10:27:17 AM"

            addDialog.kaishiSHijian.DateTime = DateTime.ParseExact(strstartTime, "yyyy-MM-dd HH:mm:ss", null);
            addDialog.jiesuSHijian.DateTime = DateTime.ParseExact(strendTime, "yyyy-MM-dd HH:mm:ss", null);

            addDialog.ShowDialog();
            if (!addDialog.bSavebtn) return;
            updateDB(listID, addDialog.chepaihao.Text, addDialog.kaishiSHijian.DateTime.ToString(), addDialog.jiesuSHijian.DateTime.ToString());
/**/
        }
    }
}
