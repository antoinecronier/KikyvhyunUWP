using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Media;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.System.Display;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Kikyvhyun.Utils.Camera
{
    public class CameraManager
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        MediaCapture mediaCapture;
        LowLagMediaRecording mediaRecording;
        StorageFile currentVideo;
        StorageFile currentPhoto;
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #region Singleton
        private static CameraManager instance;

        private CameraManager()
        {
        }

        public static CameraManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CameraManager();
                }
                return instance;
            }
        }

        #endregion
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public async Task Init()
        {
            if (mediaCapture == null)
            {
                mediaCapture = new MediaCapture();
                await mediaCapture.InitializeAsync();
            }
        }
        #region Pick
        public async Task<SoftwareBitmap> TakePick()
        {
            await Init();
            var lowLagCapture = await mediaCapture.PrepareLowLagPhotoCaptureAsync(ImageEncodingProperties.CreateUncompressed(MediaPixelFormat.Bgra8));

            var capturedPhoto = await lowLagCapture.CaptureAsync();
            var softwareBitmap = capturedPhoto.Frame.SoftwareBitmap;

            await lowLagCapture.FinishAsync();

            return softwareBitmap;
        }

        public async Task<SoftwareBitmap> TakePickWithUIOverlay()
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            StorageFolder destinationFolder =
                await ApplicationData.Current.LocalFolder.CreateFolderAsync("ProfilePhotoFolder",
            CreationCollisionOption.OpenIfExists);

            currentPhoto = await photo.CopyAsync(destinationFolder, "ProfilePhoto.jpg", NameCollisionOption.ReplaceExisting);
            await photo.DeleteAsync();

            IRandomAccessStream stream = await currentPhoto.OpenAsync(FileAccessMode.Read);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();

            return softwareBitmap;
        }

        public async Task<SoftwareBitmapSource> ToBitmapSource(SoftwareBitmap softwareBitmap)
        {
            SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap,
            BitmapPixelFormat.Bgra8,
            BitmapAlphaMode.Premultiplied);

            SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
            await bitmapSource.SetBitmapAsync(softwareBitmapBGR8);

            return bitmapSource;
        }
        #endregion

        #region Video
        public async void SetCaptureSource(CaptureElement element)
        {
            await Init();
            element.Source = mediaCapture;
            await mediaCapture.StartPreviewAsync();
        }

        public async void TakeVideo()
        {
            await Init();
            StorageFolder destinationFolder =
                await ApplicationData.Current.LocalFolder.CreateFolderAsync("VideoFolder",
            CreationCollisionOption.OpenIfExists);

            //var myVideos = await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Videos);
            //currentVideo = await myVideos.SaveFolder.CreateFileAsync("video.mp4", CreationCollisionOption.GenerateUniqueName);
            currentVideo = await destinationFolder.CreateFileAsync("video.mp4", CreationCollisionOption.GenerateUniqueName);

            mediaRecording = await mediaCapture.PrepareLowLagRecordToStorageFileAsync(
                    MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Auto), currentVideo);
            mediaCapture.RecordLimitationExceeded += MediaCapture_RecordLimitationExceeded;
            await mediaRecording.StartAsync();
            OnVideoStartEvent(new EventArgs());
        }

        public async void StopVideo()
        {
            if (mediaCapture.CameraStreamState == Windows.Media.Devices.CameraStreamState.Streaming)
            {
                await mediaRecording.StopAsync();
                await mediaRecording.FinishAsync();
                OnVideoEndEvent(new EventArgs());
            }
        }

        private async void MediaCapture_RecordLimitationExceeded(MediaCapture sender)
        {
            await mediaRecording.StopAsync();
            OnVideoEndEvent(new EventArgs());
        }
        #endregion

        #endregion

        #region Events
        public event EventHandler VideoStartEvent;

        protected virtual void OnVideoStartEvent(EventArgs e)
        {
            EventHandler handler = VideoStartEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler VideoEndEvent;

        protected virtual void OnVideoEndEvent(EventArgs e)
        {
            EventHandler handler = VideoEndEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
    }
}
