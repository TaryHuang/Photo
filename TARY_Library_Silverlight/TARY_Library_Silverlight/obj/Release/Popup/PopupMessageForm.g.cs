﻿#pragma checksum "C:\Users\Administrator\Desktop\TARY_Library_Silverlight\TARY_Library_Silverlight\Popup\PopupMessageForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7F7BCD2D7A22A87182E01E5D327839FC"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.18033
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace TARY_Library_Silverlight.Popup {
    
    
    public partial class PopupMessageForm : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard ACTION;
        
        internal System.Windows.Media.Animation.Storyboard CloseStory;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid body;
        
        internal System.Windows.Controls.TextBlock title;
        
        internal System.Windows.Controls.TextBlock MsgText;
        
        internal System.Windows.Controls.StackPanel Bottom;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/TARY_Library_Silverlight;component/Popup/PopupMessageForm.xaml", System.UriKind.Relative));
            this.ACTION = ((System.Windows.Media.Animation.Storyboard)(this.FindName("ACTION")));
            this.CloseStory = ((System.Windows.Media.Animation.Storyboard)(this.FindName("CloseStory")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.body = ((System.Windows.Controls.Grid)(this.FindName("body")));
            this.title = ((System.Windows.Controls.TextBlock)(this.FindName("title")));
            this.MsgText = ((System.Windows.Controls.TextBlock)(this.FindName("MsgText")));
            this.Bottom = ((System.Windows.Controls.StackPanel)(this.FindName("Bottom")));
        }
    }
}
