// Updated by XamlIntelliSenseFileGenerator 12.05.2020 02:03:25
#pragma checksum "..\..\MenuGlowne.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "467FD27E80E51388D00BF4333F6BA1AF9777C840D62FE38D745D6F1772E92ED9"
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


namespace AplikacjaDietetyczna
{


    /// <summary>
    /// MenuGlowne
    /// </summary>
    public partial class MenuGlowne : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 27 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;

#line default
#line hidden


#line 29 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PokazID;

#line default
#line hidden


#line 30 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PokazAdmin;

#line default
#line hidden


#line 34 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMenu;

#line default
#line hidden


#line 35 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewMenu;

#line default
#line hidden


#line 36 "..\..\MenuGlowne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem ItemMain;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 12 "..\..\MenuGlowne.xaml"
                    ((AplikacjaDietetyczna.MenuGlowne)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);

#line default
#line hidden
                    return;
                case 2:
                    this.GridMain = ((System.Windows.Controls.Grid)(target));
                    return;
                case 3:
                    this.PokazID = ((System.Windows.Controls.TextBlock)(target));

#line 29 "..\..\MenuGlowne.xaml"
                    this.PokazID.Loaded += new System.Windows.RoutedEventHandler(this.PokazID_Loaded);

#line default
#line hidden
                    return;
                case 4:
                    this.PokazAdmin = ((System.Windows.Controls.TextBlock)(target));

#line 30 "..\..\MenuGlowne.xaml"
                    this.PokazAdmin.Loaded += new System.Windows.RoutedEventHandler(this.PokazAdmin_Loaded);

#line default
#line hidden
                    return;
                case 5:
                    this.GridMenu = ((System.Windows.Controls.Grid)(target));
                    return;
                case 6:
                    this.ListViewMenu = ((System.Windows.Controls.ListView)(target));

#line 35 "..\..\MenuGlowne.xaml"
                    this.ListViewMenu.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewMenu_SelectionChanged);

#line default
#line hidden
                    return;
                case 7:
                    this.ItemMain = ((System.Windows.Controls.ListViewItem)(target));
                    return;
                case 8:
                    this.ItemCreate = ((System.Windows.Controls.ListViewItem)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

