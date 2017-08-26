using Foundation;
using UIKit;
using MaterialComponents.MaterialSnackbar;

namespace ShrineXamarin
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions) {

            var mainStoryBoardName = "ProductGrid";

            var home = UIStoryboard.FromName(mainStoryBoardName, null).InstantiateInitialViewController() as ProductGridViewController;

            home.isHome = true;
            home.TabBarItem.TitlePositionAdjustment = new UIOffset(0, -4);
            home.TabBarItem.Title = "Home";
            home.TabBarItem.Image = UIImage.FromBundle("Diamond");
            home.products = ProductFactory.ProductsForCategory(ProductFactory.Home);

            var clothing = UIStoryboard.FromName(mainStoryBoardName, null).InstantiateInitialViewController() as ProductGridViewController;

            clothing.TabBarItem.TitlePositionAdjustment = new UIOffset(0, -4);
            clothing.TabBarItem.Title = "Clothing";
            var ui = UIImage.FromBundle("HeartEmpty");
            clothing.TabBarItem.Image = ui;
            clothing.products = ProductFactory.ProductsForCategory(ProductFactory.Clothing);

            var popsicles = UIStoryboard.FromName(mainStoryBoardName, null).InstantiateInitialViewController() as ProductGridViewController;

            popsicles.TabBarItem.TitlePositionAdjustment = new UIOffset(0, -4);
            popsicles.TabBarItem.Title = "Popsicles";
            popsicles.TabBarItem.Image = UIImage.FromBundle("Cart");
            popsicles.products = ProductFactory.ProductsForCategory(ProductFactory.Popslices);

            var tabBarController = new UITabBarController();
            tabBarController.ViewControllers = new UIViewController[] { clothing, home, popsicles };
            tabBarController.TabBar.TintColor = new UIColor(96 / 255f, 128 / 255f, 139 / 255f, 1f);
            tabBarController.SelectedIndex = 1;

            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = tabBarController;
            Window.MakeKeyAndVisible();

            MDCSnackbarManager.SetBottomOffset(tabBarController.TabBar.Bounds.Size.Height);

            return true;
        }
    }
}
