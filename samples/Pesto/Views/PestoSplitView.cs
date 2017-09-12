using System;
using UIKit;
using CoreGraphics;
namespace Pesto.Views
{
    public class PestoSplitView : UIView
    {
        UIView leftView;
        UIView rightView;
        CGSize originalSize;

        public PestoSplitView(CGRect frame, UIView leftView, UIView rightView): base(frame)
        {
            originalSize = frame.Size;

            var leftWidth = PestoDetailConstants.SplitWidth;
            var height = frame.Size.Height;

            this.leftView = new UIView(new CGRect(0, 1f, leftWidth, height));
            this.leftView.Add(leftView);
            AddSubview(this.leftView);

            var rightFrame = new CGRect(leftWidth, 0, this.Frame.Size.Width - leftWidth,
                                       height);
            this.rightView = new UIView(rightFrame);
            this.rightView.AddSubview(rightView);
            this.rightView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;
            AddSubview(rightView);
        }

        public override CGSize IntrinsicContentSize
        {
            get
            {
                return originalSize;
            }
        }
    }
}
