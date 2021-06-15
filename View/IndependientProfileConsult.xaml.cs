using System.Windows;
using System.Windows.Controls;
using Employex.Api;
using Employex.Client;
using WPFCustomMessageBox;
using System.IO;
using System.Windows.Media.Imaging;
using System;
using Employex.Model;
using System.Collections.ObjectModel;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para ProfileConsult.xaml
    /// </summary>
    public partial class IndependientProfileConsult : Page
    {
        private ObservableCollection<LaboralExperience> laboralExperiencesCollection;
        private ObservableCollection<Education> educationsCollection;
        private ObservableCollection<Certification> certificationCollection;
        private ObservableCollection<Section> sectionsCollection;
        private readonly string user;
        public IndependientProfileConsult()
        {
            InitializeComponent();
            user = Configuration.Default.Username;
        }

        public IndependientProfileConsult(string userEmail)
        {
            InitializeComponent();
            user = userEmail;
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

        private void BackIcon_Clicked(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                CustomMessageBox.ShowOK("No hay entrada a la cual volver.", "Error al navegar hacía atrás", "Aceptar");
        }

        private void GetProfileInfo(string userID)
        {
            ProgressBar.Visibility = Visibility.Visible;
            ProfileScrollViewer.Visibility = Visibility.Collapsed;

            IndependientUserApi independientUserApi = new IndependientUserApi();
            try
            {
                var independientUser = independientUserApi.GetIndependintUserById(userID);
                NameTextBlock.Text = independientUser.Name + " " + independientUser.Surnames;
                OcupationTextBlock.Text = independientUser.Ocupation;
                LocationTextBlock.Text = independientUser.User.City + ", " + independientUser.User.Country;
                DescriptionTextBlock.Text = independientUser.PersoanlDescription;
                EmailTextBlock.Text = independientUser.User.Email;
                if (independientUser.User.ProfilePhoto != null)
                    ShowProfileImage(independientUser.User.ProfilePhoto.File);
                ShowLaboralExperienceInfo(independientUser);
                ShowEducationInfo(independientUser);
                ShowCertifications(independientUser);
                ShowSections(independientUser);
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

        private void ShowLaboralExperienceInfo(IndependientUser independientUser)
        {
            var laboralExperiencesList = independientUser.LaboralExperience;
            laboralExperiencesCollection = new ObservableCollection<LaboralExperience>();
            if (laboralExperiencesList != null)
            {              
                foreach (LaboralExperience jobOffer in laboralExperiencesList)
                {
                    if (jobOffer != null)
                        laboralExperiencesCollection.Add(jobOffer);
                }
                laboralExperienceList.ItemsSource = laboralExperiencesCollection;
                DataContext = laboralExperiencesCollection;
                laboralExperiencePanel.Visibility = Visibility.Visible;
            }           
        }

        private void ShowEducationInfo(IndependientUser independientUser)
        {
            var educationsList = independientUser.Education;
            educationsCollection = new ObservableCollection<Education>();
            if (educationsList != null)
            {               
                foreach (Education education in educationsList)
                {
                    if (education != null)
                        educationsCollection.Add(education);
                }
                educationList.ItemsSource = educationsCollection;
                DataContext = educationsCollection;
                educationPanel.Visibility = Visibility.Visible;
            }           
        }

        private void ShowCertifications(IndependientUser independientUser)
        {
            var certificationsList = independientUser.Certification;
            certificationCollection = new ObservableCollection<Certification>();
            if (certificationsList != null)
            {
                foreach (Certification certification in certificationsList)
                {
                    if (certification != null)
                        certificationCollection.Add(certification);
                }
                certificationList.ItemsSource = certificationCollection;
                DataContext = certificationCollection;
                certificationPanel.Visibility = Visibility.Visible;
            }
        }

        private void ShowSections(IndependientUser independientUser)
        {
            var sectionsList = independientUser.Section;
            sectionsCollection = new ObservableCollection<Section>();
            if (sectionsList != null)
            {
                foreach (Section section in sectionsList)
                {
                    if (section != null)
                        sectionsCollection.Add(section);
                }
                sectionList.ItemsSource = sectionsCollection;
                DataContext = sectionsCollection;
                sectionPanel.Visibility = Visibility.Visible;
            }
        }

        private void LaboralExperienceButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AddLaboralExperience());
            return;
        }

        private void EducationButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AddEducation());
            return;
        }

        private void SectionButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AddSection());
            return;
        }

        private void CertificationButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AddCertification());
            return;
        }       
    }
}
