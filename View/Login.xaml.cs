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
            ApiClient apiClient = new ApiClient();
            if (apiClient.LogIn(UserTextBox.Text, PasswordTextBox.Password)) {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new Home());
                return;
            }
        }

        private void RegisterButton_Clicked(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new RegisterSelection());
            return;
        }
    }
}
