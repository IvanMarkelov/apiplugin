﻿#pragma checksum "..\..\..\MainWindow\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "954A191AC3C98C3E9CCDCEDAC4F64309CBAB7F2559F24A283424F7C925DB1319"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LEDEL_BIM.MainWindow;
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


namespace LEDEL_BIM.MainWindow {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox namesList;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox typeList;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loadFrom;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loadTo;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fluxFrom;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fluxTo;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox colorTemperatureList;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox photometricWebList;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView treeViewLFF;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button applyButton;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\MainWindow\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button insertButton;
        
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
            System.Uri resourceLocater = new System.Uri("/LEDEL_BIM;component/mainwindow/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow\MainWindow.xaml"
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
            this.namesList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\MainWindow\MainWindow.xaml"
            this.namesList.GotFocus += new System.Windows.RoutedEventHandler(this.ComboBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.typeList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.loadFrom = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\..\MainWindow\MainWindow.xaml"
            this.loadFrom.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 60 "..\..\..\MainWindow\MainWindow.xaml"
            this.loadFrom.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.loadTo = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\..\MainWindow\MainWindow.xaml"
            this.loadTo.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 66 "..\..\..\MainWindow\MainWindow.xaml"
            this.loadTo.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.fluxFrom = ((System.Windows.Controls.TextBox)(target));
            
            #line 72 "..\..\..\MainWindow\MainWindow.xaml"
            this.fluxFrom.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 72 "..\..\..\MainWindow\MainWindow.xaml"
            this.fluxFrom.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.fluxTo = ((System.Windows.Controls.TextBox)(target));
            
            #line 78 "..\..\..\MainWindow\MainWindow.xaml"
            this.fluxTo.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 78 "..\..\..\MainWindow\MainWindow.xaml"
            this.fluxTo.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.colorTemperatureList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 83 "..\..\..\MainWindow\MainWindow.xaml"
            this.colorTemperatureList.LostFocus += new System.Windows.RoutedEventHandler(this.colorTemperatureList_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.photometricWebList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.treeViewLFF = ((System.Windows.Controls.TreeView)(target));
            
            #line 107 "..\..\..\MainWindow\MainWindow.xaml"
            this.treeViewLFF.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.treeViewLFF_SelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.applyButton = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\..\MainWindow\MainWindow.xaml"
            this.applyButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.insertButton = ((System.Windows.Controls.Button)(target));
            
            #line 127 "..\..\..\MainWindow\MainWindow.xaml"
            this.insertButton.Click += new System.Windows.RoutedEventHandler(this.InsertButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

