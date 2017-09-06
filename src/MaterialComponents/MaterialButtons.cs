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
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using MaterialComponents;

namespace MaterialComponents.MaterialButtons
{
    

	// @interface MDCButton : UIButton
    //[Protocol, Model]
	[BaseType (typeof(UIButton))]
	interface MDCButton
	{
		// @property (assign, nonatomic) MDCInkStyle inkStyle;
		[Export ("inkStyle", ArgumentSemantic.Assign)]
		MDCInkStyle InkStyle { get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified inkColor;
		[Export ("inkColor", ArgumentSemantic.Strong)]
		UIColor InkColor { get; set; }

		// @property (assign, nonatomic) CGFloat inkMaxRippleRadius;
		[Export ("inkMaxRippleRadius")]
		nfloat InkMaxRippleRadius { get; set; }

		// @property (nonatomic) CGFloat disabledAlpha;
		[Export ("disabledAlpha")]
		nfloat DisabledAlpha { get; set; }

		// @property (getter = isUppercaseTitle, nonatomic) BOOL uppercaseTitle;
		[Export ("uppercaseTitle")]
		bool UppercaseTitle { [Bind ("isUppercaseTitle")] get; set; }

		// @property (nonatomic) UIEdgeInsets hitAreaInsets;
		[Export ("hitAreaInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets HitAreaInsets { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable underlyingColorHint;
		[NullAllowed, Export ("underlyingColorHint", ArgumentSemantic.Strong)]
		UIColor UnderlyingColorHint { get; set; }

		// @property (readwrite, nonatomic, setter = mdc_setAdjustsFontForContentSizeCategory:) BOOL mdc_adjustsFontForContentSizeCategory __attribute__((annotate("ui_appearance_selector")));
		[Export ("mdc_adjustsFontForContentSizeCategory")]
		bool Mdc_adjustsFontForContentSizeCategory { get; [Bind ("mdc_setAdjustsFontForContentSizeCategory:")] set; }

		// -(UIColor * _Nullable)backgroundColorForState:(UIControlState)state;
		[Export ("backgroundColorForState:")]
		[return: NullAllowed]
		UIColor BackgroundColorForState (UIControlState state);

		// -(void)setBackgroundColor:(UIColor * _Nullable)backgroundColor forState:(UIControlState)state __attribute__((annotate("ui_appearance_selector")));
		[Export ("setBackgroundColor:forState:")]
		void SetBackgroundColor ([NullAllowed] UIColor backgroundColor, UIControlState state);

		// -(void)setBackgroundColor:(UIColor * _Nullable)backgroundColor;
		[Export ("setBackgroundColor:")]
		void SetBackgroundColor ([NullAllowed] UIColor backgroundColor);

		// -(void)setEnabled:(BOOL)enabled animated:(BOOL)animated;
		[Export ("setEnabled:animated:")]
		void SetEnabled (bool enabled, bool animated);

		// -(CGFloat)elevationForState:(UIControlState)state;
		[Export ("elevationForState:")]
		nfloat ElevationForState (UIControlState state);

		// -(void)setElevation:(CGFloat)elevation forState:(UIControlState)state;
		[Export ("setElevation:forState:")]
		void SetElevation (nfloat elevation, UIControlState state);

        // MARK: Check v34.0.1
        // -(UIColor * _Nullable)borderColorForState:(UIControlState)state;
        [Export("borderColorForState:")]
        [return: NullAllowed]
        UIColor BorderColorForState(UIControlState state);

        // -(void)setBorderColor:(UIColor * _Nullable)borderColor forState:(UIControlState)state __attribute__((annotate("ui_appearance_selector")));
        [Export("setBorderColor:forState:")]
        void SetBorderColor([NullAllowed] UIColor borderColor, UIControlState state);

        // -(CGFloat)borderWidthForState:(UIControlState)state;
        [Export("borderWidthForState:")]
        nfloat BorderWidthForState(UIControlState state);

        // -(void)setBorderWidth:(CGFloat)borderWidth forState:(UIControlState)state __attribute__((annotate("ui_appearance_selector")));
        [Export("setBorderWidth:forState:")]
        void SetBorderWidth(nfloat borderWidth, UIControlState state);

		// @property (nonatomic, strong) UIColor * _Nullable customTitleColor __attribute__((deprecated("Use setTitleColor:forState: instead"))) __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export ("customTitleColor", ArgumentSemantic.Strong)]
		UIColor CustomTitleColor { get; set; }

		// @property (nonatomic) BOOL shouldRaiseOnTouch __attribute__((deprecated("Use MDCFlatButton instead of shouldRaiseOnTouch = NO")));
		[Export ("shouldRaiseOnTouch")]
		bool ShouldRaiseOnTouch { get; set; }

		// @property (nonatomic) BOOL shouldCapitalizeTitle __attribute__((deprecated("Use uppercaseTitle instead.")));
		[Export ("shouldCapitalizeTitle")]
		bool ShouldCapitalizeTitle { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable underlyingColor __attribute__((deprecated("Use underlyingColorHint instead.")));
		[NullAllowed, Export ("underlyingColor", ArgumentSemantic.Strong)]
		UIColor UnderlyingColor { get; set; }
	}

	// @interface MDCFlatButton : MDCButton
	[BaseType (typeof(MDCButton))]
    //[Protocol, Model]
	interface MDCFlatButton
	{
		// @property (nonatomic) BOOL hasOpaqueBackground;
		[Export ("hasOpaqueBackground")]
		bool HasOpaqueBackground { get; set; }
	}

    // @interface MDCFloatingButton : MDCButton
    //[Protocol, Model]
	[BaseType (typeof(MDCButton))]
	interface MDCFloatingButton
	{
		// +(instancetype _Nonnull)floatingButtonWithShape:(MDCFloatingButtonShape)shape;
		[Static]
		[Export ("floatingButtonWithShape:")]
		MDCFloatingButton FloatingButtonWithShape (MDCFloatingButtonShape shape);

        // +(CGFloat)defaultDimension;
        [Static]
        [Export("defaultDimension")]
        //[Verify (MethodToProperty)]
        nfloat DefaultDimension();//{ get; }

        // +(CGFloat)miniDimension;
        [Static]
        [Export("miniDimension")]
        //[Verify (MethodToProperty)]
        nfloat MiniDimension();//{ get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame shape:(MDCFloatingButtonShape)shape __attribute__((objc_designated_initializer));
		[Export ("initWithFrame:shape:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGRect frame, MDCFloatingButtonShape shape);

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		//FIXMEL another .ctor /w same name [Export ("initWithCoder:")]
		//[DesignatedInitializer]
		//IntPtr Constructor (NSCoder aDecoder);

		// +(instancetype _Nonnull)buttonWithShape:(MDCFloatingButtonShape)shape __attribute__((deprecated("Use floatingButtonWithShape: instead.")));
		[Static]
		[Export ("buttonWithShape:")]
		MDCFloatingButton ButtonWithShape (MDCFloatingButtonShape shape);
	}

	// @interface MDCRaisedButton : MDCButton
	[BaseType (typeof(MDCButton))]
	interface MDCRaisedButton
	{
	}

    // @interface Animation (MDCFloatingButton)
    [Category]
    [BaseType(typeof(MDCFloatingButton))]
    interface MDCFloatingButton_Animation {
        // -(void)expand:(BOOL)animated completion:(void (^ _Nullable)(void))completion;
        [Export("expand:completion:")]
        void Expand(bool animated, [NullAllowed] Action completion);

        // -(void)collapse:(BOOL)animated completion:(void (^ _Nullable)(void))completion;
        [Export("collapse:completion:")]
        void Collapse(bool animated, [NullAllowed] Action completion);
    }
}
