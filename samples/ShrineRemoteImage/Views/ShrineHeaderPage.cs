using System;
using UIKit;
using Foundation;
using ShrineRemoteImage;
using CoreFoundation;

namespace ShrineRemoteImage.iOS.View
{
    public class ShrineHeaderPage
    {
        UIColor textColor = new UIColor(10 / 255, 49 / 255, 66 / 255, 1f);
        UIFont fontAbril = UIFont.FromName("AbrilFatface-Regular", 36);
        UIFont fontHelvetica = UIFont.FromName("Helvetica", 14);
        UIColor cyanBoxolor = new UIColor(0.19f, 0.94f, 0.94f, 1f);
        UIColor descColor = new UIColor(0.54f, 1f);
        String descString = "Leave the tunnel and the rain is fallin amazing things happen when you wait";

        RemoteImageService remoteImageService = RemoteImageService.Instance;


        UIView page;
        UIView imageView;
        UILabel label;
        UILabel labelDesc;
        UIView cyanBox;
        String imageName;
        String description;

        public ShrineHeaderPage(UIView page, UIImageView imageView, UILabel label,
                                UILabel labelDesc, UIView cyanBox, String imageName,
                               String description)
        {
            this.page = page;
            this.imageView = imageView;
            this.label = label;
            this.labelDesc = labelDesc;
            this.cyanBox = cyanBox;
            this.imageName = imageName;
            this.description = description;

            imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            imageView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            page.AddSubview(imageView);

            var url = new NSUrl(ShrineData.baseURL + imageName);

            remoteImageService.FetchImageAndThumbNail(url,(UIImage image, UIImage thumbnailImage) => {
                DispatchQueue.MainQueue.DispatchAsync(() => {
                        imageView.Image = image;
                        imageView.SetNeedsDisplay();
                });
            });

            label.Font = fontAbril;
            label.TextColor = textColor;
            label.LineBreakMode = UILineBreakMode.WordWrap;
            label.Lines = 2;
            label.AttributedText = AttributedString(description, 0.0f);
            label.SizeToFit();
            page.AddSubview(label);

            labelDesc.Font = fontHelvetica;
            labelDesc.TextColor = textColor;
            labelDesc.LineBreakMode = UILineBreakMode.WordWrap;
            labelDesc.Lines = 3;
            labelDesc.AttributedText = AttributedString(descString, 1.2f);
            labelDesc.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            page.AddSubview(labelDesc);

            cyanBox.BackgroundColor = cyanBoxolor;
            page.AddSubview(cyanBox);

            var inkoverLay = new ShrineInkOverlay(page.Bounds);
            inkoverLay.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;
            
            page.AddSubview(inkoverLay);
        }

        NSMutableAttributedString AttributedString(String stringValue,
                                                  nfloat linHeightMultiple) {
            var paragraphStyle = new NSMutableParagraphStyle();
            paragraphStyle.LineHeightMultiple = linHeightMultiple;

            var attrString = new NSMutableAttributedString(stringValue);

            attrString.AddAttribute(UIStringAttributeKey.ParagraphStyle,paragraphStyle,
                                    new NSRange(0, attrString.Length));
            return attrString;
        }
    }
}
