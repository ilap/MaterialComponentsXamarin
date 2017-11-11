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
using CoreAnimation;
using CoreGraphics;
using UIKit;
using MaterialComponents;
using ObjCRuntime;

namespace MaterialComponents.MaterialFlexibleHeader
{
	// @interface MDCFlexibleHeaderContainerViewController : UIViewController
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
	}

	// typedef void (^MDCFlexibleHeaderChangeContentInsetsBlock)();
	delegate void MDCFlexibleHeaderChangeContentInsetsBlock();

	// typedef void (^MDCFlexibleHeaderShadowIntensityChangeBlock)(CALayer * _Nonnull, CGFloat);
	delegate void MDCFlexibleHeaderShadowIntensityChangeBlock(CALayer arg0, nfloat arg1);

	// @interface MDCFlexibleHeaderView : UIView
	[BaseType(typeof(UIView))]
	interface MDCFlexibleHeaderView
	{
		// @property (nonatomic, strong) CALayer * _Nullable shadowLayer;
		[NullAllowed, Export("shadowLayer", ArgumentSemantic.Strong)]
		CALayer ShadowLayer { get; set; }

		// -(void)setShadowLayer:(CALayer * _Nonnull)shadowLayer intensityDidChangeBlock:(MDCFlexibleHeaderShadowIntensityChangeBlock _Nonnull)block;
		[Export("setShadowLayer:intensityDidChangeBlock:")]
		void SetShadowLayer(CALayer shadowLayer, MDCFlexibleHeaderShadowIntensityChangeBlock block);

		// -(void)trackingScrollViewDidScroll;
		[Export("trackingScrollViewDidScroll")]
		void TrackingScrollViewDidScroll();
		//void Scrolled(UIScrollView scrollView);

		// -(void)trackingScrollViewDidEndDraggingWillDecelerate:(BOOL)willDecelerate;
		[Export("trackingScrollViewDidEndDraggingWillDecelerate:")]
		void TrackingScrollViewDidEndDraggingWillDecelerate(bool willDecelerate);

		// -(void)trackingScrollViewDidEndDecelerating;
		[Export("trackingScrollViewDidEndDecelerating")]
		void TrackingScrollViewDidEndDecelerating();

		// -(BOOL)trackingScrollViewWillEndDraggingWithVelocity:(CGPoint)velocity targetContentOffset:(CGPoint * _Nonnull)targetContentOffset;
		// HACK: was CGPoint* targetContentOffset 
		[Export("trackingScrollViewWillEndDraggingWithVelocity:targetContentOffset:")]
		unsafe bool TrackingScrollViewWillEndDraggingWithVelocity(CGPoint velocity, CGPoint targetContentOffset);

		// -(void)trackingScrollWillChangeToScrollView:(UIScrollView * _Nullable)scrollView;
		[Export("trackingScrollWillChangeToScrollView:")]
		void TrackingScrollWillChangeToScrollView([NullAllowed] UIScrollView scrollView);

		// -(void)shiftHeaderOnScreenAnimated:(BOOL)animated;
		[Export("shiftHeaderOnScreenAnimated:")]
		void ShiftHeaderOnScreenAnimated(bool animated);

		// -(void)shiftHeaderOffScreenAnimated:(BOOL)animated;
		[Export("shiftHeaderOffScreenAnimated:")]
		void ShiftHeaderOffScreenAnimated(bool animated);

		// @property (readonly, nonatomic) BOOL prefersStatusBarHidden;
		[Export("prefersStatusBarHidden")]
		bool PrefersStatusBarHidden { get; }

		// -(void)interfaceOrientationWillChange;
		[Export("interfaceOrientationWillChange")]
		void InterfaceOrientationWillChange();

		// -(void)interfaceOrientationIsChanging;
		[Export("interfaceOrientationIsChanging")]
		void InterfaceOrientationIsChanging();

		// -(void)interfaceOrientationDidChange;
		[Export("interfaceOrientationDidChange")]
		void InterfaceOrientationDidChange();

		// -(void)viewWillTransitionToSize:(CGSize)size withTransitionCoordinator:(id<UIViewControllerTransitionCoordinator> _Nonnull)coordinator;
		[Export("viewWillTransitionToSize:withTransitionCoordinator:")]
		void ViewWillTransitionToSize(CGSize size, IUIViewControllerTransitionCoordinator coordinator);

		// -(void)changeContentInsets:(MDCFlexibleHeaderChangeContentInsetsBlock _Nonnull)block;
		[Export("changeContentInsets:")]
		void ChangeContentInsets(MDCFlexibleHeaderChangeContentInsetsBlock block);

		// -(void)forwardTouchEventsForView:(UIView * _Nonnull)view;
		[Export("forwardTouchEventsForView:")]
		void ForwardTouchEventsForView(UIView view);

		// -(void)stopForwardingTouchEventsForView:(UIView * _Nonnull)view;
		[Export("stopForwardingTouchEventsForView:")]
		void StopForwardingTouchEventsForView(UIView view);

		// @property (readonly, nonatomic) MDCFlexibleHeaderScrollPhase scrollPhase;
		[Export("scrollPhase")]
		MDCFlexibleHeaderScrollPhase ScrollPhase { get; }

		// @property (readonly, nonatomic) CGFloat scrollPhaseValue;
		[Export("scrollPhaseValue")]
		nfloat ScrollPhaseValue { get; }

		// @property (readonly, nonatomic) CGFloat scrollPhasePercentage;
		[Export("scrollPhasePercentage")]
		nfloat ScrollPhasePercentage { get; }

		// @property (nonatomic) CGFloat minimumHeight;
		[Export("minimumHeight")]
		nfloat MinimumHeight { get; set; }

		// @property (nonatomic) CGFloat maximumHeight;
		[Export("maximumHeight")]
		nfloat MaximumHeight { get; set; }

        // @property (nonatomic) BOOL minMaxHeightIncludesSafeArea;
        [Export("minMaxHeightIncludesSafeArea")]
        bool MinMaxHeightIncludesSafeArea { get; set; }

		// @property (nonatomic) MDCFlexibleHeaderShiftBehavior shiftBehavior;
		[Export("shiftBehavior", ArgumentSemantic.Assign)]
		MDCFlexibleHeaderShiftBehavior ShiftBehavior { get; set; }

		// @property (nonatomic) MDCFlexibleHeaderContentImportance headerContentImportance;
		[Export("headerContentImportance", ArgumentSemantic.Assign)]
		MDCFlexibleHeaderContentImportance HeaderContentImportance { get; set; }

		// @property (nonatomic) BOOL canOverExtend;
		[Export("canOverExtend")]
		bool CanOverExtend { get; set; }

		// @property (nonatomic) BOOL statusBarHintCanOverlapHeader;
		[Export("statusBarHintCanOverlapHeader")]
		bool StatusBarHintCanOverlapHeader { get; set; }

		// @property (nonatomic) float visibleShadowOpacity;
		[Export("visibleShadowOpacity")]
		float VisibleShadowOpacity { get; set; }

		// @property (nonatomic, weak) UIScrollView * _Nullable trackingScrollView;
		[NullAllowed, Export("trackingScrollView", ArgumentSemantic.Weak)]
		UIScrollView TrackingScrollView { get; set; }

		// @property (nonatomic) BOOL trackingScrollViewIsBeingScrubbed;
		[Export("trackingScrollViewIsBeingScrubbed")]
		bool TrackingScrollViewIsBeingScrubbed { get; set; }

		// @property (getter = isInFrontOfInfiniteContent, nonatomic) BOOL inFrontOfInfiniteContent;
		[Export("inFrontOfInfiniteContent")]
		bool InFrontOfInfiniteContent { [Bind("isInFrontOfInfiniteContent")] get; set; }

		// @property (nonatomic) BOOL sharedWithManyScrollViews;
		[Export("sharedWithManyScrollViews")]
		bool SharedWithManyScrollViews { get; set; }

		// @property (nonatomic) BOOL contentIsTranslucent;
		[Export("contentIsTranslucent")]
		bool ContentIsTranslucent { get; set; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		MDCFlexibleHeaderViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MDCFlexibleHeaderViewDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic) MDCFlexibleHeaderShiftBehavior behavior __attribute__((deprecated("Use shiftBehavior instead.")));

		[Export("behavior", ArgumentSemantic.Assign)]
		MDCFlexibleHeaderShiftBehavior Behavior { get; set; }

		// @property (nonatomic, strong) UIView * _Nonnull contentView __attribute__((deprecated("Please register views directly to the flexible header.")));
		[Export("contentView", ArgumentSemantic.Strong)]
		UIView ContentView { get; set; }
	}

	// @protocol MDCFlexibleHeaderViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCFlexibleHeaderViewDelegate
	{
		// @required -(void)flexibleHeaderViewNeedsStatusBarAppearanceUpdate:(MDCFlexibleHeaderView * _Nonnull)headerView;
		[Abstract]
		[Export("flexibleHeaderViewNeedsStatusBarAppearanceUpdate:")]
		void FlexibleHeaderViewNeedsStatusBarAppearanceUpdate(MDCFlexibleHeaderView headerView);

		// @required -(void)flexibleHeaderViewFrameDidChange:(MDCFlexibleHeaderView * _Nonnull)headerView;
		[Abstract]
		[Export("flexibleHeaderViewFrameDidChange:")]
		void FlexibleHeaderViewFrameDidChange(MDCFlexibleHeaderView headerView);
	}

	// @interface MDCFlexibleHeaderViewController : UIViewController <UIScrollViewDelegate, UITableViewDelegate>
	[BaseType(typeof(UIViewController))]
	interface MDCFlexibleHeaderViewController : IUIScrollViewDelegate, IUITableViewDelegate
	{
		// @property (readonly, nonatomic, strong) MDCFlexibleHeaderView * _Nonnull headerView;
		[Export("headerView", ArgumentSemantic.Strong)]
		MDCFlexibleHeaderView HeaderView { get; }

		[Wrap("WeakLayoutDelegate")]
		[NullAllowed]
		MDCFlexibleHeaderViewLayoutDelegate LayoutDelegate { get; set; }

		// @property (nonatomic, weak) id<MDCFlexibleHeaderViewLayoutDelegate> _Nullable layoutDelegate;
		[NullAllowed, Export("layoutDelegate", ArgumentSemantic.Weak)]
		NSObject WeakLayoutDelegate { get; set; }

		// -(BOOL)prefersStatusBarHidden;
		[Export("prefersStatusBarHidden")]
		//[Verify(MethodToProperty)]
		bool PrefersStatusBarHidden();

		// -(UIStatusBarStyle)preferredStatusBarStyle;
		[Export("preferredStatusBarStyle")]
		//[Verify(MethodToProperty)]
		UIStatusBarStyle PreferredStatusBarStyle();

		// -(void)updateTopLayoutGuide;
		[Export("updateTopLayoutGuide")]
		void UpdateTopLayoutGuide();
	}

	// @protocol MDCFlexibleHeaderViewLayoutDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCFlexibleHeaderViewLayoutDelegate
	{
		// @required -(void)flexibleHeaderViewController:(MDCFlexibleHeaderViewController * _Nonnull)flexibleHeaderViewController flexibleHeaderViewFrameDidChange:(MDCFlexibleHeaderView * _Nonnull)flexibleHeaderView;
		[Abstract]
		[Export("flexibleHeaderViewController:flexibleHeaderViewFrameDidChange:")]
		void FlexibleHeaderViewFrameDidChange(MDCFlexibleHeaderViewController flexibleHeaderViewController, MDCFlexibleHeaderView flexibleHeaderView);
	}
}
