// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ShrineXamarin
{
    [Register ("ProductCollectionViewCell")]
    partial class ProductCollectionViewCell
    {
        void ReleaseDesignerOutlets ()
        {
            if (cellImageView != null) {
                cellImageView.Dispose ();
                cellImageView = null;
            }

            if (favoriteButton != null) {
                favoriteButton.Dispose ();
                favoriteButton = null;
            }

            if (priceLabel != null) {
                priceLabel.Dispose ();
                priceLabel = null;
            }
        }
    }
}
