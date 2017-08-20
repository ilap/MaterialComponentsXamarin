using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;

using MaterialComponents;
using MaterialComponents.MaterialCollections;
using MaterialComponents.MaterialAnimationTiming;
using MaterialComponents.MaterialActivityIndicator;
using MaterialComponents.MaterialTypography;
using MaterialComponents.MaterialPalettes;
using MaterialComponents.MaterialInk;
using MaterialComponents.MaterialSlider;
using MaterialComponents.MaterialTabs;
using MaterialComponents.MaterialAppBar;
using MaterialComponents.MaterialDialogs;
using MaterialComponents.MaterialSnackbar;
using MaterialComponents.MaterialTextFields;
using MaterialComponents.MaterialButtons;

namespace MaterialComponentsApp
{
    public partial class ControlsViewController : UIViewController
    {
		// MARK: CALayer layer;
		// MARK: MDCInkTouchController inkTouchController;
		// MARK: MDCActivityIndicator activityIndicator;
		// MARK: MDCSlider slider;

		public ControlsViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            /*// Setup label
            label.Text = "This is a new2";
			label.Font = MDCTypography.Display1Font;
			label.Alpha = MDCTypography.Display4FontOpacity;
			label.SizeToFit();

            var name = new MDCTextField();

            name.Placeholder = "Name";

            //name.Placeholderplace = "Name";

            name.TranslatesAutoresizingMaskIntoConstraints = false;

            name.AutocapitalizationType = UITextAutocapitalizationType.Words;
			name.SizeToFit();
            View.AddSubview(name);

            //name.Delete(this);

            //View.AddSubview(activityIndicator);


            // Setup Butons
			nextButton.SetTitle("Tap Me", UIControlState.Normal);

            activityIndicator = new MDCActivityIndicator();
            activityIndicator.Frame = new CGRect(50, 150, 50, 50);
            activityIndicator.IndicatorMode = MDCActivityIndicatorMode.Indeterminate;
            activityIndicator.Progress = 1.0f;

            View.AddSubview(activityIndicator);

            //Slider
            slider = new MDCSlider();
            slider.Frame = new CGRect(20, 250, 200, 32);
            View.AddSubview(slider);
            //View.AddSubview(doButton);


            View.BackgroundColor = UIColor.FromWhiteAlpha(0.95f, 1.0f);
             

            // Floating layer              
            layer = new CALayer();
            layer.Bounds = new CGRect(0, 0, 50, 50);
            layer.Position = new CGPoint(20, 350);
            layer.Contents = UIImage.FromFile("/Users/ilap/Pictures/SupaG.jpg").CGImage;//FIXME: UIImage.FromBundle("SupaG").CGImage; // 
            layer.ContentsGravity = CALayer.GravityResize;
            layer.BorderWidth = 1.5f;
            layer.BorderColor = UIColor.Green.CGColor;


            inkTouchController = new MDCInkTouchController(doButton);
            inkTouchController.AddInkView();

            View.BackgroundColor = MDCPalette.GreenPalette.Tint500;
            View.Layer.AddSublayer(layer);
            */

		}

        /*
		public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);


			MDCAnimationTimingFunction materialCurve = MDCAnimationTimingFunction.EaseInOut;
            var timingFunction = (CoreAnimation.CAMediaTimingFunction) MDC_CAMediaTimingFunction.Mdc_functionWithType(materialCurve);
            CABasicAnimation animation = CABasicAnimation.FromKeyPath("transform.translation.x");

            animation.TimingFunction = timingFunction;
            animation.Duration = 2;

            var pt = layer.Position;
            animation.From = NSValue.FromCGPoint(pt);
            animation.To = NSValue.FromCGPoint(new CGPoint(pt.X+300, pt.Y));
            layer.AddAnimation(animation, "position");
        }

        */
        partial void DoButton_TouchUpInside(UIButton sender)
        {
			//activityIndicator.StartAnimating();
			//slider.SetValue(100f, true);
        }

        partial void NextButton_TouchUpInside(UIButton sender)
        {
            //throw new NotImplementedException();
        }
    }
}