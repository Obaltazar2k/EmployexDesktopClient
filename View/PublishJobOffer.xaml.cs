using Employex.Api;
using Employex.Client;
using Employex.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WPFCustomMessageBox;

namespace Employex.View
{
    /// <summary>
    /// Lógica de interacción para PublishJobOffer.xaml
    /// </summary>
    public partial class PublishJobOffer : Page
    {
        OpenFileDialog dialog;
        List<Media> imagesList = new List<Media>();

        public PublishJobOffer()
        {
            InitializeComponent();
            FullCombobox();
        }

        private void FullCombobox()
        {
            JobCategoryCombobox.ItemsSource = Enum.GetValues(typeof(JobCategory)).Cast<JobCategory>();
        }

        private void PublishButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JobOfferApi jobOfferApi = new JobOfferApi();

                JobOffer jobOffer = new JobOffer(job: JobTextBox.Text, description: DescriptionTextBox.Text, jobCategory: (JobCategory)JobCategoryCombobox.SelectedItem, media: imagesList);
                jobOfferApi.AddJobOffer(jobOffer);
                CustomMessageBox.ShowOK("La oferta de trabajo ha sido publicada con éxito.", "Publicación exitosa", "Aceptar");
                BackIcon_Clicked(new object(),new RoutedEventArgs());
            
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 400) { }
                    //CustomMessageBox.ShowOK("Ya existe un usuario con el correo " + EmailTextBox.Text, "Usuario existente", "Aceptar");
            }
        }

        private void BackIcon_Clicked(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                CustomMessageBox.ShowOK("No hay entrada a la cual volver.", "Error al navegar hacía atrás", "Aceptar");
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
                    if(image2.Source == null)
                    {
                        image2.Source = new BitmapImage(fileUri);
                        image2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        if (image3.Source == null)
                        {
                            image3.Source = new BitmapImage(fileUri);
                            image3.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            image4.Source = new BitmapImage(fileUri);
                            image4.Visibility = Visibility.Visible;
                            AddImageButton.IsEnabled = false;
                        }
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
    }
}
