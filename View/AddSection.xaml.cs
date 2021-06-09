using Employex.Api;
using Employex.Client;
using Employex.Model;
using Employex.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WPFCustomMessageBox;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para AddSection.xaml
    /// </summary>
    public partial class AddSection : Page
    {
        OpenFileDialog dialog;
        List<Media> imagesList = new List<Media>();
        public AddSection()
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
                    SectionApi sectionApi = new SectionApi();
                    Section section = new Section(title: TitleTextBox.Text, description: DescriptionTextBox.Text, media: imagesList);
                    var user = Configuration.Default.Username;
                    sectionApi.AddSection(section, user);
                    CustomMessageBox.ShowOK("La sección de interés ha sido registrada con éxito.", "Registro exitoso", "Aceptar");
                    BackIcon_Clicked(new object(), new RoutedEventArgs());
                }              
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 500)
                    CustomMessageBox.ShowOK("Error de conexión con la base de datos, intente mas tarde", "Error de conexión", "Aceptar");
            }
        }

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            dialog = new OpenFileDialog
            {
                Filter = "Image files|*.png;*.jpg;*.jpeg",
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(dialog.FileName);
                if (image1.Source == null)
                {
                    ImageAddIcon.Visibility = Visibility.Collapsed;
                    image1.Source = new BitmapImage(fileUri);
                    image1.Visibility = Visibility.Visible;
                }
                else
                {
                    if (image2.Source == null)
                    {
                        image2.Source = new BitmapImage(fileUri);
                        image2.Visibility = Visibility.Visible;
                        AddImageButton.IsEnabled = false;
                    }
                }
            }

            Media image = new Media();
            Stream myStream = null;
            myStream = dialog.OpenFile();
            if (myStream != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    byte[] imageFile = ms.ToArray();
                    image.File = imageFile;
                    imagesList.Add(image);
                }
            }
        }

        private bool VerificateFields()
        {
            return FieldsVerificator.VerificateString(TitleTextBox.Text, "Titulo de sección");
        }
    }
}
