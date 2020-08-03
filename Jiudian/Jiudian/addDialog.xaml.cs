using Jiudian.propertyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Jiudian
{
    /// <summary>
    /// add.xaml 的交互逻辑
    /// </summary>
    public partial class AddDialog : Window
    {
        public bool bSavebtn = false;
        
        public AddDialog()
        {
            InitializeComponent();
            
        }
        public static bool IsVehicleNumber(string vehicleNumber)
        {
            bool result = false;
            if (vehicleNumber.Length == 7)
            {
                string express = @"^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$";
                result = Regex.IsMatch(vehicleNumber, express);
            }
            else if(vehicleNumber.Length == 8)
            {
                string express = @"^[京津晋冀蒙辽吉黑沪苏浙皖闽赣鲁豫鄂湘粤桂琼渝川贵云藏陕甘青宁新]{1}[ABCDEFGHJKLMNPQRSTUVWXY]{1}[1-9DF]{1}[1-9ABCDEFGHJKLMNPQRSTUVWXYZ]\d{3}[1-9DF]$";
                result = Regex.IsMatch(vehicleNumber, express);
            }
            return result;
        }

        private List<string> str1 = new List<string>() { "京", "津", "冀", "晋", "蒙", "辽", "吉",
"黑", "沪", "苏", "浙du", "皖", "闽", "赣", "鲁", "豫", "鄂", "湘", "粤", "桂", "琼", "渝", "川", "贵", "云", "藏", "陕zhi", "甘", "青", "宁", "新", "学" };
       
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!IsVehicleNumber(this.chepaihao.Text))
            {
                MessageBox.Show("车牌号不合法");
                return;
            }
            bSavebtn = true;
            this.Close();
        }

        private void cancleBtn_Click(object sender, RoutedEventArgs e)
        {
               bSavebtn = false;
              this.Close();

            
        }
    }
}
