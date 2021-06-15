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
                string response = generalUserApi.LoginUser(UserTextBox.Text, PasswordTextBox.Password);
                string[] res = response.Split('/');
                Configuration.Default.KindOf = res[0];
                Configuration.Default.AccessToken = res[1];
                Configuration.Default.Username = UserTextBox.Text;
                Configuration.Default.Password = PasswordTextBox.Password;
                if (res[0].Equals("IND"))
                    NavigationService.Navigate(new IndependientProfileConsult());
                else
                    NavigationService.Navigate(new Home(false));
                //var mainWindow = (MainWindow)Application.Current.MainWindow;
                //mainWindow?.ChangeView(new Home());
                return;
            } catch (ApiException ex)
            {
                if (ex.ErrorCode == 401)
                    CustomMessageBox.Show("Credenciales incorrectas");
                if (ex.ErrorCode == 423)
                {
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow?.ChangeView(new ValidateUser(UserTextBox.Text, ex.ErrorContent));
                    return;
                }
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
