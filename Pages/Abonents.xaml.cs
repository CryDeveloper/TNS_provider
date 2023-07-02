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

namespace TNS__provider_.Pages
{
    /// <summary>
    /// Логика взаимодействия для Abonents.xaml
    /// </summary>
    public partial class Abonents : Page
    {
        bool b;

        public Abonents()
        {
            InitializeComponent();
            dgSubscribers.ItemsSource = GlobalData.ConnectDB.Subscribers.ToList();
            cbActive.IsChecked = true;

            var a = GlobalData.ConnectDB.Contracts.ToList()[0];
            var b = GlobalData.ConnectDB.Subscribers.ToList()[0];
            var a1 = GlobalData.ConnectDB.Contracts.Where(x => x.IdSubscriber == b.Id).ToList();



        }

        void Filter()
        {
            List<Subscribers> subscribers = new List<Subscribers>();

            if ((bool)cbActive.IsChecked && (bool)cbNoActive.IsChecked)
            {
                subscribers = GlobalData.ConnectDB.Subscribers.ToList();
            }
            else if ((bool)cbActive.IsChecked && (bool)!cbNoActive.IsChecked)
            {
                subscribers = GlobalData.ConnectDB.Subscribers.Where(x => x.Contracts/*.FirstOrDefault(y => x.NumberSubscriber == x.NumberSubscriber)*/.TerminationDate == null).ToList();
            }
            else if ((bool)!cbActive.IsChecked && (bool)cbNoActive.IsChecked)
            {
                subscribers = GlobalData.ConnectDB.Subscribers.Where(x => x.Contracts/*.FirstOrDefault(y => x.NumberSubscriber == x.NumberSubscriber)*/.TerminationDate != null).ToList();
            }
            else
            {
                subscribers = new List<Subscribers>();
            }

            dgSubscribers.ItemsSource = subscribers;
            if (subscribers.Count == 0)
            {
                MessageBox.Show("Отсутствуют требования, удовлетворяющие результатам поиска");
            }
        }

        private void dgSubscribers_MouseDoubleClick(object sender, MouseButtonEventArgs e) // При двойном нажатие открывается страница с подробным описанием абонента
        {
            Subscribers subscriber = new Subscribers();
            foreach (Subscribers subscribers in dgSubscribers.SelectedItems)
            {
                subscriber = subscribers;
            }
            if (subscriber == null)
            {
                return;
            }
            else
            {
                NavigationService.Navigate(new PageAboutAbonent(subscriber));
            }
        }

        //private void tbSearchPersonalAccount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    if (!(Char.IsDigit(e.Text, 0)))
        //    {
        //        e.Handled = true;
        //    }
        //}
        private void cbActive_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void tbSearchSurname_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Filter();
        }

    }
}
