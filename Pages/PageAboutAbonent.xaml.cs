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
using TNS__provider_.Model;

namespace TNS__provider_.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAboutAbonent.xaml
    /// </summary>
    public partial class PageAboutAbonent : Page
    {
        Subscribers subscriber;
        public PageAboutAbonent(Subscribers subscriber)
        {
            InitializeComponent();
            //MainGrid.DataContext = subscriber;


        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
