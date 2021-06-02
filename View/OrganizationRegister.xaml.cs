using Employex.Api;
using Employex.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPFCustomMessageBox;
using Employex.Model;
using Employex.Client;
using System;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using System.Linq;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para OrganizationRegister.xaml
    /// </summary>
    public partial class OrganizationRegister : Page
    {
        OpenFileDialog dialog;
        Stream myStream = null;
        public OrganizationRegister()
        {
            InitializeComponent();
            SectorComboBox.ItemsSource = Enum.GetValues(typeof(Sector)).Cast<Sector>();
            string defaultAvatarImageUri = (Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Utilities\\Images\\defaultOrganizationAvatar.png")));
            myStream = new FileStream(defaultAvatarImageUri, FileMode.Open, FileAccess.Read);
        }

        private void BackIcon_Clicked(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                CustomMessageBox.ShowOK("No hay entrada a la cual volver.", "Error al navegar hacía atrás", "Aceptar");
        }

        private void RegisterButton_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VerificateFields())
                {
                    OrganizationUserApi organizationtUserApi = new OrganizationUserApi();
                    OrganizationUser organizationUser = new OrganizationUser(name: NameTextBox.Text, contactEmail: AgentEmailTextBox.Text);
                    User generalUser = new User(email: EmailTextBox.Text);
                    Media perfilImage = new Media();

                    generalUser.City = CityTextBox.Text;
                    generalUser.Country = CountryTextBox.Text;
                    generalUser.Password = PasswordTextBox.Password;

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

                    organizationUser.About = DescripctionTextBox.Text;
                    organizationUser.ContactPhone = PhoneTextBox.Text;
                    organizationUser.ContactName = AgentTextBox.Text;
                    organizationUser.ZipCode = Convert.ToInt32(PostalCodeTextBox.Text);
                    organizationUser.WebSite = WebSiteTextBox.Text;
                    organizationUser.WorkSector = (Sector)SectorComboBox.SelectedItem;
                    organizationUser.User = generalUser;

                    var response = organizationtUserApi.RegisterOrganizationUserWithHttpInfo(organizationUser);
                    CustomMessageBox.ShowOK("El usuario ha sido registrado con éxito.", "Registro exitoso", "Aceptar");
                    BackIcon_Clicked(new object(), new RoutedEventArgs());
                }
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 400)
                    CustomMessageBox.ShowOK("Ya existe un usuario con el correo " + EmailTextBox.Text, "Usuario existente", "Aceptar");
            }
        }

        private void NumbersTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
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
                && FieldsVerificator.VerificateEmail(AgentEmailTextBox.Text)
                && FieldsVerificator.VerificateName(AgentTextBox.Text)
                && FieldsVerificator.VerificateName(NameTextBox.Text)
                && FieldsVerificator.VerificatePlace(CountryTextBox.Text)
                && FieldsVerificator.VerificatePlace(CityTextBox.Text);
        }
    }
}
