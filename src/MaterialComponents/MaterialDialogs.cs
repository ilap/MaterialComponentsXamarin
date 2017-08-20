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

using CoreGraphics;
using Foundation;
using MaterialComponents;
using UIKit;

namespace MaterialComponents.MaterialDialogs
{
	// @interface MDCAlertController : UIViewController
	//FIXME: CS0108 and CS0114 by replacing [Protocol] -> [Protocol, Model]
	[Protocol, Model]
	[BaseType (typeof(UIViewController))]
	interface MDCAlertController
	{
		// +(instancetype _Nonnull)alertControllerWithTitle:(NSString * _Nullable)title message:(NSString * _Nullable)message;
		[Static]
		[Export ("alertControllerWithTitle:message:")]
		MDCAlertController AlertControllerWithTitle ([NullAllowed] string title, [NullAllowed] string message);

		// -(void)addAction:(MDCAlertAction * _Nonnull)action;
		[Export ("addAction:")]
		void AddAction (MDCAlertAction action);

		// @property (readonly, nonatomic) NSArray<MDCAlertAction *> * _Nonnull actions;
		[Export ("actions")]
		MDCAlertAction[] Actions { get; }

		// @property (copy, nonatomic) NSString * _Nullable title;
		[NullAllowed, Export ("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable message;
		[NullAllowed, Export ("message")]
		string Message { get; set; }

		// @property (readwrite, nonatomic, setter = mdc_setAdjustsFontForContentSizeCategory:) BOOL mdc_adjustsFontForContentSizeCategory __attribute__((annotate("ui_appearance_selector")));
		[Export ("mdc_adjustsFontForContentSizeCategory")]
		bool Mdc_adjustsFontForContentSizeCategory { get; [Bind ("mdc_setAdjustsFontForContentSizeCategory:")] set; }
	}

	// typedef void (^MDCActionHandler)(MDCAlertAction * _Nonnull);
	delegate void MDCActionHandler (MDCAlertAction arg0);

	// @interface MDCAlertAction : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MDCAlertAction : INSCopying
	{
		// +(instancetype _Nonnull)actionWithTitle:(NSString * _Nonnull)title handler:(MDCActionHandler _Nullable)handler;
		[Static]
		[Export ("actionWithTitle:handler:")]
		MDCAlertAction ActionWithTitle (string title, [NullAllowed] MDCActionHandler handler);

		// @property (readonly, nonatomic) NSString * _Nullable title;
		[NullAllowed, Export ("title")]
		string Title { get; }
	}

	// @interface MDCDialogPresentationController : UIPresentationController
	[BaseType (typeof(UIPresentationController))]
	interface MDCDialogPresentationController
	{
		// @property (assign, nonatomic) BOOL dismissOnBackgroundTap;
		[Export ("dismissOnBackgroundTap")]
		bool DismissOnBackgroundTap { get; set; }

		// -(CGSize)sizeForChildContentContainer:(id<UIContentContainer> _Nonnull)container withParentContainerSize:(CGSize)parentSize;
		[Export ("sizeForChildContentContainer:withParentContainerSize:")]
		CGSize SizeForChildContentContainer (UIContentContainer container, CGSize parentSize);

		// -(CGRect)frameOfPresentedViewInContainerView;
		[Export ("frameOfPresentedViewInContainerView")]
		//[Verify (MethodToProperty)]
		CGRect FrameOfPresentedViewInContainerView { get; }
	}

	// @interface MDCDialogTransitionController : NSObject <UIViewControllerAnimatedTransitioning, UIViewControllerTransitioningDelegate>
	[BaseType (typeof(NSObject))]
	interface MDCDialogTransitionController : IUIViewControllerAnimatedTransitioning, IUIViewControllerTransitioningDelegate
	{
	}

	// @interface MaterialDialogs (UIViewController)
	//[Category]
    //HACK: Check[BaseType (typeof(UIViewController))]
	interface UIViewController_MaterialDialogs
	{
		// @property (readonly, nonatomic) MDCDialogPresentationController * _Nullable mdc_dialogPresentationController;
		[NullAllowed, Export ("mdc_dialogPresentationController")]
		MDCDialogPresentationController Mdc_dialogPresentationController { get; }
	}
}
