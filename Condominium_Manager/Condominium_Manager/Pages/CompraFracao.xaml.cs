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
    /// Interaction logic for CompraFracao.xaml
    /// </summary>
    public partial class CompraFracao : UserControl
    {

        private WindowViewModel vm;
        private Predio p;
        private Fracao f;
        public ObservableCollection<Condomino> Condominos { get; set; }
        public ObservableCollection<Sujeito_Fiscal> sjs { get; set; } = new ObservableCollection<Sujeito_Fiscal>(Sujeito_Fiscal.get_All_SujFiscal());
        public DateTime StartDate { get; set; }


        public CompraFracao(WindowViewModel vm, Predio p, Fracao f, DateTime StartDate)
        {
            InitializeComponent();
            Condominos = new ObservableCollection<Condomino>(Condomino.get_Condominos(p.ID));
            this.vm = vm;
            this.p = p;
            this.f = f;
            this.StartDate = StartDate;
        }

        private void CompraButton(object sender, RoutedEventArgs e)
        {
            if (calendarCompra.SelectedDate == null)
            {
                var res = MessageBox.Show(
                          "Escolha uma data no calendário",
                          "Escolher Data",
                          MessageBoxButton.OK,
                          MessageBoxImage.Warning
                      );

                return;
            }
            
            DateTime date = calendarCompra.SelectedDate.Value;

            Compra c = new Compra(f, (Condomino)CBCondomino.SelectedItem, date);
            c.save();
            f.CurrentCondomino = (Condomino)CBCondomino.SelectedItem;
            vm.changeViewFractionPage(p, f);
        }

        private void CancelarButton(object sender, RoutedEventArgs e)
        {
            vm.changeViewFractionPage(p, f);
        }
    }
}
