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
    /// Interaction logic for AddReunionWithDate.xaml
    /// </summary>
    public partial class AddReunionWithDate : UserControl
    {
        public AddReunionWithDate(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            Condominos = new ObservableCollection<Condomino>(Condomino.get_All_Current_Condominos(p.ID));
        }
        private DateTime dt = DateTime.Now;
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

            Reuniao re = new Reuniao(p.ID, dt, titulo, descricao, ata: ata);

            foreach (Condomino selected in selectedCondominos.SelectedItems)
            {
                re.add_Condomino(selected);
            }

            re.save();
            vm.changeViewAgendaPage(p);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            vm.changeViewReunionPage(p);
        }
    }
}
