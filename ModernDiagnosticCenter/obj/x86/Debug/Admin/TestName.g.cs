﻿#pragma checksum "..\..\..\..\Admin\TestName.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DAD15FDDD3862606E83230E98D93AB95"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
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


namespace ModernDiagnosticCenter.Admin {
    
    
    /// <summary>
    /// TestName
    /// </summary>
    public partial class TestName : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Admin\TestName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button admin_add;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Admin\TestName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox admin_test_name_combobox_update;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Admin\TestName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox admin_test_name_combobox_remove;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Admin\TestName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button admin_remove_test_button;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Admin\TestName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox admin_add_price;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Admin\TestName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox admin_test_name_add;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Admin\TestName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox admin_price_update;
        
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
            System.Uri resourceLocater = new System.Uri("/ModernDiagnosticCenter;component/admin/testname.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Admin\TestName.xaml"
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
            
            #line 11 "..\..\..\..\Admin\TestName.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Update);
            
            #line default
            #line hidden
            return;
            case 2:
            this.admin_add = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Admin\TestName.xaml"
            this.admin_add.Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 3:
            this.admin_test_name_combobox_update = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\..\..\Admin\TestName.xaml"
            this.admin_test_name_combobox_update.GotFocus += new System.Windows.RoutedEventHandler(this.admin_test_name_combobox_update_GotFocus);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\..\Admin\TestName.xaml"
            this.admin_test_name_combobox_update.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.admin_test_name_combobox_update_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.admin_test_name_combobox_remove = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\..\..\Admin\TestName.xaml"
            this.admin_test_name_combobox_remove.GotFocus += new System.Windows.RoutedEventHandler(this.admin_test_name_combobox_remove_GotFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.admin_remove_test_button = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Admin\TestName.xaml"
            this.admin_remove_test_button.Click += new System.Windows.RoutedEventHandler(this.admin_remove_test_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.admin_add_price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.admin_test_name_add = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.admin_price_update = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

