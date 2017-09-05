using System;
using MaterialComponents.MaterialInk;
using CoreGraphics;
using UIKit;
using Foundation;

namespace ShrineRemoteImage.iOS.View
{
    
    public class ShrineInkOverlay : UIView, IMDCInkTouchControllerDelegate
    {
        MDCInkTouchController inkTouchController;

        public ShrineInkOverlay(CGRect frame) : base (frame)
        {
            InitTouchController();
        }

        public ShrineInkOverlay() : base() {
            InitTouchController();
        }

        void InitTouchController() {
            var cyan = new UIColor(22 / 255f, 240 / 255f, 240 / 255f, 0.2f);
            inkTouchController = new MDCInkTouchController(this);
            inkTouchController.DefaultInkView.InkColor = cyan;
            inkTouchController.AddInkView();
            inkTouchController.Delegate = new ShrineInkOverlayDelegate();
        }

        [Export("layoutSubviews")]
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
        }

        public class ShrineInkOverlayDelegate : MDCInkTouchControllerDelegate {
            
            public ShrineInkOverlayDelegate (): base () {
                Console.WriteLine("ShrineInkOverlayDelegate was called\n");

            }

            // XXX: InkOverLay Example
            // public override bool ShouldProcessInkTouchesAtTouchLocation(MDCInkTouchController inkTouchController, CGPoint location) {
            //    return true;
            //}
        }
    }
}
