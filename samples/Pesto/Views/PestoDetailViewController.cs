using System;
using UIKit;
using MaterialComponents.MaterialAppBar;
using MaterialComponents.MaterialFlexibleHeader;

namespace Pesto.Views
{
    public class PestoDetailViewController : UIViewController, IUIScrollViewDelegate
    {
        public UIScrollView scrollView;
        public UIScrollView imageView;
        public String descText;
        public String iconImageName;

        MDCAppBar appBar;
        MDCFlexibleHeaderViewController fhvc;
        PestoRecipeCardView bottomView;

        public PestoDetailViewController() : base()
        {
            CommonInit();
        }

        void CommonInit() {
            
        }
    }
}
