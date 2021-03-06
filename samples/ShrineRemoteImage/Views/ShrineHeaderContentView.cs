﻿//
// ShrineHeaderContentView.cs
//
// Author:
//       Pal Dorogi "ilap" <pal.dorogi@gmail.com>
//
// Copyright (c) 2017 Pal Dorogi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Foundation;
using UIKit;
using MaterialComponents.MaterialPageControl;
using CoreGraphics;
using System.Linq;

namespace ShrineRemoteImage.iOS.View
{
    public class ShrineHeaderContentView : UIView, IUIScrollViewDelegate
    {
        public MDCPageControl pageControl = new MDCPageControl();
        public UIScrollView scrollView = new UIScrollView();
        public UIImageView logoImageView = new UIImageView(UIImage.FromBundle("ShrineLogo"));
        public UIImageView logoTextImageView = new UIImageView(UIImage.FromBundle("ShrineTextLogo"));

        UIView[] pages = new UIView[3];
        UILabel label = new UILabel();
        UILabel labelDesc = new UILabel();
        UILabel label2 = new UILabel();
        UILabel labelDesc2 = new UILabel();
        UILabel label3 = new UILabel();
        UILabel labelDesc3 = new UILabel();
        UIView cyanBox = new UIView();
        UIView cyanBox2 = new UIView();
        UIView cyanBox3 = new UIView();
        UIImageView imageView = new UIImageView();
        UIImageView imageView2 = new UIImageView();
        UIImageView imageView3 = new UIImageView();

        [Export("initWithFrame:")]
        public ShrineHeaderContentView(CGRect frame) : base(frame)
        {
            CommonInit();
        }

        void CommonInit()
        {
            var boundsWidth = Bounds.Width;
            var boundsHeight = Bounds.Height;

            scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                                                UIViewAutoresizing.FlexibleHeight;
            scrollView.Delegate = this as IUIScrollViewDelegate;
            scrollView.PagingEnabled = true;
            scrollView.ShowsHorizontalScrollIndicator = false;
            AddSubview(scrollView);
            AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                                                 UIViewAutoresizing.FlexibleHeight;


            for (int i = 0; i <= 2; i++)
            {
                var boundsLeft = i * boundsWidth;
                // TODO: Check Bounds...
                Bounds.Offset(boundsLeft, 0);
                var pageFrame = Bounds;
                var page = new UIView(pageFrame);
                page.ClipsToBounds = true;
                page.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                                                 UIViewAutoresizing.FlexibleHeight;
                this.pages[i] = page;
                scrollView.AddSubview(page);
            }

            pageControl.NumberOfPages = 3;
            pageControl.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                                                 UIViewAutoresizing.FlexibleHeight;
            var pageControlSize = pageControl.SizeThatFits(Bounds.Size);
            pageControl.Frame = new CGRect(0, boundsHeight - pageControlSize.Height,
                                           boundsWidth, pageControlSize.Height);

            pageControl.AddTarget(this, new ObjCRuntime.Selector("didChangePage:"), UIControlEvent.ValueChanged);

            AddSubview(pageControl);
            AddHeaderPages();
            AddSubview(logoImageView);
            AddSubview(logoTextImageView);
        }

        void AddHeaderPages()
        {

            var s1 = new ShrineHeaderPage(this.pages[0],
                                          imageView,
                                          label,
                                          labelDesc,
                                          cyanBox,
                                          "chair.png",
                                          "Green \ncomfort chair");


            var s2 = new ShrineHeaderPage(this.pages[1],
                                          imageView2,
                                          label2,
                                          labelDesc2,
                                          cyanBox2,
                                          "backpack.png",
                                          "Best gift for \nthe traveler");


            var s3 = new ShrineHeaderPage(this.pages[2],
                                          imageView3,
                                          label3,
                                          labelDesc3,
                                          cyanBox3,
                                          "heels.png",
                                          "Better \nwearing heels");

        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var boundsWidth = Bounds.Width;
            var boundsHeight = Bounds.Height;

            for (int i = 0; i < pages.Count(); i++)
            {
                var boundsLeft = i * boundsWidth;
                // TODO: Check Bounds...
                var b = Bounds;
                b.Offset(boundsLeft, 0);
                var pageFrame = b;
                var page = pages[i];
                page.Frame = pageFrame;
            }


            var pageControlSize = pageControl.SizeThatFits(Bounds.Size);
            pageControl.Frame = new CGRect(0, boundsHeight - pageControlSize.Height,
                                           boundsWidth, pageControlSize.Height);

            var scrollWidth = boundsWidth * pages.Count();
            scrollView.Frame = new CGRect(0, 0, boundsWidth, boundsHeight);
            scrollView.ContentSize = new CGSize(scrollWidth, boundsHeight);


            var scrollViewOffsetX = pageControl.CurrentPage * boundsWidth;
            scrollView.SetContentOffset(new CGPoint(scrollViewOffsetX, 0), false);
            logoImageView.Center = new CGPoint(Frame.Size.Width / 2f, 44);
            logoTextImageView.Center = new CGPoint(Frame.Size.Width / 2f, 44);

            var labelWidth = 250f;
            var labelWidthFrame = new CGRect(Frame.Size.Width - labelWidth,
                                             90, labelWidth, label.Frame.Size.Height);

            var labelDescWidth = 200f;
            var labelDescWidthFrame = new CGRect(Frame.Size.Width - labelDescWidth - 10,
                                             190, labelDescWidth, 40);

            label.Frame = labelWidthFrame;
            labelDesc.Frame = labelDescWidthFrame;

            label2.Frame = labelWidthFrame;
            labelDesc2.Frame = labelDescWidthFrame;

            label3.Frame = labelWidthFrame;
            labelDesc3.Frame = labelDescWidthFrame;

            var cyanBoxFrame = new CGRect(Frame.Size.Width - 210, 180, 100, 8);
            cyanBox.Frame = cyanBoxFrame;
            cyanBox2.Frame = cyanBoxFrame;
            cyanBox3.Frame = cyanBoxFrame;

            imageView.Frame = new CGRect(-180, 120, 420, Frame.Size.Height);
            imageView2.Frame = new CGRect(-220, 110, 420, Frame.Size.Height);
            imageView3.Frame = new CGRect(-180, 40, 420, Frame.Size.Height);

        }

        [Export("didChangePage:")]
        public void OnTouchUpInside(MDCPageControl sender)
        {
            var offset = scrollView.ContentOffset;

            offset.X = sender.CurrentPage * scrollView.Bounds.Size.Width;
            scrollView.SetContentOffset(offset, true);

        }

        [Export("scrollViewDidScroll:")]
        public void Scrolled(UIScrollView scrollView)
        {
            pageControl.Scrolled(scrollView);
        }

        [Export("scrollViewDidEndDecelerating:")]
        public void DecelerationEnded(UIScrollView scrollView)
        {
            pageControl.DecelerationEnded(scrollView);
        }

        [Export("scrollViewDidEndScrollingAnimation:")]
        public void ScrollAnimationEnded(UIScrollView scrollView)
        {
            pageControl.ScrollAnimationEnded(scrollView);
        }

    }

}
