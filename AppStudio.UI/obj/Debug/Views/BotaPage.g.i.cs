﻿#pragma checksum "D:\Oltion\APLIKACIONE\VetemShqip\AppStudio.UI\Views\BotaPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5D6BC09C3A478D83A06D385034D251AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Cimbalino.Phone.Toolkit.Behaviors;
using Microsoft.Phone.Controls;
using SOMAWP8;
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


namespace AppStudio {
    
    
    public partial class BotaPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Cimbalino.Phone.Toolkit.Behaviors.ApplicationBarBehavior appBar;
        
        internal Microsoft.Phone.Controls.Panorama Container;
        
        internal Microsoft.Phone.Controls.PanoramaItem BotaItem;
        
        internal SOMAWP8.SomaAdViewer SmaatoAd;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/AppStudio;component/Views/BotaPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.appBar = ((Cimbalino.Phone.Toolkit.Behaviors.ApplicationBarBehavior)(this.FindName("appBar")));
            this.Container = ((Microsoft.Phone.Controls.Panorama)(this.FindName("Container")));
            this.BotaItem = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("BotaItem")));
            this.SmaatoAd = ((SOMAWP8.SomaAdViewer)(this.FindName("SmaatoAd")));
        }
    }
}

