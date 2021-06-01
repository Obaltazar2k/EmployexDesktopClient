using Employex.Client;
using Employex.Utilities;
using Employex.Api;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPFCustomMessageBox;
using Employex.Model;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para AddLaboralExperience.xaml
    /// </summary>
    public partial class AddLaboralExperience : Page
    {
        private readonly List<string> sectorList = new List<string> { "AGRICULTURA, PLANTACIONES, U OTROS SECTORES RURALES", "ALIMENTACION, BEBIDAS, TABACO", "COMERCIO", "CONSTRUCCION", "EDUCACION", "FABRICACION DE MATERIAL DE TRANSPORTE",
        "FUNCION PUBLICA","HOTELERIA, RESTAURACIÓN, TURISMO", "INDUSTRIAS QUIMICAS", "INGENIERIA MECANICA Y ELECTICA", "MEDIOS DE COMUNICACION, CULTURA, GRAFICOS", "MINERIA", "PETROLEO Y PRODUCCION DE GASES, REFINACION DE PETROLEO",
        "PRODUCCION DE MATERIALES BASICOS", "SERVICIOS DE CORREO Y TELECOMUNICACIONES", "SERVICIOS DE SALUD", "SERVICIOS FINANCIEROS, SERVICIOS PROFESIONALES", "SERVICIOS PUBLICOS", "SILVICULTURA, MADERA, CELULOSA, PAPEL",
        "TEXTILES, VESTIDO, CUERO, CALZADO", "TRANSPORTE", "TRANSPORTE MARITIMO"};

        private readonly List<string> jobCategoryList = new List<string> {"CARPINTERO", "CERRAJERO",  "MECANICO", "OBRERO", "FONTANERO", "SOLDADOR", "ARTISTA", "SASTRE", "AGRIGULTOR", "COCINERO", "REPARTIDOR", "SEGURIDAD", "ESTILISTA",
        "EXTERMINADOR", "CAMARERO", "CONDUCTOR", "ELECTRICISTA", "FOTOGRAFO", "CASERO", "JARDINERO", "VENDEDOR", "DENTISTA", "ENFERMERO", "DOCTOR", "EMPRESARIO", "DEPORTISTA", "ADMINISTRADOR", "SECRETARIO", "SOLDADO", "CIENTIFICO", "PROFESOR",
        "POLICIA", "GERENTE", "BOMBERO", "INGENIERO", "ARQUITECTO", "PERIODISTA", "BIBLIOTECARIO", "ABOGADO", "OTRO"};

        public AddLaboralExperience()
        {
            InitializeComponent();
            SectorComboBox.ItemsSource = sectorList;
            JobTypeComboBox.ItemsSource = jobCategoryList;
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
                    
                    var response = laboralExperienceApi.AddLaboralExperienceWithHttpInfo(laboralExperience, "adrian@gmail.com");
                    CustomMessageBox.ShowOK("El usuario ha sido registrado con éxito.", "Registro exitoso", "Aceptar");
                    BackIcon_Clicked(new object(), new RoutedEventArgs());
                }
            }
            catch(ApiException ex)
            {
                if (ex.ErrorCode == 500)
                    CustomMessageBox.ShowOK("Error de conexión con la base de datos, intente mas tarde", "Usuario existente", "Aceptar");
            }
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

            switch (SectorComboBox.SelectedIndex)
            {
                case 0:
                    laboralExperience.Sector = Sector.AGRICULTURAPLANTACIONESUOTROSSECTORESRURALES;
                    break;

                case 1:
                    laboralExperience.Sector = Sector.ALIMENTACIONBEBIDASTABACO;
                    break;

                case 2:
                    laboralExperience.Sector = Sector.COMERCIO;
                    break;

                case 3:
                    laboralExperience.Sector = Sector.CONSTRUCCION;
                    break;

                case 4:
                    laboralExperience.Sector = Sector.EDUCIACION;
                    break;

                case 5:
                    laboralExperience.Sector = Sector.FABRICACIONDEMATERIALDETRANSPORTE;
                    break;

                case 6:
                    laboralExperience.Sector = Sector.FUNCIONPUBLICA;
                    break;

                case 7:
                    laboralExperience.Sector = Sector.HOTELERIARESTAURACINTURISMO;
                    break;

                case 8:
                    laboralExperience.Sector = Sector.INDUSTRIASQUIMICAS;
                    break;

                case 9:
                    laboralExperience.Sector = Sector.INGENIERIAMECANICAYELECTICA;
                    break;

                case 10:
                    laboralExperience.Sector = Sector.MEDIOSDECOMUNICACIONCULTURAGRAFICOS;
                    break;

                case 11:
                    laboralExperience.Sector = Sector.MINERIA;
                    break;

                case 12:
                    laboralExperience.Sector = Sector.PETROLEOYPRODUCCIONDEGASESREFINACIONDEPETROLEO;
                    break;

                case 13:
                    laboralExperience.Sector = Sector.PRODUCCIONDEMATERIALESBASICOS;
                    break;

                case 14:
                    laboralExperience.Sector = Sector.SERVICIOSDECORREOYTELECOMUNICACIONES;
                    break;

                case 15:
                    laboralExperience.Sector = Sector.SERVICIOSDESALUD;
                    break;

                case 16:
                    laboralExperience.Sector = Sector.SERVICIOSFINANCIEROSSERVICIOSPROFESIONALES;
                    break;

                case 17:
                    laboralExperience.Sector = Sector.SERVICIOSPUBLICOS;
                    break;

                case 18:
                    laboralExperience.Sector = Sector.SILVICULTURAMADERACELULOSAPAPEL;
                    break;

                case 19:
                    laboralExperience.Sector = Sector.TEXTILESVESTIDOCUEROCALZADO;
                    break;

                case 20:
                    laboralExperience.Sector = Sector.TRANSPORTE;
                    break;

                case 21:
                    laboralExperience.Sector = Sector.TRANSPORTEMARITIMO;
                    break;
            }

            switch (JobTypeComboBox.SelectedIndex)
            {
                case 0:
                    laboralExperience.JobCategory = JobCategory.CARPINTERO;
                    break;

                case 1:
                    laboralExperience.JobCategory = JobCategory.CERRAJERO;
                    break;

                case 2:
                    laboralExperience.JobCategory = JobCategory.MECANICO;
                    break;

                case 3:
                    laboralExperience.JobCategory = JobCategory.OBRERO;
                    break;

                case 4:
                    laboralExperience.JobCategory = JobCategory.FONTANERO;
                    break;

                case 5:
                    laboralExperience.JobCategory = JobCategory.SOLDADOR;
                    break;

                case 6:
                    laboralExperience.JobCategory = JobCategory.ARTISTA;
                    break;

                case 7:
                    laboralExperience.JobCategory = JobCategory.SASTRE;
                    break;

                case 8:
                    laboralExperience.JobCategory = JobCategory.AGRIGULTOR;
                    break;

                case 9:
                    laboralExperience.JobCategory = JobCategory.COCINERO;
                    break;

                case 10:
                    laboralExperience.JobCategory = JobCategory.REPARTIDOR;
                    break;

                case 11:
                    laboralExperience.JobCategory = JobCategory.SEGURIDAD;
                    break;

                case 12:
                    laboralExperience.JobCategory = JobCategory.ESTILISTA;
                    break;

                case 13:
                    laboralExperience.JobCategory = JobCategory.EXTERMINADOR;
                    break;

                case 14:
                    laboralExperience.JobCategory = JobCategory.CAMARERO;
                    break;

                case 15:
                    laboralExperience.JobCategory = JobCategory.CONDUCTOR;
                    break;

                case 16:
                    laboralExperience.JobCategory = JobCategory.ELECTRICISTA;
                    break;

                case 17:
                    laboralExperience.JobCategory = JobCategory.FOTOGRAFO;
                    break;

                case 18:
                    laboralExperience.JobCategory = JobCategory.CASERO;
                    break;

                case 19:
                    laboralExperience.JobCategory = JobCategory.JARDINERO;
                    break;

                case 20:
                    laboralExperience.JobCategory = JobCategory.VENDEDOR;
                    break;

                case 21:
                    laboralExperience.JobCategory = JobCategory.DENTISTA;
                    break;

                case 22:
                    laboralExperience.JobCategory = JobCategory.ENFERMERO;
                    break;

                case 23:
                    laboralExperience.JobCategory = JobCategory.DOCTOR;
                    break;

                case 24:
                    laboralExperience.JobCategory = JobCategory.EMPRESARIO;
                    break;

                case 25:
                    laboralExperience.JobCategory = JobCategory.DEPORTISTA;
                    break;

                case 26:
                    laboralExperience.JobCategory = JobCategory.ADMINISTRADOR;
                    break;

                case 27:
                    laboralExperience.JobCategory = JobCategory.SECRETARIO;
                    break;

                case 28:
                    laboralExperience.JobCategory = JobCategory.SOLDADO;
                    break;

                case 29:
                    laboralExperience.JobCategory = JobCategory.CIENTIFICO;
                    break;

                case 30:
                    laboralExperience.JobCategory = JobCategory.PROFESOR;
                    break;

                case 31:
                    laboralExperience.JobCategory = JobCategory.POLICIA;
                    break;

                case 32:
                    laboralExperience.JobCategory = JobCategory.GERENTE;
                    break;

                case 33:
                    laboralExperience.JobCategory = JobCategory.BOMBERO;
                    break;

                case 34:
                    laboralExperience.JobCategory = JobCategory.INGENIERO;
                    break;

                case 35:
                    laboralExperience.JobCategory = JobCategory.ARQUITECTO;
                    break;

                case 36:
                    laboralExperience.JobCategory = JobCategory.PERIODISTA;
                    break;

                case 37:
                    laboralExperience.JobCategory = JobCategory.BIBLIOTECARIO;
                    break;

                case 38:
                    laboralExperience.JobCategory = JobCategory.ABOGADO;
                    break;

                case 39:
                    laboralExperience.JobCategory = JobCategory.OTRO;
                    break;

            }

            return laboralExperience;
        }
    }
}
