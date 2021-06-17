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
    /// Lógica de interacción para PublishedJobOffers.xaml
    /// </summary>
    public partial class PublishedJobOffers : Page
    {
        private ObservableCollection<JobOffer> jobOffersCollection;
        public PublishedJobOffers()
        {
            InitializeComponent();
            GetJobOffers();
        }

        private void BackIcon_Clicked(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                CustomMessageBox.ShowOK("No hay entrada a la cual volver.", "Error al navegar hacía atrás", "Aceptar");
        }

        private async void GetJobOffers()
        {
            ProgressBar.Visibility = Visibility.Visible;
            ScrollViewer.Visibility = Visibility.Collapsed;

            JobOfferApi jobOfferApi = new JobOfferApi();
            try
            {
                var jobOffersList = await jobOfferApi.GetJobOffersPublishedByTheUserAsync(Configuration.Default.Username);
                jobOffersCollection = new ObservableCollection<JobOffer>();
                if (jobOffersList != null)
                {
                    foreach (JobOffer jobOffer in jobOffersList)
                    {
                        if (jobOffer != null)
                            jobOffersCollection.Add(jobOffer);
                    }
                }
                JobOffersList.ItemsSource = jobOffersCollection;
                DataContext = jobOffersCollection;

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

        private void ManageApplicantsButton_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = JobOffersList.Items.IndexOf(item);
            var jobOffer = jobOffersCollection[index];

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ApplicantsConsult(jobOffer.Username, jobOffer.JobOfferId));
            return;
        }
    }
}
