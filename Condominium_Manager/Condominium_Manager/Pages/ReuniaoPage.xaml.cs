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
    /// Interaction logic for ReuniaoPage.xaml
    /// </summary>
    public partial class ReuniaoPage : UserControl, INotifyPropertyChanged
    {

        private Predio p;
        private WindowViewModel vm;
        private DateTime _startDate = DateTime.Now.AddMonths(-1);
        private DateTime _endDate = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Reuniao> _Reunioes { get; set; }

        public ObservableCollection<Reuniao> Reunioes
        {
            get
            {
                return _Reunioes;
            }
            set
            {
                _Reunioes = value;
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
                Reunioes = new ObservableCollection<Reuniao>(Reuniao.get_Reunioes(p.ID, EndDate, StartDate));
                PropertyChanged(this, new PropertyChangedEventArgs("Reunioes"));
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
                Reunioes = new ObservableCollection<Reuniao>(Reuniao.get_Reunioes(p.ID, EndDate, StartDate));
                PropertyChanged(this, new PropertyChangedEventArgs("Reunioes"));
            }
        }

        public ReuniaoPage(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
        }

        private void ReunionGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NoReunionLabel.Visibility = Visibility.Collapsed;
            ReunionViewer.Visibility = Visibility.Visible;
        }

        private void Add_Reuniao(object sender, RoutedEventArgs e)
        {
            vm.changeViewReunionWDatePage(p);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Reunioes = new ObservableCollection<Reuniao>(Reuniao.get_Reunioes(p.ID, EndDate, StartDate));
            PropertyChanged(this, new PropertyChangedEventArgs("Reunioes"));
        }
    }
}
