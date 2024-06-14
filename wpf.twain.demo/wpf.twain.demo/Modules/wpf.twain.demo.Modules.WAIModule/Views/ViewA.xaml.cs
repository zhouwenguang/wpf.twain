using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WIA;

namespace wpf.twain.demo.Modules.WAIModule.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewA : UserControl
    {
        public ViewA()
        {
            InitializeComponent();
        }

        private void ScanButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var commonDialog = new CommonDialog();
                var scannerDevice = commonDialog.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
                if (scannerDevice != null)
                {
                    //var scanItem = scannerDevice.Items[1];
                    //var imageFile = (ImageFile)commonDialog.ShowTransfer(scanItem, WIA.FormatID.wiaFormatJPEG, false);
                    //if (imageFile != null)
                    //{
                    //    var filePath = Path.Combine(Path.GetTempPath(), "scannedImage.jpg");
                    //    SaveImageToFile(imageFile, filePath);
                    //    DisplayImage(filePath);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("扫描时发生错误：" + ex.Message);
            }
        }

        private void SaveImageToFile(ImageFile imageFile, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            imageFile.SaveFile(filePath);
        }

        private void DisplayImage(string filePath)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(filePath, UriKind.Absolute);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            //ScannedImage.Source = bitmapImage;
        }
    }
}
