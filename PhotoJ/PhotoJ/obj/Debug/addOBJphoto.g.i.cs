﻿#pragma checksum "C:\Users\Tary\Desktop\2013.03.27提交\PhotoJ\PhotoJ\addOBJphoto.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "71EC529E18D3A3D12EA34A44994512A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.261
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
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


namespace PhotoJ {
    
    
    public partial class addOBJphoto : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid G_TYPE;
        
        internal System.Windows.Controls.Image image1;
        
        internal System.Windows.Controls.Image image2;
        
        internal System.Windows.Controls.Border S_PHOTO;
        
        internal System.Windows.Controls.ScrollViewer G_PHOTO;
        
        internal System.Windows.Controls.Canvas PHOTO;
        
        internal System.Windows.Controls.Button OK;
        
        internal System.Windows.Controls.StackPanel TOOL;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhotoJ;component/addOBJphoto.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.G_TYPE = ((System.Windows.Controls.Grid)(this.FindName("G_TYPE")));
            this.image1 = ((System.Windows.Controls.Image)(this.FindName("image1")));
            this.image2 = ((System.Windows.Controls.Image)(this.FindName("image2")));
            this.S_PHOTO = ((System.Windows.Controls.Border)(this.FindName("S_PHOTO")));
            this.G_PHOTO = ((System.Windows.Controls.ScrollViewer)(this.FindName("G_PHOTO")));
            this.PHOTO = ((System.Windows.Controls.Canvas)(this.FindName("PHOTO")));
            this.OK = ((System.Windows.Controls.Button)(this.FindName("OK")));
            this.TOOL = ((System.Windows.Controls.StackPanel)(this.FindName("TOOL")));
        }
    }
}

