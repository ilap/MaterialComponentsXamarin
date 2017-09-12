using System;
using Foundation;
using UIKit;
using CoreGraphics;
using CoreFoundation;

namespace Pesto.Service
{
    public class PestoRemoteImageService
    {
        NSCache dataCache = new NSCache();
        NSCache imageCache = new NSCache();
        NSCache thumbnailImageCache = new NSCache();
        NSCache networkImageRequested = new NSCache();

        private static PestoRemoteImageService instance;

        private PestoRemoteImageService() { }

        public static PestoRemoteImageService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PestoRemoteImageService();
                }
                return instance;
            }
        }

        public delegate void FetchImage(UIImage image, UIImage thumbnNail);

        UIImage FetchImageFromURL(NSUrl url)
        {

            var image = (UIImage)imageCache.ObjectForKey(url);
            if (image != null)
            {
                return image;
            }
            else
            {
                // MARK: Do not cast the cache to Image as it will crash.
                // So, get a standard NSObject first and if it's not null then
                // cast to image.
                var urlObj = NSObject.FromObject(url.AbsoluteString);
                var obj = networkImageRequested.ObjectForKey(urlObj);
                if (obj != null)
                {
                    return null;
                }
                else
                {
                    image = (UIImage)obj;
                    networkImageRequested.SetObjectforKey(url, urlObj);
                }
            }

            NSData imageData = NSData.FromUrl(url);
            if (imageData == null)
            {
                return null;
            }

            dataCache.SetObjectforKey(imageData, url);

            image = UIImage.LoadFromData(imageData);

            if (image != null)
            {
                imageCache.SetObjectforKey(image, url);
                return image;
            }

            return null;
        }


        public UIImage FetchThumbnailImageFromURL(NSUrl url)
        {
            var thumbnailImage = (UIImage)thumbnailImageCache.ObjectForKey(url);

            if (thumbnailImage == null)
            {
                UIImage image = FetchImageFromURL(url);
                if (image == null)
                {
                    return null;
                }
                thumbnailImage = CreateThumbNailWithImage(image);
                if (thumbnailImage != null)
                {
                    thumbnailImageCache.SetObjectforKey(thumbnailImage, url);
                }
            }
            return thumbnailImage;
        }

        UIImage CreateThumbNailWithImage(UIImage image)
        {
            var scaleFactor = 0.2f;
            CGSize scaledSize = new CGSize(image.Size.Width * scaleFactor,
                                           image.Size.Height * scaleFactor);

            UIImage thumbnailImage = ImageWithImage(image, scaledSize);
            return thumbnailImage;
        }

        public void FetchImageAndThumbNail(NSUrl url, FetchImage d)
        {

            //FIXME: Use the following for debug threads : UIDevice.InvokeInBackground ( () =>
            DispatchQueue.GetGlobalQueue(DispatchQueuePriority.Background).DispatchAsync(() =>
            {
                UIImage image = FetchImageFromURL(url);
                // FIXME: Does not work, UIImage thumbnailImage = FetchThumbnailImageFromURL(url);

                if (image == null)
                {
                    Console.WriteLine("Image is null");
                }
                d(image, null);
            });
        }

        static UIImage ImageWithImage(UIImage image, CGSize newSize)
        {

            var rect = new CGRect(0, 0, newSize.Width, newSize.Height);
            UIGraphics.BeginImageContextWithOptions(newSize, false, 0);
            image.DrawAsPatternInRect(rect);

            UIImage newImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return newImage;
        }
    }
}
