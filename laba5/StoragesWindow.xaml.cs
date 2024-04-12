using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Net.Mime.MediaTypeNames;

namespace laba5
{
    /// <summary>
    /// Логика взаимодействия для StoragesWindow.xaml
    /// </summary>
    public partial class StoragesWindow : Window
    {
        labaEntities labaEntities = new labaEntities();
        public string ret;
        public StoragesWindow(string returnwindow)
        {
            ret = returnwindow;
            InitializeComponent();
            MyDataGrid.ItemsSource = labaEntities.Storages.ToList();
            Box1.ItemsSource = labaEntities.Scooters.ToList();
            Box1.DisplayMemberPath = "Scooter_Name";
            Box3.ItemsSource = labaEntities.Providers.ToList();
            Box3.DisplayMemberPath = "Provider_Name";
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void PostsButton_Click(object sender, RoutedEventArgs e)
        {
            Post posts = new Post("Storages");
            posts.Show();
            Close();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTable employees = new EmployeesTable("Storages");
            employees.Show();
            Close();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow orders = new OrdersWindow("Storages");
            orders.Show();
            Close();
        }

        private void ScootersButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindow scooters = new ScootersWindow("Storages");
            scooters.Show();
            Close();
        }

        private void StoragesButton_Click(object sender, RoutedEventArgs e)
        {
            StoragesWindow storages = new StoragesWindow("Storages");
            storages.Show();
            Close();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            RolesWindow roles = new RolesWindow("Storages");
            roles.Show(); Close();
        }

        private void PaymentMethodsButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethods paymentMethods = new PaymentMethods("Storages");
            paymentMethods.Show(); Close();
        }

        private void ScootersTypesButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindows scootertypes = new ScootersWindows("Storages");
            scootertypes.Show(); Close();
        }

        private void OrdersScootersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersScooters orders = new OrdersScooters("Storages");
            orders.Show(); Close();
        }

        private void ProvidersButton_Click(object sender, RoutedEventArgs e)
        {
            ProvidersWindow providers = new ProvidersWindow("Storages");
            providers.Show(); Close();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyDataGrid.SelectedItem != null)
            {
                var select = MyDataGrid.SelectedItem as Storages;
                if (select != null)
                {
                    Box1.Text = Convert.ToString(labaEntities.Scooters.Single(a => a.ID_Scooter == select.Scooter_ID).Scooter_Name);
                    Box2.Text = Convert.ToString(select.Scooter_Quantity);
                    Box3.Text = Convert.ToString(labaEntities.Providers.Single(a => a.ID_Provider == select.Provider_ID).Provider_Name);
                }
                
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Storages c = new Storages();
                c.Scooter_ID = labaEntities.Scooters.Single(a=>a.Scooter_Name==Box1.Text).ID_Scooter;
                c.Scooter_Quantity = Convert.ToInt32(Box2.Text);
                c.Provider_ID = labaEntities.Providers.Single(a=>a.Provider_Name==Box3.Text).ID_Provider;
                labaEntities.Storages.Add(c);
                labaEntities.SaveChanges();
                MyDataGrid.ItemsSource = labaEntities.Storages.ToList();
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
                    var select = MyDataGrid.SelectedItem as Storages;
                    select.Scooter_ID = labaEntities.Scooters.Single(a => a.Scooter_Name == Box1.Text).ID_Scooter;
                    select.Scooter_Quantity = Convert.ToInt32(Box2.Text);
                    select.Provider_ID = labaEntities.Providers.Single(a => a.Provider_Name == Box3.Text).ID_Provider;
                    labaEntities.SaveChanges();
                    MyDataGrid.ItemsSource = labaEntities.Storages.ToList();
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
                    labaEntities.Storages.Remove(MyDataGrid.SelectedItem as Storages);
                    labaEntities.SaveChanges();
                    MyDataGrid.ItemsSource = labaEntities.Storages.ToList();
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
