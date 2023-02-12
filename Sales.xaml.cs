using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
using System.Xml;
using System.Xml.Linq;

namespace FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        SqlConnection con;

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


        private void Add_Apple(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False";
            con = new SqlConnection(connectionString);
            try
            {
                //Open the database Connection

                con.Open();

                int appleStock;
                double applePrice = 2.1;
                String query = "Select ProductID, ProductName , Amount, Price from ProductTable where ProductID=@ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", 124567);
                SqlDataReader sqlReader = cmd.ExecuteReader();
                sqlReader.Read();
                appleStock = (int)sqlReader.GetValue(2);
                //applePrice = (double)sqlReader.GetValue(3);
                //p1Price.Text = applePrice.ToString();

                int appleInOrder = 0;
                try
                {
                    appleInOrder = (int.Parse(appleAmount.Text));
                }catch(Exception)
                {
                    MessageBox.Show("Input error, please only input integer for the amount of product." +
                    "\n\nInput 0 if you don't want this product.");
                }
                double orderTPrice = Convert.ToDouble(totalPrice.Text);


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

                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Orange(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False";
            con = new SqlConnection(connectionString);
            try
            {
                //Open the database Connection

                con.Open();

                int orangeStock;
                double orangePrice = 2.49;
                String query = "Select ProductID, ProductName , Amount, Price from ProductTable where ProductID=@ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", 345678);
                SqlDataReader sqlReader = cmd.ExecuteReader();
                sqlReader.Read();
                orangeStock = (int)sqlReader.GetValue(2);
                //orangePrice = (double)sqlReader.GetValue(3);
                //p1Price.Text = OrangePrice.ToString();

                int orangeInOrder = 0;
                try
                {
                    orangeInOrder = (int.Parse(orangeAmount.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Input error, please only input integer for the amount of product." +
                    "\n\nInput 0 if you don't want this product.");
                }
                double orderTPrice = Convert.ToDouble(totalPrice.Text);


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

                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Rasp(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False";
            con = new SqlConnection(connectionString);
            try
            {
                //Open the database Connection

                con.Open();

                int raspStock;
                double raspPrice = 2.35;
                String query = "Select ProductID, ProductName , Amount, Price from ProductTable where ProductID=@ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", 125678);
                SqlDataReader sqlReader = cmd.ExecuteReader();
                sqlReader.Read();
                raspStock = (int)sqlReader.GetValue(2);
                //raspPrice = (double)sqlReader.GetValue(3);
                //p1Price.Text = RaspPrice.ToString();

                int raspInOrder = 0;
                try
                {
                    raspInOrder = (int.Parse(raspAmount.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Input error, please only input integer for the amount of product." +
                    "\n\nInput 0 if you don't want this product.");
                }
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

                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Blue(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False";
            con = new SqlConnection(connectionString);
            try
            {
                //Open the database Connection

                con.Open();

                int blueStock;
                double bluePrice = 1.45;
                String query = "Select ProductID, ProductName , Amount, Price from ProductTable where ProductID=@ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", 456732);
                SqlDataReader sqlReader = cmd.ExecuteReader();
                sqlReader.Read();
                blueStock = (int)sqlReader.GetValue(2);
                //bluePrice = (double)sqlReader.GetValue(3);
                //p1Price.Text = BluePrice.ToString();

                int blueInOrder = 0;
                try
                {
                    blueInOrder = (int.Parse(blueAmount.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Input error, please only input integer for the amount of product." +
                    "\n\nInput 0 if you don't want this product.");
                }
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

                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Cauli(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False";
            con = new SqlConnection(connectionString);
            try
            {
                //Open the database Connection

                con.Open();

                int cauliStock;
                double cauliPrice = 2.22;
                String query = "Select ProductID, ProductName , Amount, Price from ProductTable where ProductID=@ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", 238901);
                SqlDataReader sqlReader = cmd.ExecuteReader();
                sqlReader.Read();
                cauliStock = (int)sqlReader.GetValue(2);
                //cauliPrice = (double)sqlReader.GetValue(3);
                //p1Price.Text = CauliPrice.ToString();

                int cauliInOrder = 0;
                try
                {
                    cauliInOrder = (int.Parse(cauliAmount.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Input error, please only input integer for the amount of product." +
                    "\n\nInput 0 if you don't want this product.");
                }
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

                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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

        private void Order_Confirm(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-1AHTENP;Initial Catalog=FarmersMarket;Integrated Security=True;Pooling=False";
            con = new SqlConnection(connectionString);
            try
            {
                //Open the database Connection

                con.Open();

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

                String query = "Select ProductID, ProductName , Amount, Price from ProductTable where ProductID=@ProductID";

                SqlCommand cmd1 = new SqlCommand(query, con);
                cmd1.Parameters.AddWithValue("@ProductID", 124567);
                SqlDataReader sqlReader1 = cmd1.ExecuteReader();
                sqlReader1.Read();
                appleStock = (int)sqlReader1.GetValue(2);
                sqlReader1.Close();

                SqlCommand cmd2 = new SqlCommand(query, con);
                cmd2.Parameters.AddWithValue("@ProductID", 345678);
                SqlDataReader sqlReader2 = cmd2.ExecuteReader();
                sqlReader2.Read();
                orangeStock = (int)sqlReader2.GetValue(2);
                sqlReader2.Close();

                SqlCommand cmd3 = new SqlCommand(query, con);
                cmd3.Parameters.AddWithValue("@ProductID", 125678);
                SqlDataReader sqlReader3 = cmd3.ExecuteReader();
                sqlReader3.Read();
                raspStock = (int)sqlReader3.GetValue(2);
                sqlReader3.Close();

                SqlCommand cmd4 = new SqlCommand(query, con);
                cmd4.Parameters.AddWithValue("@ProductID", 456732);
                SqlDataReader sqlReader4 = cmd4.ExecuteReader();
                sqlReader4.Read();
                blueStock = (int)sqlReader4.GetValue(2);
                sqlReader4.Close();

                SqlCommand cmd5 = new SqlCommand(query, con);
                cmd5.Parameters.AddWithValue("@ProductID", 238901);
                SqlDataReader sqlReader5 = cmd5.ExecuteReader();
                sqlReader5.Read();
                cauliStock = (int)sqlReader5.GetValue(2);
                sqlReader5.Close();



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

                }
                catch (Exception)
                {
                    MessageBox.Show("Input error, please only input integer for the amount of product." +
                    "\n\nInput 0 if you don't want this product.");
                }

                double orderTPrice = 0;


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
                    orderTPrice = (applePrice * appleInOrder)
                    + (orangePrice * orangeInOrder)
                    + (raspPrice * raspInOrder)
                    + (bluePrice * blueInOrder)
                    + (cauliPrice * cauliInOrder);

                    //just for better presentation for avg score
                    orderTPrice = ((double)((int)((orderTPrice + 0.005) * 100))) / 100;
                    totalPrice.Text = orderTPrice.ToString();

                    String query2 = "Update productTable set Amount=@Amount where ProductID=@ProductID";
                    SqlCommand cmd6 = new SqlCommand(query2, con);
                    SqlCommand cmd7 = new SqlCommand(query2, con);
                    SqlCommand cmd8 = new SqlCommand(query2, con);
                    SqlCommand cmd9 = new SqlCommand(query2, con);
                    SqlCommand cmd10 = new SqlCommand(query2, con);

                    try
                    {
                        cmd6.Parameters.AddWithValue("@ProductID", 124567);
                        cmd6.Parameters.AddWithValue("@Amount", appleStock - int.Parse(appleAmount.Text));

                        cmd7.Parameters.AddWithValue("@ProductID", 345678);
                        cmd7.Parameters.AddWithValue("@Amount", orangeStock - int.Parse(orangeAmount.Text));

                        cmd8.Parameters.AddWithValue("@ProductID", 125678);
                        cmd8.Parameters.AddWithValue("@Amount", raspStock - int.Parse(raspAmount.Text));

                        cmd9.Parameters.AddWithValue("@ProductID", 456732);
                        cmd9.Parameters.AddWithValue("@Amount", blueStock - int.Parse(blueAmount.Text));

                        cmd10.Parameters.AddWithValue("@ProductID", 238901);
                        cmd10.Parameters.AddWithValue("@Amount", cauliStock - int.Parse(cauliAmount.Text));

                        //We now need to execute our Query
                        cmd6.ExecuteNonQuery();
                        cmd7.ExecuteNonQuery();
                        cmd8.ExecuteNonQuery();
                        cmd9.ExecuteNonQuery();
                        cmd10.ExecuteNonQuery();

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

                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
