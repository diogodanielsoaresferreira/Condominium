using System;
using System.Windows;
using System.Windows.Controls;
using Condominium_Manager.ViewModels;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for AddReuniao.xaml
    /// </summary>
    public partial class AddOrcamento : UserControl
    {
        private DateTime dt_initial;
        private DateTime dt_final;
        private Predio p;
        private WindowViewModel vm;

        public string Date_Initial
        {
            get
            {
                return dt_initial.ToString("dd/MM/yyyy");
            }
        }

        public string Date_Final
        {
            get
            {
                return dt_final.ToString("dd/MM/yyyy");
            }
        }

        public AddOrcamento(WindowViewModel windowViewModel, Predio p)
        {
            InitializeComponent();
            this.vm = windowViewModel;
            this.p = p;
        }

        private void add(object sender, RoutedEventArgs e)
        {
            string titulo = tbTitulo.Text;
            string descricao = tbDesc.Text;

            if (string.IsNullOrEmpty(titulo))
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "Os campos marcados com '*' são de preenchimento obrigatório.";
                return;
            }
            if (string.IsNullOrEmpty(descricao))
            {
                descricao = null;
            }

            if (tbInitial_Date.SelectedDate == null)
            {
                ErrorLabel.Content = "Escolha uma data para o início do orçamento.";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }

            DateTime dt_initial = (DateTime)tbInitial_Date.SelectedDate;

            if (tbFinal_Date.SelectedDate == null)
            {
                ErrorLabel.Content = "Escolha uma data para o fim do orçamento.";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }

            DateTime dt_final = (DateTime)tbFinal_Date.SelectedDate;

            if (DateTime.Compare(dt_initial, dt_final) > 0)
            {
                ErrorLabel.Content = "Escolha uma data final maior que a inicial.";
                ErrorBorder.Visibility = Visibility.Visible;
                return;
            }

            Orcamento orcamento = new Orcamento(titulo, dt_initial, dt_final, p, descricao, p.ID);
            
            orcamento.save();
            vm.changeViewOrcamentoPage(p);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            vm.changeViewOrcamentoPage(p);
        }
    }
}
