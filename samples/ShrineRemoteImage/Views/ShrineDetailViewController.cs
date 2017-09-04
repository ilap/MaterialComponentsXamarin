using System;
using UIKit;
using MaterialComponents.MaterialAppBar;
using MaterialComponents.MaterialButtons;
using MaterialComponents.MaterialIcons;
using CoreGraphics;
namespace ShrineRemoteImage.iOS.View
{
    public class ShrineDetailViewController : UIViewController
    {

        nfloat fabPadding = 25f;
        public string productTitle = "";
        public string desc = "";
        public string imageName = "popsicle.png";

        MDCAppBar appBar = new MDCAppBar();
        MDCFloatingButton floatingButton = new MDCFloatingButton();

        public ShrineDetailViewController() : base()
        {

            AddChildViewController(appBar.HeaderViewController);
            appBar.HeaderViewController.HeaderView.BackgroundColor = UIColor.Clear;
            appBar.NavigationBar.TintColor = UIColor.Black;
        }

        public override void ViewDidLoad()
        {
            //ase.ViewDidLoad();

            var detailView = new ShrineDetailView(View.Frame);
            detailView.title = productTitle;
            detailView.desc = desc;
            detailView.imageName = imageName;
            detailView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;
            View.AddSubview(detailView);

            appBar.AddSubviewsToParent();
            string title = "";

            var backButton = new UIBarButtonItem(title, UIBarButtonItemStyle.Done, DismissDetails);

            var backImage = new UIImage(MDCIcons.PathFor_ic_arrow_back);
            backButton.Image = backImage;
            appBar.NavigationBar.LeftBarButtonItem = backButton;

            floatingButton.SetTitle("+", UIControlState.Normal);
            floatingButton.SetTitle("-", UIControlState.Selected);
            floatingButton.BackgroundColor = new UIColor(0.086f, 0.941f, 0.941f, 1f);
            floatingButton.SizeToFit();
            View.AddSubview(floatingButton);

        }

        public override void ViewWillLayoutSubviews()
        {

            floatingButton.Frame = new CGRect(View.Frame.Width - floatingButton.Frame.Width - fabPadding,
                                              View.Frame.Height - floatingButton.Frame.Height - fabPadding,
                                              floatingButton.Frame.Width,
                                              floatingButton.Frame.Height);
        }



        public void DismissDetails(object sender, EventArgs args)
        {
            DismissViewController(true, null);
        }

    }
}
