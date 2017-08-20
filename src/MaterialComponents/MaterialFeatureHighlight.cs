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
using Foundation;
using UIKit;
using MaterialComponents;
using ObjCRuntime;

namespace MaterialComponents.MaterialFeatureHighlight
{
	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const CGFloat kMDCFeatureHighlightOuterHighlightAlpha;
		[Field("kMDCFeatureHighlightOuterHighlightAlpha", "__Internal")]
		nfloat kMDCFeatureHighlightOuterHighlightAlpha { get; }
	}

	// typedef void (^MDCFeatureHighlightCompletion)(BOOL);
	delegate void MDCFeatureHighlightCompletion(bool arg0);

	// @interface MDCFeatureHighlightViewController : UIViewController
	[BaseType(typeof(UIViewController))]
	[DisableDefaultCtor]
	interface MDCFeatureHighlightViewController
	{
		// -(instancetype _Nonnull)initWithHighlightedView:(UIView * _Nonnull)highlightedView andShowView:(UIView * _Nonnull)displayedView completion:(MDCFeatureHighlightCompletion _Nullable)completion __attribute__((objc_designated_initializer));
		[Export("initWithHighlightedView:andShowView:completion:")]
		[DesignatedInitializer]
		IntPtr Constructor(UIView highlightedView, UIView displayedView, [NullAllowed] MDCFeatureHighlightCompletion completion);

		// -(instancetype _Nonnull)initWithHighlightedView:(UIView * _Nonnull)highlightedView completion:(MDCFeatureHighlightCompletion _Nullable)completion;
		[Export("initWithHighlightedView:completion:")]
		IntPtr Constructor(UIView highlightedView, [NullAllowed] MDCFeatureHighlightCompletion completion);

		// @property (copy, nonatomic) NSString * _Nullable titleText;
		[NullAllowed, Export("titleText")]
		string TitleText { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable bodyText;
		[NullAllowed, Export("bodyText")]
		string BodyText { get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified outerHighlightColor;
		[Export("outerHighlightColor", ArgumentSemantic.Strong)]
		UIColor OuterHighlightColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified innerHighlightColor;
		[Export("innerHighlightColor", ArgumentSemantic.Strong)]
		UIColor InnerHighlightColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable titleColor;
		[NullAllowed, Export("titleColor", ArgumentSemantic.Strong)]
		UIColor TitleColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable bodyColor;
		[NullAllowed, Export("bodyColor", ArgumentSemantic.Strong)]
		UIColor BodyColor { get; set; }

		// -(void)acceptFeature;
		[Export("acceptFeature")]
		void AcceptFeature();

		// -(void)rejectFeature;
		[Export("rejectFeature")]
		void RejectFeature();
	}

	// @interface MDCFeatureHighlightView : UIView
	[BaseType(typeof(UIView))]
	interface MDCFeatureHighlightView
	{
		// @property (nonatomic, strong) UIColor * _Nullable innerHighlightColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("innerHighlightColor", ArgumentSemantic.Strong)]
		UIColor InnerHighlightColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable outerHighlightColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("outerHighlightColor", ArgumentSemantic.Strong)]
		UIColor OuterHighlightColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable titleColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("titleColor", ArgumentSemantic.Strong)]
		UIColor TitleColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable bodyColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("bodyColor", ArgumentSemantic.Strong)]
		UIColor BodyColor { get; set; }
	}
}
