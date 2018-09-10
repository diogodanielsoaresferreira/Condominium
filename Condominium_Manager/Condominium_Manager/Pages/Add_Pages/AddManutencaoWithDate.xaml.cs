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

namespace Condominium_Manager.Pages.Add_Pages
{
    /// <summary>
    /// Interaction logic for AddManutencaoWithDate.xaml
    /// </summary>
    public partial class AddManutencaoWithDate : UserControl, INotifyPropertyChanged
    {

        private DateTime dt = DateTime.Now;
        private Predio p;
        private WindowViewModel vm;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public Outros_Pagamentos op { get; set; } = null;

        public AddManutencaoWithDate(WindowViewModel vm, Predio p, Outros_Pagamentos pg = null)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            
            if (pg != null)
            {
                op = pg;
                AddPay.Visibility = Visibility.Collapsed;
                SP.Visibility = Visibility.Visible;
            }
                
            
        }

        public DateTime Date
        {
            get
            {
                return dt;
            }
            set
            {
                dt = value;
            }
        }
        
        private void Add(object sender, RoutedEventArgs e)
        {
            string Titulo = tbTitulo.Text;
            string Desc = tbDesc.Text;
            string Tipo = tbTipo.Text;

            if (string.IsNullOrEmpty(Titulo))
            {
                ErrorLabel.Content = "";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }

            Manutencao m = new Manutencao(p, dt, Titulo, Desc, tipo:Tipo, op:op);

            if(op!=null)
                op.save();
            m.save();
            vm.changeViewManutencaoPage(p);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            vm.changeViewManutencaoPage(p);
        }
        
        private void AddPayment(object sender, RoutedEventArgs e)
        {
            vm.changeViewAddPagamento(vm, p, dt, ApplicationPage.AddManutencaoWDate_Page);
        }

        private void EditPayment(object sender, RoutedEventArgs e)
        {
            vm.changeViewAddPagamento(vm, p, dt, ApplicationPage.AddManutencaoWDate_Page);
        }

        private void CancelPayment(object sender, RoutedEventArgs e)
        {
            op = null;
            AddPay.Visibility = Visibility.Visible;
            SP.Visibility = Visibility.Collapsed;
        }
    }
}