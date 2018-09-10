using Condominium_Manager.ViewModels;
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

namespace Condominium_Manager.Pages.Add_Pages
{
    /// <summary>
    /// Interaction logic for AddSujFisc.xaml
    /// </summary>
    public partial class AddSujFisc : UserControl
    {
        public WindowViewModel vm;
        public Predio p;
        public DateTime dt;
        private ApplicationPage lp;

        public AddSujFisc(WindowViewModel vm, Predio p, DateTime dt, ApplicationPage lp)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            this.dt = dt;
            this.lp = lp;
        }

        private void AddSujFis(object sender, RoutedEventArgs e)
        {
            string NIF = tbNIF.Text;
            string Nome = tbNome.Text;
            string email = tbEmail.Text;
            string morada = tbMorada.Text;

            if (string.IsNullOrEmpty(NIF))
            {
                ErrorLabel.Content = "O campo NIF não pode estar vazio.";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }

            if (NIF.Length != 9 || !NIF.All(char.IsDigit))
            {
                ErrorLabel.Content = "O campo NIF precisa de conter 9 dígitos numéricos.";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }
            

            if (string.IsNullOrEmpty(Nome))
            {
                ErrorLabel.Content = "O campo Nome não pode estar vazio.";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }

            Sujeito_Fiscal sf = new Sujeito_Fiscal(NIF, Nome, email, morada);

            sf.save();
            vm.changeViewAddPagamento(vm, p, dt, lp);

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            vm.changeViewAddPagamento(vm, p, dt, lp);
        }
    }
}
