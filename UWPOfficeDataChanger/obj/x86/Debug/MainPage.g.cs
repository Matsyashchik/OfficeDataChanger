﻿#pragma checksum "C:\Users\TUNDRA\source\repos\OfficeDataChanger\UWPOfficeDataChanger\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4D20B0D1D1CB44CAC0A9A2E32601433B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UWPOfficeDataChanger
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Drop += this.Grid_DropAsync;
                    ((global::Windows.UI.Xaml.Controls.Page)element1).DragOver += this.Grid_DragOver;
                }
                break;
            case 6: // MainPage.xaml line 36
                {
                    global::Windows.UI.Xaml.Controls.TimePickerFlyout element6 = (global::Windows.UI.Xaml.Controls.TimePickerFlyout)(target);
                    ((global::Windows.UI.Xaml.Controls.TimePickerFlyout)element6).Closing += this.timePickerFlyout_Closing;
                }
                break;
            case 7: // MainPage.xaml line 31
                {
                    global::Windows.UI.Xaml.Controls.DatePickerFlyout element7 = (global::Windows.UI.Xaml.Controls.DatePickerFlyout)(target);
                    ((global::Windows.UI.Xaml.Controls.DatePickerFlyout)element7).Closing += this.datePicker_Closing;
                }
                break;
            case 10: // MainPage.xaml line 73
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.Button_Click;
                }
                break;
            case 11: // MainPage.xaml line 77
                {
                    this.CreateTime = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 12: // MainPage.xaml line 86
                {
                    this.ModifyTime = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ModifyTime).Click += this.ModifyTime_Click;
                }
                break;
            case 13: // MainPage.xaml line 104
                {
                    this.FileList = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.FileList).SelectionChanged += this.FileList_SelectionChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

