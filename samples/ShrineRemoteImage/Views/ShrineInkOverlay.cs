﻿using System;
using MaterialComponents.MaterialInk;
using CoreGraphics;
using UIKit;
namespace ShrineRemoteImage.iOS.View
{
    
    public class ShrineInkOverlay : UIView, IMDCInkTouchControllerDelegate
    {
        MDCInkTouchController inkTouchController;

        public ShrineInkOverlay(CGRect frame) : base (frame)
        {
            var cyan = new UIColor(22 / 255, 240 / 255, 240 / 255, 0.2f);
            inkTouchController = new MDCInkTouchController(this);
            inkTouchController.DefaultInkView.InkColor = cyan;
            inkTouchController.AddInkView();
            // FIXME: inkTouchController.Delegate = (IMDCInkTouchControllerDelegate)this;

        }

        public ShrineInkOverlay() : base() {
            
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
        }
    }
}