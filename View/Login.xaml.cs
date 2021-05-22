using System.Windows;
using System.Windows.Controls;
using Employex.Api;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para NewLogin.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (TryToLogIn(UserTextBox.Text, PasswordTextBox.Password)) {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new Home());
                return;
            }
        }

        private bool TryToLogIn(string text, string password)
        {
            GeneralUserApi apiClient = new GeneralUserApi();
            if (apiClient.LogIn(text, password))
                return true;
            else
                return false;
        }

        private void RegisterButton_Clicked(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new RegisterSelection());
            return;
        }
    }
}
