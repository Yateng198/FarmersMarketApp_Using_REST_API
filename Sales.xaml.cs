using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using static FarmersMarketApp.Admin;

namespace FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        static HttpClient client;

        public Sales()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        public void FocusApple(object sender, RoutedEventArgs e)
        {
            appleAmount.Text = string.Empty;
            appleAmount.GotFocus -= FocusApple;
        }

        public void FocusOrange(object sender, RoutedEventArgs e)
        {
            orangeAmount.Text = string.Empty;
            orangeAmount.GotFocus -= FocusOrange;
        }

        public void FocusRasp(object sender, RoutedEventArgs e)
        {
            raspAmount.Text = string.Empty;
            raspAmount.GotFocus -= FocusRasp;
        }

        public void FocusBlue(object sender, RoutedEventArgs e)
        {
            blueAmount.Text = string.Empty;
            blueAmount.GotFocus -= FocusBlue;
        }

        public void FocusCauli(object sender, RoutedEventArgs e)
        {
            cauliAmount.Text = string.Empty;
            cauliAmount.GotFocus -= FocusCauli;
        }


        private async void Add_Apple(object sender, RoutedEventArgs e)
        {
            int appleStock;
            double applePrice = 2.1;

            client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7118/api/Product/getProductById/124567");
            responseMessage.EnsureSuccessStatusCode();
            string response = await responseMessage.Content.ReadAsStringAsync();

            //Build up the json response message object with customed Json class
            Json jsonObj = JsonConvert.DeserializeObject<Json>(response);

            //Get apple currently in stock information
            Product apple = jsonObj.product;
            appleStock = apple.amount;

            int appleInOrder = 0;
            try
            {
                appleInOrder = (int.Parse(appleAmount.Text));
                double orderTPrice = Convert.ToDouble(totalPrice.Text);

                //Check if amount of apple in stock is greater than user ordering, otherwise will prompt user try again
                if ((appleStock - appleInOrder) >= 0)
                {
                    orderTPrice = orderTPrice + (applePrice * appleInOrder);
                    //just for better presentation for avg score
                    orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;
                    totalPrice.Text = orderTPrice.ToString();
                }

                else
                {
                    MessageBox.Show("Sorry, we only have " + appleStock + "kg apples in stock, please choose again with valid amount.");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Input error, please only input integer for the amount of product." +
                "\n\nInput 0 if you don't want this product.");
            }
        }

        private async void Add_Orange(object sender, RoutedEventArgs e)
        {
            int orangeStock;
            double orangePrice = 2.49;
            client = new HttpClient();

            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7118/api/Product/getProductById/345678");
            responseMessage.EnsureSuccessStatusCode();
            string response = await responseMessage.Content.ReadAsStringAsync();
            Json jsonObj = JsonConvert.DeserializeObject<Json>(response);

            //Get orange in stock information
            Product orange = jsonObj.product;
            orangeStock = orange.amount;

            int orangeInOrder = 0;
            try
            {
                orangeInOrder = (int.Parse(orangeAmount.Text));

                double orderTPrice = Convert.ToDouble(totalPrice.Text);

                //Make sure amount of orange in stock is greater than user ordering
                if ((orangeStock - orangeInOrder) >= 0)
                {
                    orderTPrice = orderTPrice + (orangePrice * orangeInOrder);
                    //just for better presentation for avg score
                    orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;
                    totalPrice.Text = orderTPrice.ToString();
                }

                else
                {
                    MessageBox.Show("Sorry, we only have " + orangeStock + "kg oranges in stock, please choose again with valid amount.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Input error, please only input integer for the amount of product." +
                "\n\nInput 0 if you don't want this product.");
            }

        }

        private async void Add_Rasp(object sender, RoutedEventArgs e)
        {
            int raspStock;
            double raspPrice = 2.35;

            client = new HttpClient();

            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7118/api/Product/getProductById/125678");
            responseMessage.EnsureSuccessStatusCode();
            string response = await responseMessage.Content.ReadAsStringAsync();
            Json jsonObj = JsonConvert.DeserializeObject<Json>(response);
            //Get raspberry in stock information
            Product raspberry = jsonObj.product;
            raspStock = raspberry.amount;


            int raspInOrder = 0;
            try
            {
                raspInOrder = (int.Parse(raspAmount.Text));

                double orderTPrice = Convert.ToDouble(totalPrice.Text);


                if ((raspStock - raspInOrder) >= 0)
                {
                    orderTPrice = orderTPrice + (raspPrice * raspInOrder);
                    //just for better presentation for avg score
                    orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;
                    totalPrice.Text = orderTPrice.ToString();
                }

                else
                {
                    MessageBox.Show("Sorry, we only have " + raspStock + "kg raspberries in stock, please choose again with valid amount.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Input error, please only input integer for the amount of product." +
                "\n\nInput 0 if you don't want this product.");
            }
        }

        private async void Add_Blue(object sender, RoutedEventArgs e)
        {
            int blueStock;
            double bluePrice = 1.45;

            client = new HttpClient();

            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7118/api/Product/getProductById/456732");
            responseMessage.EnsureSuccessStatusCode();
            string response = await responseMessage.Content.ReadAsStringAsync();
            Json jsonObj = JsonConvert.DeserializeObject<Json>(response);

            //Get blueberry currently in stock information
            Product blueberry = jsonObj.product;
            blueStock = blueberry.amount;

            int blueInOrder = 0;
            try
            {
                blueInOrder = (int.Parse(blueAmount.Text));
                double orderTPrice = Convert.ToDouble(totalPrice.Text);
                if ((blueStock - blueInOrder) >= 0)
                {
                    orderTPrice = orderTPrice + (bluePrice * blueInOrder);
                    //just for better presentation for avg score
                    orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;
                    totalPrice.Text = orderTPrice.ToString();
                }

                else
                {
                    MessageBox.Show("Sorry, we only have " + blueStock + "kg blueberries in stock, please choose again with valid amount.");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Input error, please only input integer for the amount of product." +
                "\n\nInput 0 if you don't want this product.");
            }
        }

        private async void Add_Cauli(object sender, RoutedEventArgs e)
        {
            int cauliStock;
            double cauliPrice = 2.22;

            client = new HttpClient();

            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7118/api/Product/getProductById/238901");
            responseMessage.EnsureSuccessStatusCode();
            string response = await responseMessage.Content.ReadAsStringAsync();
            Json jsonObj = JsonConvert.DeserializeObject<Json>(response);
            //Get cauliflower currently in stock information
            Product cauliflower = jsonObj.product;
            cauliStock = cauliflower.amount;

            int cauliInOrder = 0;
            try
            {
                cauliInOrder = (int.Parse(cauliAmount.Text));

                double orderTPrice = Convert.ToDouble(totalPrice.Text);
                if ((cauliStock - cauliInOrder) >= 0)
                {
                    orderTPrice = orderTPrice + (cauliPrice * cauliInOrder);
                    //just for better presentation for avg score
                    orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;
                    totalPrice.Text = orderTPrice.ToString();
                }

                else
                {
                    MessageBox.Show("Sorry, we only have " + cauliStock + "kg cauliflowers in stock, please choose again with valid amount.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Input error, please only input integer for the amount of product." +
                "\n\nInput 0 if you don't want this product.");
            }
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
            appleAmount.Text = "Please enter the amount you want to buy";
            orangeAmount.Text = "Please enter the amount you want to buy";
            raspAmount.Text = "Please enter the amount you want to buy";
            blueAmount.Text = "Please enter the amount you want to buy";
            cauliAmount.Text = "Please enter the amount you want to buy";

            double orderTPrice = 0;
            totalPrice.Text = orderTPrice.ToString();
            MessageBox.Show("Shopping carts cleaned, now you could choose again!");
        }

        private async void Order_Confirm(object sender, RoutedEventArgs e)
        {
            int appleStock;
            int orangeStock;
            int raspStock;
            int blueStock;
            int cauliStock;

            double applePrice = 2.10;
            double orangePrice = 2.49;
            double raspPrice = 2.35;
            double bluePrice = 1.45;
            double cauliPrice = 2.22;

            client = new HttpClient();
            //Get all products in the data base from Rest API
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7118/api/Product/GetAllProduct");
            responseMessage.EnsureSuccessStatusCode();
            string response = await responseMessage.Content.ReadAsStringAsync();
            Json jsonObj = JsonConvert.DeserializeObject<Json>(response);
            //Take the product list from response message
            List<Product> productsList = jsonObj.listProducts;

            //Get each product currently in stock information from rest api response message object
            Product apple = productsList[0];
            appleStock = apple.amount;

            Product raspberry = productsList[1];
            raspStock = raspberry.amount;

            Product cauliflower = productsList[2];
            cauliStock = cauliflower.amount;

            Product orange = productsList[3];
            orangeStock = orange.amount;

            Product blueberry = productsList[4];
            blueStock = blueberry.amount;


            int appleInOrder = 0;
            int orangeInOrder = 0;
            int raspInOrder = 0;
            int blueInOrder = 0;
            int cauliInOrder = 0;

            try
            {
                appleInOrder = (int.Parse(appleAmount.Text));
                orangeInOrder = (int.Parse(orangeAmount.Text));
                raspInOrder = (int.Parse(raspAmount.Text));
                blueInOrder = (int.Parse(blueAmount.Text));
                cauliInOrder = (int.Parse(cauliAmount.Text));

                double orderTPrice = 0;

                //If any one in stock amount is lower than user ordering, will prompt user try again
                if ((appleStock - appleInOrder) < 0)
                {
                    MessageBox.Show("Sorry, we only have " + appleStock + "kg apples in stock, please choose again with valid amount.");
                }

                else if ((orangeStock - orangeInOrder) < 0)
                {
                    MessageBox.Show("Sorry, we only have " + orangeStock + "kg oranges in stock, please choose again with valid amount.");
                }

                else if ((raspStock - raspInOrder) < 0)
                {
                    MessageBox.Show("Sorry, we only have " + raspStock + "kg raspberries in stock, please choose again with valid amount.");
                }

                else if ((blueStock - blueInOrder) < 0)
                {
                    MessageBox.Show("Sorry, we only have " + blueStock + "kg blueberries in stock, please choose again with valid amount.");
                }

                else if ((cauliStock - cauliInOrder) < 0)
                {
                    MessageBox.Show("Sorry, we only have " + cauliStock + "kg cauliflowers in stock, please choose again with valid amount.");
                }

                else
                {
                    //Calculating total price of this order
                    orderTPrice = (applePrice * appleInOrder)
                    + (orangePrice * orangeInOrder)
                    + (raspPrice * raspInOrder)
                    + (bluePrice * blueInOrder)
                    + (cauliPrice * cauliInOrder);

                    //just for better presentation for avg score
                    orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;
                    totalPrice.Text = orderTPrice.ToString();

                    //Update new database information after this order into the database
                    Product apl = new Product()
                    {
                        productName = apple.productName,
                        productId = apple.productId,
                        amount = appleStock - int.Parse(appleAmount.Text),
                        price = apple.price,
                    };
                    _ = await client.PutAsJsonAsync("https://localhost:7118/api/Product/updateProduct", apl);

                    Product rasp = new Product()
                    {
                        productName = raspberry.productName,
                        productId = raspberry.productId,
                        amount = raspStock - int.Parse(appleAmount.Text),
                        price = raspberry.price,
                    };
                    _ = await client.PutAsJsonAsync("https://localhost:7118/api/Product/updateProduct", rasp);

                    Product cauli = new Product()
                    {
                        productName = cauliflower.productName,
                        productId = cauliflower.productId,
                        amount = cauliStock - int.Parse(appleAmount.Text),
                        price = cauliflower.price,
                    };
                    _ = await client.PutAsJsonAsync("https://localhost:7118/api/Product/updateProduct", cauli);

                    Product ora = new Product()
                    {
                        productName = orange.productName,
                        productId = orange.productId,
                        amount = orangeStock - int.Parse(appleAmount.Text),
                        price = orange.price,
                    };
                    _ = await client.PutAsJsonAsync("https://localhost:7118/api/Product/updateProduct", ora);

                    Product blu = new Product()
                    {
                        productName = blueberry.productName,
                        productId = blueberry.productId,
                        amount = blueStock - int.Parse(appleAmount.Text),
                        price = blueberry.price,
                    };
                    _ = await client.PutAsJsonAsync("https://localhost:7118/api/Product/updateProduct", blu);


                    //Order processing message
                    MessageBox.Show("Order processed.\n\n" +
                    "You've ordered " + appleInOrder + "kg Apples, "
                    + orangeInOrder + "kg Oranges, "
                    + raspInOrder + "kg Raspberries, "
                    + blueInOrder + "kg Blueberries, and "
                    + cauliInOrder + "kg Cauliflowers.\n\n The Total Price is (CA)$" + orderTPrice + ".");


                }
            catch (Exception)
            {
                MessageBox.Show("Input error, please only input integer for the amount of product." +
                "\n\nInput 0 if you don't want this product.");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
