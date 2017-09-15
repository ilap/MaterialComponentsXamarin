using System;
using MaterialComponents.MaterialCollections;
using UIKit;
using Foundation;
using CoreGraphics;
using Pesto.Service;
using MaterialComponents.MaterialShadowLayer;
using MaterialComponents.ShadowElevation;
using MaterialComponents.MaterialTypography;
using ObjCRuntime;
using CoreFoundation;

namespace Pesto.Views
{
    public class PestoCardCollectionViewCell : MDCCollectionViewCell
    {
        public String title;
        public String iconImageName;
        public String descText;
        public UIImage image;

        nfloat PestoCardPadding = 15f;
        nfloat PestoCardIconSize = 72f;

        UIImageView iconImageView;
        UIImageView thumbnailImageView;
        UILabel authorLabel;
        UILabel titleLabel;
        UIView cellView;

        PestoRemoteImageService imageService;

        [Export("initWithFrame:")]
        public PestoCardCollectionViewCell(CGRect frame) : base (frame)
        {
            // 8,8, 304, 300
            BackgroundColor = UIColor.Clear;
            imageService = PestoRemoteImageService.Instance;
            CommonInit();
            
        }

        public void CommonInit() {
            cellView = new UIView(Bounds);
            cellView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;
            cellView.BackgroundColor = UIColor.White;
            cellView.ClipsToBounds = true;
            AddSubview(cellView);

            var shadowLayer = (MDCShadowLayer)Layer;
            shadowLayer.ShadowMaskEnabled = false;
            shadowLayer.Elevation = Elevation.MDCShadowElevationCardResting;
            //0,0,304, 228
            var imageViewRect = new CGRect(0, 0, Frame.Size.Width, Frame.Size.Height - PestoCardIconSize);
            thumbnailImageView = new UIImageView(imageViewRect);
            thumbnailImageView.BackgroundColor = UIColor.LightGray;
            thumbnailImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            thumbnailImageView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;
            thumbnailImageView.ClipsToBounds = true;
            cellView.AddSubview(thumbnailImageView);

            // 0, 228, 72,72
            var iconImageViewFrame = new CGRect(0, Frame.Size.Height - PestoCardIconSize,
                                                PestoCardIconSize, PestoCardIconSize);

            iconImageView = new UIImageView(iconImageViewFrame);
            iconImageView.ContentMode = UIViewContentMode.Center;
            iconImageView.Alpha = 0.87f;
            cellView.AddSubview(iconImageView);

            authorLabel = new UILabel();
            authorLabel.Font = MDCTypography.CaptionFont;
            authorLabel.Alpha = MDCTypography.CaptionFontOpacity;
            authorLabel.TextColor = UIColor.FromWhiteAlpha(0.5f, 1f);
            authorLabel.Frame = new CGRect(PestoCardIconSize,
                                           Frame.Size.Height - authorLabel.Font.PointSize - PestoCardPadding,
                                           Frame.Size.Width - iconImageViewFrame.Size.Width,
                                          authorLabel.Font.PointSize + 2f);
            //72,273,232,14
            cellView.AddSubview(authorLabel);

            titleLabel = new UILabel();
            titleLabel.Font = MDCTypography.HeadlineFont;
            titleLabel.Alpha = MDCTypography.HeadlineFontOpacity;
            titleLabel.TextColor = UIColor.FromWhiteAlpha(0, 0.87f);
            titleLabel.Frame = new CGRect(PestoCardIconSize,
                                          authorLabel.Frame.Y - titleLabel.Font.PointSize - PestoCardPadding / 2f,
                                          Frame.Size.Width - iconImageViewFrame.Size.Width,
                                          titleLabel.Font.PointSize + 2f);
            cellView.AddSubview(titleLabel);


               
        }

        public void PopulateContent(String title, String author, NSUrl imageUrl,
                              String iconName) {
            this.title = title;
            this.titleLabel.Text = title;
            this.authorLabel.Text = author;
            this.iconImageName = iconName;

            var iconFrame = new CGRect(0, 0, 32, 32);
            var icon = UIImage.FromBundle("ic_format_color_fill");
            if (iconImageName == "Main")
            {
                icon = UIImage.FromBundle("ic_format_color_fill");
            }
            else if (iconImageName == "Meat")
            {
                icon = UIImage.FromBundle("ic_ac_unit");
            }
            else if (iconImageName == "Spicy")
            {
                icon = UIImage.FromBundle("ic_whatshot");
            }
            else if (iconImageName == "Timer")
            {
                icon = UIImage.FromBundle("ic_alarm");
            }
            else if (iconImageName == "Veggie")
            {
                icon = UIImage.FromBundle("ic_filter_vintage");
            }

            iconImageView.Image = icon;

            imageService.FetchImageAndThumbNail(imageUrl, (UIImage image, UIImage thumbnailImage) => {
                this.image = image;
                DispatchQueue.MainQueue.DispatchSync(() => {
                    // FIXME: ThumbnailImage does not work
                    this.thumbnailImageView.Image = image;
                    this.thumbnailImageView.SetNeedsDisplay();
                });
            });

        }

        public override void PrepareForReuse()
        {
            base.PrepareForReuse();
            title = null;
            image = null;
            thumbnailImageView.Image = null;
        }

        [Export("layerClass")]
        public static Class LayerClass()
        {
            return new Class(typeof(MDCShadowLayer));
        }

    }
}
