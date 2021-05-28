using Employex.Api;
using Employex.Client;
using Employex.Client;
using Employex.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private ObservableCollection<JobOffer> jobOffersCollection;
        public Home()
        {
            InitializeComponent();
            try
            {
                GetJobOffers(1);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                    MessageBox.Show("No hay más ofertas de trabajo que mostrar");
            }
        }

        public void GetJobOffers(int page)
        {
            JobOfferApi jobOfferApi = new JobOfferApi();

            var jobOffersList = jobOfferApi.GetJobOffers(page);
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
    }
}
