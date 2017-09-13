using System;
using Foundation;
using UIKit;
using MaterialComponents.MaterialCollections;
using MaterialComponents.MaterialFlexibleHeader;
using MaterialComponents.MaterialInk;
using MaterialComponents;

using Pesto.Model;
using System.Drawing;
using CoreGraphics;
using System.Linq;
using System.Security.Policy;
using MaterialComponents.MaterialShadowLayer;
using MaterialComponents.ShadowElevation;
using CoreAnimation;

namespace Pesto.Views
{
    [Register("PestoCollectionViewController")]
    public class PestoCollectionViewController : MDCCollectionViewController
    {
        static nfloat AnimationDuration = 0.33f;
        static nfloat CellHeight = 330f;
        static nfloat DefaultHeaderHeight = 240f;
        static nfloat Inset = 5f;
        static nfloat SmallHeaderHeight = 76f;

        nfloat logoScale;
        MDCInkTouchController inkTouchController;
        PestoData pestoData;

        UIView logoSmallView;
        UIView logoView;

        public MDCFlexibleHeaderShadowIntensityChangeBlock ShadowDelegate;


        static readonly NSString cellId = new NSString("PestoCardCollectionViewCell");

        nfloat scrollOffsetY;
        public DidSelectCellDelegate Delegate;


        MDCFlexibleHeaderContainerViewController flexHeaderContainerVC;
        public MDCFlexibleHeaderContainerViewController FlexHeaderContainerVC
        {
            get => flexHeaderContainerVC;
            set
            {
                this.flexHeaderContainerVC = value;
                var headerView = this.flexHeaderContainerVC.HeaderViewController.HeaderView;
                headerView.TrackingScrollView = this.CollectionView;
                headerView.MaximumHeight = DefaultHeaderHeight;
                headerView.MinimumHeight = SmallHeaderHeight;
                headerView.AddSubview(PestoHeaderView());

                var shadowLayer = MDCShadowLayer.Create();

                headerView.SetShadowLayer(shadowLayer, this.ShadowIntensityChangeBlock); /*(CALayer layer, nfloat intensity) =>
                {
                    var elevation = Elevation.MDCShadowElevationAppBar * intensity;
                    (layer as MDCShadowLayer).Elevation = elevation;
                });*/
            }
        }

        public void  ShadowIntensityChangeBlock(CALayer layer, nfloat intensity)
        {

            if (layer is MDCShadowLayer)
            {
                var elevation = Elevation.MDCShadowElevationAppBar * intensity;
                (layer as MDCShadowLayer).Elevation = elevation;
            }
        }

        [Export("initWithCollectionViewLayout:")]
        public PestoCollectionViewController(UICollectionViewLayout layout) : base (layout)
        {
            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.RegisterClassForCell(typeof(PestoCardCollectionViewCell), cellId);

            pestoData = new PestoData();

        }

        public PestoCollectionViewController() : base() {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var styler = this.Styler;
            styler.CellStyle = MDCCollectionViewCellStyle.Card;
            //styler.CellLayoutType = MDCCollectionViewCellLayoutType.Grid;
            //styler.GridPadding = Inset;

            if (View.Frame.Size.Width < View.Frame.Size.Height) {
                styler.GridColumnCount = 1;
            } else {
                styler.GridColumnCount = 2;
            }
        }

        public override void ViewWillTransitionToSize(CoreGraphics.CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            //base.ViewWillTransitionToSize(toSize, coordinator);
            if (toSize.Width < toSize.Height) {
                Styler.GridColumnCount = 1;
            } else {
                Styler.GridColumnCount = 2;
            }
            CollectionView.CollectionViewLayout.InvalidateLayout();
            CenterHeaderWithSize(toSize);

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            CollectionView.CollectionViewLayout.InvalidateLayout();
            CenterHeaderWithSize(View.Frame.Size);
        }


        [Export("collectionView:didSelectItemAtIndexPath:")]
        public override void DidSelectItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath) {
            base.DidSelectItemAtIndexPath(collectionView, indexPath);
            var cell = this.GetCell(collectionView, indexPath);
            //FIXME: this.
            if (cell is PestoCardCollectionViewCell)
            {
                this.Delegate(cell as PestoCardCollectionViewCell, () => { });
            }
            Console.WriteLine("DidSelectItemAtIndexPath\n");
        }

        [Export("collectionView:cellHeightAtIndexPath:")]
        public override nfloat CellHeightAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return CellHeight;
        }
        [Export("collectionView:cellForItemAtIndexPath:")]
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (PestoCardCollectionViewCell)collectionView.DequeueReusableCell(cellId, indexPath);
            if (cell == null)
            {
                return new UICollectionViewCell(CGRect.Empty);
            }

            var itemNum = indexPath.Row;
            NSUrl baseURL = new NSUrl(PestoData.DataBaseURL);

            var imageURLString = baseURL + pestoData.imageFileNames[itemNum];

            NSUrl imageURL = new NSUrl(imageURLString);

            var title = pestoData.titles[itemNum];
            var author = pestoData.authors[itemNum];
            var iconName = pestoData.iconNames[itemNum];

            cell.descText = pestoData.descriptions[itemNum];
            cell.PopulateContent(title, author, imageURL, iconName);

            return cell;
        }


        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1; //pestoData.imageFileNames.Count();
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return pestoData.imageFileNames.Count();
        }

        UIView PestoHeaderView()
        {
            var headerFrame = flexHeaderContainerVC.HeaderViewController.HeaderView.Bounds;
            var pestoHeaderView = new UIView(headerFrame);

            UIColor teal = new UIColor(0f, 0.67f, 0.55f, 1f);

            pestoHeaderView.BackgroundColor = teal;
            pestoHeaderView.Layer.MasksToBounds = true;
            pestoHeaderView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;

            var image = UIImage.FromBundle("PestoLogoLarge");
            logoView = new UIImageView(image);

            logoView.Center = new CGPoint(pestoHeaderView.Frame.Size.Width / 2f,
                                          pestoHeaderView.Frame.Size.Height / 2f);
            pestoHeaderView.AddSubview(logoView);

            var logoSmallImage = UIImage.FromBundle("PestoLogoSmall");
            logoSmallView = new UIImageView(logoSmallImage);

            logoSmallView.ContentMode = UIViewContentMode.ScaleAspectFill;
            logoSmallView.Layer.Opacity = 0f;

            pestoHeaderView.AddSubview(logoSmallView);

            inkTouchController = new MDCInkTouchController(pestoHeaderView);
            inkTouchController.AddInkView();
            return pestoHeaderView;
        }


        void CenterHeaderWithSize(CGSize size)
        {
            var statusBarHeight = UIApplication.SharedApplication.StatusBarFrame.Size.Height;
            var width = size.Width;

            var headerFrame = flexHeaderContainerVC.HeaderViewController.HeaderView.Bounds;
            if (logoView != null & logoSmallView != null)
            {
                logoView.Center = new CGPoint(width / 2f, headerFrame.Size.Height / 2f);
                logoSmallView.Center = new CGPoint(width / 2f,
                                                   (headerFrame.Size.Height - statusBarHeight) / 2f + statusBarHeight);
            }

        }

        // MARK: UIScrollViewDelegate
        public override void Scrolled(UIScrollView scrollView)
        {
            //base.Scrolled(scrollView);
            flexHeaderContainerVC.HeaderViewController.Scrolled(scrollView);
            scrollOffsetY = scrollView.ContentOffset.Y;
            if (logoView == null | logoSmallView == null) {
                return;
            }
            CenterHeaderWithSize(View.Frame.Size);
            logoScale = scrollView.ContentOffset.Y / -DefaultHeaderHeight;

            if (logoScale < 0.5f) {
                logoScale = 0.5f;
                UIView.AnimateNotify(AnimationDuration,
                                     0f,
                                     UIViewAnimationOptions.CurveEaseOut,
                                     () =>
                                     {
                                         logoView.Layer.Opacity = 0;
                                         logoSmallView.Layer.Opacity = 1f;
                                     }, 
                                     new UICompletionHandler((bool finished) => {}));
            } else {
                UIView.AnimateNotify(AnimationDuration,
                                     0f,
                                     UIViewAnimationOptions.CurveEaseOut,
                                     () =>
                                     {
                                         logoView.Layer.Opacity = 1f;
                                         logoSmallView.Layer.Opacity = 0;
                                     },
                                     new UICompletionHandler((bool finished) => { }));                
            }

            logoView.Transform = CGAffineTransform.MakeScale(logoScale, logoScale);

        }

    }
}
