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
    /// Lógica de interacción para EditOrganizationProfile.xaml
    /// </summary>
    public partial class EditOrganizationProfile : Page
    {
        OrganizationUser organizationUser;
        OpenFileDialog dialog;
        Stream myStream = null;
        public EditOrganizationProfile(OrganizationUser organizationProfile)
        {
            InitializeComponent();
            organizationUser = organizationProfile;
            SectorComboBox.ItemsSource = Enum.GetValues(typeof(Sector)).Cast<Sector>();
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
                    OrganizationUserApi organizationtUserApi = new OrganizationUserApi();

                    organizationUser.Name = NameTextBox.Text;
                    organizationUser.ContactEmail = AgentEmailTextBox.Text;
                    organizationUser.User.City = CityTextBox.Text;
                    organizationUser.User.Country = CountryTextBox.Text;

                    if (myStream != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            myStream.CopyTo(ms);
                            byte[] imageFile = ms.ToArray();
                            organizationUser.User.ProfilePhoto.File = imageFile;
                        }
                    }

                    organizationUser.ContactName = AgentTextBox.Text;
                    organizationUser.ContactPhone = PhoneTextBox.Text;
                    organizationUser.ZipCode = Convert.ToInt32(PostalCodeTextBox.Text);
                    organizationUser.WebSite = WebSiteTextBox.Text;
                    organizationUser.About = DescripctionTextBox.Text;
                    organizationUser.WorkSector = (Sector)SectorComboBox.SelectedItem;

                    organizationtUserApi.PatchOrganizationUserById(organizationUser, organizationUser.User.Email);
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
            EmailTextBox.Text = organizationUser.User.Email;
            NameTextBox.Text = organizationUser.Name;
            AgentTextBox.Text = organizationUser.ContactName;
            AgentEmailTextBox.Text = organizationUser.ContactEmail;
            PhoneTextBox.Text = organizationUser.ContactPhone;
            CityTextBox.Text = organizationUser.User.City;
            CountryTextBox.Text = organizationUser.User.Country;
            PostalCodeTextBox.Text = organizationUser.ZipCode.ToString();
            WebSiteTextBox.Text = organizationUser.WebSite;
            DescripctionTextBox.Text = organizationUser.About;
            int selectedSector = SectorComboBox.Items.IndexOf(organizationUser.WorkSector);
            SectorComboBox.SelectedIndex = selectedSector;
            ShowProfileImage(organizationUser.User.ProfilePhoto.File);
        }

        private void ShowProfileImage(byte[] image)
        {
            Image profileImage = new Image();
            using (MemoryStream stream = new MemoryStream(image))
            {
                perfilImage.ImageSource = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
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
            return FieldsVerificator.VerificateEmail(AgentEmailTextBox.Text)
                && FieldsVerificator.VerificateName(AgentTextBox.Text)
                && FieldsVerificator.VerificateName(NameTextBox.Text)
                && FieldsVerificator.VerificatePlace(CountryTextBox.Text)
                && FieldsVerificator.VerificatePlace(CityTextBox.Text);
        }
    }
}
