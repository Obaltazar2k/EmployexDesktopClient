using Employex.Api;
using Employex.Client;
using Employex.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
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

        public Home()
        {
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
            } 
            catch(ApiException ex)
            {
                if(ex.ErrorCode.Equals(404))
                    CustomMessageBox.Show("No hay más ofertas que mostrar");
            }
            finally
            {
                ValidateButtons();
                ScrollViewer.Visibility = Visibility.Visible;
                ProgressBar.Visibility = Visibility.Collapsed;
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
            PageTextBlock.Text = page.ToString();

            if (!jobOffersCollection.Count.Equals(10))
                NextPageButton.IsEnabled = false;
            else
                NextPageButton.IsEnabled = true;
        }
    }
}
