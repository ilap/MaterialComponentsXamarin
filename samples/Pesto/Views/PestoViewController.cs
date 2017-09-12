using System;
using MaterialComponents.MaterialAppBar;
using MaterialComponents.MaterialFlexibleHeader;
using UIKit;
using Foundation;
using CoreGraphics;

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
            result.collectionViewController.flexHeaderContainerVC = result;
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

        public PestoViewController()
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

        public void DidSelectCell(PestoCardCollectionViewCell cell, Action completion)
        {
            //zoomableView.Frame = new 
            Console.Write("Fuck!");

        }

       /* public class PestoAnimator : IUIViewControllerAnimatedTransitioning
        {
            public bool IsPresentation = true;
            CGRect frame = CGRect.Empty;
            PestoViewController controller;

            public PestoAnimator(PestoViewController controller, CGRect frame)
            {
                this.controller = controller;
                this.frame = frame;
            }*/

            public double TransitionDuration(IUIViewControllerContextTransitioning transitionContext)
            {
                return 0.2;
            }

            public void AnimateTransition(IUIViewControllerContextTransitioning transitionContext)
            {
                var fromController = transitionContext.GetViewControllerForKey(
                    UITransitionContext.FromViewControllerKey);
                var toContreoller = transitionContext.GetViewControllerForKey(
                    UITransitionContext.ToViewControllerKey);

                if (fromController is PestoDetailViewController &
                    toContreoller is PestoViewController)
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
        /*}*/

        public IUIViewControllerAnimatedTransitioning GetAnimationControllerForPresentedController(UIViewController presented, UIViewController presenting, UIViewController source)
        {
            return null;
        }

        public IUIViewControllerAnimatedTransitioning GetAnimationControllerForDismissedController(UIViewController dismissed)
        {
            return this;
        }
    }
}
