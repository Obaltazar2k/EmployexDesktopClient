using Employex.Client;
using Employex.Utilities;
using Employex.Api;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPFCustomMessageBox;
using Employex.Model;
using System;
using System.Linq;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para AddLaboralExperience.xaml
    /// </summary>
    public partial class AddLaboralExperience : Page
    {
        public AddLaboralExperience()
        {
            InitializeComponent();
            SectorComboBox.ItemsSource = Enum.GetValues(typeof(Sector)).Cast<Sector>();
            JobTypeComboBox.ItemsSource = Enum.GetValues(typeof(JobCategory)).Cast<JobCategory>();
        }

        private void BackIcon_Clicked(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                CustomMessageBox.ShowOK("No hay entrada a la cual volver.", "Error al navegar hacía atrás", "Aceptar");
        }

        private void RegistButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VerificateFields())
                {
                    LaboralExperienceApi laboralExperienceApi = new LaboralExperienceApi();
                    var laboralExperience = generateLaboralExperience();
                    var user = Configuration.Default.Username;
                    var response = laboralExperienceApi.AddLaboralExperienceWithHttpInfo(laboralExperience, user);
                    CustomMessageBox.ShowOK("La experiencia laboral ha sido registrado con éxito.", "Registro exitoso", "Aceptar");
                    BackIcon_Clicked(new object(), new RoutedEventArgs());
                }
            }
            catch(ApiException ex)
            {
                if (ex.ErrorCode == 500)
                    CustomMessageBox.ShowOK("Error de conexión con la base de datos, intente mas tarde", "Error de conexión", "Aceptar");
            }
        }     

        private LaboralExperience generateLaboralExperience()
        {
            bool currentJob = false;
            if(YesRadioButton.IsChecked == true)
            {
                currentJob = true;
            }

            LaboralExperience laboralExperience = new LaboralExperience(jobTitle: TitleTextBox.Text, currentJob: currentJob);
            laboralExperience.StartDate = dpStartDate.SelectedDate;
            laboralExperience.EndDate = dpEndDate.SelectedDate;
            laboralExperience.CompanyName = CorpNameTextBox.Text;
            laboralExperience.Location = CityTextBox.Text + ", " + CountryTextBox.Text;
            laboralExperience.Sector = (Sector)SectorComboBox.SelectedItem;
            laboralExperience.JobCategory = (JobCategory)SectorComboBox.SelectedItem;

            return laboralExperience;
        }

        private bool VerificateFields()
        {
            return FieldsVerificator.VerificateString(TitleTextBox.Text, "Titulo de experiencia")
                && FieldsVerificator.VerificateString(CorpNameTextBox.Text, "Nombre de empresa")
                && FieldsVerificator.VerificateString(CountryTextBox.Text, "País")
                && FieldsVerificator.VerificateString(CityTextBox.Text, "Ciudad")
                && FieldsVerificator.VerificateDate(dpStartDate.Text)
                && FieldsVerificator.VerificateDate(dpEndDate.Text);
        }
    }
}
