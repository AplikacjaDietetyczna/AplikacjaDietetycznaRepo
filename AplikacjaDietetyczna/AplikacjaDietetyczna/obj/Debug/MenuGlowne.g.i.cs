﻿#pragma checksum "..\..\MenuGlowne.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0872BB0F890055BF99DB8370A48870B20EE2992D2AB42ABFC1B837475CC84D1F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AplikacjaDietetyczna;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace AplikacjaDietetyczna {
    
    
    /// <summary>
    /// MenuGlowne
    /// </summary>
    public partial class MenuGlowne : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PokazID;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PokazAdmin;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ONas;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Wyloguj;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMenu;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewMenu;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem ItemPodsumowanie;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem Dodaj;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem Kalkulator;
        
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
            System.Uri resourceLocater = new System.Uri("/AplikacjaDietetyczna;component/menuglowne.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MenuGlowne.xaml"
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
            
            #line 13 "..\..\MenuGlowne.xaml"
            ((AplikacjaDietetyczna.MenuGlowne)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GridMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.PokazID = ((System.Windows.Controls.TextBlock)(target));
            
            #line 33 "..\..\MenuGlowne.xaml"
            this.PokazID.Loaded += new System.Windows.RoutedEventHandler(this.PokazID_Loaded);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PokazAdmin = ((System.Windows.Controls.TextBlock)(target));
            
            #line 34 "..\..\MenuGlowne.xaml"
            this.PokazAdmin.Loaded += new System.Windows.RoutedEventHandler(this.PokazAdmin_Loaded);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 39 "..\..\MenuGlowne.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Profil_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ONas = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\MenuGlowne.xaml"
            this.ONas.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Wyloguj = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\MenuGlowne.xaml"
            this.Wyloguj.Click += new System.Windows.RoutedEventHandler(this.Wyloguj_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GridMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.ListViewMenu = ((System.Windows.Controls.ListView)(target));
            
            #line 58 "..\..\MenuGlowne.xaml"
            this.ListViewMenu.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewMenu_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ItemPodsumowanie = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 11:
            this.Dodaj = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 12:
            this.Kalkulator = ((System.Windows.Controls.ListViewItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

