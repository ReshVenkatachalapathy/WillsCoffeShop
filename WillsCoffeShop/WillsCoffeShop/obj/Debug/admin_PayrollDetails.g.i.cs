﻿#pragma checksum "..\..\admin_PayrollDetails.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F2C2E8D0AF5035883469C7FBEE50475DE80B1E7B8ECFFF52AA71EB81934D93F0"
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
using WillsCoffeShop;


namespace WillsCoffeShop {
    
    
    /// <summary>
    /// admin_PayrollDetails
    /// </summary>
    public partial class admin_PayrollDetails : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\admin_PayrollDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmployeeIdTextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\admin_PayrollDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\admin_PayrollDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker PaymentPeriodFromDatePicker;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\admin_PayrollDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker PaymentPeriodToDatePicker;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\admin_PayrollDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SalaryTextBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\admin_PayrollDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TotalHoursWorkedTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/WillsCoffeShop;component/admin_payrolldetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\admin_PayrollDetails.xaml"
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
            
            #line 20 "..\..\admin_PayrollDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\admin_PayrollDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EmployeeIdTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\admin_PayrollDetails.xaml"
            this.EmployeeIdTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.EmployeeIdTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PaymentPeriodFromDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.PaymentPeriodToDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.SalaryTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\admin_PayrollDetails.xaml"
            this.SalaryTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SalaryTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TotalHoursWorkedTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\admin_PayrollDetails.xaml"
            this.TotalHoursWorkedTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TotalHoursWorkedTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 47 "..\..\admin_PayrollDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 48 "..\..\admin_PayrollDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 49 "..\..\admin_PayrollDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

