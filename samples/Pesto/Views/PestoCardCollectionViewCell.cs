using System;
using MaterialComponents.MaterialCollections;
using UIKit;
using Foundation;
using CoreGraphics;
using Pesto.Service;

namespace Pesto.Views
{
    public class PestoCardCollectionViewCell : MDCCollectionViewCell
    {
        public String title;
        public String iconImageName;
        public String descText;
        public UIImage image;

        nfloat PestoCardPadding = 15f;
        nfloat PestoCardIconSice = 72f;

        UIImageView iconImageView;
        UIImageView thumbnailImageView;
        UILabel authorLabel;
        UILabel titleLabel;
        UILabel cellView;

        PestoRemoteImageService imageService;

        [Export("initWithFrame:")]
        public PestoCardCollectionViewCell(CGRect frame) : base (frame)
        {
            BackgroundColor = UIColor.Clear;
            imageService = PestoRemoteImageService.Instance;
            CommonInit();
            
        }

        public void CommonInit() {
                
        }

        public void PopulateContent(String title, String author, NSUrl imageUrl,
                              String iconName) {
            this.title = title;
            this.titleLabel.Text = title;
            this.authorLabel.Text = author;
            this.iconImageName = iconName;

            var iconFrame = new CGRect(0, 0, 32, 32);

        }
    }
}
