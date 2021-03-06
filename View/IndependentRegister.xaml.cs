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
        Stream myStream = null;
        public IndependentRegister()
        {
            InitializeComponent();
            string defaultAvatarImageUri = (Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Utilities\\Images\\defaultAvatar.jpg")));
            myStream = new FileStream(defaultAvatarImageUri, FileMode.Open, FileAccess.Read);
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
                    generalUser.Password = Encrypt.GetSHA256(PasswordTextBox.Password);
                                        
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

                    string fullName = independientUser.Name + " " + independientUser.Surnames;
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow?.ChangeView(new ValidateUser(independientUser.User.Email, fullName));
                    return;
                }               
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 401)
                    CustomMessageBox.ShowOK("Ya existe un usuario con el correo " + EmailTextBox.Text, "Usuario existente", "Aceptar");
                if (ex.ErrorCode == 500)
                {
                    CustomMessageBox.ShowOK("Ocurrió un error en la conexión con la base de datos. Por favor intentelo más tarde", "Error de conexión", "Aceptar");
                    Restarter.RestarEmployex();
                }                  
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
                Uri fileUri = new Uri(dialog.FileName);
                perfilImage.ImageSource = new BitmapImage(fileUri);
                myStream = dialog.OpenFile();
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
