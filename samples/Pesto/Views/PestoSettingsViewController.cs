using System;
using UIKit;

using MaterialComponents.MaterialCollections;
using MaterialComponents.MaterialAppBar;
using Foundation;
using MaterialComponents;
using CoreGraphics;

namespace Pesto.Views
{
    public class PestoSettingsViewController : MDCCollectionViewController
    {
        MDCAppBar appBar;
        UIColor tealColor;
        static String cellId = "itemCellIdentifier";
        static NSString headerId = new NSString("Header");

        String[,] contents = new String[2, 2] {
               {"Public Profile","Subscribe to Daily Digest"},
               {"Get Email Notifications","Get Text Notifications"} 
        };


        public PestoSettingsViewController() : base()
        {
            Title = "Settings";
            appBar = new MDCAppBar();
            AddChildViewController(appBar.HeaderViewController);

            tealColor = new UIColor(0f, 0.67f, 0.55f, 1f);
            appBar.HeaderViewController.HeaderView.BackgroundColor = tealColor;
            appBar.NavigationBar.TintColor = UIColor.White;

            UITextAttributes myTextAttrib = new UITextAttributes();

            var attr = new NSDictionary<NSString, NSObject>(
            UIStringAttributeKey.ForegroundColor, UIColor.White);

            appBar.NavigationBar.TitleTextAttributes = attr;


            //Styler.CellStyle = MDCCollectionViewCellStyle.Card;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // FIXME: Does not work if Styling is an Abstract Class
            var styler = this.Styler;
            styler.CellStyle = MDCCollectionViewCellStyle.Card;

            appBar.HeaderViewController.HeaderView.TrackingScrollView = CollectionView;
            appBar.AddSubviewsToParent();

            var backButon = new UIBarButtonItem("", UIBarButtonItemStyle.Done,(sender, e) => {
                DismissViewController(true, null);
            });

            var backImage = UIImage.FromBundle("Back");
            backButon.Image = backImage;

            NavigationItem.LeftBarButtonItem = backButon;
            NavigationItem.RightBarButtonItem = null;

            CollectionView.RegisterClassForCell(typeof(MDCCollectionViewTextCell), cellId);

            CollectionView.RegisterClassForSupplementaryView(typeof(MDCCollectionViewTextCell),
                                                             UICollectionElementKindSection.Header,
                                                             headerId);

        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 2;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 2;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (MDCCollectionViewTextCell)collectionView.DequeueReusableCell(cellId, indexPath);

            cell.TextLabel.Text = contents[indexPath.Section, indexPath.Item];
            UISwitch editingSwitch = new UISwitch(CGRect.Empty);
            cell.AccessoryView = editingSwitch;

            return cell;
        }

        public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
        {
            var supplementaryView = (MDCCollectionViewTextCell)collectionView.DequeueReusableSupplementaryView(elementKind, headerId, indexPath);

            if (elementKind.ToString() == "UICollectionElementKindSectionHeader") {
                if (indexPath.Section == 0) {
                    supplementaryView.TextLabel.Text = "Account";
                }
                else if (indexPath.Section == 1)
                {
                    supplementaryView.TextLabel.Text = "Notifocation";
                }
                supplementaryView.TextLabel.TextColor = tealColor;
            }

            return supplementaryView;
        }

        [Export("collectionView:layout:referenceSizeForHeaderInSection:")]
        public CGSize GetReferenceSizeForHeader(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        {
            return new CGSize(CollectionView.Bounds.Size.Width, Constants.MDCCellDefaultOneLineHeight);
        }

    }
}
