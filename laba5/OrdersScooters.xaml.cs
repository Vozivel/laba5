using System;
using System.Collections.Generic;
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

namespace laba5
{
    /// <summary>
    /// Логика взаимодействия для OrdersScooters.xaml
    /// </summary>
    public partial class OrdersScooters : Window
    {
        labaEntities labaEntities = new labaEntities();
        public string ret;
        public OrdersScooters(string returnwindow)
        {
            ret = returnwindow;
            InitializeComponent();
            MyDataGrid.ItemsSource = labaEntities.Orders_Scooters.ToList();
            Box1.ItemsSource = labaEntities.Orders.ToList();
            Box1.DisplayMemberPath = "ID_Order";
            Box2.ItemsSource = labaEntities.Scooters.ToList();
            Box2.DisplayMemberPath = "Scooter_Name";
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void PostsButton_Click(object sender, RoutedEventArgs e)
        {
            Post posts = new Post("OrdersScooters");
            posts.Show();
            Close();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTable employees = new EmployeesTable("OrdersScooters");
            employees.Show();
            Close();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow orders = new OrdersWindow("OrdersScooters");
            orders.Show();
            Close();
        }

        private void ScootersButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindow scooters = new ScootersWindow("OrdersScooters");
            scooters.Show();
            Close();
        }

        private void StoragesButton_Click(object sender, RoutedEventArgs e)
        {
            StoragesWindow storages = new StoragesWindow("OrdersScooters");
            storages.Show();
            Close();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            RolesWindow roles = new RolesWindow("OrdersScooters");
            roles.Show(); Close();
        }

        private void PaymentMethodsButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethods paymentMethods = new PaymentMethods("OrdersScooters");
            paymentMethods.Show(); Close();
        }

        private void ScootersTypesButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindows scootertypes = new ScootersWindows("OrdersScooters");
            scootertypes.Show(); Close();
        }

        private void OrdersScootersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersScooters orders = new OrdersScooters("OrdersScooters");
            orders.Show(); Close();
        }

        private void ProvidersButton_Click(object sender, RoutedEventArgs e)
        {
            ProvidersWindow providers = new ProvidersWindow("OrdersScooters");
            providers.Show(); Close();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyDataGrid.SelectedItem != null)
            {
                var select = MyDataGrid.SelectedItem as Orders_Scooters;
                if (select != null)
                {
                    Box1.Text = Convert.ToString(select.Order_ID);
                    Box2.Text = Convert.ToString(labaEntities.Scooters.Single(a => a.ID_Scooter == select.Scooter_ID).Scooter_Name);
                }

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Orders_Scooters c = new Orders_Scooters();
                c.Order_ID = Convert.ToInt32(Box1.Text);
                c.Scooter_ID = labaEntities.Scooters.Single(a=>a.Scooter_Name==Box2.Text).ID_Scooter;
                labaEntities.Orders_Scooters.Add(c);
                labaEntities.SaveChanges();
                MyDataGrid.ItemsSource = labaEntities.Orders_Scooters.ToList();
            }
            catch
            {
                MessageBox.Show("Неправильное значение");
            }

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (MyDataGrid.SelectedItem != null)
            {
                try
                {
                    var select = MyDataGrid.SelectedItem as Orders_Scooters;
                    select.Order_ID = Convert.ToInt32(Box1.Text);
                    select.Scooter_ID = labaEntities.Scooters.Single(a => a.Scooter_Name == Box2.Text).ID_Scooter;
                    labaEntities.SaveChanges();
                    MyDataGrid.ItemsSource = labaEntities.Orders_Scooters.ToList();
                }
                catch
                {
                    MessageBox.Show("Неправильное значение");
                }
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MyDataGrid.SelectedItem != null)
            {
                try
                {
                    labaEntities.Orders_Scooters.Remove(MyDataGrid.SelectedItem as Orders_Scooters);
                    labaEntities.SaveChanges();
                    MyDataGrid.ItemsSource = labaEntities.Orders_Scooters.ToList();
                }
                catch
                {
                    MessageBox.Show("Неправильное значение");
                }
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            switch (ret)
            {
                case "Posts":
                    PostsButton_Click(sender, e);
                    break;

                case "Employees":
                    EmployeesButton_Click(sender, e);
                    break;

                case "Orders":
                    OrdersButton_Click(sender, e);
                    break;

                case "Scooters":
                    ScootersButton_Click(sender, e);
                    break;

                case "Storagers":
                    StoragesButton_Click(sender, e);
                    break;

                case "Roles":
                    RolesButton_Click(sender, e);
                    break;

                case "PaymentMethods":
                    PaymentMethodsButton_Click(sender, e);
                    break;

                case "ScootersTypes":
                    ScootersTypesButton_Click(sender, e);
                    break;

                case "OrdersScooters":
                    OrdersScootersButton_Click(sender, e);
                    break;

                case "Providers":
                    ProvidersButton_Click(sender, e);
                    break;

                default:
                    AdminWindowxaml adminWindowxaml = new AdminWindowxaml("");
                    adminWindowxaml.Show();
                    Close();
                    break;
            }
        }
    }

}
