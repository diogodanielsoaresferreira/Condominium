using Condominium_Manager.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for AddBuilding.xaml
    /// </summary>
    public partial class AddBuilding : UserControl, INotifyPropertyChanged
    {

        WindowViewModel vm;
        public ObservableCollection<Photo> photos { get; set; } = new ObservableCollection<Photo>();
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public AddBuilding(WindowViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
        }

        private void Add_Building(object sender, RoutedEventArgs e)
        {
            
            string nome = tbNome.Text;
            string lat = tbLatitude.Text;
            string lon = tbLongitude.Text;
            string area = tbArea.Text;
            string cidade = tbCidade.Text;
            string codigo_p = tbCodigo_Postal.Text + "-" +tbCodigo_Postal2.Text;
            string mor = tbMorada.Text;
            double f_lat = -200;
            double f_lon = -200;
            double f_area = -1;
            Predio p;

            if(string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "Os campos marcados com '*' são de preenchimento obrigatório.";
                return;
            }

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

            if (codigo_p.Length != 8 && codigo_p.Length!=1)
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "O código Postal tem de estar num formato xxxx-yyy.";
                return;
            }

            if (codigo_p.Length == 1)
            {
                codigo_p = "";
            }

            if(f_lat<-90 || f_lat > 90)
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
            }

            p = new Predio(nome, f_lat, f_lon, mor, cidade, codigo_p, f_area);
            p.Photos = new List<Photo>(photos);
            vm.Buildings.Add(p);
            p.save();
            vm.changeViewInitialPage();
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf|JPG Image (.jpg)|*.jpg|All Images|*.jpg;*.wmf;*.tiff;*.png;*.jpeg;*.gif;*.bmp)";
            saveFileDialog.Multiselect = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                for (int i=0; i<saveFileDialog.SafeFileNames.Length; i++)
                {
                    if(!photos.Any(p => p.FileName== saveFileDialog.SafeFileNames[i])) {
                        Photo p;
                        if(new FileInfo(saveFileDialog.FileNames[i]).Length==0)
                            p = new Photo(saveFileDialog.SafeFileNames[i], new FileInfo(saveFileDialog.FileNames[i]).Length / 100, saveFileDialog.FileNames[i]);
                        else
                            p = new Photo(saveFileDialog.SafeFileNames[i], new FileInfo(saveFileDialog.FileNames[i]).Length, saveFileDialog.FileNames[i]);
                        photos.Add(p);
                    }
                }
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(photos)));
            }
        }
        
        
    }
}
