using System;
using System.Collections.Generic;
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
using Condominium_Manager.ViewModels;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for AddManutencao.xaml
    /// </summary>
    public partial class AddManutencao : UserControl
    {
        private DateTime dt;
        private Predio p;
        private WindowViewModel vm;
        public Outros_Pagamentos op { get; set; }

        public string Date
        {
            get
            {
                return dt.ToString("dd/MM/yyyy");
            }
            
        }
        

        public AddManutencao(WindowViewModel vm, DateTime dt, Predio p, Outros_Pagamentos pg=null)
        {
            InitializeComponent();
            this.vm = vm;
            this.dt = dt;
            this.p = p;

            if (pg != null)
            {
                op = pg;
                AddPay.Visibility = Visibility.Collapsed;
                SP.Visibility = Visibility.Visible;
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

            Manutencao m = new Manutencao(p, dt, Titulo, Desc, tipo: Tipo, op: op);

            op.save();
            m.save();
            vm.changeViewAgendaPage(p);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            vm.changeViewAgendaPage(p);
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
