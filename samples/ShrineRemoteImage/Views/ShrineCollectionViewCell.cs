using System;
using Foundation;
using UIKit;
using CoreGraphics;
using CoreFoundation;

namespace ShrineRemoteImage.iOS.View
{
    [Register("ShrineCollectionViewCell")]
    public class ShrineCollectionViewCell : UICollectionViewCell 
    {
        UIImageView imageView = new UIImageView();
        UIImageView avatarView = new UIImageView();

        UILabel label = new UILabel();
        UILabel labelAvatar = new UILabel();
        UILabel labelPrice = new UILabel();
        UIView cellContent = new UIView();

        ShrineInkOverlay shrineInkOverlay = new ShrineInkOverlay();
        RemoteImageService remoteImageService = RemoteImageService.Instance;


        [Export("initWithFrame:")]
        public ShrineCollectionViewCell(CGRect frame) : base(frame)
        {

            cellContent.Frame = Bounds;
            cellContent.BackgroundColor = UIColor.White;
            cellContent.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;
            cellContent.ClipsToBounds = true;

            imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            imageView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;
            cellContent.AddSubview(imageView);

            avatarView.Layer.CornerRadius = 12;
            avatarView.BackgroundColor = UIColor.LightGray;
            avatarView.ClipsToBounds = true;
            cellContent.AddSubview(avatarView);

            labelAvatar.LineBreakMode = UILineBreakMode.WordWrap;
            labelAvatar.TextColor = UIColor.Gray;
            labelAvatar.Lines = 1;
            labelAvatar.Font = UIFont.FromName("Helvetica", 14);
            cellContent.AddSubview(labelAvatar);

            labelPrice.LineBreakMode = UILineBreakMode.WordWrap;
            labelPrice.Font = UIFont.FromName("Helvetica-Bold", 16);
            cellContent.AddSubview(labelPrice);

            shrineInkOverlay.Frame = Bounds;
            shrineInkOverlay.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;
            cellContent.AddSubview(shrineInkOverlay);

        }

        public ShrineCollectionViewCell() : base()
        {
            Console.WriteLine("From Base\n");

        }

        public ShrineCollectionViewCell(IntPtr handle) : base(handle)
        {

            Console.WriteLine("From Base Frame\n");

        }

        public override void ApplyLayoutAttributes(UICollectionViewLayoutAttributes layoutAttributes)
        {
            base.ApplyLayoutAttributes(layoutAttributes);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.AddSubview(cellContent);

            var imagePad = 40f;
            imageView.Frame = new CGRect(imagePad, imagePad, 
                                         Frame.Size.Width - imagePad * 2,
                                         Frame.Size.Height - 10 - imagePad * 2);

            var avatarDim = 24f;
            avatarView.Frame = new CGRect(10,
                                      Frame.Size.Height - avatarDim - 10,
                                      avatarDim,
                                      avatarDim);

            labelAvatar.Frame = new CGRect(15 + avatarDim,
                                            Frame.Size.Height - 30,
                                            Frame.Size.Width,
                                            16);

            labelPrice.SizeToFit();
            labelPrice.Frame = new CGRect(Frame.Size.Width - labelPrice.Frame.Size.Width - 10,
                                          10,
                                          labelPrice.Frame.Size.Width,
                                          labelPrice.Frame.Size.Height);
            
        }

        public void PopulateCell(String title, String imageName, String avatarName,
                  String shoptTitle, String price)
        {
            labelAvatar.Text = shoptTitle;
            labelPrice.Text = price;

            var urlString = ShrineData.baseURL + imageName;
            var url = new NSUrl(urlString);

            remoteImageService.FetchImageAndThumbNail(url, (UIImage image, UIImage thumbnailImage) => {
                DispatchQueue.MainQueue.DispatchSync(() => {
                    // FIXME: ThumbnailImage does not work
                        this.imageView.Image = image;
                        this.imageView.SetNeedsDisplay();
                });
            });

            var avatarUrlString = ShrineData.baseURL + avatarName;
            var avatarUrl = new NSUrl(avatarUrlString);

            remoteImageService.FetchImageAndThumbNail(avatarUrl, (UIImage image, UIImage thumbnailImage) => {
                DispatchQueue.MainQueue.DispatchSync(() => {
                    // FIXME: ThumbnailImage does not work
                        this.avatarView.Image = image;
                        this.avatarView.SetNeedsDisplay();
                });
            });
        }
    }
}
