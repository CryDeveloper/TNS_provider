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
using TNS__provider_.Classes;
using TNS__provider_.Model;
using TNS__provider_.Pages;
using TNS__provider_.Properties;

namespace TNS__provider_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GlobalData.ActiveMainFrame = MainWindowFrame;
            cbUser.ItemsSource = GlobalData.ConnectDB.Employees.ToList();
            cbUser.SelectedIndex = 0;

            HeaderBlock.Text = "Абоненты ТНС";
            GlobalData.ActiveMainFrame.Navigate(new Abonents());
        }

        private void btnAbonent_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            HeaderBlock.Text = btn.Content.ToString()+ " ТНС";
            GlobalData.ActiveMainFrame.Navigate(new Abonents());
        }

        private void btnManageEqip_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            HeaderBlock.Text = btn.Content.ToString();
            GlobalData.ActiveMainFrame.Navigate(new Test());
        }

        private void btnActive_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            HeaderBlock.Text = btn.Content.ToString();
            GlobalData.ActiveMainFrame.Navigate(new Test());
        }

        private void btnBilling_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            HeaderBlock.Text = btn.Content.ToString();
            GlobalData.ActiveMainFrame.Navigate(new Test());
        }

        private void btnUserSupport_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            HeaderBlock.Text = btn.Content.ToString();
            GlobalData.ActiveMainFrame.Navigate(new Test());
        }

        private void btnCRM_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            HeaderBlock.Text = btn.Content.ToString();
            GlobalData.ActiveMainFrame.Navigate(new Test());
        }

        private void Menu_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuColumn.Width = new GridLength(150.0);
            BigMenu.Visibility = Visibility.Visible;
            LittleMenu.Visibility = Visibility.Collapsed;
        }

        private void Menu_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuColumn.Width = new GridLength(70.0);
            BigMenu.Visibility = Visibility.Collapsed;
            LittleMenu.Visibility = Visibility.Visible;
        }

        private void cbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employees employee = GlobalData.ConnectDB.Employees.FirstOrDefault(x => cbUser.SelectedIndex + 1 == x.Id);
            if(employee.Number.Contains("ID"))
            {
                ImageSourceConverter image = new ImageSourceConverter();
                try
                {
                    imgUser.ImageSource = (ImageSource)image.ConvertFromString("Resource/" + Convert.ToString(employee.Number) + ".jpg");
                }
                catch
                {
                    imgUser.ImageSource = (ImageSource)image.ConvertFromString("Resource/" + Convert.ToString(employee.Number) + ".png");
                }
            }
            else
            {
                imgUser.ImageSource = null;
            }

            var acces = GlobalData.ConnectDB.AccesToMenuItems.Where(x => x.RoleId == employee.RoleId).ToList();
            List<Button> collectionBtn = BigMenu.Children.OfType<Button>().ToList();
            List<Image> collectionImg = LittleMenu.Children.OfType<Image>().ToList();
            var a = collectionImg[0].Source.ToString().Contains("Лого");
            foreach (var item in acces)
            {
                Button button = collectionBtn.FirstOrDefault(x => (string)x.Content == item.MenuItems.Items);
                if(button!=null)
                {
                    button.Visibility = Visibility.Visible;
                }

                Image image = collectionImg.FirstOrDefault(x => x.Source.ToString().Contains(item.MenuItems.Items));
                if (image != null)
                {
                    image.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
