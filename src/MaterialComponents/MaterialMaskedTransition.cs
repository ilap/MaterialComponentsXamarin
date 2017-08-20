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
using MotionTransitioning;

namespace MaterialComponents.MaterialMaskedTransition
{
	// @interface MDCMaskedTransition : NSObject <MDMTransition>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MDCMaskedTransition : MDMTransition
	{
		// -(instancetype _Nonnull)initWithSourceView:(UIView * _Nonnull)sourceView __attribute__((objc_designated_initializer));
		[Export ("initWithSourceView:")]
		[DesignatedInitializer]
		IntPtr Constructor (UIView sourceView);

		// @property (copy, nonatomic) CGRect (^ _Nullable)(UIPresentationController * _Nonnull) calculateFrameOfPresentedView;
		[NullAllowed, Export ("calculateFrameOfPresentedView", ArgumentSemantic.Copy)]
		Func<UIPresentationController, CGRect> CalculateFrameOfPresentedView { get; set; }
	}
}
