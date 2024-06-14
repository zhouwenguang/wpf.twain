using NTwain;
using NTwain.Data;
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

namespace wpf.twain.demo.Modules.NTwainModule.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewA : UserControl
    {
        private TwainSession _twain;
        public ViewA()
        {
            InitializeComponent();
            _twain = new TwainSession(TWIdentity.CreateFromAssembly(DataGroups.Image, this.GetType().Assembly));
            _twain.TransferReady += _twain_TransferReady;
            _twain.DataTransferred += _twain_DataTransferred;
            _twain.SourceDisabled += _twain_SourceDisabled;
            _twain.TransferError += _twain_TransferError;
            _twain.Open();
        }

        private void ScanButton_Click(object sender, RoutedEventArgs e)
        {
            if (_twain.State == 4)
            {
                //_twain.SelectSource();
            }
        }

        private void _twain_TransferReady(object sender, TransferReadyEventArgs e)
        {
            var src = _twain.CurrentSource;
            if (src != null)
            {
                var pending = e.PendingTransferCount;
                for (int i = 0; i < pending; i++)
                {
                    //src.TransferPictures();
                }
            }
        }

        private void _twain_DataTransferred(object sender, DataTransferredEventArgs e)
        {
            if (e.NativeData != IntPtr.Zero)
            {
                //var img = e.GetNativeImage();
                //if (img != null)
                //{
                //    using (MemoryStream memory = new MemoryStream())
                //    {
                //        img.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                //        memory.Position = 0;
                //        BitmapImage bitmapImage = new BitmapImage();
                //        bitmapImage.BeginInit();
                //        bitmapImage.StreamSource = memory;
                //        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                //        bitmapImage.EndInit();
                //        ScannedImage.Source = bitmapImage;
                //    }
                //}
            }
        }

        private void _twain_TransferError(object sender, TransferErrorEventArgs e)
        {
            MessageBox.Show("Transfer error: " + e.Exception.Message);
        }

        private void _twain_SourceDisabled(object sender, EventArgs e)
        {
            _twain.CurrentSource.Close();
        }

        //protected override onclo

        //protected override void OnClosed(EventArgs e)
        //{
        //    _twain.Close();
        //    base.OnClosed(e);
        //}
    }
}
