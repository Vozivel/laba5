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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics.Eventing.Reader;

namespace laba5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        labaEntities content = new labaEntities();
        public string returnwindow = "Employees";
        private static string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                string sb = "";
                for (int i  = 0; i < hash.Length/4; i++)
                {
                    sb += hash[i].ToString("x2");
                }
                return sb;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Entry_Button_Click(object sender, RoutedEventArgs e)
        {
            var allogin = content.Employees.ToList();
            try
            {
                var var_i = allogin.Single(u => u.Employee_Name == Login_Box.Text);
                int i = Convert.ToInt32(var_i.ID_Employee);
                var var_j = allogin.Single(b => b.Password_Data == Hash(Password_Box.Password));
                int j = Convert.ToInt32(var_j.ID_Employee);
                if (i == j && i != -1)
                {
                    var string_log = allogin.Single(u => u.ID_Employee == i);
                    int roled_id = string_log.Role_ID;
                    string roled = content.Roles.Single(a => a.ID_Role == roled_id).Role_Name;
                    switch (roled)
                    {
                        case "Администратор":
                            AdminWindowxaml admin = new AdminWindowxaml("");
                            admin.Show();
                            Close();
                            break;
                        default:
                            NoAdmin noAdmin = new NoAdmin("");
                            noAdmin.Show();
                            Close();
                            break;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Неверные Данные Для Авторизации");
            }
            }
        }
    }

