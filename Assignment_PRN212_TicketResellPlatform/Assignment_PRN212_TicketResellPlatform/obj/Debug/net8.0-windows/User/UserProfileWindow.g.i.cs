﻿#pragma checksum "..\..\..\..\User\UserProfileWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B3FAED797DE7105415BBCD6937779AC2E1581A55"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Assignment_PRN212_TicketResellPlatform.User;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Assignment_PRN212_TicketResellPlatform.User {
    
    
    /// <summary>
    /// UserProfileWindow
    /// </summary>
    public partial class UserProfileWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\User\UserProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label fullnameHeaderLabel;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\User\UserProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label fullnameLabel;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\User\UserProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox firstnameTextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\User\UserProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lastnameTextBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\User\UserProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailTextBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\User\UserProfileWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Assignment_PRN212_TicketResellPlatform;V1.0.0.0;component/user/userprofilewindow" +
                    ".xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\User\UserProfileWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.fullnameHeaderLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.fullnameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            
            #line 46 "..\..\..\..\User\UserProfileWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowMyShopWindow);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 47 "..\..\..\..\User\UserProfileWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowBalanceManagementWindow);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 48 "..\..\..\..\User\UserProfileWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowChangePasswordWindow);
            
            #line default
            #line hidden
            return;
            case 6:
            this.firstnameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.lastnameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.emailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.phoneTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

