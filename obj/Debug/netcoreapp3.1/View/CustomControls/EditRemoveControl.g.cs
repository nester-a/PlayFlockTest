﻿#pragma checksum "..\..\..\..\..\View\CustomControls\EditRemoveControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A6BB5F1201E7346256E6C3355194BC168E5E62B3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PlayFlockTest.View.CustomControls;
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


namespace PlayFlockTest.View.CustomControls {
    
    
    /// <summary>
    /// EditRemoveControl
    /// </summary>
    public partial class EditRemoveControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\..\View\CustomControls\EditRemoveControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PlayFlockTest.View.CustomControls.EditRemoveControl root;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\View\CustomControls\EditRemoveControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel buttonsStackPanel;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\View\CustomControls\EditRemoveControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\View\CustomControls\EditRemoveControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button removeButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PlayFlockTest;component/view/customcontrols/editremovecontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\CustomControls\EditRemoveControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.root = ((PlayFlockTest.View.CustomControls.EditRemoveControl)(target));
            return;
            case 2:
            this.buttonsStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.editButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\..\View\CustomControls\EditRemoveControl.xaml"
            this.editButton.Click += new System.Windows.RoutedEventHandler(this.editButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.removeButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\..\View\CustomControls\EditRemoveControl.xaml"
            this.removeButton.Click += new System.Windows.RoutedEventHandler(this.removeButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

