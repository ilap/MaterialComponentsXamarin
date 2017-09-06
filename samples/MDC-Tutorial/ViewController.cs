//
// Copyright (c) 2017 The Material Components for iOS Xamarin Binding Authors.
// All Rights Reserved.
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
//

using System;

using UIKit;
using Foundation;

using MaterialComponents;
using MaterialComponents.MaterialCollections;
using MaterialComponents.MaterialAppBar;
using MaterialComponents.MaterialButtons;

namespace MDCTutorial
{
	public partial class ViewController : MDCCollectionViewController
	{

        MDCAppBar appBar = new MDCAppBar();
        MDCFloatingButton fab = new MDCFloatingButton();
        UIBarButtonItem navBtn;

		protected ViewController(IntPtr handle) : base(handle) {
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad() {
			base.ViewDidLoad();

			// FIXME: Does not work if Styling is an Abstract Class
			var styler = this.Styler;
			styler.CellStyle = MDCCollectionViewCellStyle.Card;

			AddChildViewController(appBar.HeaderViewController);
			appBar.HeaderViewController.HeaderView.BackgroundColor = new UIColor(1f, 0.76f, 0.03f, 1.0f);

			var cv = CollectionView;
			appBar.HeaderViewController.HeaderView.TrackingScrollView = CollectionView;
			appBar.AddSubviewsToParent();

			Title = "Material";

            // FIXME: Does not work.
            navBtn = new UIBarButtonItem(UIBarButtonSystemItem.Done, null) {
                Title = "Edit",
                Style = UIBarButtonItemStyle.Plain
            };
            navBtn.Clicked += OnDoneClicked;

			//this.NavigationItem.SetRightBarButtonItem(
			//	new UIBarButtonItem(UIBarButtonSystemItem.Action, (sender, args) => {
            //        // button was clicked
             //       Console.WriteLine("UIBarButtonItem");
             //       })
			//, true);
            NavigationItem.SetLeftBarButtonItem(navBtn, true);
            //base.NavigationItem.
			appBar.NavigationBar.TintColor = UIColor.Black;

			//FIXME: Does not work if MDCCollectionViewEditing is an Abstract Class
			this.Editor.Editing = false; //true;

			Add(fab);
			fab.TranslatesAutoresizingMaskIntoConstraints = false;
			fab.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -16.0f).Active = true;
			fab.BottomAnchor.ConstraintEqualTo(View.BottomAnchor, -16.0f).Active = true;

			fab.SetTitle("+", UIControlState.Normal);
			fab.SetTitle("-", UIControlState.Selected);
			fab.AddTarget(FabDidTap, UIControlEvent.TouchUpInside);
		}

		void OnDoneClicked(object sender, EventArgs args) {
			Console.WriteLine("This isn't firing...");
		}

		public override void ViewWillAppear(bool animated) {
			base.ViewWillAppear(animated);
			NavigationController?.SetNavigationBarHidden(true, animated);
		}

		// MARK: UICollectionViewDataSource

		public override nint NumberOfSections(UICollectionView collectionView) {
			return 5;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section) {
			return 4;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var textCell = (MDCCollectionViewTextCell)collectionView.DequeueReusableCell("cell", indexPath);


			var animals = new String[] { "Lions", "Tigers", "Bears", "Monkeys" };
			textCell.TextLabel.Text = animals[indexPath.Row];

			return textCell;
		}

		// MARK: UIScrollViewDelegate

		public override bool PrefersStatusBarHidden() {
			return false;
		}

		public override void DecelerationEnded(UIScrollView scrollView) {
			var hv = appBar.HeaderViewController.HeaderView;

			if (scrollView == hv.TrackingScrollView) {
				hv.TrackingScrollViewDidEndDecelerating();
			}
		}

		public override void Scrolled(UIScrollView scrollView) {
			var hv = appBar.HeaderViewController.HeaderView;

			if (scrollView == hv.TrackingScrollView) {
				hv.TrackingScrollViewDidScroll();
			}
		}

        public override void WillEndDragging(UIScrollView scrollView, CoreGraphics.CGPoint velocity, ref CoreGraphics.CGPoint targetContentOffset) {
			var hv = appBar.HeaderViewController.HeaderView;

            if (scrollView == hv.TrackingScrollView) {
                hv.TrackingScrollViewWillEndDraggingWithVelocity(velocity, targetContentOffset);
            }

        }

        public override void DraggingEnded(UIScrollView scrollView, bool willDecelerate) {
			var hv = appBar.HeaderViewController.HeaderView;

			if (scrollView == hv.TrackingScrollView) {
                hv.TrackingScrollViewDidEndDraggingWillDecelerate(willDecelerate);
			}
        }

		// MARK: Button DID Tap

		public void FabDidTap(object sender, EventArgs args) {
            if (sender is UIButton) {
				var s = sender as UIButton;
				this.Editor.Editing = !this.Editor.Editing;
				s.Selected = !s.Selected;
			}
		}
	}
}
