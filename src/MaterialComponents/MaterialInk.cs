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
using CoreGraphics;
using UIKit;
using MaterialComponents;
using ObjCRuntime;

namespace MaterialComponents.MaterialInk
{
	// @interface MDCInkGestureRecognizer : UIGestureRecognizer
	[BaseType(typeof(UIGestureRecognizer))]
	interface MDCInkGestureRecognizer
	{
		// @property (assign, nonatomic) CGFloat dragCancelDistance;
		[Export("dragCancelDistance")]
		nfloat DragCancelDistance { get; set; }

		// @property (assign, nonatomic) BOOL cancelOnDragOut;
		[Export("cancelOnDragOut")]
		bool CancelOnDragOut { get; set; }

		// @property (nonatomic) CGRect targetBounds;
		[Export("targetBounds", ArgumentSemantic.Assign)]
		CGRect TargetBounds { get; set; }

		// -(CGPoint)touchStartLocationInView:(UIView *)view;
		[Export("touchStartLocationInView:")]
		CGPoint TouchStartLocationInView(UIView view);

		// -(BOOL)isTouchWithinTargetBounds;
		[Export("isTouchWithinTargetBounds")]
		//[Verify(MethodToProperty)]
		bool IsTouchWithinTargetBounds { get; }
	}

	// @interface MDCInkTouchController : NSObject <UIGestureRecognizerDelegate>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface MDCInkTouchController : IUIGestureRecognizerDelegate
	{
		// @property (readonly, nonatomic, weak) UIView * _Nullable view;
		[NullAllowed, Export("view", ArgumentSemantic.Weak)]
		UIView View { get; }

		// @property (readonly, nonatomic, strong) MDCInkView * _Nonnull defaultInkView;
		[Export("defaultInkView", ArgumentSemantic.Strong)]
		MDCInkView DefaultInkView { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		MDCInkTouchControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MDCInkTouchControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL delaysInkSpread;
		[Export("delaysInkSpread")]
		bool DelaysInkSpread { get; set; }

		// @property (assign, nonatomic) CGFloat dragCancelDistance;
		[Export("dragCancelDistance")]
		nfloat DragCancelDistance { get; set; }

		// @property (assign, nonatomic) BOOL cancelsOnDragOut;
		[Export("cancelsOnDragOut")]
		bool CancelsOnDragOut { get; set; }

		// @property (nonatomic) CGRect targetBounds;
		[Export("targetBounds", ArgumentSemantic.Assign)]
		CGRect TargetBounds { get; set; }

		// @property (readonly, nonatomic, strong) MDCInkGestureRecognizer * _Nonnull gestureRecognizer;
		[Export("gestureRecognizer", ArgumentSemantic.Strong)]
		MDCInkGestureRecognizer GestureRecognizer { get; }

		// -(instancetype _Nonnull)initWithView:(UIView * _Nonnull)view __attribute__((objc_designated_initializer));
		[Export("initWithView:")]
		[DesignatedInitializer]
		IntPtr Constructor(UIView view);

		// -(void)addInkView;
		[Export("addInkView")]
		void AddInkView();

		// -(void)cancelInkTouchProcessing;
		[Export("cancelInkTouchProcessing")]
		void CancelInkTouchProcessing();

		// -(MDCInkView * _Nullable)inkViewAtTouchLocation:(CGPoint)location;
		[Export("inkViewAtTouchLocation:")]
		[return: NullAllowed]
		MDCInkView InkViewAtTouchLocation(CGPoint location);
	}

	// @protocol MDCInkTouchControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCInkTouchControllerDelegate
	{
		// @optional -(void)inkTouchController:(MDCInkTouchController * _Nonnull)inkTouchController insertInkView:(UIView * _Nonnull)inkView intoView:(UIView * _Nonnull)view;
		[Export("inkTouchController:insertInkView:intoView:")]
		void InkTouchController(MDCInkTouchController inkTouchController, UIView inkView, UIView view);

		// @optional -(MDCInkView * _Nullable)inkTouchController:(MDCInkTouchController * _Nonnull)inkTouchController inkViewAtTouchLocation:(CGPoint)location;
		[Export("inkTouchController:inkViewAtTouchLocation:")]
		[return: NullAllowed]
		MDCInkView InkTouchControllerInkViewAtTouchLocation(MDCInkTouchController inkTouchController, CGPoint location);

		// @optional -(BOOL)inkTouchController:(MDCInkTouchController * _Nonnull)inkTouchController shouldProcessInkTouchesAtTouchLocation:(CGPoint)location;
		[Export("inkTouchController:shouldProcessInkTouchesAtTouchLocation:")]
		bool InkTouchController(MDCInkTouchController inkTouchController, CGPoint location);

		// @optional -(void)inkTouchController:(MDCInkTouchController * _Nonnull)inkTouchController didProcessInkView:(MDCInkView * _Nonnull)inkView atTouchLocation:(CGPoint)location;
		[Export("inkTouchController:didProcessInkView:atTouchLocation:")]
		void InkTouchController(MDCInkTouchController inkTouchController, MDCInkView inkView, CGPoint location);
	}

	// typedef void (^MDCInkCompletionBlock)();
	delegate void MDCInkCompletionBlock();

	// @interface MDCInkView : UIView
	[BaseType(typeof(UIView))]
	interface MDCInkView
	{
		// @property (assign, nonatomic) MDCInkStyle inkStyle;
		[Export("inkStyle", ArgumentSemantic.Assign)]
		MDCInkStyle InkStyle { get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified inkColor;
		[Export("inkColor", ArgumentSemantic.Strong)]
		UIColor InkColor { get; set; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull defaultInkColor;
		[Export("defaultInkColor", ArgumentSemantic.Strong)]
		UIColor DefaultInkColor { get; }

		// @property (assign, nonatomic) CGFloat maxRippleRadius;
		[Export("maxRippleRadius")]
		nfloat MaxRippleRadius { get; set; }

		// @property (assign, nonatomic) BOOL usesCustomInkCenter;
		[Export("usesCustomInkCenter")]
		bool UsesCustomInkCenter { get; set; }

		// @property (assign, nonatomic) CGPoint customInkCenter;
		[Export("customInkCenter", ArgumentSemantic.Assign)]
		CGPoint CustomInkCenter { get; set; }

		// -(void)startTouchBeganAnimationAtPoint:(CGPoint)point completion:(MDCInkCompletionBlock _Nullable)completionBlock;
		[Export("startTouchBeganAnimationAtPoint:completion:")]
		void StartTouchBeganAnimationAtPoint(CGPoint point, [NullAllowed] MDCInkCompletionBlock completionBlock);

		// -(void)startTouchEndedAnimationAtPoint:(CGPoint)point completion:(MDCInkCompletionBlock _Nullable)completionBlock;
		[Export("startTouchEndedAnimationAtPoint:completion:")]
		void StartTouchEndedAnimationAtPoint(CGPoint point, [NullAllowed] MDCInkCompletionBlock completionBlock);

		// -(void)cancelAllAnimationsAnimated:(BOOL)animated;
		[Export("cancelAllAnimationsAnimated:")]
		void CancelAllAnimationsAnimated(bool animated);
	}

}
