﻿#pragma checksum "..\..\..\..\View\AddNewAddressWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "577255E0C2D56E85E26A162DC7014E4869AB1E06"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Presentation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Presentation.View {
    
    
    /// <summary>
    /// AddNewAddressWindow
    /// </summary>
    public partial class AddNewAddressWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\View\AddNewAddressWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Toolbar;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\View\AddNewAddressWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addressStreet;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\View\AddNewAddressWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addressCity;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\View\AddNewAddressWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addressRegion;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\View\AddNewAddressWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addressPostalCode;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\View\AddNewAddressWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addressCountry;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Presentation;component/view/addnewaddresswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\AddNewAddressWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Toolbar = ((System.Windows.Controls.Grid)(target));
            
            #line 25 "..\..\..\..\View\AddNewAddressWindow.xaml"
            this.Toolbar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Toolbar_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 27 "..\..\..\..\View\AddNewAddressWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Window_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.addressStreet = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.addressCity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.addressRegion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.addressPostalCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.addressCountry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 75 "..\..\..\..\View\AddNewAddressWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddAddressButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

