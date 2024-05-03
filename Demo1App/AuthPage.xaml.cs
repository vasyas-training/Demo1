using Database;
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

namespace Demo1App
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Demo1Context DbContext = DbHelper.GetDemo1Context();
        public AuthPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var password = Password.Password;
            var isCorrect =  DbContext.Employees.Any(a => a.Login == login && a.Password == password);
            if (!isCorrect )
            {
                MessageBox.Show("Логин или пароль не верны");
                return;
            }
            NavigationManager.frame.Navigate(new MainPage());
        }
    }
}
