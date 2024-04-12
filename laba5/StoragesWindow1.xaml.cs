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
    /// Логика взаимодействия для StoragesWindow1.xaml
    /// </summary>
    public partial class StoragesWindow1 : Window
    {
        labaEntities labaEntities = new labaEntities();
        public string ret;
        public StoragesWindow1(string returnwindow)
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
            Post1 posts = new Post1("Storages");
            posts.Show();
            Close();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTable1 employees = new EmployeesTable1("Storages");
            employees.Show();
            Close();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow1 orders = new OrdersWindow1("Storages");
            orders.Show();
            Close();
        }

        private void ScootersButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindow1 scooters = new ScootersWindow1("Storages");
            scooters.Show();
            Close();
        }

        private void StoragesButton_Click(object sender, RoutedEventArgs e)
        {
            StoragesWindow1 storages = new StoragesWindow1("Storages");
            storages.Show();
            Close();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }

        private void PaymentMethodsButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethods1 paymentMethods = new PaymentMethods1("Storages");
            paymentMethods.Show(); Close();
        }

        private void ScootersTypesButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindows1 scootertypes = new ScootersWindows1("Storages");
            scootertypes.Show(); Close();
        }

        private void OrdersScootersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersScooters1 orders = new OrdersScooters1("Storages");
            orders.Show(); Close();
        }

        private void ProvidersButton_Click(object sender, RoutedEventArgs e)
        {
            ProvidersWindow1 providers = new ProvidersWindow1("Storages");
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
            MessageBox.Show("Недостаточно прав");

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
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
                    NoAdmin adminWindowxaml = new NoAdmin("");
                    adminWindowxaml.Show();
                    Close();
                    break;
            }
        }
    }
}
