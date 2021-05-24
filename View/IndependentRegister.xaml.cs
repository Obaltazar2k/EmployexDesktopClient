using Employex.Api;
using Employex.Client;
using Employex.Model;
using Employex.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPFCustomMessageBox;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para IndependentRegister.xaml
    /// </summary>
    public partial class IndependentRegister : Page
    {
        public IndependentRegister()
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

        private void RegistButton_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (VerificateFields())
                {
                    IndependientUserApi independientUserApi = new IndependientUserApi();
                    IndependientUser independientUser = new IndependientUser(name: NameTextBox.Text);
                    User generalUser = new User(email: EmailTextBox.Text);

                    generalUser.City = CityTextBox.Text;
                    generalUser.Country = CountryTextBox.Text;
                    generalUser.Password = PasswordTextBox.Password;

                    independientUser.Surnames = LastNameTextBox.Text;
                    independientUser.Ocupation = OcupationTextBox.Text;
                    independientUser.PersoanlDescription = GeneralDescripctionTextBox.Text;
                    independientUser.User = generalUser;

                    var response = independientUserApi.RegisterIndpendientUserWithHttpInfo(independientUser);
                    CustomMessageBox.ShowOK("UEl usuario ha sido registrado con éxito.", "Registro exitoso", "Aceptar");
                    BackIcon_Clicked(new object(), new RoutedEventArgs());
                }               
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 400)
                    CustomMessageBox.ShowOK("Ya existe un usuario con el correo " + EmailTextBox.Text, "Usuario existente", "Aceptar");
            }           
        }

        private bool VerificateFields()
        {
            return FieldsVerificator.VerificateEmail(EmailTextBox.Text)
                && FieldsVerificator.VerificateName(NameTextBox.Text)
                && FieldsVerificator.VerificateName(LastNameTextBox.Text)
                && FieldsVerificator.VerificatePlace(CountryTextBox.Text)
                && FieldsVerificator.VerificatePlace(CityTextBox.Text)
                && FieldsVerificator.VerificateOcupation(OcupationTextBox.Text);
        }
    }
}
