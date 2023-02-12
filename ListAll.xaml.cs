using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using System.Threading;

namespace FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for ListAll.xaml
    /// </summary>
    /// 

    public partial class ListAll : Window
    {
        //Display all data information in DB in this page with DataGrid
        public ListAll()
        {
            InitializeComponent();
            listDB();
        }

        //Task-await-async control threading synchronization
        private async void listDB()
        {
            //Set up connection 
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False");
            try
            {
                await Task.Run(() =>
                {
                    //Open the connection
                    con.Open();
                    string query = "Select ProductId, ProductName, Amount, Price from ProductTable";
                    SqlCommand cmd = new SqlCommand(query, con);

                    //Execute the query to get all data in this DB
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("ProductTable");
                    adapter.Fill(dt);

                    //Current thread communicate with UI thread to change UI display information
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        dataGrid.ItemsSource = dt.DefaultView;
                    }));
                    adapter.Update(dt);
                    
                });
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //close connection
                con.Close();
            }
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Admin_Page_Button_Click(object sender, RoutedEventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Close();
        }

        
    }
}
