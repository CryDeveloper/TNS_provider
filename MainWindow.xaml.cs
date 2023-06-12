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
using TNS__provider_.Pages;

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
    }
}
