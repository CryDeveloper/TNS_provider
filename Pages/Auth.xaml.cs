using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using TNS__provider_.Classes;

namespace TNS__provider_.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        List<Users> Users = new List<Users>();
        private Timer _timer = null;
        private string chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM[];',./{}:|<>?1234567890!@#$%^&*()_+=-";
        Random random = new Random();
        private string code;
        public Auth()
        {
            Users user = new Users();
            user.Number = "1";
            user.Password = "1";
            Users.Add(user);
            InitializeComponent();
        }
        /// <summary>
        /// Очистка всех полей на форме авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Number.Clear();
            Password.Clear();
            Code.Clear();
        }
        private void Number_KeyUp(object sender, KeyEventArgs k)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text != null && k.Key == Key.Enter)
            {
                GlobalData.AuthUser = Users.FirstOrDefault(x => x.Number == textBox.Text);
                if (GlobalData.AuthUser != null)
                {
                    Password.IsEnabled = true;
                    Password.Focus();
                }
                else
                {
                    MessageBox.Show("Нет сотрудника с таким номером. Проверьте введенные данные.");
                }
            }
        }

        private void Password_KeyUp(object sender, KeyEventArgs k)
        {
            TextBox textBox = sender as TextBox;
            if (Password.Text != null && k.Key == Key.Enter)
            {
                if(GlobalData.AuthUser.Password == textBox.Text)
                {
                    GenerateCode();
                    ForCodePanel.IsEnabled = true;
                    Code.Focus();
                    Entry.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Неверный пароль.");
                }
            }
        }

        private void GenerateCode()
        {
            Code.Clear();
            code = "1"/*new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray())*/;
            MessageBox.Show($"Запомните следующий код регистрации: {code}");
            /*я забыла код для таймера*/
        }

        private void Code_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (code == Code.Text)
                {
                    /*отключение таймера*/
                    MessageBox.Show("Вы зашли как (роль пользователя)");
                }
                else
                {
                    MessageBox.Show("Неверный код. Попробуйте еще раз, нажав на кнопку обновления возле кода.");
                }
            }
        }

        private void Entry_Click(object sender, RoutedEventArgs e)
        {
            if(code == Code.Text)
            {
                /*откючение таймера*/
                MessageBox.Show("Вы зашли как (роль пользователя)");
            }
            else
            {
                MessageBox.Show("Неверный код. Попробуйте еще раз, нажав на кнопку обновления возле кода.");
            }
        }

        private void UpdateCode_Click(object sender, RoutedEventArgs e)
        {
            GenerateCode();
        }


    }
}
