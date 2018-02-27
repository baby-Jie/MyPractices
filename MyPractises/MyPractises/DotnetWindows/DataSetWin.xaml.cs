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
using System.Windows.Shapes;

namespace MyPractises.DotnetWindows
{
    /// <summary>
    /// Interaction logic for DataSetWin.xaml
    /// </summary>
    public partial class DataSetWin : Window
    {
        public DataSetWin()
        {
            InitializeComponent();
        }

        string conStr = @"Data Source=PC-20170515PJNW\SQLEXPRESS;Initial Catalog=HeiMaSeven;Integrated Security=true";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(conStr);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tblPerson", sqlCon);
            DataSet set = new DataSet();
            adapter.Fill(set);
            DataTable tb =  set.Tables[0];

            dgShowMsg.ItemsSource = tb.DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataSet set = new DataSet("School");
            DataTable tb = new DataTable("Student");
            set.Tables.Add(tb);
            DataColumn column = new DataColumn("autoid", typeof(int));
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 100;
            column.AutoIncrementStep = 1;

            tb.Columns.Add(column);
            tb.Columns.Add("name", typeof(string));
            tb.Columns.Add("score", typeof(int));

            DataRow row1 = tb.NewRow();
            row1[1] = "smx";
            row1[2] = 12;

            DataRow row2 = tb.NewRow();
            row2[1] = "xyj";
            row2[2] = 99;

            tb.Rows.Add(row1);
            tb.Rows.Add(row2);

            dgShowMsg.ItemsSource = tb.DefaultView;
               
        }
    }
}
