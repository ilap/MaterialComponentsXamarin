
using System;
using Foundation;
using UIKit;
using CoreFoundation;
using CoreGraphics;

namespace ShrineRemoteImage.iOS
{
    public class RemoteImageService
    {
        NSCache dataCache = new NSCache();
        NSCache imageCache = new NSCache();
        NSCache thumbnailImageCache = new NSCache();
        NSCache networkImageRequested = new NSCache();

        private static RemoteImageService instance;

        private RemoteImageService() {}

        public static RemoteImageService Instance 
        {
            get
            {
                if (instance == null) {
                    instance = new RemoteImageService();
                }
                return instance;
            }
        }

        public delegate void FetchImage(UIImage image, UIImage thumnNail);

        UIImage FetchImageFromURL(NSUrl url) {

            var image = (UIImage)imageCache.ObjectForKey(url);
            if (image != null) {
                return image;
            } else {
                image = (UIImage)networkImageRequested.ObjectForKey(NSObject.FromObject(url.AbsoluteString));
                if (image != null) {
                    return null;
                } else {
                    networkImageRequested.SetObjectforKey(url, NSObject.FromObject(url.AbsoluteString));
                }
            }

            NSData imageData = NSData.FromUrl(url);
            if (imageData == null) {
                return null;
            }

            dataCache.SetObjectforKey(imageData, url);

            image = UIImage.LoadFromData(imageData);


            if (image != null) {
                imageCache.SetObjectforKey(image, url);
                return image;
            }

            return null;
        }


        public UIImage FetchThumbnailImageFromURL(NSUrl url) {
            var thumbnailImage = (UIImage)thumbnailImageCache.ObjectForKey(url);

            if (thumbnailImage == null) {
                UIImage image = FetchImageFromURL(url);
                if (image == null) {
                    return null;
                }
                //return image;
                thumbnailImage = CreateThumbNailWithImage(image);
                if (thumbnailImage != null) {
                    thumbnailImageCache.SetObjectforKey(thumbnailImage, url);
                }
            }
            return thumbnailImage;
        }

        UIImage CreateThumbNailWithImage (UIImage image) {
            var scaleFactor = 0.2f;
            CGSize scaledSize = new CGSize(image.Size.Width * scaleFactor, 
                                           image.Size.Height * scaleFactor);

            UIImage thumbnailImage = ImageWithImage(image, scaledSize);
            return thumbnailImage;
        }


        public void FetchImageAndThumbNail(NSUrl url, FetchImage d)
        {

            DispatchQueue.GetGlobalQueue(DispatchQueuePriority.Background).DispatchAsync(() =>
            {
                UIImage image = FetchImageFromURL(url);
                //UIImage thumbnailImage = FetchThumbnailImageFromURL(url);
                //UIImage thumbnailImage = null;

                if (image == null)
                {
                    Console.WriteLine("Image is null");
                }
                d(image, null);
            });
        }

        static UIImage ImageWithImage(UIImage image, CGSize newSize) {

            var rect = new CGRect(0, 0, newSize.Width, newSize.Height);
            UIGraphics.BeginImageContextWithOptions(newSize, false, 0);
            image.DrawAsPatternInRect(rect);

            UIImage newImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return newImage;
        }
    }
}
