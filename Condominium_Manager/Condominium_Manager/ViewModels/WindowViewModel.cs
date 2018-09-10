using Condominium_Manager.Pages;
using Condominium_Manager.Pages.Add_Pages;
using Condominium_Manager.Pages.Edit_Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Condominium_Manager.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {
        public ObservableCollection<Predio> _Buildings { get; set; }
        public ObservableCollection<Predio> Buildings {
            get
            {
                return _Buildings;
            }
            set
            {
                _Buildings = value;
                OnPropertyChanged(nameof(_Buildings));
            }
        }
        public int _cbIndex { get; set; } = -1;
        public int cbIndex {
            get
            {
                return _cbIndex;
            }
            set
            {
                _cbIndex = value;
                OnPropertyChanged(nameof(_cbIndex));
            }
        }

        /// <summary>
        /// The window this view model controls
        /// </summary>
        public Window mWindow;

        /// <summary>
        /// The window resizer helper that keeps the window size correct in various states
        /// </summary>
        private WindowResizer mWindowResizer;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        public GridLength Column1Width { get; set; } = new GridLength(0, GridUnitType.Star);

        public GridLength Column2Width { get; set; } = new GridLength(5, GridUnitType.Star);

        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 850;

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 650;

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless {  get { return (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked); } }

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get { return Borderless ? 0 : 6; } }

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                // If it is maximized or docked, no border
                return Borderless ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                // If it is maximized or docked, no border
                return Borderless ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the grid of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }


        public ICommand V { get; set; }
        public ICommand F { get; set; }
        public ICommand B { get; set; }
        public ICommand C { get; set; }
        public ICommand Q { get; set; }
        public ICommand A { get; set; }
        public ICommand R { get; set; }
        public ICommand O { get; set; }
        public ICommand M { get; set; }

        public Predio CurrentBuilding { get; set; }

        private ApplicationPage _page;

        /// <summary>
        /// Index of array of pages
        /// </summary>
        public ApplicationPage page {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        /// <summary>
        /// Array of pages
        public List<UserControl> pages;
        public UserControl CurrentPage
        {
            get
            {
                return pages[(int)page];
            }
        }
        

        public UserControl CurrentSidebar
        {
            get
            {
                return new MainSideBar(this);
            }
        }



        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                WindowResized();
            };

            // Create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            V = new RelayCommand(() => { if (CurrentBuilding != null) changeViewEnterB(CurrentBuilding); } );
            F = new RelayCommand(() => { if (CurrentBuilding != null) changeViewFractions(CurrentBuilding); });
            B = new RelayCommand(() => { if (CurrentBuilding != null) changeViewFinancesPage(CurrentBuilding); });
            C = new RelayCommand(() => { if (CurrentBuilding != null) changeViewCondominosPage(); });
            Q = new RelayCommand(() => { if (CurrentBuilding != null) changeviewQuotaPage(CurrentBuilding); });
            A = new RelayCommand(() => { if (CurrentBuilding != null) changeViewAgendaPage(CurrentBuilding); });
            R = new RelayCommand(() => { if (CurrentBuilding != null) changeViewReunionPage(CurrentBuilding); });
            O = new RelayCommand(() => { if (CurrentBuilding != null) changeViewOrcamentoPage(CurrentBuilding); });
            M = new RelayCommand(() => { if (CurrentBuilding != null) changeViewManutencaoPage(CurrentBuilding); });


            Buildings = new ObservableCollection<Predio>(Predio.get_All_Buildings());

            // Fix window resize issue
            mWindowResizer = new WindowResizer(mWindow);

            // Listen out for dock changes
            mWindowResizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                mDockPosition = dock;

                // Fire off resize events
                WindowResized();
            };
            
            
            pages = new List<UserControl>( new UserControl[Enum.GetNames(typeof(ApplicationPage)).Length]);

            changeViewInitialPage();

        }
        /// <summary>
        /// If the window resizes to a special position (docked or maximized)
        /// this will update all required property change events to set the borders and radius values
        /// </summary>
        private void WindowResized()
        {
            // Fire off events for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        # region ViewChangers

        public void changeViewInitialPage()
        {
            Column1Width = new GridLength(0, GridUnitType.Star);

            pages[(int)ApplicationPage.Buildings_Page] = new BuildingsPage(this);
            page = ApplicationPage.Buildings_Page;
            
            // Change dropdown selection to not selected
            cbIndex = -1;
        }

        public void changeViewInitialPage(int cbIndex)
        {
            Column1Width = new GridLength(0, GridUnitType.Star);

            pages[(int)ApplicationPage.Buildings_Page] = new BuildingsPage(this);
            page = ApplicationPage.Buildings_Page;

            (pages[(int)page] as BuildingsPage).p = Buildings[cbIndex];
            (pages[(int)page] as BuildingsPage).show_Building(Buildings[cbIndex]);

            this.cbIndex = cbIndex;

        }

        public void changeViewAddB()
        {

            pages[(int)ApplicationPage.Add_Building] = new AddBuilding(this);
            page = ApplicationPage.Add_Building;

            cbIndex = -1;
        }

        public void changeViewEdit(Predio p)
        {

            pages[(int)ApplicationPage.Edit_Building] = new EditBuilding(this, p);
            page = ApplicationPage.Edit_Building;

            CurrentBuilding = p;
        }

        public void changeViewEnterB(Predio p)
        {
            Column1Width = new GridLength(1, GridUnitType.Star);

            pages[(int)ApplicationPage.Building_Main_Page] = new BuildingMainPage(this, p);
            // Two pages for c# to recognize the change of pages
            page = ApplicationPage.Fractions_Page;
            page = ApplicationPage.Building_Main_Page;

            CurrentBuilding = p;
        }

        public void changeViewAddFraction(Predio p)
        {

            pages[(int)ApplicationPage.Add_Fraction] = new AddFraction(this, p);
            page = ApplicationPage.Add_Fraction;

            CurrentBuilding = p;
        }

        public void changeViewFractions(Predio p)
        {

            pages[(int)ApplicationPage.Fractions_Page] = new FractionsPage(this, p);
            page = ApplicationPage.Fractions_Page;

            CurrentBuilding = p;
        }

        public void changeViewAgendaPage(Predio p)
        {

            pages[(int)ApplicationPage.Agenda_Page] = new AgendaPage(this, p);
            page = ApplicationPage.Agenda_Page;

            CurrentBuilding = p;
        }

        public void changeViewCondominosPage()
        {

            pages[(int)ApplicationPage.Condominos_Page] = new CondominosPage(this, CurrentBuilding);
            page = ApplicationPage.Condominos_Page;
        }

        public void changeViewAddCondomino()
        {

            pages[(int)ApplicationPage.Add_Condomino] = new AddCondomino(this);
            page = ApplicationPage.Add_Condomino;
        }

        public void changeViewAddNota(DateTime dt, Predio p)
        {

            pages[(int)ApplicationPage.Add_Nota] = new AddNota(this, dt, p);
            page = ApplicationPage.Add_Nota;
        }

        public void changeViewAddAviso(DateTime dt, Predio p)
        {

            pages[(int)ApplicationPage.Add_Aviso] = new AddAviso(this, dt, p);
            page = ApplicationPage.Add_Aviso;
        }

        public void changeViewAddReuniao(DateTime dt, Predio p)
        {

            pages[(int)ApplicationPage.Add_Reuniao] = new AddReuniao(this, dt, p);
            page = ApplicationPage.Add_Reuniao;
        }

        public void changeViewAddManutencao(DateTime dt, Predio p)
        {

            pages[(int)ApplicationPage.Add_Manutencao] = new AddManutencao(this, dt, p);
            page = ApplicationPage.Add_Manutencao;
        }

        public void changeViewReunionPage(Predio p)
        {

            pages[(int)ApplicationPage.Reuniao_Page] = new ReuniaoPage(this, p);
            page = ApplicationPage.Reuniao_Page;
        }

        public void changeViewFinancesPage(Predio p)
        {

            pages[(int)ApplicationPage.Finances_Page] = new FinancesPage(this, p);
            page = ApplicationPage.Finances_Page;
        }

        public void changeViewReunionWDatePage(Predio p)
        {

            pages[(int)ApplicationPage.ReunionWDate_Page] = new AddReunionWithDate(this, p);
            page = ApplicationPage.ReunionWDate_Page;
        }

        public void changeViewManutencaoPage(Predio p)
        {

            pages[(int)ApplicationPage.Manutencao_Page] = new ManutencaoPage(this, p);
            page = ApplicationPage.Manutencao_Page;
        }

        public void changeViewAddManutencaoWDate(Predio p, Outros_Pagamentos op = null)
        {

            pages[(int)ApplicationPage.AddManutencaoWDate_Page] = new AddManutencaoWithDate(this, p, op);
            page = ApplicationPage.AddManutencaoWDate_Page;
        }

        public void changeViewOrcamentoPage(Predio p)
        {

            pages[(int)ApplicationPage.Orcamento_Page] = new OrcamentoPage(this, p);
            page = ApplicationPage.Orcamento_Page;
        }

        public void changeViewAddOrcamentoPage(Predio p)
        {

            pages[(int)ApplicationPage.Add_Orcamento] = new AddOrcamento(this, p);
            page = ApplicationPage.Add_Orcamento;
        }

        public void changeviewQuotaPage(Predio p)
        {

            pages[(int)ApplicationPage.Quota_Page] = new QuotaPage(this, p);
            page = ApplicationPage.Quota_Page;
        }

        public void changeViewPayQuota(int fracao_id, Predio p, ApplicationPage pg)
        {

            pages[(int)ApplicationPage.Pay_Quota] = new PayQuota(this, fracao_id, p, pg);
            page = ApplicationPage.Pay_Quota;
        }

        public void changeViewFractionPage(Predio p, Fracao f)
        {

            pages[(int)ApplicationPage.Fraction_Page] = new FractionPage(this, f, p);
            page = ApplicationPage.Fraction_Page;
        }

        public void changeViewEditFraction(Predio p, Fracao f)
        {

            pages[(int)ApplicationPage.Edit_Fraction] = new EditFracao(this, p, f);
            page = ApplicationPage.Edit_Fraction;
        }

        public void changeViewCompraPage(Predio p, Fracao f, DateTime StartDate)
        {

            pages[(int)ApplicationPage.Compra_Page] = new CompraFracao(this, p, f, StartDate);
            page = ApplicationPage.Compra_Page;
        }

        public void changeViewVendaPage(Predio p, Fracao f, Compra c, DateTime StartDate)
        {

            pages[(int)ApplicationPage.Venda_Page] = new VendaFracao(this, p, f, c, StartDate);
            page = ApplicationPage.Venda_Page;
        }

        public void changeViewAddPagamento(WindowViewModel vm, Predio p, DateTime dt, ApplicationPage lp)
        {
            pages[(int)ApplicationPage.AddPagamento_Page] = new AddPagamento(vm, p, dt, lp);
            page = ApplicationPage.AddPagamento_Page;
        }

        public void changeViewAddSujFisc(WindowViewModel vm, Predio p, DateTime dt, ApplicationPage lp)
        {
            pages[(int)ApplicationPage.AddSujFisc] = new AddSujFisc(vm, p, dt, lp);
            page = ApplicationPage.AddSujFisc;
        }

        #endregion
    }
}
