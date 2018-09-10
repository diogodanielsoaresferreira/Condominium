using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for ManutencaoPage.xaml
    /// </summary>
    public partial class ManutencaoPage : UserControl, INotifyPropertyChanged
    {
        WindowViewModel vm;
        Predio p;
        private DateTime _startDate = DateTime.Now.AddMonths(-1);
        private DateTime _endDate = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;

        public ManutencaoPage(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
        }

        private ObservableCollection<Manutencao> _Manutencoes { get; set; }

        public ObservableCollection<Manutencao> Manutencoes
        {
            get
            {
                return _Manutencoes;
            }
            set
            {
                _Manutencoes = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                Manutencoes = new ObservableCollection<Manutencao>(Manutencao.get_Manutencoes(p, EndDate, StartDate));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Manutencoes)));
            }
        }
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                Manutencoes = new ObservableCollection<Manutencao>(Manutencao.get_Manutencoes(p, EndDate, StartDate));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Manutencoes)));
            }
        }

        private void ManutencaoGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NoManuLabel.Visibility = Visibility.Collapsed;
            ManutencaoViewer.Visibility = Visibility.Visible;
            if (ManutencaoGrid.SelectedItem != null)
            {
                if (((Manutencao)(ManutencaoGrid.SelectedItem)).op != null)
                {
                    SP1.Visibility = Visibility.Visible;
                    SP2.Visibility = Visibility.Visible;
                    NoPa.Visibility = Visibility.Hidden;
                }
                else
                {
                    SP1.Visibility = Visibility.Collapsed;
                    SP2.Visibility = Visibility.Collapsed;
                    NoPa.Visibility = Visibility.Visible;
                }
            }
        }

        private void Add_Manutencao(object sender, RoutedEventArgs e)
        {
            vm.changeViewAddManutencaoWDate(p);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Manutencoes = new ObservableCollection<Manutencao>(Manutencao.get_Manutencoes(p, EndDate, StartDate));
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Manutencoes)));
        }
    }
}
