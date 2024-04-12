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
    /// Логика взаимодействия для PaymentMethods.xaml
    /// </summary>
    public partial class PaymentMethods : Window
    {
        labaEntities labaEntities = new labaEntities();
        public string ret;
        public PaymentMethods(string returnwindow)
        {
            ret = returnwindow;
            InitializeComponent();
            MyDataGrid.ItemsSource = labaEntities.Payment_Method.ToList();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void PostsButton_Click(object sender, RoutedEventArgs e)
        {
            Post posts = new Post("PaymentMethods");
            posts.Show();
            Close();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTable employees = new EmployeesTable("PaymentMethods");
            employees.Show();
            Close();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow orders = new OrdersWindow("PaymentMethods");
            orders.Show();
            Close();
        }

        private void ScootersButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindow scooters = new ScootersWindow("PaymentMethods");
            scooters.Show();
            Close();
        }

        private void StoragesButton_Click(object sender, RoutedEventArgs e)
        {
            StoragesWindow storages = new StoragesWindow("PaymentMethods");
            storages.Show();
            Close();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            RolesWindow roles = new RolesWindow("PaymentMethods");
            roles.Show(); Close();
        }

        private void PaymentMethodsButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethods paymentMethods = new PaymentMethods("PaymentMethods");
            paymentMethods.Show(); Close();
        }

        private void ScootersTypesButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindows scootertypes = new ScootersWindows("PaymentMethods");
            scootertypes.Show(); Close();
        }

        private void OrdersScootersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersScooters orders = new OrdersScooters("PaymentMethods");
            orders.Show(); Close();
        }

        private void ProvidersButton_Click(object sender, RoutedEventArgs e)
        {
            ProvidersWindow providers = new ProvidersWindow("PaymentMethods");
            providers.Show(); Close();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyDataGrid.SelectedItem != null)
            {
                var select = MyDataGrid.SelectedItem as Payment_Method;
                if (select != null)
                {
                    Box1.Text = Convert.ToString(select.Method_Name);
                }

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Payment_Method c = new Payment_Method();
                c.Method_Name = Box1.Text;
                labaEntities.Payment_Method.Add(c);
                labaEntities.SaveChanges();
                MyDataGrid.ItemsSource = labaEntities.Payment_Method.ToList();
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
                    var select = MyDataGrid.SelectedItem as Payment_Method;
                    select.Method_Name = Box1.Text;
                    labaEntities.SaveChanges();
                    MyDataGrid.ItemsSource = labaEntities.Payment_Method.ToList();
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
                    labaEntities.Payment_Method.Remove(MyDataGrid.SelectedItem as Payment_Method);
                    labaEntities.SaveChanges();
                    MyDataGrid.ItemsSource = labaEntities.Payment_Method.ToList();
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
