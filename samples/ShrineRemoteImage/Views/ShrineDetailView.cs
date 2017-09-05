using System;
using UIKit;
using CoreGraphics;
using Foundation;
using CoreFoundation;

namespace ShrineRemoteImage.iOS.View
{
    public class ShrineDetailView : UIScrollView
    {
        public String title = "";
        public String desc = "";
        public String imageName = "popsicle.png";

        RemoteImageService remoteImageService = RemoteImageService.Instance;
        UILabel label = new UILabel();
        UILabel labelDesc = new UILabel();
        UIImageView imageView = new UIImageView();

        [Export("initWithFrame:")]
        public ShrineDetailView(CGRect frame) : base(frame) {
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            BackgroundColor = UIColor.White;
            var minContentHeight = 640f;

            ContentSize = new CGSize(Frame.Width, minContentHeight);
            var labelPadding = 50f;

            imageView.Frame = new CGRect(labelPadding, labelPadding,
                                         Frame.Size.Width - 2 * labelPadding,
                                         220);

            imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            imageView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
            AddSubview(imageView);

            var urlString = ShrineData.baseURL + imageName;
            var url = new NSUrl(urlString);

            remoteImageService.FetchImageAndThumbNail(url, (UIImage image, UIImage thumbnailImage) => {
                DispatchQueue.MainQueue.DispatchAsync(() => {
                        this.imageView.Image = image;
                        imageView.SetNeedsDisplay();
                });
            });

            ConfigureTitleLabel(label, labelPadding);
            AddSubview(label);

            ConfigureDescriptionLabel(labelDesc, labelPadding);
            AddSubview(labelDesc);

        }

        void ConfigureTitleLabel(UILabel label, nfloat labelPadding)
        {
            label.Font = UIFont.FromName("AbrilFatface-Regular", 36);
            label.TextColor = new UIColor(0.039f, 0.192f, 0.259f, 1f);
            label.LineBreakMode = UILineBreakMode.WordWrap;
            label.Lines = 2;

            var paragraphStyle = new NSMutableParagraphStyle();
            paragraphStyle.LineHeightMultiple = 0.8f;

            var attrString = new NSMutableAttributedString(title);
            attrString.AddAttribute(UIStringAttributeKey.ParagraphStyle, paragraphStyle,
                                    new NSRange(0, attrString.Length));
            label.AttributedText = attrString;
            label.SizeToFit();
            label.Frame = new CGRect(labelPadding, 280,
                                     label.Frame.Size.Width,
                                     label.Frame.Size.Height);


            label.AutoresizingMask = UIViewAutoresizing.FlexibleHeight |
                UIViewAutoresizing.FlexibleHeight;
        }

        void ConfigureDescriptionLabel(UILabel label, nfloat labelPadding)
        {
            label.Font = UIFont.FromName("Helvetica", 14);
            label.TextColor = new UIColor(0.054f, 1f);
            label.LineBreakMode = UILineBreakMode.WordWrap;
            label.Lines = 5;

            var descParagraphStyle = new NSMutableParagraphStyle();
            descParagraphStyle.LineHeightMultiple = 1.5f;

            var descAttrString = new NSMutableAttributedString(desc);
            descAttrString.AddAttribute(UIStringAttributeKey.ParagraphStyle, descParagraphStyle,
                                    new NSRange(0, descAttrString.Length));
            label.AttributedText = descAttrString;

            label.Frame = new CGRect(labelPadding, 360,
                                     Frame.Size.Width - 2 * labelPadding,
                                     160);

            label.SizeToFit();
            label.AutoresizingMask = UIViewAutoresizing.FlexibleHeight |
                UIViewAutoresizing.FlexibleHeight;
        }
    }
}
