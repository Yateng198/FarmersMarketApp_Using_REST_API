using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        //Global variable
        private static HttpClient client;

        //In this page, we are using Task-async-await to contorl Threads Synchronization.
        public Admin()
        {
            InitializeComponent();
           
        }

        public class Product
        {
            public string productName { get; set; }
            public int productId { get; set; }
            public int amount { get; set; }
            public double price { get; set; }
        }
        public class Json
        {
            public string statuesCode { get; set; }
            public string statusMessage { get; set; }
            public Product product { get; set; }
            public List<Product> listProducts { get; set; }

        }


        //Back to home window and close the connection
        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        //Insert operation
        private async void Insert_Button_Click(object sender, RoutedEventArgs e)
        {
            //Invoke the insertButton() method
            await Task.Run(insertButton);
        }

        private void insertButton()
        {
            try
            {
                //Dispatch current thread to communicate with the UI thread
                Application.Current.Dispatcher.Invoke(new Action(async () =>
                {
                    try
                    {
                        client = new HttpClient();
                        Product product = new Product();
                        if (!p_name.Text.Equals(""))
                        {
                            product.productId = int.Parse(p_id.Text);
                            product.productName = p_name.Text;
                            product.amount = int.Parse(p_amount.Text);
                            product.price = float.Parse(p_price.Text);

                            _ = await client.PostAsJsonAsync("https://localhost:7118/api/Product/addProduct", product);
                            MessageBox.Show(p_amount.Text + " kg " + p_name.Text + " has been added successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Enter the product name and try again please!");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please check you input, digits only for Id, Amount and Price!");
                    }
                }));

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Delete operation
        private async void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            //Run the deleteButton method
            await Task.Run(deleteButton);


        }

        private void deleteButton()
        {
            try
            {
                //Dispatch current thread to communicate with the UI thread
                Application.Current.Dispatcher.Invoke(new Action(async () =>
                {
                    try
                    {
                        int.Parse(p_id.Text.Trim());

                        client = new HttpClient();
                        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7118/api/Product/DeleteProduct/" + p_id.Text.Trim());
                        responseMessage.EnsureSuccessStatusCode();
                        string response = await responseMessage.Content.ReadAsStringAsync();
                        Json jsonObj = JsonConvert.DeserializeObject<Json>(response);
                        if (jsonObj.statusMessage.Equals("Product Found and Deleted!"))
                        {
                            MessageBox.Show("Product Found and deleted!");
                        }
                        else
                        {
                            MessageBox.Show("Product not found, check your Id and try again please!");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Enter the product Id that you want to delete by digits only please!");
                    }
                }));

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Update operation
        private async void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            //Run the updateButton method
            await Task.Run(updateButton);

        }
        private void updateButton()
        {
            try
            {
                //Dispatch current thread to communicate with the UI thread
                Application.Current.Dispatcher.Invoke(new Action(async () =>
                {
                    try
                    {
                        client = new HttpClient();
                        if (!p_name.Text.Equals(""))
                        {
                            Product product = new Product()
                            {
                                productId = int.Parse(p_id.Text.Trim()),
                                productName = p_name.Text.Trim(),
                                amount = int.Parse(p_amount.Text.Trim()),
                                price = float.Parse(p_price.Text.Trim())
                            };
                            await client.PutAsJsonAsync("https://localhost:7118/api/Product/updateProduct", product);

                            MessageBox.Show("Product information updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("The product name can not be blank, try again please!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Input error, digit only for ID, Amount and Price, try again please!");
                    }

                }));


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(searchButton);
        }

        private void searchButton()
        {
            try
            {
                //Dispatch current thread to communicate with the UI thread
                Application.Current.Dispatcher.Invoke(new Action(async () =>
                {

                    try
                    {
                        _ = (int.Parse(p_id.Text));
                        client = new HttpClient();
                        if (!(p_id.Text.Equals("")))
                        {
                            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7118/api/Product/getProductById/" + p_id.Text);
                            responseMessage.EnsureSuccessStatusCode();
                            string response = await responseMessage.Content.ReadAsStringAsync();
                            // Console.WriteLine(response.ToString());

                            Json jsonObj = JsonConvert.DeserializeObject<Json>(response);
                            Product product = jsonObj.product;
                            if (product != null)
                            {
                                p_name.Text = product.productName;
                                p_id.Text = product.productId.ToString();
                                p_amount.Text = product.amount.ToString();
                                p_price.Text = product.price.ToString();
                            }
                            else
                            {
                                MessageBox.Show("No iteam found with thid ID!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter the product id you want search please!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Input error, digits only for product ID, try again please!");
                    }
                }));

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //To check all the data in DB, will display in an independent window
        //And close this window DB connection
        private void List_All_Button_Click(object sender, RoutedEventArgs e)
        {
            ListAll ls = new ListAll();
            ls.Show();
            this.Close();
        }
    }
}
