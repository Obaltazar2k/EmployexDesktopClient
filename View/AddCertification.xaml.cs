using Employex.Api;
using Employex.Client;
using Employex.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPFCustomMessageBox;
using Employex.Model;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para AddCertification.xaml
    /// </summary>
    public partial class AddCertification : Page
    {
        public AddCertification()
        {
            InitializeComponent();
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
                    CertificationApi certificationApi = new CertificationApi();
                    Certification certification = new Certification(credentialUrl: UrlTextBox.Text, issuingCompany: CorpNameTextBox.Text,
                        expirationDate: dpEndDate.SelectedDate, expeditionDate: dpStartDate.SelectedDate, title: TitleTextBox.Text);
                    var user = Configuration.Default.Username;
                    certificationApi.AddCertification(certification, user);
                    CustomMessageBox.ShowOK("La certificación ha sido registrada con éxito.", "Registro exitoso", "Aceptar");
                    BackIcon_Clicked(new object(), new RoutedEventArgs());
                }
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 500)
                    CustomMessageBox.ShowOK("Error de conexión con la base de datos, intente mas tarde", "Error de conexión", "Aceptar");
            }
        }

        private bool VerificateFields()
        {
            return FieldsVerificator.VerificateDate(dpStartDate.Text)
            && FieldsVerificator.VerificateDate(dpEndDate.Text);
        }
    }
}
