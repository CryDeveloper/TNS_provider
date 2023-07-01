using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;
using TNS__provider_.Classes;

namespace TNS__provider_.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        private DbTnsEntities _db = new DbTnsEntities();
        private DispatcherTimer dispatcher;
        //dispatcher = new DispatcherTimer();
        //dispatcher.Interval = new TimeSpan(0, 0, 1);
        //dispatcher.Tick += new EventHandler(TimerEnd);
        //dispatcher.Start();
        private string chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM[];',./{}:|<>?1234567890!@#$%^&*()_+=-";
        Random random = new Random();
        private string code;
        public Auth()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Метод таймера, возврающий сообщение о том, что время вышло.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerEnd(object sender, EventArgs e)
        {
            
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
            Password.IsEnabled = false;
            Code.Clear();
            ForCodePanel.IsEnabled = false;
            Entry.IsEnabled = false;
        }
        /// <summary>
        /// Идентификация пользователя при вводе номера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="k"></param>
        private void Number_KeyUp(object sender, KeyEventArgs k)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text != null && k.Key == Key.Enter)
            {
                GlobalData.AuthUser = _db.Employees.FirstOrDefault(x => x.Number == textBox.Text);
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

        /// <summary>
        /// Аутентификация по паролю.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="k"></param>
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

        /// <summary>
        /// Генерация кода для поля.
        /// </summary>
        private void GenerateCode()
        {
            Code.Clear();
            code =/* "1"*/new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            MessageBox.Show($"Запомните следующий код авторизации: {code}");
            /*я забыла код для таймера*/
        }

        /// <summary>
        /// Дейтсвие при нажатии enter в поле ввода кода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Code_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (code == Code.Text)
                {
                    /*отключение таймера*/
                    MessageBox.Show($"Ваша роль: {GlobalData.AuthUser.RolesEmployees.NameRole.ToLower()}");
                }
                else
                {
                    MessageBox.Show("Неверный код. Попробуйте еще раз, нажав на кнопку обновления возле кода.");
                }
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку "Вход".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Entry_Click(object sender, RoutedEventArgs e)
        {
            if(code == Code.Text)
            {
                /*откючение таймера*/
                MessageBox.Show($"Ваша роль: {GlobalData.AuthUser.RolesEmployees.NameRole.ToLower()}");
            }
            else
            {
                MessageBox.Show("Неверный код. Попробуйте еще раз, нажав на кнопку обновления возле кода.");
            }
        }

        /// <summary>
        /// Действия при нажатии на кнопку обнолвения кода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgUpdate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenerateCode();
        }
    }
}
