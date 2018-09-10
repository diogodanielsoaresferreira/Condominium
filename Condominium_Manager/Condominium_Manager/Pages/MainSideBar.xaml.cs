using Condominium_Manager.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for MainSideBar.xaml
    /// </summary>
    public partial class MainSideBar : UserControl
    {
        private WindowViewModel vm;
        
        public MainSideBar(WindowViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
        }


        private void Fractions_Page(object sender, RoutedEventArgs e)
        {
            vm.changeViewFractions(vm.CurrentBuilding);
        }

        private void Out_Building(object sender, RoutedEventArgs e)
        {
            vm.changeViewInitialPage(vm.cbIndex);
        }

        private void MainBPage(object sender, RoutedEventArgs e)
        {
            vm.changeViewEnterB(vm.CurrentBuilding);
        }

        private void AgendaPage(object sender, RoutedEventArgs e)
        {
            vm.changeViewAgendaPage(vm.CurrentBuilding);
        }

        private void Condominos_Page(object sender, RoutedEventArgs e)
        {
            vm.changeViewCondominosPage();
        }

        private void Reunion_Page(object sender, RoutedEventArgs e)
        {
            vm.changeViewReunionPage(vm.CurrentBuilding);
        }

        private void FinancesPage(object sender, RoutedEventArgs e)
        {
            vm.changeViewFinancesPage(vm.CurrentBuilding);
        }

        private void Manutencao_Page(object sender, RoutedEventArgs e)
        {
            vm.changeViewManutencaoPage(vm.CurrentBuilding);
        }

        private void Orcamento_Page(object sender, RoutedEventArgs e)
        {
            vm.changeViewOrcamentoPage(vm.CurrentBuilding);
        }

        private void Quotas_Page(object sender, RoutedEventArgs e)
        {
            vm.changeviewQuotaPage(vm.CurrentBuilding);
        }
    }
}
