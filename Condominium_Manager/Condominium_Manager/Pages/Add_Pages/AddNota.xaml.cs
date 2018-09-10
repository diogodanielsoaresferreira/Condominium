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

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for AddNota.xaml
    /// </summary>
    public partial class AddNota : UserControl
    {
        public WindowViewModel vm;
        private DateTime dt { get; set; }
        private Predio p;
        public string date
        {
            get
            {
                return dt.ToString("dd/MM/yyyy");
            }
        }

        public AddNota(WindowViewModel vm, DateTime dt, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.dt = dt;
            this.p = p;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            vm.changeViewAgendaPage(p);
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

            Nota n = new Nota(p.ID, dt, titulo, descricao);
            n.save();
            vm.changeViewAgendaPage(p);
        }
    }
}
