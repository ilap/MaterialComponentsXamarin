using System;
using UIKit;
using MaterialComponents.MaterialAppBar;
using MaterialComponents.MaterialFlexibleHeader;

namespace Pesto.Views
{
    public static class PestoDetail {
        public static nfloat AnimationDelay = 1f;
        public static nfloat AnimationDuration = 0.33f;
        public static nfloat FlexibleHeaderLandscapeHeight { get => 160f };
        public static nfloat FlexibleHeaderMinHeight { get => 320f };
        public static nfloat RecipeCardHeight { get => 400f };
        
    }

    public class PestoDetailViewController : UIViewController, IUIScrollViewDelegate
    {
        public UIScrollView scrollView;
        public UIScrollView imageView;
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

            var imageViewFrame = fhvc.HeaderView.Bounds;
            imageView = new UIIMageView(imageViewFrame);
            imageView.ContentMode = UIViewContentModeScale.AspectFill;
            imageView.AutoResizingMask = UIViewAutoresizing.FlexibleWidth | 
            UIViewAutoresizing.FlexibleHeight;

            fhvc.HeaderView.AddSubView(imageView);

            appBar = new MDCAppBar();
            AddChildViewController(appBar.HeaderViewController);

            appBar.HeaderViewController.HeaderView.BackgroundColor = UIColor.Clear;
            appBar.NavigationBar.TintColor = UIColor.White;

            var backButton = new UIBarButtonItem(icon, UIBarButtonItemStyle.Done, DidTapBack);
            var backImage = new UIImage.FromBundle("Back");
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
            scrollView.AutoResizingMask = UIViewAutoresizing.FlexibleWidth | 
            UIViewAutoresizing.FlexibleHeight;
            View.AddSubView(scrollView);

            scrollView.Delegate = this;
            fhvc.HeaderView.TrackingScrollView = scrollView;
            fhvc.HeaderView.ClipsToBounds = true;

            fhvc.View.Frame = View.Bounds;
            View.AddSubView(fhvc.View);

            fhvc.MoveToParentViewController();


            var bottomFrame = new CGRect(0, 0, View.Bounds.Size.Width,
            PestoDetail.lRecipeCardHeight);

            bottomView = new PestoRecipeCardView(bottomFrame);

            bottomView.descText = this.descText;
            bottomView.Title = this.Title;
            bottomView.iconImageName = this.iconImageName;
            bottomView.Alpha = 0;
            bottomView..AutoResizingMask = UIViewAutoresizing.FlexibleWidth | 
            UIViewAutoresizing.FlexibleHeight;
            scrollView.AddSubView(bottomView);

            DispatchQueue.MainQueue.DispatchAsync(() => {
                UIView.AnimateNotify(PestoDetail.AnimationDuration,
                PestoDetail.AnimationDelay,
                UIViewAnimationOptions.CurveEaseOut,
                () =>
                {
                     var quantumEaseInOut = CAMediaTimingFunction.mdc_functionWithType(MDCAnimationTimingFunction.EaseInOut);
                    CATransation.AnimationTimingFunction = quantumEaseInOut;
                    this.bottomView.Alpha = 1f;
                }, 
                new UICompletionHandler((bool finished) => {}));
            });

            appBar.AddSubViewsToParent();

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

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
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
        public override void Scrolled(UIScrollView scrollView) {
            var contentOffsetY = -scrollView.contentOffset.Y;
            if (contentOffsetY < PestoDetail.FlexibleHeaderMinHeight) {
                contentOffsetY = PestoDetail.FlexibleHeaderMinHeight;
            }
            fhvc.Scrolled(scrollView);
        }
    }
}