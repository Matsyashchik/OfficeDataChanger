using System;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using System.Collections.ObjectModel;
using UWPOfficeDataChanger;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPOfficeDataChanger
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        FileWorker fileWorker = new FileWorker();
        FileData thisFileData;
        ObservableCollection<string> documentList = new ObservableCollection<string>();
        DateTime creationTime = new DateTime();
        public MainPage()
        {
            this.InitializeComponent();
            FileList.ItemsSource = documentList;
        }

        //public enum FileTypes : string
        //{
        //    Word = ".doc",
        //    WordNew = ".docx',
        //    Excel =".xls",
        //    ExcelNew = ".xlsx",
        //    ExcelMacros = ".xlsm"
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var r = CreateTime;
            //datePicker.Focus(FocusState.Pointer);
            //datePicker.Focus(FocusState.Programmatic);
            //var picker = new Windows.Storage.Pickers.FileOpenPicker();
            //picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            //Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            var x = CreateTime.Template.TargetType;
        }

        private async void Grid_DropAsync(object sender, DragEventArgs e)
        {
            //FileTypes s = FileTypes.;
            var x = sender;
            var z = e;
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        var storageFile = item as StorageFile;
                        //if (storageFile.FileType )
                        //{
                            
                        //}
                        documentList.Add(storageFile.Path);
                        //SetFileData(fileWorker.LoadFile(storageFile.Path));
                    }
                    
                }
            }
        }

        private void SetFileData(FileData data)
        {
            thisFileData = data;
            var x = CreateTime;
        }

        private bool isSupportedExtension(string extencion)
        {
            //foreach (var fileType in FileTypes)
            //{
            //    if (extencion == fileType)
            //    {

            //    }
            //}
            return true;
        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {
            //To specifies which operations are allowed    
            e.AcceptedOperation = DataPackageOperation.Link;
            e.DragUIOverride.Caption = "добавить файл";
            e.DragUIOverride.IsGlyphVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsCaptionVisible = true;
        }

        private void datePicker_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Flyout flyout = new Flyout();
            flyout.ShowAt(sender as FrameworkElement);

        }

        private void FileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void timePickerFlyout_Closing(FlyoutBase sender, FlyoutBaseClosingEventArgs args)
        {
            SetDateTime(sender.Target.Tag, (sender as TimePickerFlyout).Time);
        }

        private void SetDateTime(object tag, TimeSpan time)
        {
            string timeType = tag.ToString();
            switch (timeType)
            {
                case "CreateTime":
                    creationTime = new DateTime(creationTime.Year, creationTime.Month, creationTime.Day, time.Hours, time.Minutes, time.Seconds);
                    break;
                default:
                    break;

            }
        }

        private void SetDateTime(object tag, DateTime date)
        {
            string dateType = tag.ToString();
            switch (dateType)
            {
                case "CreateTime":
                    creationTime = new DateTime(date.Year, date.Month, date.Day, creationTime.Hour, creationTime.Minute, creationTime.Second);
                    break;
                default:
                    break;

            }
        }

        private void datePicker_Closing(FlyoutBase sender, FlyoutBaseClosingEventArgs args)
        {
            //var s = sender.Target.Tag;
            SetDateTime(sender.Target.Tag, (sender as DatePickerFlyout).Date.Date);
            var d = (sender as DatePickerFlyout).Date.Date;

        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ModifyTime_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
        }

        
    }
}
