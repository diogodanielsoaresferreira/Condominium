﻿#pragma checksum "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D3A3DE6357A976D00DFBD980EAB352E8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Condominium_Manager.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Condominium_Manager.Pages {
    
    
    /// <summary>
    /// AddManutencao
    /// </summary>
    public partial class AddManutencao : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ErrorBorder;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ErrorLabel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTitulo;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDesc;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTipo;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPay;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel SP;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditPay;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelPay;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Condominium_Manager;component/pages/add_pages/addmanutencao.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ErrorBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.ErrorLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.tbTitulo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbDesc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbTipo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AddPay = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
            this.AddPay.Click += new System.Windows.RoutedEventHandler(this.AddPayment);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SP = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.EditPay = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
            this.EditPay.Click += new System.Windows.RoutedEventHandler(this.EditPayment);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CancelPay = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
            this.CancelPay.Click += new System.Windows.RoutedEventHandler(this.CancelPayment);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 64 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 65 "..\..\..\..\Pages\Add_Pages\AddManutencao.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

