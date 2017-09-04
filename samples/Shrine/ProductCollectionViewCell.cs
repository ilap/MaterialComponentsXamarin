using System;

using Foundation;
using UIKit;

using ShrineXamarin.Model;

namespace ShrineXamarin
{
	public partial class ProductCollectionViewCell : UICollectionViewCell
	{
        
        [Outlet]
        public MaterialComponents.MaterialButtons.MDCFlatButton favoriteButton { get; set; }

        [Outlet]
        public UIKit.UIImageView cellImageView { get; set; }

        [Outlet]
        public UIKit.UILabel priceLabel { get; set; }

        Product product;
		
        public ProductCollectionViewCell (IntPtr handle) : base (handle) {
		}

        public override void AwakeFromNib() {
            base.AwakeFromNib();
            favoriteButton.ContentEdgeInsets = UIEdgeInsets.Zero;
            var image = favoriteButton.ImageForState(UIControlState.Normal).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            favoriteButton.SetImage(image, UIControlState.Normal);

            image = favoriteButton.ImageForState(UIControlState.Selected).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            favoriteButton.SetImage(image, UIControlState.Selected);

        }

        public void SetProduct(Product product) {
            this.product = product;
            this.cellImageView.Image = UIImage.FromBundle(product.ImagePath);
            this.favoriteButton.Selected = product.IsFavorite;
            this.priceLabel.Text = product.Price;
        }
	}
}
