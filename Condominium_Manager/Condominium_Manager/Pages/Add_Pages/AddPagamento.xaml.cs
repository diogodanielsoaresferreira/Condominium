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

namespace Condominium_Manager.Pages.Add_Pages
{
    /// <summary>
    /// Interaction logic for AddPagamento.xaml
    /// </summary>
    public partial class AddPagamento : UserControl
    {
        public WindowViewModel vm;
        public Predio p;
        public DateTime dt;
        private DateTime initialDT;
        private ApplicationPage lastPage;

        public ObservableCollection<Sujeito_Fiscal> SujeitosFiscais { get; set; } = new ObservableCollection<Sujeito_Fiscal>(Sujeito_Fiscal.get_All_SujFiscal());

        public AddPagamento(WindowViewModel vm, Predio p, DateTime dt, ApplicationPage lastPage)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            this.dt = dt;
            initialDT = dt;
            this.lastPage = lastPage;
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

        public string date
        {
            get
            {
                return dt.ToString("dd/MM/yyyy");
            }
        }

        private void AddSujFisc(object sender, RoutedEventArgs e)
        {
            vm.changeViewAddSujFisc(vm, p, dt, lastPage);
        }

        private void AddPayment(object sender, RoutedEventArgs e)
        {
            
            string desc = tbDesc.Text;
            string balanco = tbBalanco.Text;

            if (datePicker.SelectedDate == null)
            {
                ErrorLabel.Content = "Escolha uma data para o pagamento";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }

            DateTime data = (DateTime)datePicker.SelectedDate;

            if (ChooseSujFis.SelectedItem == null)
            {
                ErrorLabel.Content = "Escolha um sujeito fiscal para associar ao pagamento";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }

            Sujeito_Fiscal sf = (Sujeito_Fiscal)ChooseSujFis.SelectedItem;

            if (string.IsNullOrEmpty(balanco))
            {
                ErrorLabel.Content = "O campo 'Balanco' necessita de ser preenchido com um valor numérico";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }
            double bal;
            try
            {
                bal = double.Parse(balanco);
            }
            catch(Exception exc)
            {
                ErrorLabel.Content = "O campo 'Balanco' necessita de ser preenchido com um valor numérico";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }

            Console.WriteLine(desc);
            Outros_Pagamentos op = new Outros_Pagamentos(data, -bal, p, sf, desc);
            

            if (lastPage == ApplicationPage.AddManutencaoWDate_Page)
                vm.changeViewAddManutencaoWDate(p, op);
            else
                vm.changeViewAddManutencao(initialDT, p);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            if (lastPage == ApplicationPage.AddManutencaoWDate_Page)
                vm.changeViewAddManutencaoWDate(p);
            else
                vm.changeViewAddManutencao(initialDT, p);
        }
        
    }
}
