﻿#pragma checksum "..\..\..\View\DataBaseManage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9440C11ADD27B56E3ECD2C01D92093AEE57B3321C7527B329E534FC76F337784"
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
    /// DataBaseManage
    /// </summary>
    public partial class DataBaseManage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\View\DataBaseManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Presentation.View.DataBaseManage ResponsiveMainWindow;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\DataBaseManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Toolbar;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\View\DataBaseManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem StudentsTab;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\View\DataBaseManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem DormitoriesTab;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\View\DataBaseManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem FloorsTab;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\View\DataBaseManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem RoomsTab;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\View\DataBaseManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem ResidentsTab;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\View\DataBaseManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem NotificationsTab;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\View\DataBaseManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem ExtraInfoTab;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/view/databasemanage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\DataBaseManage.xaml"
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
            this.ResponsiveMainWindow = ((Presentation.View.DataBaseManage)(target));
            return;
            case 2:
            this.Toolbar = ((System.Windows.Controls.Grid)(target));
            
            #line 31 "..\..\..\View\DataBaseManage.xaml"
            this.Toolbar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Toolbar_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 33 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Home_Window_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 34 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Hide_Window_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 35 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Normalize_Window_Clock);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 36 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Window_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StudentsTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 8:
            
            #line 48 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.ListView)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DormitoriesTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 10:
            
            #line 68 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.ListView)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.FloorsTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 12:
            
            #line 85 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.ListView)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.RoomsTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 14:
            
            #line 102 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.ListView)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            this.ResidentsTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 16:
            
            #line 118 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.ListView)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 17:
            this.NotificationsTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 18:
            
            #line 137 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.ListView)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 19:
            this.ExtraInfoTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 20:
            
            #line 153 "..\..\..\View\DataBaseManage.xaml"
            ((System.Windows.Controls.ListView)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

