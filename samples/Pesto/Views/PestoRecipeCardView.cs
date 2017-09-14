using System;
using UIKit;
using CoreGraphics;
using Foundation;
using MaterialComponents.MaterialTypography;

namespace Pesto.Views
{
    public static class PestoDetailConstants {
            // private variables
        public static nfloat DescTextHeight = 140;
        public static nfloat DetailPadding = 28;
        public static nfloat SplitWidth = 64;
    }
    public class PestoRecipeCardView : UIView
    {
        private String title;
        private UILabel titleLabel;
        private String iconImageName;
        private String descText;

        public String Title
        {
            get => title;
            set
            {
                title = value;
                TitleLabel.Text = title;
            }
        }

        public String IconImageName {
            get => iconImageName;
            set {
                iconImageName = value;
                var iconFrame = new CGRect(0, 0, 32, 32);
                // FIXME: generate icons.
                var icon = UIImage.FromBundle("ic_home");
                iconImageView.Image = icon;
            }
        }
        public String DescText {
            get => descText;
            set {
                descText = value;
                var descParagraphStyle = new NSMutableParagraphStyle();
                descParagraphStyle.LineHeightMultiple = 1.2f;

                var descAttrString = new NSMutableAttributedString(descText);
                descAttrString.AddAttribute(UIStringAttributeKey.ParagraphStyle, descParagraphStyle,
                                    new NSRange(0, descAttrString.Length));
                labelDesc.AttributedText = descAttrString;
                labelDesc.Frame = new CGRect(0, 0, contentViewFrame.Size.Width - PestoDetailConstants.SplitWidth,
                                             PestoDetailConstants.DescTextHeight);
            }
        }
        public UILabel TitleLabel {
            get => titleLabel;
            set => titleLabel = value;
        }



        CGRect contentViewFrame;
        UIImageView iconImageView;
        UILabel amount1;
        UILabel amount2;
        UILabel amount3;
        UILabel amount4;
        UILabel ingredient1;
        UILabel ingredient2;
        UILabel ingredient3;
        UILabel ingredient4;
        UILabel labelDesc;
        UIStackView stackView;

        /*public PestoRecipeCardView() : base()
        {
            BackgroundColor = UIColor.White;
            CommonInit();
        }*/

        public PestoRecipeCardView(CGRect frame) : base(frame)
        {
            BackgroundColor = UIColor.White;
            CommonInit();
        }

        void CommonInit() {
            contentViewFrame = new CGRect(PestoDetailConstants.DetailPadding, PestoDetailConstants.DetailPadding,
                                          Frame.Size.Width - PestoDetailConstants.DetailPadding * 2f,
                                          Frame.Size.Height - PestoDetailConstants.DetailPadding * 2f);

            var contentView = new UIView(contentViewFrame);

            contentView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;
            AddSubview(contentView);

            var iconFrame = new CGRect(0, 0, 32, 32);
            var image = UIImage.FromBundle("ic_home");

            iconImageView = new UIImageView(image);
            iconImageView.Frame = new CGRect(0, 1f, iconImageView.Frame.Size.Width,
                                             iconImageView.Frame.Size.Height);

            TitleLabel = new UILabel();
            TitleLabel.Font = MDCTypography.HeadlineFont;
            TitleLabel.Alpha = MDCTypography.HeadlineFontOpacity;
            TitleLabel.TextColor = UIColor.FromWhiteAlpha(0, 0.87f);
            TitleLabel.Frame = new CGRect(0, 0, contentViewFrame.Size.Width - PestoDetailConstants.SplitWidth,
                                          MDCTypography.Display1Font.PointSize + 4f);

            labelDesc = new UILabel();
            labelDesc.Lines = 8;
            labelDesc.LineBreakMode = UILineBreakMode.WordWrap;
            labelDesc.Font = MDCTypography.Body1Font;
            labelDesc.Alpha = MDCTypography.Body1FontOpacity;
            labelDesc.AutoresizingMask = UIViewAutoresizing.FlexibleWidth |
                UIViewAutoresizing.FlexibleHeight;

            var bodyFont = MDCTypography.Body1Font;
            var bodyFontOpacity = MDCTypography.Body1FontOpacity;

            ingredient1 = new UILabel();
            ingredient1.Text = "Mozzarella cheese";
            ingredient1.Font = bodyFont;
            ingredient1.Alpha = bodyFontOpacity;
            ingredient1.SizeToFit();

            ingredient2 = new UILabel();
            ingredient2.Text = "Toasts";
            ingredient2.Font = bodyFont;
            ingredient2.Alpha = bodyFontOpacity;
            ingredient2.SizeToFit();

            ingredient3 = new UILabel();
            ingredient3.Text = "Homemade pesto";
            ingredient3.Font = bodyFont;
            ingredient3.Alpha = bodyFontOpacity;
            ingredient3.SizeToFit();

            ingredient4 = new UILabel();
            ingredient4.Text = "Freshly ground pepper";
            ingredient4.Font = bodyFont;
            ingredient4.Alpha = bodyFontOpacity;
            ingredient4.SizeToFit();

            var teal = new UIColor(0.09f, 0.54f, 0.44f, 1f);
            var captionFont = MDCTypography.CaptionFont;
            var captionFontOpacity = MDCTypography.CaptionFontOpacity;

            amount1 = new UILabel();
            amount1.Text = "6 pieces";
            amount1.Font = captionFont;
            amount1.Alpha = captionFontOpacity;
            amount1.TextColor = teal;
            amount1.SizeToFit();

            amount2 = new UILabel();
            amount2.Text = "6 pieces";
            amount2.Font = captionFont;
            amount2.Alpha = captionFontOpacity;
            amount2.TextColor = teal;
            amount2.SizeToFit();

            amount3 = new UILabel();
            amount3.Text = "2/3 cup";
            amount3.Font = captionFont;
            amount3.Alpha = captionFontOpacity;
            amount3.TextColor = teal;
            amount3.SizeToFit();

            amount4 = new UILabel();
            amount4.Text = "2/3 cup";
            amount4.Font = captionFont;
            amount4.Alpha = captionFontOpacity;
            amount4.TextColor = teal;
            amount4.SizeToFit();

            var splitViewTitleFrame = new CGRect(0, 0, contentViewFrame.Size.Width,
                                                 MDCTypography.Display1Font.PointSize + 4f);

            var splitViewTitle = new PestoSplitView(splitViewTitleFrame, iconImageView,
                                                    TitleLabel);

            var splitViewDescFrame = new CGRect(0, 0, contentViewFrame.Size.Width,
                                                PestoDetailConstants.DescTextHeight);
            var splitViewDesc = new PestoSplitView(splitViewDescFrame, null,
                                               labelDesc);
            
            var splitViewRect = new CGRect(0, 0, contentViewFrame.Size.Width, 18f);

            var splitView1 = new PestoSplitView(splitViewRect, amount1, ingredient1);
            var splitView2 = new PestoSplitView(splitViewRect, amount2, ingredient2);
            var splitView3 = new PestoSplitView(splitViewRect, amount3, ingredient3);
            var splitView4 = new PestoSplitView(splitViewRect, amount4, ingredient4);

            var stackFrame = new CGRect(PestoDetailConstants.DetailPadding, 0, Bounds.Size.Width - PestoDetailConstants.DetailPadding * 2f,
                                        Bounds.Size.Height);

            stackView = new UIStackView(stackFrame);
            stackView.Axis = UILayoutConstraintAxis.Vertical;
            stackView.Spacing = 12f;
            stackView.TranslatesAutoresizingMaskIntoConstraints = false;
            contentView.AddSubview(stackView);

            stackView.AddArrangedSubview(splitViewTitle);
            stackView.AddArrangedSubview(splitViewDesc);
            stackView.AddArrangedSubview(splitView1);
            stackView.AddArrangedSubview(splitView2);
            stackView.AddArrangedSubview(splitView3);
            stackView.AddArrangedSubview(splitView4);

            stackView.TopAnchor.ConstraintEqualTo(contentView.TopAnchor).Active = true;
            stackView.LeftAnchor.ConstraintEqualTo(contentView.LeftAnchor).Active = true;
            stackView.RightAnchor.ConstraintEqualTo(contentView.RightAnchor).Active = true;
            stackView.WidthAnchor.ConstraintEqualTo(contentView.WidthAnchor).Active = true;
        }
    }
}
