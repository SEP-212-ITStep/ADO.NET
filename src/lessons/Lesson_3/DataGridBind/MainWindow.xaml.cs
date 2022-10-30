using System;
using System.Collections.Generic;
using System.Data;
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
using Microsoft.Data.SqlClient;

namespace DataGridBind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string connectionString =
            @"Data Source=LAPTOP-EGOR\EGOR_SQL_SERVER;Initial Catalog=AdventureWorks2019;Integrated Security=True;Encrypt=false;";
        private static SqlDataAdapter? _adapter;
        private static DataSet _dataSet;
        private static readonly SqlConnection Connection = new(connectionString);
        protected override void OnClosed(EventArgs e)
        {
            Connection.Dispose();
            base.OnClosed(e);
        }

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                Connection.Open();
                _adapter = new SqlDataAdapter("SELECT * FROM  Production.Product p", Connection);

                _dataSet = new DataSet();
                _adapter.Fill(_dataSet);

                ProductDataGrid.ItemsSource = _dataSet.Tables[0].DefaultView;
                _adapter.UpdateCommand = new SqlCommandBuilder(_adapter).GetUpdateCommand();
            }
            catch (Exception e)
            {
                this.ErrorTextBlock.Text = e.ToString();
            }

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductDataGrid.ItemsSource is DataView { Table: { } } dataView)
                { 
                    _adapter?.Update(dataView.Table);
                }
            }
            catch (Exception exception)
            {
                this.ErrorTextBlock.Dispatcher.Invoke(() =>
                {
                    this.ErrorTextBlock.Text = exception.ToString();
                });
            }

        }
    }
}
