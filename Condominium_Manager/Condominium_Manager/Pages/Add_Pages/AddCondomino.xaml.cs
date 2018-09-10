using Condominium_Manager.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for AddCondomino.xaml
    /// </summary>
    public partial class AddCondomino : UserControl
    {

        private WindowViewModel vm;

        public AddCondomino(WindowViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
        }

        private void Add_Condomino(object sender, RoutedEventArgs e)
        {
            
            string nome = tbNome.Text;
            string CC = tbCC.Text;
            string NIF = tbNIF.Text;
            string Email = tbEmail.Text;

            Condomino c;
        

            if(string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(CC) || string.IsNullOrEmpty(NIF))
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "Os campos marcados com '*' são de preenchimento obrigatório.";
                return;
            }

            if (NIF.Length != 9 || !NIF.All(char.IsDigit))
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "O campo 'NIF' precisa de ter exatamente 9 caracteres numéricos.";
                return;
            }

            if (CC.Length != 8 || !CC.All(char.IsDigit))
            {
                ErrorBorder.Visibility = Visibility.Visible;
                ErrorLabel.Content = "O campo 'CC' precisa de ter exatamente 8 caracteres numéricos.";
                return;
            }
            

            c = new Condomino(CC, nome, NIF, Email);
            c.save();
            vm.changeViewCondominosPage();
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            vm.changeViewCondominosPage();
        }
    }
}
