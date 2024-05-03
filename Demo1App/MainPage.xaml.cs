using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Demo1App
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Demo1Context Context = DbHelper.GetDemo1Context();

        private void LoadData()
        {
            var query = from application in Context.Applications
                        where (application.Id.ToString() + " " + application.Name + " " + application.Description).Contains(Search.Text)
                        orderby application.Id select new { application.Id, application.Name, application.Description, application.StartedTime, Type = application.DeviceTypeNavigation.Name, Status = application.StatusNavigation.Name };
            if (query.ToList().Count == 0)
            {
                MessageBox.Show("Ничего не найдено");
                return;
            }
            DataTable.ItemsSource = null;
            DataTable.ItemsSource = query.ToList();
                                // Context.Applications.ToList();
        }




        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void GoToQrBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.frame.Navigate(new QrPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (int) ((Button)sender).CommandParameter;
            var selectedApplication = (from application in Context.Applications
                              where application.Id == id select application).First();
            Context.Remove(selectedApplication);
            Context.SaveChanges();
            LoadData();
        }
    }
}
