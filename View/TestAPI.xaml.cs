using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Employex.Model;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para TestAPI.xaml
    /// </summary>
    public partial class TestAPI : Page
    {
        public TestAPI()
        {
            InitializeComponent();
        }

        private void GetButton_Clicked(object sender, RoutedEventArgs e)
        {
            ApiClient apiClient = new ApiClient();
            JobOffer jobOffer = apiClient.GetFirstJobOffer();
            /*
            JobOfferIdTextBox.Text = jobOffer.job_offer_id;
            JobTextBox.Text = jobOffer.job;
            DescriptionTextBox.Text = jobOffer.description;
            JobCategoryTextBox.Text = jobOffer.job_category;
            LocationTextBox.Text = jobOffer.location;
            */
        }
    }
}
