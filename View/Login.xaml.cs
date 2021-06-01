using System;
using System.Windows;
using System.Windows.Controls;
using Employex.Api;
using Employex.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using WPFCustomMessageBox;

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
            GeneralUserApi generalUserApi = new GeneralUserApi();
            try
            {
                var response = generalUserApi.LoginUser(UserTextBox.Text, PasswordTextBox.Password);
                Configuration.Default.AccessToken = response;
                Configuration.Default.Username = UserTextBox.Text;
                Configuration.Default.Password = PasswordTextBox.Password;
                NavigationService.Navigate(new IndependientProfileConsult());
                //var mainWindow = (MainWindow)Application.Current.MainWindow;
                //mainWindow?.ChangeView(new Home());
                return;
            } catch (ApiException ex)
            {
                if (ex.ErrorCode == 401)
                    CustomMessageBox.Show("Credenciales incorrectas");
            }
        }

        private void RegisterButton_Clicked(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AddLaboralExperience());
            return;
        }
    }
}
