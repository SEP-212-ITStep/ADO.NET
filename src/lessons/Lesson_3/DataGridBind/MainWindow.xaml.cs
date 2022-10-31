using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using Microsoft.Win32;

namespace DataGridBind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string ConnectionString =
            @"Data Source=LAPTOP-EGOR\EGOR_SQL_SERVER;Initial Catalog=AdventureWorks2019;Integrated Security=True;Encrypt=false;";
        private static SqlDataAdapter? _adapter;
        private static readonly SqlConnection Connection = new(ConnectionString);
        private string _assemblyPath;
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

            }
            catch (Exception e)
            {
                this.ErrorTextBlock.Text = e.ToString();
            }
            /*
             *   Connection.Open();
                _adapter = new SqlDataAdapter("SELECT * FROM  Production.Product p", Connection);

                var dataSet = new DataSet();
                _adapter.Fill(dataSet);

                ProductDataGrid.ItemsSource = dataSet.Tables[0].DefaultView;
                _adapter.UpdateCommand = new SqlCommandBuilder(_adapter).GetUpdateCommand();
             */
        }

        private static object? GetDataFromAssembly(string path)
        {
            var assembly = Assembly.LoadFile(path);
            var program = assembly.GetTypes().Single(w => w.Name == "Program");
            var instance = Activator.CreateInstance(program);
            var method = program.GetMethod("Query");
            return method?.Invoke(instance, new object?[] { ConnectionString, "SELECT * FROM PRODUCTION.PRODUCT" });
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

        private void LoadAssemblyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_assemblyPath))
                {
                    MessageBox.Show("Select file before opening!");
                }
                else
                {
                    this.ProductDataGrid.ItemsSource = GetDataFromAssembly(_assemblyPath) as IEnumerable;
                }
            }
            catch (Exception exception)
            {
                ErrorTextBlock.Text = exception.ToString();
            }
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "DLL files only (*.dll)|*.dll"
                };
                if (openFileDialog.ShowDialog() is true)
                {
                    _assemblyPath = openFileDialog.FileName;
                    this.FilePathTextBlock.Text = _assemblyPath;
                }
            }
            catch (Exception exception)
            {
                this.ErrorTextBlock.Text = exception.ToString();
            }
        }
    }
}
