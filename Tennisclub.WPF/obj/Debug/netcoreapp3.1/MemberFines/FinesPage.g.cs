﻿#pragma checksum "..\..\..\..\MemberFines\FinesPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6D6910DB5F603D64DFCCC580AC536DADC4D52839"
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
using Tennisclub.WPF.MemberFines;


namespace Tennisclub.WPF.MemberFines {
    
    
    /// <summary>
    /// FinesPage
    /// </summary>
    public partial class FinesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\MemberFines\FinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_HandoutDateFilter;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\MemberFines\FinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_PaymentDateFilter;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\MemberFines\FinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Filter;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\MemberFines\FinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ClearFilter;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\MemberFines\FinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid finesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\MemberFines\FinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_PaymentDate;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\MemberFines\FinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_CompletePayment;
        
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
            System.Uri resourceLocater = new System.Uri("/Tennisclub.WPF;component/memberfines/finespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MemberFines\FinesPage.xaml"
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
            this.dp_HandoutDateFilter = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.dp_PaymentDateFilter = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.btn_Filter = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\MemberFines\FinesPage.xaml"
            this.btn_Filter.Click += new System.Windows.RoutedEventHandler(this.btn_Filter_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_ClearFilter = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\MemberFines\FinesPage.xaml"
            this.btn_ClearFilter.Click += new System.Windows.RoutedEventHandler(this.btn_ClearFilter_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.finesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 53 "..\..\..\..\MemberFines\FinesPage.xaml"
            this.finesDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FinesDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dp_PaymentDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.btn_CompletePayment = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\..\MemberFines\FinesPage.xaml"
            this.btn_CompletePayment.Click += new System.Windows.RoutedEventHandler(this.btn_CompletePayment_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
