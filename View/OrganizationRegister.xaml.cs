using Employex.Api;
using Employex.Utilities;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPFCustomMessageBox;
using Employex.Model;
using Employex.Client;
using System;
using System.Windows.Input;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para OrganizationRegister.xaml
    /// </summary>
    public partial class OrganizationRegister : Page
    {
        private readonly List<string> sectorList = new List<string> { "AGRICULTURA, PLANTACIONES, U OTROS SECTORES RURALES", "ALIMENTACION, BEBIDAS, TABACO", "COMERCIO", "CONSTRUCCION", "EDUCACION", "FABRICACION DE MATERIAL DE TRANSPORTE",
        "FUNCION PUBLICA","HOTELERIA, RESTAURACIÓN, TURISMO", "INDUSTRIAS QUIMICAS", "INGENIERIA MECANICA Y ELECTICA", "MEDIOS DE COMUNICACION, CULTURA, GRAFICOS", "MINERIA", "PETROLEO Y PRODUCCION DE GASES, REFINACION DE PETROLEO",
        "PRODUCCION DE MATERIALES BASICOS", "SERVICIOS DE CORREO Y TELECOMUNICACIONES", "SERVICIOS DE SALUD", "SERVICIOS FINANCIEROS, SERVICIOS PROFESIONALES", "SERVICIOS PUBLICOS", "SILVICULTURA, MADERA, CELULOSA, PAPEL", 
            "TEXTILES, VESTIDO, CUERO, CALZADO", "TRANSPORTE", "TRANSPORTE MARITIMO"};
        public OrganizationRegister()
        {
            InitializeComponent();
            SectorComboBox.ItemsSource = sectorList;
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
            try
            {
                if (VerificateFields())
                {
                    OrganizationUserApi organizationtUserApi = new OrganizationUserApi();
                    OrganizationUser organizationUser = new OrganizationUser(name: NameTextBox.Text, contactEmail: AgentEmailTextBox.Text);
                    User generalUser = new User(email: EmailTextBox.Text);

                    generalUser.City = CityTextBox.Text;
                    generalUser.Country = CountryTextBox.Text;
                    generalUser.Password = PasswordTextBox.Password;

                    organizationUser.About = DescripctionTextBox.Text;
                    organizationUser.ContactPhone = PhoneTextBox.Text;
                    organizationUser.ContactName = AgentTextBox.Text;
                    organizationUser.ZipCode = Convert.ToInt32(PostalCodeTextBox.Text);
                    organizationUser.WebSite = WebSiteTextBox.Text;
                    switch (SectorComboBox.SelectedIndex)
                    {
                        case 0:
                            organizationUser.WorkSector = Sector.AGRICULTURAPLANTACIONESUOTROSSECTORESRURALES;
                            break;

                        case 1:
                            organizationUser.WorkSector = Sector.ALIMENTACIONBEBIDASTABACO;
                            break;

                        case 2:
                            organizationUser.WorkSector = Sector.COMERCIO;
                            break;

                        case 3:
                            organizationUser.WorkSector = Sector.CONSTRUCCION;
                            break;

                        case 4:
                            organizationUser.WorkSector = Sector.EDUCIACION;
                            break;

                        case 5:
                            organizationUser.WorkSector = Sector.FABRICACIONDEMATERIALDETRANSPORTE;
                            break;

                        case 6:
                            organizationUser.WorkSector = Sector.FUNCIONPUBLICA;
                            break;

                        case 7:
                            organizationUser.WorkSector = Sector.HOTELERIARESTAURACINTURISMO;
                            break;

                        case 8:
                            organizationUser.WorkSector = Sector.INDUSTRIASQUIMICAS;
                            break;

                        case 9:
                            organizationUser.WorkSector = Sector.INGENIERIAMECANICAYELECTICA;
                            break;

                        case 10:
                            organizationUser.WorkSector = Sector.MEDIOSDECOMUNICACIONCULTURAGRAFICOS;
                            break;

                        case 11:
                            organizationUser.WorkSector = Sector.MINERIA;
                            break;

                        case 12:
                            organizationUser.WorkSector = Sector.PETROLEOYPRODUCCIONDEGASESREFINACIONDEPETROLEO;
                            break;

                        case 13:
                            organizationUser.WorkSector = Sector.PRODUCCIONDEMATERIALESBASICOS;
                            break;

                        case 14:
                            organizationUser.WorkSector = Sector.SERVICIOSDECORREOYTELECOMUNICACIONES;
                            break;

                        case 15:
                            organizationUser.WorkSector = Sector.SERVICIOSDESALUD;
                            break;

                        case 16:
                            organizationUser.WorkSector = Sector.SERVICIOSFINANCIEROSSERVICIOSPROFESIONALES;
                            break;

                        case 17:
                            organizationUser.WorkSector = Sector.SERVICIOSPUBLICOS;
                            break;

                        case 18:
                            organizationUser.WorkSector = Sector.SILVICULTURAMADERACELULOSAPAPEL;
                            break;

                        case 19:
                            organizationUser.WorkSector = Sector.TEXTILESVESTIDOCUEROCALZADO;
                            break;

                        case 20:
                            organizationUser.WorkSector = Sector.TRANSPORTE;
                            break;

                        case 21:
                            organizationUser.WorkSector = Sector.TRANSPORTEMARITIMO;
                            break;
                    }
                    organizationUser.User = generalUser;

                    var response = organizationtUserApi.RegisterOrganizationUserWithHttpInfo(organizationUser);
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

        private void NumbersTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private bool VerificateFields()
        {
            return FieldsVerificator.VerificateEmail(EmailTextBox.Text)
                && FieldsVerificator.VerificateEmail(AgentEmailTextBox.Text)
                && FieldsVerificator.VerificateName(AgentTextBox.Text)
                && FieldsVerificator.VerificateName(NameTextBox.Text)
                && FieldsVerificator.VerificatePlace(CountryTextBox.Text)
                && FieldsVerificator.VerificatePlace(CityTextBox.Text);
        }
    }
}
