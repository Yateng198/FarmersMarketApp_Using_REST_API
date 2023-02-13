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
            await Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7118/api/Product/GetAllProduct");
                responseMessage.EnsureSuccessStatusCode();
                string response = await responseMessage.Content.ReadAsStringAsync();
                Json jsonObj = JsonConvert.DeserializeObject<Json>(response);

                //Get the product list in the json response message object
                List<Product> products = jsonObj.listProducts;
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    //Fill up the datagrid with the product list information
                    dataGrid.ItemsSource = products;
                }));

            });
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
