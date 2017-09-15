using System;
using UIKit;
using MaterialComponents.MaterialAppBar;
using MaterialComponents.MaterialFlexibleHeader;
using CoreGraphics;
using CoreFoundation;
using CoreAnimation;
using MaterialComponents.MaterialAnimationTiming;
using MaterialComponents;

namespace Pesto.Views
{
    public class PestoDetailViewController : UIViewController, IUIScrollViewDelegate
    {
        public UIScrollView scrollView;
        public UIImageView imageView;
        public String descText;
        public String iconImageName;

        MDCAppBar appBar;
        MDCFlexibleHeaderViewController fhvc;
        PestoRecipeCardView bottomView;

        public PestoDetailViewController() : base()
        {
            CommonInit();
        }

        void CommonInit() {
            fhvc = new MDCFlexibleHeaderViewController();
            AddChildViewController(fhvc);

            CGRect imageViewFrame = fhvc.HeaderView.Bounds;

            imageView = new UIImageView(imageViewFrame);
                
            imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            imageView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                                        UIViewAutoresizing.FlexibleHeight;

            fhvc.HeaderView.AddSubview(imageView);

            appBar = new MDCAppBar();
            AddChildViewController(appBar.HeaderViewController);

            appBar.HeaderViewController.HeaderView.BackgroundColor = UIColor.Clear;
            appBar.NavigationBar.TintColor = UIColor.White;

            var backButton = new UIBarButtonItem("", UIBarButtonItemStyle.Done, DidTapBack);

            var backImage = UIImage.FromBundle("Back");
            backButton.Image = backImage;
            NavigationItem.LeftBarButtonItem = backButton;


        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (View.Frame.Size.Height > View.Frame.Size.Width) {
                fhvc.HeaderView.MinimumHeight = PestoDetail.FlexibleHeaderMinHeight;
            } else {
                fhvc.HeaderView.MinimumHeight = PestoDetail.FlexibleHeaderLandscapeHeight;
                fhvc.HeaderView.MaximumHeight = PestoDetail.FlexibleHeaderLandscapeHeight;
            }

            scrollView = new UIScrollView(View.Bounds);
            scrollView.BackgroundColor = UIColor.White;
            scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
            UIViewAutoresizing.FlexibleHeight;
            
            View.AddSubview(scrollView);

            scrollView.Delegate = this;
            fhvc.HeaderView.TrackingScrollView = scrollView;
            fhvc.HeaderView.ClipsToBounds = true;

            fhvc.View.Frame = View.Bounds;
            View.AddSubview(fhvc.View);

            fhvc.DidMoveToParentViewController(this);


            var bottomFrame = new CGRect(0, 0, View.Bounds.Size.Width,
            PestoDetail.RecipeCardHeight);

            bottomView = new PestoRecipeCardView(bottomFrame);

            bottomView.DescText = this.descText;
            bottomView.Title = this.Title;
            bottomView.IconImageName = this.iconImageName;
            bottomView.Alpha = 0;
            bottomView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | 
            UIViewAutoresizing.FlexibleHeight;
            scrollView.AddSubview(bottomView);

            DispatchQueue.MainQueue.DispatchAsync(() => {
                UIView.AnimateNotify(PestoDetail.AnimationDuration,
                PestoDetail.AnimationDelay,
                UIViewAnimationOptions.CurveEaseOut,
                () =>
                {
                    var quantumEaseInOut = MDC_CAMediaTimingFunction.Mdc_functionWithType(MDCAnimationTimingFunction.EaseInOut);
                    CATransaction.AnimationTimingFunction = quantumEaseInOut;
                    this.bottomView.Alpha = 1f;
                }, 
                new UICompletionHandler((bool finished) => {}));
            });

            appBar.AddSubviewsToParent();

            // Only display title in the bottom view with no title in the app bar.
            bottomView.Title = Title;
            appBar.NavigationBar.Title = "";

        }

        public override void ViewWillAppear(bool animated) {
			base.ViewWillAppear(animated);
			NavigationController?.SetNavigationBarHidden(true, animated);
		}

		public override UIViewController ChildViewControllerForStatusBarHidden()
		{
			return fhvc;
		}

        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            //base.ViewWillTransitionToSize(toSize, coordinator);
            if (toSize.Width < toSize.Height) {
                fhvc.HeaderView.MinimumHeight = PestoDetail.FlexibleHeaderMinHeight;
            } else {
                fhvc.HeaderView.MinimumHeight = PestoDetail.FlexibleHeaderLandscapeHeight;
                fhvc.HeaderView.MaximumHeight = PestoDetail.FlexibleHeaderLandscapeHeight;
            }
        }


        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            scrollView.ContentSize = new CGSize(bottomView.Bounds.Size.Width,
            PestoDetail.RecipeCardHeight);
        }

        public void DidTapBack(object sender, EventArgs args)
        {
            this.DismissViewController(true, null);
        }

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.LightContent;
        }
        
        // MARK: UIScrollViewDelegate
        public void Scrolled(UIScrollView scrollView) {
            var contentOffsetY = -scrollView.ContentOffset.Y;
            if (contentOffsetY < PestoDetail.FlexibleHeaderMinHeight) {
                contentOffsetY = PestoDetail.FlexibleHeaderMinHeight;
            }
            fhvc.Scrolled(scrollView);
        }
    }
}