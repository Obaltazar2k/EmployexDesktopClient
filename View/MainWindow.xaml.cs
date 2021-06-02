using Employex.View;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace Employex
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();

        public MainWindow()
        {
            InitializeComponent();
            
            ITheme theme = _paletteHelper.GetTheme();
            theme.SetPrimaryColor(System.Windows.Media.Color.FromRgb(0, 74, 173));
            theme.SetSecondaryColor(System.Windows.Media.Color.FromRgb(230, 225, 225));
            _paletteHelper.SetTheme(theme);
            
            Application.Current.MainWindow = this;
            Loaded += OnMainWindowLoaded;
        }

        public void ChangeView(Page view)
        {
            FrameContent.NavigationService.Navigate(view);
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            ChangeView(new AddSection());
        }
    }
}
