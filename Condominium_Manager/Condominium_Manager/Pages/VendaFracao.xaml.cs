using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for VendaFracao.xaml
    /// </summary>
    public partial class VendaFracao : UserControl
    {
        private WindowViewModel vm;
        private Predio p;
        public Compra c;
        public Fracao f { get; set; }
        public ObservableCollection<Sujeito_Fiscal> sjs { get; set; } = new ObservableCollection<Sujeito_Fiscal>(Sujeito_Fiscal.get_All_SujFiscal());
        public DateTime StartDate { get; set; }

        public VendaFracao(WindowViewModel vm, Predio p, Fracao f, Compra c, DateTime StartDate)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            this.f = f;
            this.c = c;
            this.StartDate = StartDate;
        }

        private void VendaButton(object sender, RoutedEventArgs e)
        {
            if (calendarVenda.SelectedDate == null)
            {
                var res = MessageBox.Show(
                          "Escolha uma data no calendário",
                          "Escolher Data",
                          MessageBoxButton.OK,
                          MessageBoxImage.Warning
                      );
               
                return;
            }

            if (calendarVenda.SelectedDate.Value < c._Data_Compra)
            {
                var res = MessageBox.Show(
                          "Escolha uma posterior à data de compra da fração",
                          "Data Inválida",
                          MessageBoxButton.OK,
                          MessageBoxImage.Warning
                      );

                return;
            }

            DateTime date = calendarVenda.SelectedDate.Value;
           
            c._Data_Venda = date;
            c.update();
            f.CurrentCondomino = null;
            vm.changeViewFractionPage(p, f);
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {

            vm.changeViewFractionPage(p, f);
        }
    }
}
