﻿#pragma checksum "..\..\..\UserControls\UserControlSQL.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9B0DCAFE7A75C85E7C7390C2FA435233A010E955199023996086D41FE9A8DAA2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using AplikacjaDietetyczna.UserControls;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace AplikacjaDietetyczna.UserControls {
    
    
    /// <summary>
    /// UserControlSQL
    /// </summary>
    public partial class UserControlSQL : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\UserControls\UserControlSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ZapisaneSQL;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UserControls\UserControlSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.WatermarkTextBox Select;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\UserControls\UserControlSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button policzBMI;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\UserControls\UserControlSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SelectDataGrid;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\UserControls\UserControlSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtMessages;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\UserControls\UserControlSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DoZatwierdzeniaTekst;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\UserControls\UserControlSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.WatermarkTextBox DoZatwierdzenia;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\UserControls\UserControlSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Zatwierdz;
        
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
            System.Uri resourceLocater = new System.Uri("/AplikacjaDietetyczna;component/usercontrols/usercontrolsql.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\UserControlSQL.xaml"
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
            
            #line 10 "..\..\..\UserControls\UserControlSQL.xaml"
            ((AplikacjaDietetyczna.UserControls.UserControlSQL)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ZapisaneSQL = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\..\UserControls\UserControlSQL.xaml"
            this.ZapisaneSQL.DropDownClosed += new System.EventHandler(this.ZapisaneSQL_closing);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Select = ((Xceed.Wpf.Toolkit.WatermarkTextBox)(target));
            return;
            case 4:
            this.policzBMI = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\UserControls\UserControlSQL.xaml"
            this.policzBMI.Click += new System.Windows.RoutedEventHandler(this.Click_sql);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SelectDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.txtMessages = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.DoZatwierdzeniaTekst = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.DoZatwierdzenia = ((Xceed.Wpf.Toolkit.WatermarkTextBox)(target));
            return;
            case 9:
            this.Zatwierdz = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\UserControls\UserControlSQL.xaml"
            this.Zatwierdz.Click += new System.Windows.RoutedEventHandler(this.Zatwierdz_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

