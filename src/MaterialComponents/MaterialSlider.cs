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
using ObjCRuntime;

namespace MaterialComponents.MaterialSlider
{
	// @interface MDCSlider : UIControl <NSSecureCoding>
	[BaseType(typeof(UIControl))]
	interface MDCSlider : INSSecureCoding
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		MDCSliderDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MDCSliderDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified color;
		[Export("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified trackBackgroundColor;
		[Export("trackBackgroundColor", ArgumentSemantic.Strong)]
		UIColor TrackBackgroundColor { get; set; }

		// @property (assign, nonatomic) NSUInteger numberOfDiscreteValues;
		[Export("numberOfDiscreteValues")]
		nuint NumberOfDiscreteValues { get; set; }

		// @property (assign, nonatomic) CGFloat value;
		[Export("value")]
		nfloat Value { get; set; }

		// -(void)setValue:(CGFloat)value animated:(BOOL)animated;
		[Export("setValue:animated:")]
		void SetValue(nfloat value, bool animated);

		// @property (assign, nonatomic) CGFloat minimumValue;
		[Export("minimumValue")]
		nfloat MinimumValue { get; set; }

		// @property (assign, nonatomic) CGFloat maximumValue;
		[Export("maximumValue")]
		nfloat MaximumValue { get; set; }

		// @property (getter = isContinuous, assign, nonatomic) BOOL continuous;
		[Export("continuous")]
		bool Continuous { [Bind("isContinuous")] get; set; }

		// @property (assign, nonatomic) CGFloat filledTrackAnchorValue;
		[Export("filledTrackAnchorValue")]
		nfloat FilledTrackAnchorValue { get; set; }

		// @property (assign, nonatomic) BOOL shouldDisplayDiscreteValueLabel;
		[Export("shouldDisplayDiscreteValueLabel")]
		bool ShouldDisplayDiscreteValueLabel { get; set; }

		// @property (getter = isThumbHollowAtStart, assign, nonatomic) BOOL thumbHollowAtStart;
		[Export("thumbHollowAtStart")]
		bool ThumbHollowAtStart { [Bind("isThumbHollowAtStart")] get; set; }
	}

	// @protocol MDCSliderDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCSliderDelegate
	{
		// @optional -(BOOL)slider:(MDCSlider * _Nonnull)slider shouldJumpToValue:(CGFloat)value;
		[Export("slider:shouldJumpToValue:")]
		bool Slider(MDCSlider slider, float value);

		// @optional -(NSString * _Nonnull)slider:(MDCSlider * _Nonnull)slider displayedStringForValue:(CGFloat)value;
		[Export("slider:displayedStringForValue:")]
		string Slider_DisplayedStringForValue(MDCSlider slider, float value);

		// @optional -(NSString * _Nonnull)slider:(MDCSlider * _Nonnull)slider accessibilityLabelForValue:(CGFloat)value;
		[Export("slider:accessibilityLabelForValue:")]
		string Slider_AccessibilityLabelForValue(MDCSlider slider, float value);
	}
}
