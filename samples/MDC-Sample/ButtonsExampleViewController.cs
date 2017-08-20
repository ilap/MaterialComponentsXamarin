using Foundation;
using System;
using UIKit;
using MaterialComponents.MaterialButtons;
using ObjCRuntime;
using CoreGraphics;
using CoreAnimation;

namespace MaterialComponentsApp
{
    public partial class ButtonsExampleViewController : UIViewController
    {
        MDCRaisedButton raisedButton;
        MDCFlatButton flatButton;
        MDCFloatingButton floatingButton;

        public ButtonsExampleViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			View.BackgroundColor = UIColor.FromWhiteAlpha(0.9f, 1.0f);
			var backgroundColor = UIColor.FromWhiteAlpha(0.1f, 1.0f);


            // Raised Button
			raisedButton = new MDCRaisedButton();
			raisedButton.SetBackgroundColor(backgroundColor, UIControlState.Normal);
			raisedButton.SetElevation(4, UIControlState.Normal);
			raisedButton.SetTitle("Tap Me too", UIControlState.Normal);

			raisedButton.SizeToFit();
			raisedButton.TranslatesAutoresizingMaskIntoConstraints = false;
            raisedButton.AddTarget(Tap, UIControlEvent.TouchUpInside);
			View.AddSubview(raisedButton);


            // FlatButton
            flatButton = new MDCFlatButton();
            flatButton.SetTitleColor(UIColor.Gray, UIControlState.Normal);
			flatButton.SetTitle("Tap Me too", UIControlState.Normal);
            //flatButton.Enabled = false;
			flatButton.SizeToFit();
			flatButton.TranslatesAutoresizingMaskIntoConstraints = false;
            flatButton.AddTarget(Tap, UIControlEvent.TouchUpInside);
            flatButton.HasOpaqueBackground = false;
            View.AddSubview(flatButton);

			// FloatingButton
            floatingButton = new MDCFloatingButton();
            floatingButton.BackgroundColor = backgroundColor;
			floatingButton.SizeToFit();
			floatingButton.TranslatesAutoresizingMaskIntoConstraints = false;
            floatingButton.AddTarget(Tap, UIControlEvent.TouchUpInside);

            var plusShapeLayer = ButtonsPlusShape.createPlusShapeLayer(floatingButton);

             floatingButton.Layer.AddSublayer(plusShapeLayer);

            View.AddSubview(floatingButton);
        }

        void centerView(UIView view, UIView onView ) {
            onView.AddConstraint(NSLayoutConstraint.Create(
                view,
                NSLayoutAttribute.CenterX,
                NSLayoutRelation.Equal,
                onView,
                NSLayoutAttribute.CenterX,
                1.0f,
                0.0f));
			onView.AddConstraint(NSLayoutConstraint.Create(
	            view,
	            NSLayoutAttribute.CenterY,
	            NSLayoutRelation.Equal,
	            onView,
	            NSLayoutAttribute.CenterY,
	            1.0f,
	            0.0f));

            
        }
        public override void UpdateViewConstraints()
        {
            base.UpdateViewConstraints();
			centerView(flatButton, View);

			// Center them
			var views = new NSDictionary("raised", raisedButton,
										 "flat", flatButton,
										 "floating", floatingButton);
			View.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:[raised]-40-[flat]-40-[floating]",
																   NSLayoutFormatOptions.AlignAllCenterX,
																   null,
																   views));

        }

		//[Export("tap:sender:")]
        void Tap (object sender, EventArgs args) {

            if ( sender is UIButton) {
                label.Text = (sender as UIButton).Class.Name + "Was Tapped....";
            }
		    
		}
	}


    class ButtonsPlusShape : NSObject
    {

        static nfloat floatingButtonPlusDimension = 24f;

    	static UIBezierPath plusShapePath() {
            var bezierPath = new UIBezierPath();


            bezierPath.MoveTo(new CGPoint(19, 13));
            bezierPath.AddLineTo( new CGPoint(13, 13));
            bezierPath.AddLineTo(new CGPoint(13, 19));
            bezierPath.AddLineTo(new CGPoint(11, 19));
            bezierPath.AddLineTo(new CGPoint(11, 13));
            bezierPath.AddLineTo(new CGPoint(5, 13));
            bezierPath.AddLineTo(new CGPoint(5, 11));
            bezierPath.AddLineTo(new CGPoint(11, 11));
            bezierPath.AddLineTo(new CGPoint(11, 5));
            bezierPath.AddLineTo(new CGPoint(13, 5));
            bezierPath.AddLineTo(new CGPoint(13, 11));
            bezierPath.AddLineTo(new CGPoint(19, 11));
            bezierPath.AddLineTo(new CGPoint(19, 13));
            bezierPath.ClosePath();

            return bezierPath;
        }

        public static CAShapeLayer createPlusShapeLayer(MDCFloatingButton fb) {
            var plusShape = new CAShapeLayer();


            plusShape.Path = ButtonsPlusShape.plusShapePath().CGPath;
            plusShape.FillColor = UIColor.White.CGColor;
            plusShape.Position =
              new CGPoint((fb.Frame.Size.Width - floatingButtonPlusDimension) / 2,
                          (fb.Frame.Size.Height - floatingButtonPlusDimension) / 2);

            return plusShape;
          }
    }

}