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
using System.Net.Http;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using static FarmersMarketApp.Admin;

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
                await Task.Run(async () =>
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7118/api/Product/GetAllProduct");
                    responseMessage.EnsureSuccessStatusCode();
                    string response = await responseMessage.Content.ReadAsStringAsync();
                    Json jsonObj = JsonConvert.DeserializeObject<Json>(response);
                    List<Product> products = jsonObj.listProducts;
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        dataGrid.ItemsSource = products;
                    }));

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
