using System;
using System.Linq;
using System.Collections.Generic;

using Foundation;
using UIKit;
using CoreGraphics;


using MaterialComponents;
using MaterialComponents.MaterialAppBar;
using MaterialComponents.MaterialCollections;
using MaterialComponents.MaterialSnackbar;

using ShrineXamarin.Model;

namespace ShrineXamarin
{
    public partial class ProductGridViewController : MDCCollectionViewController
    {
        [Outlet]
        public ShrineXamarin.HomeHeaderView headerContentView { get; set; }

        [Outlet]
        public UIKit.UIImageView shrineLogo { get; set; }

        public Boolean isHome = false;

        public List<Product> products = new List<Product>();
        MDCAppBar appBar = new MDCAppBar();

        static readonly NSString cellId = new NSString("cell");

        public ProductGridViewController (IntPtr handle) : base (handle) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            CollectionView.ContentInset = 
                new UIEdgeInsets(0, 0, 
                                 TabBarController.TabBar.Bounds.Size.Height, 0);

            AddChildViewController(appBar.HeaderViewController);
            appBar.AddSubviewsToParent();
            appBar.HeaderViewController.HeaderView.TrackingScrollView = 
                CollectionView;
            appBar.HeaderViewController.HeaderView.BackgroundColor = 
                UIColor.White;
            appBar.HeaderViewController.HeaderView.MaximumHeight = 440;
            appBar.HeaderViewController.HeaderView.MinimumHeight = 72;

            if (isHome) {
                SetupHeaderContentView();
                SetupHeaderLogo();
            }
            Title = TabBarItem.Title;

            Styler.CellStyle = MDCCollectionViewCellStyle.Card;
            Styler.CellLayoutType = MDCCollectionViewCellLayoutType.Grid;
            Styler.GridPadding = 8;

            UpdateLayout();

        }

        public override void ViewWillAppear(bool animated) {
            base.ViewWillAppear(animated);
            UpdateLayout();
        }

        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator) {
            base.ViewWillTransitionToSize(toSize, coordinator);
            UpdateLayout();
        }

        public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection) {
            base.TraitCollectionDidChange(previousTraitCollection);
            UpdateLayout();
        }

        void SetupHeaderContentView() {
            appBar.HeaderViewController.HeaderView.AddSubview(headerContentView);
            headerContentView.Frame = appBar.HeaderViewController.HeaderView.Frame;
            headerContentView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
        }

        void SizeHeaderView() {
            var headerView = appBar.HeaderViewController.HeaderView;

            var bounds = UIScreen.MainScreen.Bounds;

            if (isHome && bounds.Size.Width < bounds.Size.Height) {
                headerView.MaximumHeight = 440;
            } else {
                headerView.MaximumHeight = 72;
            }
            headerView.MinimumHeight = 72;
        }

        void UpdateLayout() {
            
            SizeHeaderView();

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == 
                UIUserInterfaceIdiom.Pad) {
                Styler.GridColumnCount = 5;
            } else {
                switch (TraitCollection.HorizontalSizeClass) {

                    case UIUserInterfaceSizeClass.Compact:
                        Styler.GridColumnCount = 2;
                        break;
                    case UIUserInterfaceSizeClass.Unspecified:
                    case UIUserInterfaceSizeClass.Regular:
                        Styler.GridColumnCount = 4;
                        break;
                }
            }
        }

        void SetupHeaderLogo() {
            var logo = shrineLogo;
            appBar.HeaderViewController.HeaderView.AddSubview(logo);
            logo.TopAnchor.ConstraintEqualTo(logo.Superview.TopAnchor, 24).Active = true;
            logo.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            logo.TranslatesAutoresizingMaskIntoConstraints = false;
            logo.Alpha = 0;
        }

        // MARK: Collectionviews
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)  {

            var cell  = (ProductCollectionViewCell)collectionView.DequeueReusableCell(cellId, indexPath);

            if (cell == null) {
                return new UICollectionViewCell(CGRect.Empty);
            }

            var product = products[(int)indexPath.Item];
            cell.SetProduct(product);

            cell.favoriteButton.Tag = indexPath.Item;
            if (!cell.favoriteButton.AllTargets.Contains(this)) {
                // BUG: Use only Selector as the normal AddTarget does not work. Report a Bug...
                cell.favoriteButton.AddTarget(this, new ObjCRuntime.Selector("onTouchUpInside:"), UIControlEvent.TouchUpInside);
                //cell.favoriteButton.AddTarget(this.OnTouchUpInside, UIControlEvent.TouchUpInside);
            }

            return cell;
        }

        //MARK: Button Did Touchs...

        // BUG: Use only Selector
        // public void OnTouchUpInside(object sender, EventArgs e)
        [Export("onTouchUpInside:")]
        public void OnTouchUpInside(UIButton sender)
        {
            var btn = sender as UIButton;
            if (btn == null) {
                return;
            }
            var product = products[(int)btn.Tag];

            product.IsFavorite = !product.IsFavorite;

            var nt = NSIndexPath.FromItemSection(btn.Tag, 0);

            NSIndexPath[] nipa = new NSIndexPath[1];
            nipa[0] = nt;
            CollectionView.ReloadItems(nipa);

            if (product.IsFavorite) {
                var message = new MDCSnackbarMessage();
                message.Text = "Added to Favorites!";
                MDCSnackbarManager.ShowMessage(message);
            }

        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section) {
            return products.Count();
        }

        public override nfloat CellHeightAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath) {
            //return base.CollectionViewCellHeightAtIndexPath(collectionView, indexPath);
            var w = CollectionView.Bounds.Size.Width;

            var baseHeight = w  - (Styler.GridColumnCount + 1) * Styler.GridColumnCount;
            var adjustment = (5f / 4f) / Styler.GridColumnCount;
            var height = baseHeight * adjustment;
            return height;
        }

        // MARK: UIScrollViewDelegate
        public override void Scrolled(UIScrollView scrollView) {
            //base.Scrolled(scrollView);
            appBar.HeaderViewController.Scrolled(scrollView);
            var scrollOffsetY = scrollView.ContentOffset.Y;
            var opacity = 1f;
            var logoOpacity = 0f;

            if (scrollOffsetY > -240) {
                opacity = 0f;
                logoOpacity = 1f;
            }

            UIView.Animate(0.5, () => {
                this.headerContentView.backgroundImage.Alpha = opacity;
                this.headerContentView.descLabel.Alpha = opacity;
                this.headerContentView.titleLabel.Alpha = opacity;

                this.shrineLogo.Alpha = logoOpacity;
            });
        }

        public override void DecelerationEnded(UIScrollView scrollView) {
            
            if (scrollView == appBar.HeaderViewController.HeaderView.TrackingScrollView) {
                appBar.HeaderViewController.HeaderView.TrackingScrollViewDidEndDecelerating();
            }
        }

        public override void WillEndDragging(UIScrollView scrollView, CoreGraphics.CGPoint velocity, ref CoreGraphics.CGPoint targetContentOffset) {
            var hv = appBar.HeaderViewController.HeaderView;

            if (scrollView == hv.TrackingScrollView) {
                hv.TrackingScrollViewWillEndDraggingWithVelocity(velocity, targetContentOffset);
            }
        }
    }
}
