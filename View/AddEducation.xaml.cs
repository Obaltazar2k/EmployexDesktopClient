using Employex.Api;
using Employex.Client;
using Employex.Model;
using Employex.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCustomMessageBox;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para AddEducation.xaml
    /// </summary>
    public partial class AddEducation : Page
    {
        public AddEducation()
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
                    EducationApi educationApi = new EducationApi();
                    var education = generateEducation();

                    var response = educationApi.AddEducationWithHttpInfo(education, "adrian@gmail.com");
                    CustomMessageBox.ShowOK("La información educativa se ha sido registrada con éxito.", "Registro exitoso", "Aceptar");
                    BackIcon_Clicked(new object(), new RoutedEventArgs());
                }
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 500)
                    CustomMessageBox.ShowOK("Error de conexión con la base de datos, intente mas tarde", "Error de conexión", "Aceptar");
            }
        }

        private Education generateEducation()
        {

            Education education = new Education(title: TitleTextBox.Text, university: UniversityNameTextBox.Text);
            education.StartDate = dpStartDate.SelectedDate;
            education.EndDate = dpEndDate.SelectedDate;
            education.Average = float.Parse(AverageTextBox.Text);
            education.Discipline = DisciplineTextBox.Text;
            education.Description = DescriptionTextBox.Text;

            return education;
        }

        private bool VerificateFields()
        {
            return FieldsVerificator.VerificateString(TitleTextBox.Text, "Titulo de experiencia")
                && FieldsVerificator.VerificateString(UniversityNameTextBox.Text, "Nombre de universidad")
                && FieldsVerificator.VerificateString(DisciplineTextBox.Text, "Disciplina")
                && FieldsVerificator.VerificatePromedio(AverageTextBox.Text)
                && FieldsVerificator.VerificateDate(dpStartDate.Text)
                && FieldsVerificator.VerificateDate(dpEndDate.Text);
        }
    }
}
