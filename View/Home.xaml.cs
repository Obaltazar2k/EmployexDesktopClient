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
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private ObservableCollection<JobOffer> jobOffersCollection;
        private int page { get; set; } = 1;
        public bool isIndependient { get; set; }

        public Home(bool isIndependient)
        {
            this.isIndependient = isIndependient;
            InitializeComponent();
        }

        private async void GetJobOffers(int page)
        {
            ProgressBar.Visibility = Visibility.Visible;
            ScrollViewer.Visibility = Visibility.Collapsed;

            JobOfferApi jobOfferApi = new JobOfferApi();
            try
            {
                var jobOffersList = await jobOfferApi.GetJobOffersAsync(page);
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

                ValidateButtons();
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

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Configuration.Default.AccessToken = null;
            Configuration.Default.Username = null;
            Configuration.Default.Password = null;
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Login());
            return;
        }

        private void PubishJobOfferButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new PublishJobOffer());
            return;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GetJobOffers(page);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                    MessageBox.Show("No hay más ofertas de trabajo que mostrar");
            }
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                page--;
                GetJobOffers(page);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                    MessageBox.Show("No hay más ofertas de trabajo que mostrar");
            }
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                page++;
                PageTextBlock.Text = page.ToString();
                GetJobOffers(page);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                    MessageBox.Show("No hay más ofertas de trabajo que mostrar");
            }
        }

        private void ValidateButtons()
        {
            if (page.Equals(1))
                PreviousPageButton.IsEnabled = false;
            else
                PreviousPageButton.IsEnabled = true;

            if (!jobOffersCollection.Count.Equals(10))
                NextPageButton.IsEnabled = false;
            else
                NextPageButton.IsEnabled = true;
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

        private void ButtonApply_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = JobOffersList.Items.IndexOf(item);
            var jobOffer = jobOffersCollection[index];

            try
            {
                AplicationsApi aplicationsApi = new AplicationsApi();
                aplicationsApi.AddAplicationToJobOffer(jobOffer.Username, jobOffer.JobOfferId);
                CustomMessageBox.Show("Se ha registrado tu oferta de trabajo");
            } 
            catch(ApiException ex)
            {
                if (ex.ErrorCode.Equals(406))
                    CustomMessageBox.Show("Esta oferta de trabajo es tuya");
                if (ex.ErrorCode.Equals(409))
                    CustomMessageBox.Show("Ya has aplicado en esta oferta de trabajo");
            }
        }

        private void ConsultProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (isIndependient)
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new IndependientProfileConsult());
                return;
            }
            else
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new OrganizationProfileConsult());
                return;
            }           
        }
    }
}
