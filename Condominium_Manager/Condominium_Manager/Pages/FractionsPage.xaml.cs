using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;


namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for FractionsPage.xaml
    /// </summary>
    public partial class FractionsPage : UserControl, INotifyPropertyChanged
    {
        WindowViewModel vm;
        private Predio p;
        private ObservableCollection<Fracao> _Items = new ObservableCollection<Fracao>();

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public ObservableCollection<Fracao> Items
        {
            get { return _Items; }
        }

        public string Ocupacao { get; set; }

        public FractionsPage(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            
            List<Fracao> fractions = Fracao.get_All_Fractions(p.ID);

            int oc = 0;

            foreach(Fracao fraction in fractions)
            {
                _Items.Add(fraction);
                if (fraction.CurrentCondomino != null)
                    oc += 1;
            }

            if (fractions.Count()!=0)
                Ocupacao = (Math.Round(100*oc/(double)fractions.Count(),2)).ToString()+"% ("+oc+"/"+ fractions.Count()+")";
            else
            {
                Ocupacao = "0% (" + oc + "/" + fractions.Count() + ")";
            }
        }

        private void AddFraction(object sender, RoutedEventArgs e)
        {
            vm.changeViewAddFraction(p);
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            vm.changeViewFractionPage(p, (Fracao)FractionGrid.SelectedItem);
        }

        private void DeleteFrac(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show(
                           "Tem a certeza que deseja apagar a fração do sistema ?",
                           "Apagar fração",
                           MessageBoxButton.YesNo,
                           MessageBoxImage.Question
                       );
            if (res.ToString() == "Yes")
            {
                ((Fracao)FractionGrid.SelectedItem).Delete();
                
                _Items = new ObservableCollection<Fracao>(Fracao.get_All_Fractions(p.ID));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Items)));
                
                MessageBox.Show(
                           "Fração apagada com sucesso!",
                           "Apagar fração",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information
                       );
                

            }
        }

        private void FractionGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            vm.changeViewFractionPage(p, (Fracao)FractionGrid.SelectedItem);
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            ((ToolTip)((FrameworkElement)sender).ToolTip).IsOpen = true;
        }

        private void HelpButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ((ToolTip)((FrameworkElement)sender).ToolTip).IsOpen = false;
        }
    }
}
