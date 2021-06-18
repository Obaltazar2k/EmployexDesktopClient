using Employex.Api;
using Employex.Client;
using Employex.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WPFCustomMessageBox;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para OrganizationProfileConsult.xaml
    /// </summary>
    public partial class OrganizationProfileConsult : Page
    {
        private readonly string user;
        OrganizationUser organizationUser;
        public OrganizationProfileConsult()
        {
            InitializeComponent();
            user = Configuration.Default.Username;
        }

        public OrganizationProfileConsult(string userEmail)
        {
            InitializeComponent();
            user = userEmail;
            ManageProfileButton.Visibility = Visibility.Collapsed;
        }

        private void BackIcon_Clicked(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                CustomMessageBox.ShowOK("No hay entrada a la cual volver.", "Error al navegar hacía atrás", "Aceptar");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GetProfileInfo(user);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                    MessageBox.Show("No hay más ofertas de trabajo que mostrar");
            }
        }

        private void GetProfileInfo(string userID)
        {
            ProgressBar.Visibility = Visibility.Visible;
            ProfileScrollViewer.Visibility = Visibility.Collapsed;

            OrganizationUserApi organizationUserApi = new OrganizationUserApi();
            try
            {
                organizationUser = organizationUserApi.GetOrganizationUserById(userID);
                NameTextBlock.Text = organizationUser.Name;
                SectorTextBlock.Text = "Sector: " + organizationUser.WorkSector.ToString().ToLowerInvariant();
                EmailTextBlock.Text = organizationUser.User.Email;
                WebSiteTextBlock.Text = organizationUser.WebSite;
                ContactNameTextBlock.Text = organizationUser.ContactName;
                ContactEmailTextBlock.Text = organizationUser.ContactEmail;
                ContactNumberTextBlock.Text = organizationUser.ContactPhone;
                DescriptionTextBlock.Text = organizationUser.About;
                LocationTextBlock.Text = organizationUser.User.City + ", " + organizationUser.User.Country + " CP: " + organizationUser.ZipCode.ToString();
                if (organizationUser.User.ProfilePhoto != null)
                    ShowProfileImage(organizationUser.User.ProfilePhoto.File);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode.Equals(404))
                    CustomMessageBox.Show("No hay más ofertas que mostrar");
            }
            finally
            {
                ProfileScrollViewer.Visibility = Visibility.Visible;
                ProgressBar.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowProfileImage(byte[] image)
        {
            Image profileImage = new Image();
            using (MemoryStream stream = new MemoryStream(image))
            {
                perfilImage.ImageSource = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new EditOrganizationProfile(organizationUser));
            return;
        }
    }
}
