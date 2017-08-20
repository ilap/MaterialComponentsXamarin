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

namespace MaterialComponents.MaterialBottomSheet
{
	// @interface MDCBottomSheetController : UIViewController
	[BaseType(typeof(UIViewController))]
	interface MDCBottomSheetController
	{
		// @property (readonly, nonatomic, strong) UIViewController * _Nonnull contentViewController;
		[Export("contentViewController", ArgumentSemantic.Strong)]
		UIViewController ContentViewController { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		MDCBottomSheetControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MDCBottomSheetControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype _Nonnull)initWithContentViewController:(UIViewController * _Nonnull)contentViewController;
		[Export("initWithContentViewController:")]
		IntPtr Constructor(UIViewController contentViewController);
	}

	// @protocol MDCBottomSheetControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCBottomSheetControllerDelegate
	{
		// @required -(void)bottomSheetControllerDidDismissBottomSheet:(MDCBottomSheetController * _Nonnull)controller;
		[Abstract]
		[Export("bottomSheetControllerDidDismissBottomSheet:")]
		void BottomSheetControllerDidDismissBottomSheet(MDCBottomSheetController controller);
	}

	// @protocol MDCBottomSheetPresentationControllerDelegate <UIAdaptivePresentationControllerDelegate>
    //FIXME: CS0108 and CS0114 by replacing [Protocol] -> [Protocol, Model] DOES NOT WORK
	[Protocol]
	[BaseType(typeof(UIAdaptivePresentationControllerDelegate))]
	interface MDCBottomSheetPresentationControllerDelegate
	{
		// @optional -(void)prepareForBottomSheetPresentation:(MDCBottomSheetPresentationController * _Nonnull)bottomSheet;
		[Export("prepareForBottomSheetPresentation:")]
		void PrepareForBottomSheetPresentation(MDCBottomSheetPresentationController bottomSheet);

		// @optional -(void)bottomSheetPresentationControllerDidDismissBottomSheet:(MDCBottomSheetPresentationController * _Nonnull)bottomSheet;
		[Export("bottomSheetPresentationControllerDidDismissBottomSheet:")]
		void BottomSheetPresentationControllerDidDismissBottomSheet(MDCBottomSheetPresentationController bottomSheet);
	}

	// @interface MDCBottomSheetPresentationController : UIPresentationController
	[BaseType(typeof(UIPresentationController))]
	interface MDCBottomSheetPresentationController
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		MDCBottomSheetPresentationControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MDCBottomSheetPresentationControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

	}

	// @interface MDCBottomSheetTransitionController : NSObject <UIViewControllerAnimatedTransitioning, UIViewControllerTransitioningDelegate>
	[BaseType(typeof(NSObject))]
	interface MDCBottomSheetTransitionController : IUIViewControllerAnimatedTransitioning, IUIViewControllerTransitioningDelegate
	{
	}

	// @interface MaterialBottomSheet (UIViewController)
	[Category]
	[BaseType(typeof(UIViewController))]
	interface UIViewController_MaterialBottomSheet
	{
		// @property (readonly, nonatomic) MDCBottomSheetPresentationController * _Nullable mdc_bottomSheetPresentationController;
		//XXX: Converted from property { get } to method.
		[NullAllowed, Export("mdc_bottomSheetPresentationController")]
		MDCBottomSheetPresentationController Mdc_bottomSheetPresentationController();
	}
}
