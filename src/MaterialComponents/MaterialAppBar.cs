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

namespace MaterialComponents.MaterialAppBar
{
	using MaterialComponents.MaterialFlexibleHeader;
	using MaterialComponents.MaterialHeaderStackView;
	using MaterialComponents.MaterialNavigationBar;

	/*// @interface MDCFlexibleHeaderContainerViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface MDCFlexibleHeaderContainerViewController
    {
        // -(instancetype _Nonnull)initWithContentViewController:(UIViewController * _Nullable)contentViewController __attribute__((objc_designated_initializer));
        [Export("initWithContentViewController:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] UIViewController contentViewController);

        // @property (readonly, nonatomic, strong) MDCFlexibleHeaderViewController * _Nonnull headerViewController;
        [Export("headerViewController", ArgumentSemantic.Strong)]
        MDCFlexibleHeaderViewController HeaderViewController { get; }

        // @property (nonatomic, strong) UIViewController * _Nullable contentViewController;
        [NullAllowed, Export("contentViewController", ArgumentSemantic.Strong)]
        UIViewController ContentViewController { get; set; }
    }*/

	// @interface MDCAppBarTextColorAccessibilityMutator : NSObject
	[BaseType(typeof(NSObject))]
	interface MDCAppBarTextColorAccessibilityMutator
	{
		// -(void)mutate:(MDCAppBar * _Nonnull)appBar;
		[Export("mutate:")]
		void Mutate(MDCAppBar appBar);
	}

	// @interface MDCAppBar : NSObject
	[BaseType(typeof(NSObject))]
	interface MDCAppBar
	{
		// -(void)addSubviewsToParent;
		[Export("addSubviewsToParent")]
		void AddSubviewsToParent();

		// @property (readonly, nonatomic, strong) MDCFlexibleHeaderViewController * _Nonnull headerViewController;
		[Export("headerViewController", ArgumentSemantic.Strong)]
		MDCFlexibleHeaderViewController HeaderViewController { get; }

		// @property (readonly, nonatomic, strong) MDCNavigationBar * _Nonnull navigationBar;
		[Export("navigationBar", ArgumentSemantic.Strong)]
		MDCNavigationBar NavigationBar { get; }

		// @property (readonly, nonatomic, strong) MDCHeaderStackView * _Nonnull headerStackView;
		[Export("headerStackView", ArgumentSemantic.Strong)]
		MDCHeaderStackView HeaderStackView { get; }
	}

	// @interface MDCAppBarContainerViewController : UIViewController
	[BaseType(typeof(UIViewController))]
	[DisableDefaultCtor]
	interface MDCAppBarContainerViewController
	{
		// -(instancetype _Nonnull)initWithContentViewController:(UIViewController * _Nonnull)contentViewController __attribute__((objc_designated_initializer));
		[Export("initWithContentViewController:")]
		[DesignatedInitializer]
		IntPtr Constructor(UIViewController contentViewController);

		// @property (readonly, nonatomic, strong) MDCAppBar * _Nonnull appBar;
		[Export("appBar", ArgumentSemantic.Strong)]
		MDCAppBar AppBar { get; }

		// @property (readonly, nonatomic, strong) UIViewController * _Nonnull contentViewController;
		[Export("contentViewController", ArgumentSemantic.Strong)]
		UIViewController ContentViewController { get; }
	}
}
