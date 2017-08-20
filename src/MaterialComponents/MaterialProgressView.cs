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

namespace MaterialComponents.MaterialProgressView
{
	// @interface MDCProgressView : UIView
	[BaseType(typeof(UIView))]
	interface MDCProgressView
	{
		// @property (nonatomic, strong) UIColor * _Null_unspecified progressTintColor __attribute__((annotate("ui_appearance_selector")));
		[Export("progressTintColor", ArgumentSemantic.Strong)]
		UIColor ProgressTintColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified trackTintColor __attribute__((annotate("ui_appearance_selector")));
		[Export("trackTintColor", ArgumentSemantic.Strong)]
		UIColor TrackTintColor { get; set; }

		// @property (assign, nonatomic) float progress;
		[Export("progress")]
		float Progress { get; set; }

		// @property (assign, nonatomic) MDCProgressViewBackwardAnimationMode backwardProgressAnimationMode;
		[Export("backwardProgressAnimationMode", ArgumentSemantic.Assign)]
		MDCProgressViewBackwardAnimationMode BackwardProgressAnimationMode { get; set; }

		// -(void)setProgress:(float)progress animated:(BOOL)animated completion:(void (^ _Nullable)(BOOL))completion;
		[Export("setProgress:animated:completion:")]
		void SetProgress(float progress, bool animated, [NullAllowed] Action<bool> completion);

		// -(void)setHidden:(BOOL)hidden animated:(BOOL)animated completion:(void (^ _Nullable)(BOOL))completion;
		[Export("setHidden:animated:completion:")]
		void SetHidden(bool hidden, bool animated, [NullAllowed] Action<bool> completion);
	}
}
