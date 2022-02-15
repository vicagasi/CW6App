using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace CW6App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OleDbConnection cn;
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\CW6Database.accdb");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            /* === ASSETS === */
            // Employee ID
            string query = "select* from Assets";
            AssetEmpID.Text = getData(query);
            // Asset ID
            query = "SELECT AssetID from Assets";
            AssetAssetID.Text = getData(query);
            // Asset Descriptions
            query = "SELECT Description from Assets";
            AssetDesc.Text = getData(query);
        }

        private void Button_ClickEMP(object sender, RoutedEventArgs e)
        {

            /* === EMPLOYEES === */
            // Employee ID
            String query = "select* from Employees";
            EmpEmpID.Text = getData(query);
            // Asset ID
            query = "SELECT FirstName from Employees";
            FirstName.Text = getData(query);
            // Asset Descriptions
            query = "SELECT LastName from Employees";
            LastName.Text = getData(query);
        }

        public string getData(string query)
        {
            OleDbConnection cn;
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\CW6Database.accdb");
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }
            return data;
        }
    }
}
