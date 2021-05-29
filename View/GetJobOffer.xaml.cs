using System.Windows.Controls;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class GetJobOffer : UserControl
    {
        public GetJobOffer()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string getJobOfferJob { get; set; }
        public string getJobOfferUsername { get; set; }
        public string getJobOfferJobCategory { get; set; }
        public string getJobOfferDescription { get; set; }
        public string getJobOfferLocation { get; set; }
    }
}
