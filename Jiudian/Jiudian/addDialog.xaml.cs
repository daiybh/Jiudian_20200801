using Jiudian.propertyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            zk_platelistTableAdapter helper = new zk_platelistTableAdapter();
            //  helper.Update()
            bSavebtn = true;
            this.Close();
        }

        private void cancleBtn_Click(object sender, RoutedEventArgs e)
        {
            //   bSavebtn = false;
            //  this.Close();

            this.jiesuSHijian.DateTime = DateTime.Now;
        }
    }
}
