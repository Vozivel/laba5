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
    /// Логика взаимодействия для ScootersWindow.xaml
    /// </summary>
    public partial class ScootersWindow : Window
    {
        labaEntities labaEntities = new labaEntities();
        public string ret;
        public ScootersWindow(string returnwindow)
        {
            ret = returnwindow;
            InitializeComponent();
            MyDataGrid.ItemsSource = labaEntities.Scooters.ToList();
            Box3.ItemsSource = labaEntities.Scooters_Types.ToList();
            Box3.DisplayMemberPath = "Scooter_Type_Name";
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void PostsButton_Click(object sender, RoutedEventArgs e)
        {
            Post posts = new Post("Scooters");
            posts.Show();
            Close();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTable employees = new EmployeesTable("Scooters");
            employees.Show();
            Close();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow orders = new OrdersWindow("Scooters");
            orders.Show();
            Close();
        }

        private void ScootersButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindow scooters = new ScootersWindow("Scooters");
            scooters.Show();
            Close();
        }

        private void StoragesButton_Click(object sender, RoutedEventArgs e)
        {
            StoragesWindow storages = new StoragesWindow("Scooters");
            storages.Show();
            Close();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            RolesWindow roles = new RolesWindow("Scooters");
            roles.Show(); Close();
        }

        private void PaymentMethodsButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentMethods paymentMethods = new PaymentMethods("Scooters");
            paymentMethods.Show(); Close();
        }

        private void ScootersTypesButton_Click(object sender, RoutedEventArgs e)
        {
            ScootersWindows scootertypes = new ScootersWindows("Scooters");
            scootertypes.Show(); Close();
        }

        private void OrdersScootersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersScooters orders = new OrdersScooters("Scooters");
            orders.Show(); Close();
        }

        private void ProvidersButton_Click(object sender, RoutedEventArgs e)
        {
            ProvidersWindow providers = new ProvidersWindow("Scooters");
            providers.Show(); Close();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyDataGrid.SelectedItem != null)
            {
                var select = MyDataGrid.SelectedItem as Scooters;
                if (select != null)
                {
                    Box1.Text = Convert.ToString(select.Scooter_Name);
                    Box2.Text = Convert.ToString(select.Scooter_Cost);
                    Box3.Text = Convert.ToString(labaEntities.Scooters_Types.Single(a => a.ID_Type == select.Scooter_Type_ID).Scooter_Type_Name);
                }

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Scooters c = new Scooters();
                c.Scooter_Name = Box1.Text;
                c.Scooter_Cost = Convert.ToInt32(Box2.Text);
                c.Scooter_Type_ID = labaEntities.Scooters_Types.Single(a=>a.Scooter_Type_Name==Box3.Text).ID_Type;
                labaEntities.Scooters.Add(c);
                labaEntities.SaveChanges();
                MyDataGrid.ItemsSource = labaEntities.Scooters.ToList();
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
                    var select = MyDataGrid.SelectedItem as Scooters;
                    select.Scooter_Name = Box1.Text;
                    select.Scooter_Cost = Convert.ToInt32(Box2.Text);
                    select.Scooter_Type_ID = labaEntities.Scooters_Types.Single(a => a.Scooter_Type_Name == Box3.Text).ID_Type;
                    labaEntities.SaveChanges();
                    MyDataGrid.ItemsSource = labaEntities.Scooters.ToList();
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
                    labaEntities.Scooters.Remove(MyDataGrid.SelectedItem as Scooters);
                    labaEntities.SaveChanges();
                    MyDataGrid.ItemsSource = labaEntities.Scooters.ToList();
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
