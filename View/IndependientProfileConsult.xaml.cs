using System.Windows;
using System.Windows.Controls;
using Employex.Api;
using Employex.Client;
using WPFCustomMessageBox;
using System.IO;
using System.Windows.Media.Imaging;
using System;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para ProfileConsult.xaml
    /// </summary>
    public partial class IndependientProfileConsult : Page
    {
        public IndependientProfileConsult()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GetProfileInfo("adrian@gmail.com");
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

            IndependientUserApi independientUserApi = new IndependientUserApi();
            try
            {
                var independientUser = independientUserApi.GetIndependintUserById(userID);
                Console.Write(independientUser.Name);
                NameTextBlock.Text = independientUser.Name + " " + independientUser.Surnames;
                OcupationTextBlock.Text = independientUser.Ocupation;
                LocationTextBlock.Text = independientUser.User.City + ", " + independientUser.User.Country;
                DescriptionTextBlock.Text = independientUser.PersoanlDescription;
                EmailTextBlock.Text = independientUser.User.Email;
                ShowProfileImage(independientUser.User.ProfilePhoto.File);
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
                perfilImage.ImageSource = BitmapFrame.Create(stream,
                                                  BitmapCreateOptions.None,
                                                  BitmapCacheOption.OnLoad);
            }
        }

        private void LaboralExperienceButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AddLaboralExperience());
            return;
        }
    }
}
