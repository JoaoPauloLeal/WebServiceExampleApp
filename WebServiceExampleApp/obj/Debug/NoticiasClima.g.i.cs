﻿#pragma checksum "C:\Users\evandro\Desktop\WebServiceExampleApp\WebServiceExampleApp\NoticiasClima.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9E3D3F17C7DFECB173D427A907B12D5F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WebServiceExampleApp {
    
    
    public partial class NoticiasClima : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button loadFeedButton;
        
        internal System.Windows.Controls.ProgressBar progress;
        
        internal System.Windows.Controls.ListBox feedListBox;
        
        internal System.Windows.Controls.Border border1;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/WebServiceExampleApp;component/NoticiasClima.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.loadFeedButton = ((System.Windows.Controls.Button)(this.FindName("loadFeedButton")));
            this.progress = ((System.Windows.Controls.ProgressBar)(this.FindName("progress")));
            this.feedListBox = ((System.Windows.Controls.ListBox)(this.FindName("feedListBox")));
            this.border1 = ((System.Windows.Controls.Border)(this.FindName("border1")));
        }
    }
}

