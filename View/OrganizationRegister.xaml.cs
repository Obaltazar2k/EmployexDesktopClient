using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPFCustomMessageBox;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para OrganizationRegister.xaml
    /// </summary>
    public partial class OrganizationRegister : Page
    {
        public OrganizationRegister()
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

        private void RegisterButton_Clicked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
