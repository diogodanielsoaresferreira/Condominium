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
    /// Interaction logic for AddFraction.xaml 
    /// </summary> 
    public partial class AddFraction : UserControl, INotifyPropertyChanged
    {

        WindowViewModel vm;
        private Predio p;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public ObservableCollection<Photo> photos { get; set; } = new ObservableCollection<Photo>();

        public AddFraction(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
        }

        private void Add_Fraction(object sender, RoutedEventArgs e)
        {

            string piso = tbPiso.Text;
            string zona = tbZona.Text;
            string area = tbArea.Text;
            string quota = tbQuota.Text;

            double f_area = -1;
            double f_quota = -1;
            int d_piso = -1;

            int IDPredio = p.ID;

            Fracao f;

            if (!string.IsNullOrEmpty(piso))
            {
                try
                {
                    d_piso = int.Parse(piso);
                }
                catch (FormatException)
                {
                    ErrorBorder.Visibility = Visibility.Visible;
                    ErrorLabel.Content = "O campo 'Piso' deve ser um valor inteiro.";
                    return;
                }
            }
            else
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "O campo 'Piso' tem de ser preenchido.";
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
            else
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "O campo 'Área' tem de ser preenchido.";
                return;
            }

            if (!string.IsNullOrEmpty(quota))
            {
                try
                {
                    f_quota = double.Parse(quota);
                }
                catch (FormatException)
                {
                    ErrorBorder.Visibility = Visibility.Visible;
                    ErrorLabel.Content = "O campo 'Quota' deve ser um valor numérico maior que zero.";
                    return;
                }

                if (f_quota < 0)
                {
                    ErrorBorder.Visibility = Visibility.Visible;
                    ErrorLabel.Content = "O campo 'Quota' deve ser um valor numérico maior que zero.";
                    return;
                }
            }
            
            string tipo = CBTipo.Text;

            f = new Fracao(d_piso, zona, f_quota, f_area, tipo, IDPredio);
            f.Photos = new List<Photo>(photos);
            f.save();
            vm.changeViewFractions(p);
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
    }
}