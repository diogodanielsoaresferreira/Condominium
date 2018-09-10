using Condominium_Manager.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for EditBuilding.xaml
    /// </summary>
    public partial class EditBuilding : UserControl, INotifyPropertyChanged
    {
        WindowViewModel vm;
        public Predio p;
        public ObservableCollection<Photo> photos { get; set; } = new ObservableCollection<Photo>();
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public EditBuilding(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            tbNome.Text = p.Nome;
            tbLatitude.Text = p.Latitude.ToString();
            tbLongitude.Text = p.Longitude.ToString();
            if (p.Area != -1)
                tbArea.Text = p.Area.ToString();
            if (p.Cidade != null)
                tbCidade.Text = p.Cidade.ToString();
            if(p.Morada != null)
                tbMorada.Text = p.Morada;
            if(p.Codigo_Postal != null)
            {

                tbCodigo_Postal.Text = p.Codigo_Postal.Split('-')[0];
                tbCodigo_Postal2.Text = p.Codigo_Postal.Split('-')[1];
            }

            photos = new ObservableCollection<Photo>(p.getImagesPhotos());
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(photos)));
        }

        private void UpdateBuilding(object sender, RoutedEventArgs e)
        {
            string nome = tbNome.Text;
            string lat = tbLatitude.Text;
            string lon = tbLongitude.Text;
            string area = tbArea.Text;
            string cidade = tbCidade.Text;
            string codigo_p = tbCodigo_Postal.Text + "-" + tbCodigo_Postal2.Text;
            string mor = tbMorada.Text;
            double f_lat = -200;
            double f_lon = -200;
            double f_area = -1;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "Os campos marcados com '*' são de preenchimento obrigatório.";
                return;
            }
            
            p.Nome = nome;

            try
            {
                f_lat = double.Parse(lat);
                f_lon = double.Parse(lon);
            }
            catch (FormatException)
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "Os campos 'Latitude' e 'Longitude' devem ser valores numéricos.";
                return;
            }

            if (codigo_p.Length != 8 && codigo_p.Length != 1)
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "O código Postal tem de estar num formato xxxx-yyy.";
                return;
            }

            if (codigo_p.Length == 1)
            {
                codigo_p = "";
            }


            if (f_lat < -90 || f_lat > 90)
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "O campo 'Latitude' deve conter valores numéricos compreendidos entre -90 e 90.";
                return;
            }

            if (f_lon < -180 || f_lon > 180)
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "O campo 'Longitude' deve conter valores numéricos compreendidos entre -180 e 180.";
                return;
            }

            p.Latitude = f_lat;
            p.Longitude = f_lon;

            if (!string.IsNullOrEmpty(area))
            {
                try
                {
                    f_area = double.Parse(area);
                }
                catch (FormatException)
                {
                    ErrorBorder.Visibility = Visibility.Visible;
                    ErrorLabel.Content = "O campo 'Área' deve ser um valor numérico maior que zero.";
                    return;
                }

                if (f_area < 0)
                {
                    ErrorBorder.Visibility = Visibility.Visible;
                    ErrorLabel.Content = "O campo 'Área' deve ser um valor numérico maior que zero.";
                    return;
                }
                else
                {
                    p.Area = f_area;
                }
            }

            if (!string.IsNullOrEmpty(cidade))
            {
                p.Cidade = cidade;
            }
            if (!string.IsNullOrEmpty(codigo_p))
            {
                p.Codigo_Postal = codigo_p;
            }
            if (!string.IsNullOrEmpty(mor))
            {
                p.Morada = mor;
            }
            

            // Update the new photos
            p.Photos = new List<Photo>(photos);

            bool upd = p.Update();
            if (!upd)
            {
                ErrorLabel.Content = "Edifício não encontrado na base de dados!";
                return;
            }
            else
                vm.changeViewInitialPage(vm.cbIndex);
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf|JPG Image (.jpg)|*.jpg|All Images|*.jpg;*.wmf;*.tiff;*.png;*.jpeg;*.gif;*.bmp)";
            saveFileDialog.Multiselect = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                for (int i = 0; i < saveFileDialog.SafeFileNames.Length; i++)
                {
                    if (!photos.Any(p => p.FileName == saveFileDialog.SafeFileNames[i]))
                    {
                        Photo p;
                        if (new FileInfo(saveFileDialog.FileNames[i]).Length == 0)
                            p = new Photo(saveFileDialog.SafeFileNames[i], new FileInfo(saveFileDialog.FileNames[i]).Length / 100, saveFileDialog.FileNames[i]);
                        else
                            p = new Photo(saveFileDialog.SafeFileNames[i], new FileInfo(saveFileDialog.FileNames[i]).Length, saveFileDialog.FileNames[i]);
                        photos.Add(p);
                    }
                }
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(photos)));
            }
        }

        private void DeleteBuilding(object sender, RoutedEventArgs e)
        {
            photos.Remove((Photo)myDataGrid.SelectedItem);
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(photos)));
        }

        private void Retroceder(object sender, RoutedEventArgs e)
        {
            vm.changeViewInitialPage(vm.cbIndex);
        }
    }
}
