using Employex.Api;
using Employex.Client;
using Employex.Model;
using Employex.Utilities;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WPFCustomMessageBox;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para IndependentRegister.xaml
    /// </summary>
    public partial class IndependentRegister : Page
    {
        OpenFileDialog dialog;
        public IndependentRegister()
        {
            InitializeComponent();
        }

        private void BackIcon_Clicked(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                CustomMessageBox.ShowOK("No hay entrada a la cual volver.", "Error al navegar hacía atrás", "Aceptar");
        }

        private void RegistButton_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VerificateFields())
                {
                    IndependientUserApi independientUserApi = new IndependientUserApi();
                    IndependientUser independientUser = new IndependientUser(name: NameTextBox.Text);
                    User generalUser = new User(email: EmailTextBox.Text);
                    Media perfilImage = new Media();

                    generalUser.City = CityTextBox.Text;
                    generalUser.Country = CountryTextBox.Text;
                    generalUser.Password = PasswordTextBox.Password;
                    
                    Stream myStream = null;
                    myStream = dialog.OpenFile();
                    if (myStream != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            myStream.CopyTo(ms);
                            byte[] imageFile = ms.ToArray();
                            perfilImage.File = imageFile;
                            generalUser.ProfilePhoto = perfilImage;
                        }
                    }

                    independientUser.Surnames = LastNameTextBox.Text;
                    independientUser.Ocupation = OcupationTextBox.Text;
                    independientUser.PersoanlDescription = GeneralDescripctionTextBox.Text;
                    independientUser.User = generalUser;

                    var response = independientUserApi.RegisterIndpendientUserWithHttpInfo(independientUser);
                    CustomMessageBox.ShowOK("El usuario ha sido registrado con éxito.", "Registro exitoso", "Aceptar");
                    //BackIcon_Clicked(new object(), new RoutedEventArgs());
                }               
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 400)
                    CustomMessageBox.ShowOK("Ya existe un usuario con el correo " + EmailTextBox.Text, "Usuario existente", "Aceptar");
            }           
        }

        private void SelectImageButton_Clicked(object sender, RoutedEventArgs e)
        {
            dialog = new OpenFileDialog();
            dialog = new OpenFileDialog
            {
                Filter = "Image files|*.png;*.jpg;*.jpeg",
                FilterIndex = 1
            };

            if(dialog.ShowDialog() == true)
            {
                ImageAddIcon.Visibility = Visibility.Hidden;
                Uri fileUri = new Uri(dialog.FileName);
                perfilImage.Source = new BitmapImage(fileUri);
            }
        }

        private bool VerificateFields()
        {
            return FieldsVerificator.VerificateEmail(EmailTextBox.Text)
                && FieldsVerificator.VerificateName(NameTextBox.Text)
                && FieldsVerificator.VerificateName(LastNameTextBox.Text)
                && FieldsVerificator.VerificatePlace(CountryTextBox.Text)
                && FieldsVerificator.VerificatePlace(CityTextBox.Text)
                && FieldsVerificator.VerificateOcupation(OcupationTextBox.Text);
        }
    }
}
