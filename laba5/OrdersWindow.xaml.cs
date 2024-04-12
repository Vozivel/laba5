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
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        labaEntities labaEntities = new labaEntities();
        public string ret;
        public OrdersWindow(string returnwindow)
        {
            ret = returnwindow;
            InitializeComponent();
            MyDataGrid.ItemsSource = labaEntities.Orders.ToList();
            Box1.ItemsSource = labaEntities.Payment_Method.ToList();
            Box1.DisplayMemberPath = "Method_Name";
            Box3.ItemsSource = labaEntities.Employees.ToList();
            Box3.DisplayMemberPath = "Employee_Name";
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void PostsButton_Click(object sender, RoutedEventArgs e)
        {
            Post posts = new Post("Orders");
            posts.Show();
            Close();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTable employees = new EmployeesTable("Orders");
            employees.Show();
            Close();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow orders = new OrdersWindow("Orders");
            orders.Show();
            Close();
        }

        private void ScootersButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindow scooters = new ScootersWindow("Orders");
            scooters.Show();
            Close();
        }

        private void StoragesButton_Click(object sender, RoutedEventArgs e)
        {
            StoragesWindow storages = new StoragesWindow("Orders");
            storages.Show();
            Close();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            RolesWindow roles = new RolesWindow("Orders");
            roles.Show(); Close();
        }

        private void PaymentMethodsButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethods paymentMethods = new PaymentMethods("Orders");
            paymentMethods.Show(); Close();
        }

        private void ScootersTypesButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindows scootertypes = new ScootersWindows("Orders");
            scootertypes.Show(); Close();
        }

        private void OrdersScootersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersScooters orders = new OrdersScooters("Orders");
            orders.Show(); Close();
        }

        private void ProvidersButton_Click(object sender, RoutedEventArgs e)
        {
            ProvidersWindow providers = new ProvidersWindow("Orders");
            providers.Show(); Close();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyDataGrid.SelectedItem != null)
            {
                var select = MyDataGrid.SelectedItem as Orders;
                if (select != null)
                {
                    Box1.Text = Convert.ToString(labaEntities.Payment_Method.Single(a => a.ID_Method == select.Method_ID).Method_Name);
                    Box2.Text = Convert.ToString(select.Order_Cost);
                    Box3.Text = Convert.ToString(labaEntities.Employees.Single(a => a.ID_Employee == select.Employee_ID).Employee_Name);
                }

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Orders c = new Orders();
                c.Method_ID = labaEntities.Payment_Method.Single(a=>a.Method_Name==Box1.Text).ID_Method;
                c.Order_Cost = Convert.ToInt32(Box2.Text);
                c.Employee_ID = labaEntities.Employees.Single(a => a.Employee_Name == Box3.Text).ID_Employee;
                labaEntities.Orders.Add(c);
                labaEntities.SaveChanges();
                MyDataGrid.ItemsSource = labaEntities.Orders.ToList();
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
                    var select = MyDataGrid.SelectedItem as Orders;
                    select.Method_ID = labaEntities.Payment_Method.Single(a => a.Method_Name == Box1.Text).ID_Method;
                    select.Order_Cost = Convert.ToInt32(Box2.Text);
                    select.Employee_ID = labaEntities.Employees.Single(a => a.Employee_Name == Box3.Text).ID_Employee;
                    labaEntities.SaveChanges();
                    MyDataGrid.ItemsSource = labaEntities.Orders.ToList();
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
                    labaEntities.Orders.Remove(MyDataGrid.SelectedItem as Orders);
                    labaEntities.SaveChanges();
                    MyDataGrid.ItemsSource = labaEntities.Orders.ToList();
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
