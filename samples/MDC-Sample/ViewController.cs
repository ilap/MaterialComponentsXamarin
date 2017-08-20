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
using CoreAnimation;
using CoreGraphics;
using Foundation;

using MaterialComponents;
using MaterialComponents.MaterialCollections;
using MaterialComponents.MaterialAppBar;
using MaterialComponents.MaterialDialogs;
using MaterialComponents.MaterialSnackbar;
//using MaterialComponents.MaterialTextFields;

namespace MaterialComponentsApp
{
    public partial class ViewController : MDCCollectionViewController
    {


        MDCAppBar appBar = new MDCAppBar();

       // public override void MakeTextWritingDirectionLeftToRight(Foundation.NSObject sender)
        //{
          //  base.MakeTextWritingDirectionLeftToRight(sender);
        //}

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            AddChildViewController(appBar.HeaderViewController);
            appBar.HeaderViewController.HeaderView.BackgroundColor = new UIColor(1f, 0.76f, 0.03f, 1.0f);

            var cv = CollectionView;
            appBar.HeaderViewController.HeaderView.TrackingScrollView = CollectionView;
            appBar.NavigationBar.TintColor = UIColor.Black;
            appBar.AddSubviewsToParent();

            Title = "Material Components";

			this.NavigationItem.SetRightBarButtonItem(
	            new UIBarButtonItem(UIBarButtonSystemItem.Action, (sender, args) => {
		        // button was clicked
	            })
            , true);
            

            // FIXME: Does not work as Styling is an Abstract Class
            var styler = this.Styler;
			styler.CellStyle = MDCCollectionViewCellStyle.Card;
			
            //FIXME: Does not work as  MDCCollectionViewEditing is an Abstract Class
            this.Editor.Editing = false; //true;

		}

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 2;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 4;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var textCell = (MDCCollectionViewTextCell)collectionView.DequeueReusableCell("cell", indexPath);


            var animals = new String[] {"Lions", "Tigers", "Bears", "Monkeys"};
            textCell.TextLabel.Text = animals[indexPath.Row];

            return textCell;
		}

        public override UIColor CollectionViewInkColorAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath){

            var alertController = MDCAlertController.AlertControllerWithTitle("Title","Message");

            var action = MDCAlertAction.ActionWithTitle("OK", null);

            alertController.AddAction(action);

            PresentViewController(alertController, true,  () => {
				var message = new MDCSnackbarMessage();
				message.Text = "The groundhog (Marmota monax) is also known as a woodchuck or whistlepig.";
				MDCSnackbarManager.ShowMessage(message);                
            });

            this.Editor.Editing = !this.Editor.Editing;
            return collectionView.BackgroundColor; //UIColor.Blue;
		}

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            base.ItemSelected(collectionView, indexPath);
        }


		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController?.SetNavigationBarHidden(true, animated);
        }

        public override bool PrefersStatusBarHidden()
        {
            return false;
        }

        public override void DecelerationEnded(UIScrollView scrollView)
        {
            //base.DecelerationEnded(scrollView);
            var hv = appBar.HeaderViewController.HeaderView;
            if (scrollView == hv.TrackingScrollView) {
                // hv.Track
                hv.TrackingScrollViewDidEndDecelerating();       
            }
        }

        public override void Scrolled(UIScrollView scrollView)
        {
            //base.Scrolled(scrollView);
			//base.DecelerationEnded(scrollView);
			var hv = appBar.HeaderViewController.HeaderView;
			if (scrollView == hv.TrackingScrollView)
			{
                //hv.Scrolled(scrollView);//scrollView);
                hv.TrackingScrollViewDidScroll();

			}
        }

    }
}
