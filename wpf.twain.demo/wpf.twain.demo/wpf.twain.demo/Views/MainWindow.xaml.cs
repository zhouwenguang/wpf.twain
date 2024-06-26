﻿using NTwain;
using NTwain.Data;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace wpf.twain.demo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TwainSession _twain;
        public MainWindow()
        {
            InitializeComponent();
            //Allow old Device DSM drives
            PlatformInfo.Current.PreferNewDSM = false;

            var appId = TWIdentity.CreateFromAssembly(DataGroups.Image, Assembly.GetExecutingAssembly());
            _twain = new TwainSession(appId);

            PlatformInfo.Current.PreferNewDSM = false;
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
                //_twain.GetSources();
                //_twain.SelectSource();
            }
            else if (_twain.State == 3)
            {
                //在此状态下，DSM 已经打开。应用程序可以列出和选择数据源。
                _twain.GetSources();
            }

        }

        /// <summary>
        /// 处理传输准备事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 处理数据传输事件，将图像数据转换为 BitmapImage 并显示在 Image 控件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _twain_DataTransferred(object sender, DataTransferredEventArgs e)
        {
            if (e.NativeData != IntPtr.Zero)
            {
                //e.FileDataPath = e.NativeData;
                var img = e.GetNativeImageStream();
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

        protected override void OnClosed(EventArgs e)
        {
            _twain.Close();
            base.OnClosed(e);
        }
    }
}
