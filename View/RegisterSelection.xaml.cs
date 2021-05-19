using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPFCustomMessageBox;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para RegisterSelection.xaml
    /// </summary>
    public partial class RegisterSelection : Page
    {
        public RegisterSelection()
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

        private void IndependientButton_Clicked(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new IndependentRegister());
            return;
        }

        private void OrganizationButton_Clicked(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new OrganizationRegister());
            return;
        }
    }
}
