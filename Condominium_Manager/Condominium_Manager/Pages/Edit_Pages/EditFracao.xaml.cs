using Condominium_Manager.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

namespace Condominium_Manager.Pages.Edit_Pages
{
    /// <summary>
    /// Interaction logic for EditFracao.xaml
    /// </summary>
    public partial class EditFracao : UserControl, INotifyPropertyChanged
    {
        private WindowViewModel vm;
        private Predio p;
        public Fracao f;
        public ObservableCollection<Photo> photos { get; set; } = new ObservableCollection<Photo>();
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public EditFracao(WindowViewModel vm, Predio p, Fracao f)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            this.f = f;

            tbPiso.Text = f.Piso.ToString();
            tbArea.Text = f.Area.ToString();

            if (f.Quota != -1)
                tbQuota.Text = f.Quota.ToString();

            if (!string.IsNullOrEmpty(f.Zona))
                tbZona.Text = f.Zona;

            if (f.Tipo == "Estacionamento")
                CBTipo.SelectedIndex = 1;
            else if (f.Tipo == "Comercial")
                CBTipo.SelectedIndex = 1;

            photos = new ObservableCollection<Photo>(f.getImagesPhotos());
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(photos)));
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

        private void DeletePhoto(object sender, RoutedEventArgs e)
        {
            photos.Remove((Photo)myDataGrid.SelectedItem);
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(photos)));
        }

        private void UpdateFrac(object sender, RoutedEventArgs e)
        {
            string piso = tbPiso.Text;
            string zona = tbZona.Text;
            string area = tbArea.Text;
            string quota = tbQuota.Text;

            double f_area = -1;
            double f_quota = -1;
            int d_piso = -1;

            int IDPredio = p.ID;
            

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

            f.Piso = d_piso;
            f.Area = f_area;
            f.Quota = f_quota;
            f.Zona = zona;
            f.Tipo = tipo;

            f.Photos = new List<Photo>(photos);

            bool upd = f.Update();
            if (!upd)
            {
                ErrorLabel.Content = "Prédio não encontrado na base de dados!";
                return;
            }
            else
                vm.changeViewFractionPage(p, f);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.changeViewFractionPage(p, f);
        }
    }
}
