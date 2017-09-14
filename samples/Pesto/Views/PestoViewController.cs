using System;
using MaterialComponents.MaterialAppBar;
using MaterialComponents.MaterialFlexibleHeader;
using UIKit;
using Foundation;
using CoreGraphics;
using CoreFoundation;
using CoreAnimation;
using MaterialComponents;
using MaterialComponents.MaterialAnimationTiming;

namespace Pesto.Views
{
    public delegate void DidSelectCellDelegate(PestoCardCollectionViewCell cell, Action completion);

    public class PestoViewController : MDCFlexibleHeaderContainerViewController, IUIViewControllerAnimatedTransitioning, IUIViewControllerTransitioningDelegate
    {
        MDCAppBar appBar;
        public PestoCollectionViewController collectionViewController;
        UIImageView zoomableView;
        UIView zoomableCardView;


        public static PestoViewController InitializeWithController()
        {

            var layout = new UICollectionViewFlowLayout();
            layout.MinimumInteritemSpacing = 0f;

            var sectonInsect = 2f;

            layout.SectionInset = new UIEdgeInsets(sectonInsect, sectonInsect,
                                                   sectonInsect, sectonInsect);

            var collectionVC = new PestoCollectionViewController((UICollectionViewLayout)layout);


            var result = new PestoViewController(collectionVC);

            result.collectionViewController = collectionVC;
            result.collectionViewController.ShadowDelegate = collectionVC.ShadowIntensityChangeBlock;
            result.collectionViewController.FlexHeaderContainerVC = result;
            result.collectionViewController.Delegate = result.DidSelectCell;
                  

            result.appBar = new MDCAppBar();
            result.AddChildViewController(result.appBar.HeaderViewController);

            result.appBar.HeaderViewController.HeaderView.BackgroundColor = UIColor.Clear;
            result.appBar.NavigationBar.TintColor = UIColor.White;

            UIImage icon = UIImage.FromBundle("Settings");
            UIBarButtonItem menuButton = new UIBarButtonItem(icon, UIBarButtonItemStyle.Done, result.DidSelectSettings);

            result.NavigationItem.RightBarButtonItem = menuButton;

            return result;
        }

        protected PestoViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public PestoViewController() : base ()
        {

        }

        [Export("initWithContentViewController:")]
        public PestoViewController(UIViewController controller) : base(controller)
        {
            Console.WriteLine("Initialise with Controller");
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            appBar.AddSubviewsToParent();

            zoomableCardView = new UIView(CGRect.Empty);
            zoomableCardView.BackgroundColor = UIColor.White;
            View.AddSubview(zoomableCardView);

            zoomableView = new UIImageView(CGRect.Empty);
            zoomableView.BackgroundColor = UIColor.LightGray;
            zoomableView.ContentMode = UIViewContentMode.ScaleAspectFill;
            View.AddSubview(zoomableView);

        }

        public void DidSelectCell(PestoCardCollectionViewCell cell, Action completion)
        {
            Console.Write("Ooops! Sorry:)");
            zoomableView.Frame = new CGRect(cell.Frame.X, cell.Frame.Y - collectionViewController.scrollOffsetY,
            cell.Frame.Size.Width, cell.Frame.Size.Height - 50f);

            zoomableCardView.Frame = new CGRect(cell.Frame.X, cell.Frame.Y - collectionViewController.scrollOffsetY,
            cell.Frame.Size.Width, cell.Frame.Size.Height);

            DispatchQueue.MainQueue.DispatchAsync(() => {
                zoomableView.Image = cell.image;
                UIView.AnimateNotify(PestoDetail.AnimationDuration,
                0,
                UIViewAnimationOptions.CurveEaseOut,
                () =>
                {
                    var quantumEaseInOut = MDC_CAMediaTimingFunction.Mdc_functionWithType(MDCAnimationTimingFunction.EaseInOut);
                    CATransaction.AnimationTimingFunction = quantumEaseInOut;
                    var zoomFrame = new CGRect(0, 0, View.Bounds.Size.Width, 320f);
                    zoomableView.Frame = zoomFrame;
                    zoomableCardView.Frame = View.Bounds;
                }, 
                new UICompletionHandler((bool finished) => {
                    var detailVC = new PestoDetailViewController();
                    detailVC.imageView.Image = cell.image;
                    detailVC.Title = cell.title;
                    detailVC.descText = cell.descText;
                    detailVC.iconImageName = cell.iconImageName;
                    
                    PresentViewController(detailVC, false, () => {
                        this.zoomableView.Frame = CGRect.Empty;
                        this.zoomableCardView.Frame = CGRect.Empty;
                        completion();
                        
                    });
                }));
            });
        }

        public IUIViewControllerAnimatedTransitioning GetAnimationControllerForPresentedController(UIViewController presented, UIViewController presenting, UIViewController source)
        {
            return null;
        }

        public IUIViewControllerAnimatedTransitioning GetAnimationControllerForDismissedController(UIViewController dismissed)
        {
            return this;
        }

        public void AnimateTransition(IUIViewControllerContextTransitioning transitionContext)
        {
            var fromController = transitionContext.GetViewControllerForKey(
                UITransitionContext.FromViewControllerKey);
            var toController = transitionContext.GetViewControllerForKey(
                UITransitionContext.ToViewControllerKey);

            if (fromController is PestoDetailViewController &
                toController is PestoViewController)
            {
                CGRect detailFrame = fromController.View.Frame;
                detailFrame.Y = this.View.Frame.Size.Height;


                UIView.AnimateNotify(TransitionDuration(transitionContext),
                                     0.5f,
                                     UIViewAnimationOptions.CurveEaseIn,
                                     () => {
                                            fromController.View.Frame = detailFrame;
                                     }, new UICompletionHandler((bool finished) => {
                                         if (fromController.View != null)
                                                {
                                                    fromController.View.RemoveFromSuperview();
                                                }
                                                transitionContext.CompleteTransition(true);
                                        }));

            }
        }

        public double TransitionDuration(IUIViewControllerContextTransitioning transitionContext)
        {
            return 0.2;
        }

        public void DidSelectSettings(object sender, EventArgs args)
        {
            var settingsVC = new PestoSettingsViewController();
            settingsVC.Title = "Settings";

            var white = UIColor.White;
            var teal = new UIColor(0f, 0.67f, 0.55f, 1f);
            var rightBarButton = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done,
                                                     CloseViewController);

            rightBarButton.TintColor = white;
            settingsVC.NavigationItem.RightBarButtonItem = rightBarButton;

            var navVC = new UINavigationController(settingsVC);
            navVC.NavigationBar.BarTintColor = teal;



            navVC.NavigationBar.TitleTextAttributes = new UIStringAttributes()
            {
                ForegroundColor = white
            };
            navVC.NavigationBar.Translucent = false;
            navVC.NavigationBarHidden = true;
            PresentViewController(navVC, true, null);

        }

        public void CloseViewController(object sender, EventArgs args)
        {
            DismissViewController(true, null);
        }
    }
}
