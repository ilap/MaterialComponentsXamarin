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

namespace MaterialComponents.MaterialActivityIndicator
{
	// @interface MDCActivityIndicator : UIView
	[BaseType(typeof(UIView))]
	interface MDCActivityIndicator
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		MDCActivityIndicatorDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MDCActivityIndicatorDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (getter = isAnimating, assign, nonatomic) BOOL animating;
		[Export("animating")]
		bool Animating { [Bind("isAnimating")] get; set; }

		// @property (assign, nonatomic) CGFloat radius __attribute__((annotate("ui_appearance_selector")));
		[Export("radius")]
		nfloat Radius { get; set; }

		// @property (assign, nonatomic) CGFloat strokeWidth __attribute__((annotate("ui_appearance_selector")));
		[Export("strokeWidth")]
		nfloat StrokeWidth { get; set; }

		// @property (assign, nonatomic) BOOL trackEnabled;
		[Export("trackEnabled")]
		bool TrackEnabled { get; set; }

		// @property (assign, nonatomic) MDCActivityIndicatorMode indicatorMode;
		[Export("indicatorMode", ArgumentSemantic.Assign)]
		MDCActivityIndicatorMode IndicatorMode { get; set; }

		// -(void)setIndicatorMode:(MDCActivityIndicatorMode)mode animated:(BOOL)animated;
		[Export("setIndicatorMode:animated:")]
		void SetIndicatorMode(MDCActivityIndicatorMode mode, bool animated);

		// @property (assign, nonatomic) float progress;
		[Export("progress")]
		float Progress { get; set; }

		// @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull cycleColors __attribute__((annotate("ui_appearance_selector")));
		[Export("cycleColors", ArgumentSemantic.Copy)]
		UIColor[] CycleColors { get; set; }

		// -(void)startAnimating;
		[Export("startAnimating")]
		void StartAnimating();

		// -(void)stopAnimating;
		[Export("stopAnimating")]
		void StopAnimating();
	}

	// @protocol MDCActivityIndicatorDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCActivityIndicatorDelegate
	{
		// @optional -(void)activityIndicatorAnimationDidFinish:(MDCActivityIndicator * _Nonnull)activityIndicator;
		[Export("activityIndicatorAnimationDidFinish:")]
		void ActivityIndicatorAnimationDidFinish(MDCActivityIndicator activityIndicator);
	}
}
