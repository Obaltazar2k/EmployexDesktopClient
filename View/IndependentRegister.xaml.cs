using Employex.Api;
using Employex.Client;
using Employex.Model;
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

        private void NextButton_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                IndependientUserApi independientUserApi = new IndependientUserApi();
                IndependientUser independientUser = new IndependientUser(name: NameTextBox.Text);
                User generalUser = new User(email: EmailTextBox.Text);

                //generalUser.Email = EmailTextBox.Text;
                generalUser.City = CityTextBox.Text;
                generalUser.Country = CountryTextBox.Text;
                generalUser.Password = PasswordTextBox.Password;

                //independientUser.Name = NameTextBox.Text;
                independientUser.Surnames = LastNameTextBox.Text;
                independientUser.Ocupation = OcupationTextBox.Text;
                independientUser.PersoanlDescription = GeneralDescripctionTextBox.Text;
                independientUser.User = generalUser;

                var response = independientUserApi.RegisterIndpendientUserWithHttpInfo(independientUser);
                MessageBox.Show("Ya estufas");
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 401)
                    MessageBox.Show("Ya existe un usuario con el correo " + EmailTextBox.Text);
            }           
        }
    }
}
