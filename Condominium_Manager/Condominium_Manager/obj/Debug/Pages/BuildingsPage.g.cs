﻿#pragma checksum "..\..\..\Pages\BuildingsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A0105D0E001C5444050A97A141E173D0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Condominium_Manager;
using Microsoft.Maps.MapControl.WPF;
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
    /// BuildingsPage
    /// </summary>
    public partial class BuildingsPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 16 "..\..\..\Pages\BuildingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Map Map;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\BuildingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border PushpinPopup;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\BuildingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lName;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Pages\BuildingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lMor;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\BuildingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lCid;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\BuildingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EBButton;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Pages\BuildingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EDButton;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Pages\BuildingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DPButton;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Pages\BuildingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button APButton;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\Pages\BuildingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HelpButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Condominium_Manager;component/pages/buildingspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\BuildingsPage.xaml"
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
            this.Map = ((Microsoft.Maps.MapControl.WPF.Map)(target));
            return;
            case 3:
            this.PushpinPopup = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.lName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.lMor = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.lCid = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.EBButton = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Pages\BuildingsPage.xaml"
            this.EBButton.Click += new System.Windows.RoutedEventHandler(this.Enter_Building);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EDButton = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Pages\BuildingsPage.xaml"
            this.EDButton.Click += new System.Windows.RoutedEventHandler(this.Edit_Button);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DPButton = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\Pages\BuildingsPage.xaml"
            this.DPButton.Click += new System.Windows.RoutedEventHandler(this.Delete_Building);
            
            #line default
            #line hidden
            return;
            case 10:
            this.APButton = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\Pages\BuildingsPage.xaml"
            this.APButton.Click += new System.Windows.RoutedEventHandler(this.Add_Building);
            
            #line default
            #line hidden
            return;
            case 11:
            this.HelpButton = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\Pages\BuildingsPage.xaml"
            this.HelpButton.Click += new System.Windows.RoutedEventHandler(this.HelpButton_Click);
            
            #line default
            #line hidden
            
            #line 120 "..\..\..\Pages\BuildingsPage.xaml"
            this.HelpButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.HelpButton_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 20 "..\..\..\Pages\BuildingsPage.xaml"
            ((Microsoft.Maps.MapControl.WPF.Pushpin)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Pushpin_MouseDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

