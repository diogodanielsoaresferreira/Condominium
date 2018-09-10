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
using System.Collections.ObjectModel;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for AddReuniao.xaml
    /// </summary>
    public partial class AddReuniao : UserControl
    {
        private DateTime dt;
        private Predio p;
        private WindowViewModel vm;

        public ObservableCollection<Condomino> Condominos { get; set; }

        public string date
        {
            get
            {
                return dt.ToString("dd/MM/yyyy");
            }
        }

        public AddReuniao(WindowViewModel windowViewModel, DateTime dt, Predio p)
        {
            InitializeComponent();
            this.vm = windowViewModel;
            this.dt = dt;
            this.p = p;
            Condominos = new ObservableCollection<Condomino>(Condomino.get_All_Current_Condominos(p.ID));
        }

        private void add(object sender, RoutedEventArgs e)
        {
            string titulo = tbTitulo.Text;
            string descricao = tbDesc.Text;
            string ata = tbAta.Text;

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
            if (string.IsNullOrEmpty(ata))
            {
                ata = null;
            }

            List<Condomino> selectedCond = new List<Condomino>();

            Reuniao re = new Reuniao(p.ID, dt, titulo, descricao, ata:ata);

            foreach (Condomino selected in selectedCondominos.SelectedItems)
            {
                re.add_Condomino(selected);
            }

            re.save();
            vm.changeViewAgendaPage(p);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            vm.changeViewAgendaPage(p);
        }
    }
}
