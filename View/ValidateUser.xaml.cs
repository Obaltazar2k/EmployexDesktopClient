using System;
using System.Windows;
using System.Windows.Controls;
using Employex.Api;
using Employex.Client;
using WPFCustomMessageBox;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para ValidateUser.xaml
    /// </summary>
    public partial class ValidateUser : Page
    {
        string userEmail;
        string userFullName;

        public ValidateUser(string username, string fullName)
        {
            InitializeComponent();
            userEmail = username;
            InstructionsTextblock.Text = InstructionsTextblock.Text + userEmail;
            userFullName = fullName;
        }

        private void BackIcon_Clicked(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Login());
            return;
        }

        private void ValidateAccountButton_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.Write(userFullName);
                GeneralUserApi generalUserApi = new GeneralUserApi();
                generalUserApi.ValidateUser(userEmail, TokenTextBox.Text);
                CustomMessageBox.ShowOK("La cuenta ha sido verificada con éxito", "Verificación exitosa", "Aceptar");

                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new Login());
                return;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                    CustomMessageBox.ShowOK("El código que ha introducido no coincide con el código que le enviamos. " +
                        "Por favor, verifique que ha introducido el código correcto e intente nuevamente", "Código incorrecto", "Aceptar");
            }           
        }

        private void NewTokenButton_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                GeneralUserApi generalUserApi = new GeneralUserApi();
                generalUserApi.GenerateNewToken(userEmail, userFullName);
                CustomMessageBox.ShowOK("Se ha enviado un nuevo código de verificación", "Nuevo código", "Aceptar");
            }
            catch (ApiException ex)
            {

            }
        }
    }
}
