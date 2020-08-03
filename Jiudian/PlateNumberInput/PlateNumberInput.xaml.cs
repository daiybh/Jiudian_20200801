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

namespace PlateNumberInput
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PlateNumberInput : UserControl
    {
        private List<string> strProv = new List<string>() { "川", "京", "津", "冀", "晋", "蒙", "辽", "吉",
"黑", "沪", "苏", "浙du", "皖", "闽", "赣", "鲁", "豫", "鄂", "湘", "粤", "桂", "琼", "渝", "贵", "云", "藏", "陕zhi", "甘", "青", "宁", "新", "学" };
        private List<string> strDic = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y" };

        private Dictionary<string, int> mapProv = new Dictionary<string, int>();
        private Dictionary<string, int> mapDic = new Dictionary<string, int>();

        public PlateNumberInput()
        {

            InitializeComponent();
            this.prov.ItemsSource = strProv;
            this.dic.ItemsSource = strDic;
            this.prov.SelectedIndex = 0;
            this.dic.SelectedIndex = 0;

            for (int i = 0; i < strProv.Count; i++)
                mapProv.Add(strProv[i], i);


            for (int i = 0; i < strDic.Count; i++)
                mapDic.Add(strDic[i], i);

        }
        public string Text
        {
            get {
                return strProv[this.prov.SelectedIndex] + strDic[this.dic.SelectedIndex]+ this.chepaihao.Text;                
            }
            set {
                string prov = value.Substring(0,1);
                string dic = value.Substring(1,1);
                string number = value.Substring(2);
                this.chepaihao.Text = number;

                this.prov.SelectedIndex = mapProv[prov];
                this.dic.SelectedIndex = mapDic[dic];
            }
        }
    }
}