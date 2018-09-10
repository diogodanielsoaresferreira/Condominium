using Condominium_Manager.ViewModels;
using Microsoft.Maps.MapControl.WPF;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for BuildingsPage.xaml
    /// </summary>
    [ImplementPropertyChanged]
    public partial class BuildingsPage : UserControl, INotifyPropertyChanged
    {
        public ObservableCollection<Predio> Buildings { get; set; }
        public Predio p;
        WindowViewModel vm;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public BuildingsPage(WindowViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            Buildings = vm.Buildings;
            DataContext = this;
            
        }

        private void Pushpin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            p = ((sender as Pushpin).Tag as Predio);
            show_Building(p);
            vm.cbIndex = vm.Buildings.IndexOf(p);
        }

        public void show_Building(Predio p)
        {
            PushpinPopup.Visibility = Visibility.Visible;
            lName.Text = p.Nome;
            lName.ToolTip = p.Nome;
            lMor.Text = p.Morada;
            lMor.ToolTip = p.Morada;
            lCid.Text = p.Cidade;
            lCid.ToolTip = p.Cidade;
        }

        private void Enter_Building(object sender, RoutedEventArgs e)
        {
            vm.changeViewEnterB(p);
        }

        private void Delete_Building(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show(
                           "Tem a certeza que deseja apagar o prédio " + p.ToString() +" do sistema ?",
                           "Apagar prédio",
                           MessageBoxButton.YesNo,
                           MessageBoxImage.Question
                       );
            if(res.ToString() == "Yes")
            {
                p.Delete();
                Buildings = new ObservableCollection<Predio>(Predio.get_All_Buildings());
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Buildings)));
                vm.Buildings = Buildings;
                PushpinPopup.Visibility = Visibility.Hidden;
                MessageBox.Show(
                           "Prédio " + p.ToString() + " apagado com sucesso!",
                           "Apagar prédio",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information
                       );

                p = null;

            }
        }

        private void Edit_Button(object sender, RoutedEventArgs e)
        {
            vm.changeViewEdit(p);
        }

        private void Add_Building(object sender, RoutedEventArgs e)
        {
            vm.changeViewAddB();
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
