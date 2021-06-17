using Employex.Api;
using Employex.Client;
using Employex.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFCustomMessageBox;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para ApplicantsConsult.xaml
    /// </summary>
    public partial class ApplicantsConsult : Page
    {
        private ObservableCollection<Aplication> applicantsCollection;
        string username;
        int jobOfferId;
        public ApplicantsConsult(string userID, int jobOfferID)
        {
            InitializeComponent();
            username = userID;
            jobOfferId = jobOfferID;
            GetApplicants();
        }

        private void BackIcon_Clicked(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                CustomMessageBox.ShowOK("No hay entrada a la cual volver.", "Error al navegar hacía atrás", "Aceptar");
        }

        private async void GetApplicants()
        {
            ProgressBar.Visibility = Visibility.Visible;
            ScrollViewer.Visibility = Visibility.Collapsed;

            JobOfferApi jobOfferApi = new JobOfferApi();
            try
            {
                var aplicationsList = await jobOfferApi.GetJobOffersAplicationsAsync(Configuration.Default.Username, jobOfferId);
                applicantsCollection = new ObservableCollection<Aplication>();
                if (aplicationsList != null)
                {
                    foreach (Aplication aplicant in aplicationsList)
                    {
                        if (aplicant != null)
                            applicantsCollection.Add(aplicant);
                    }
                }
                ApplicantsList.ItemsSource = applicantsCollection;
                DataContext = applicantsCollection;

                ScrollViewer.Visibility = Visibility.Visible;
                ScrollViewer.ScrollToTop();
                ProgressBar.Visibility = Visibility.Collapsed;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode.Equals(404))
                    CustomMessageBox.Show("No hay más ofertas que mostrar");
            }
        }

        private void UserTextBlock_Click(object sender, RoutedEventArgs e)
        {
            string userEmail;
            Button botonActual = (Button)sender;
            userEmail = botonActual.Content.ToString();
            try
            {
                OrganizationUserApi organizationUserApi = new OrganizationUserApi();
                var profileConsult = organizationUserApi.GetOrganizationUserById(userEmail);

                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new OrganizationProfileConsult(userEmail));
                return;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode.Equals(404))
                {
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow?.ChangeView(new IndependientProfileConsult(userEmail));
                    return;
                }
            }
        }

        private void AproveButtonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RejectButtonButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
