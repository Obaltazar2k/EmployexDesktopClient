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
    /// Lógica de interacción para EditIndependientProfile.xaml
    /// </summary>
    public partial class EditIndependientProfile : Page
    {
        IndependientUser independientUser;
        OpenFileDialog dialog;
        Stream myStream = null;
        public EditIndependientProfile(IndependientUser independientProfile)
        {
            InitializeComponent();
            independientUser = independientProfile;
            fillTextBoxes();
        }

        private void BackIcon_Clicked(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                CustomMessageBox.ShowOK("No hay entrada a la cual volver.", "Error al navegar hacía atrás", "Aceptar");
        }

        private void UpdateButton_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VerificateFields())
                {
                    IndependientUserApi independientUserApi = new IndependientUserApi();

                    independientUser.Name = NameTextBox.Text;
                    independientUser.User.City = CityTextBox.Text;
                    independientUser.User.Country = CountryTextBox.Text;

                    if (myStream != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            myStream.CopyTo(ms);
                            byte[] imageFile = ms.ToArray();
                            independientUser.User.ProfilePhoto.File = imageFile;
                        }
                    }

                    independientUser.Surnames = LastNameTextBox.Text;
                    independientUser.Ocupation = OcupationTextBox.Text;
                    independientUser.PersoanlDescription = GeneralDescripctionTextBox.Text;

                    independientUserApi.PatchIndependintUserById(independientUser, independientUser.User.Email);
                    CustomMessageBox.ShowOK("Los datos se han actualizado con éxito.", "Actualización exitosa", "Aceptar");
                    BackIcon_Clicked(new object(), new RoutedEventArgs());
                }
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 500)
                {
                    CustomMessageBox.ShowOK("Ocurrió un error en la conexión con la base de datos. Por favor intentelo más tarde", "Error de conexión", "Aceptar");
                    Restarter.RestarEmployex();
                }
            }
        }

        private void fillTextBoxes()
        {
            EmailTextBox.Text = independientUser.User.Email;
            NameTextBox.Text = independientUser.Name;
            LastNameTextBox.Text = independientUser.Surnames;
            CityTextBox.Text = independientUser.User.City;
            CountryTextBox.Text = independientUser.User.Country;
            OcupationTextBox.Text = independientUser.Ocupation;
            GeneralDescripctionTextBox.Text = independientUser.PersoanlDescription;
            ShowProfileImage(independientUser.User.ProfilePhoto.File);
        }

        private void ShowProfileImage(byte[] image)
        {
            Image profileImage = new Image();
            using (MemoryStream stream = new MemoryStream(image))
            {
                perfilImage.ImageSource = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
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

            if (dialog.ShowDialog() == true)
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
