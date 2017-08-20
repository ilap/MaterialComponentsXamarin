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
using CoreAnimation;
using Foundation;
using UIKit;
using ObjCRuntime;
using MaterialComponents;

namespace MaterialComponents.MaterialAnimationTiming
{
    // @interface MDCAnimationTiming (CAMediaTimingFunction)
    // FIXME: Disable category and rename it (add MDC_ Prefix) as register doesn't work properly
    //[Category]
    [BaseType(typeof(NSObject))]
    // FIXME: MT5211 ERROR add Protocol.
    [Protocol]
    interface MDC_CAMediaTimingFunction
    {
        // +(CAMediaTimingFunction *)mdc_functionWithType:(MDCAnimationTimingFunction)type;
        [Static]
        [Export("mdc_functionWithType:")]
        CoreAnimation.CAMediaTimingFunction Mdc_functionWithType(MDCAnimationTimingFunction type);
    }

    // @interface MDCTimingFunction (UIView)
    // FIXED: [Category] extension
    //  [BaseType(typeof(NSObject))]
    // [BaseType(typeof(UIView))]
    interface UIView_MDCTimingFunction
    {
        // +(void)mdc_animateWithTimingFunction:(CAMediaTimingFunction *)timingFunction duration:(NSTimeInterval)duration delay:(NSTimeInterval)delay options:(UIViewAnimationOptions)options animations:(void (^)(void))animations completion:(void (^)(BOOL))completion;
        [Static]
        [Export("mdc_animateWithTimingFunction:duration:delay:options:animations:completion:")]
        void Mdc_animateWithTimingFunction(CAMediaTimingFunction timingFunction, double duration, double delay, UIViewAnimationOptions options, Action animations, Action<bool> completion);
    }
}
