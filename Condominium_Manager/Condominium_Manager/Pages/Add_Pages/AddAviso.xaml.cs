using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Condominium_Manager.ViewModels;
using Condominium_Manager.DataModels;
using System.Collections.ObjectModel;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for AddAviso.xaml
    /// </summary>
    public partial class AddAviso : UserControl
    {
        private DateTime dt;
        private Predio p;
        private WindowViewModel vm;
        public string date
        {
            get
            {
                return dt.ToString("dd/MM/yy");
            }
        }
        public ObservableCollection<Condomino> Condominos { get; set; }

        public AddAviso(WindowViewModel windowViewModel, DateTime dt, Predio p)
        {
            InitializeComponent();
            this.vm = windowViewModel;
            this.dt = dt;
            this.p = p;
            Condominos = new ObservableCollection<Condomino>(Condomino.get_All_Current_Condominos(p.ID));
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            vm.changeViewAgendaPage(p);
        }

        private void add_aviso(object sender, RoutedEventArgs e)
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

            List<Condomino> selectedCond = new List<Condomino>();

            Aviso av = new Aviso(p.ID, dt, titulo, descricao);

            string footer = "\n\n---\nEsta mensagem foi enviada pelo seu senhorio a " + DateTime.Now + ", através da aplicação dominium.";

            foreach (Condomino selected in selectedCondominos.SelectedItems)
            {
                av.add_Condomino(selected);

                // also notify by email
                if(selected.Email!=null)
                    Email.sendEmail(selected.Email, titulo, descricao + footer);
            }

            av.save();
            vm.changeViewAgendaPage(p);
        }
    }
}
