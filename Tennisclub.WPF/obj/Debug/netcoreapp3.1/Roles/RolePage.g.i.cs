﻿#pragma checksum "..\..\..\..\Roles\RolePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7784F8FC79C73C67683B35F19294705BDF71BE82"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Tennisclub.WPF.Roles;


namespace Tennisclub.WPF.Roles {
    
    
    /// <summary>
    /// RolePage
    /// </summary>
    public partial class RolePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Roles\RolePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_MemberWithRoles;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Roles\RolePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RolesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Roles\RolePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_RoleNameUpdate;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Roles\RolePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_UpdateRole;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\Roles\RolePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_RoleNameAdd;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\Roles\RolePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_AddRole;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Tennisclub.WPF;component/roles/rolepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Roles\RolePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_MemberWithRoles = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\Roles\RolePage.xaml"
            this.btn_MemberWithRoles.Click += new System.Windows.RoutedEventHandler(this.btn_MemberWithRoles_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RolesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 41 "..\..\..\..\Roles\RolePage.xaml"
            this.RolesDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RolesDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tb_RoleNameUpdate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btn_UpdateRole = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\Roles\RolePage.xaml"
            this.btn_UpdateRole.Click += new System.Windows.RoutedEventHandler(this.btn_UpdateRole_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tb_RoleNameAdd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_AddRole = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\..\Roles\RolePage.xaml"
            this.btn_AddRole.Click += new System.Windows.RoutedEventHandler(this.btn_AddRole_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

