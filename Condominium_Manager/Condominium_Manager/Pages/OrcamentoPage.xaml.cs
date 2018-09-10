using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for OrcamentoPage.xaml
    /// </summary>
    public partial class OrcamentoPage : UserControl, INotifyPropertyChanged
    {

        private Predio p;
        private WindowViewModel vm;
        private DateTime _startDate = DateTime.Now.AddMonths(-1);
        private DateTime _endDate = DateTime.Now;

        public double Value {
            get
            {
                if (OrcamentoGrid.SelectedItem != null)
                    return ((Orcamento)OrcamentoGrid.SelectedItem).items.Sum(v => v.Balanco);
                return 0;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private ObservableCollection<Orcamento> _Orcamentos { get; set; }

        public ObservableCollection<Orcamento> Orcamentos
        {
            get
            {
                return _Orcamentos;
            }
            set
            {
                _Orcamentos = value;
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
                Orcamentos = new ObservableCollection<Orcamento>(Orcamento.get_Orcamentos(p.ID, EndDate, StartDate, p));
                PropertyChanged(this, new PropertyChangedEventArgs("Orcamentos"));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Value)));
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
                Orcamentos = new ObservableCollection<Orcamento>(Orcamento.get_Orcamentos(p.ID, EndDate, StartDate, p));
                PropertyChanged(this, new PropertyChangedEventArgs("Orcamentos"));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        public OrcamentoPage(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
        }

        private void OrcamentoGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NoOrcamentoLabel.Visibility = Visibility.Collapsed;
            OrcamentoViewer.Visibility = Visibility.Visible;
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Value)));
        }

        private void Add_Orcamento(object sender, RoutedEventArgs e)
        {
            vm.changeViewAddOrcamentoPage(p);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Orcamentos = new ObservableCollection<Orcamento>(Orcamento.get_Orcamentos(p.ID, EndDate, StartDate, p));
            PropertyChanged(this, new PropertyChangedEventArgs("Orcamentos"));
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Value)));
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            string titulo = tbTitulo.Text;
            string balanco = tbBalanco.Text;
            double f_balanco;
            
            if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(balanco))
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "Os campos marcados com '*' são de preenchimento obrigatório.";
                return;
            }

            try
            {
                f_balanco = double.Parse(balanco);

            }
            catch (FormatException)
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "O campo 'Balanço' deve ser um valor numérico.";
                return;
            }

            Item item = new Item(titulo, (Orcamento)OrcamentoGrid.SelectedItem, f_balanco);

            item.save();
            vm.changeViewEnterB(p);
            vm.changeViewOrcamentoPage(p);
            
        }
    }
}
