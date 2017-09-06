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
using MotionTransitioning;
using CoreGraphics;
using ObjCRuntime;
using UIKit;

namespace MotionTransitioning
{
	// @protocol MDMTransitionContext
	[Protocol] //Fixed, Model]
	[BaseType(typeof(NSObject))]
	//[DisableDefaultCtor]
	interface MDMTransitionContext
	{
		// @required -(void)transitionDidEnd;
		[Abstract]
		[Export("transitionDidEnd")]
		void TransitionDidEnd();

		// @required @property (readonly, nonatomic) MDMTransitionDirection direction;
		[Abstract]
		[Export("direction")]
		MDMTransitionDirection Direction { get; }

		// @required @property (readonly, nonatomic) NSTimeInterval duration;
		[Abstract]
		[Export("duration")]
		double Duration { get; }

		// @required @property (readonly, nonatomic, strong) UIViewController * _Nullable sourceViewController;
		[Abstract]
		[NullAllowed, Export("sourceViewController", ArgumentSemantic.Strong)]
		UIViewController SourceViewController { get; }

		// @required @property (readonly, nonatomic, strong) UIViewController * _Nonnull backViewController;
		[Abstract]
		[Export("backViewController", ArgumentSemantic.Strong)]
		UIViewController BackViewController { get; }

		// @required @property (readonly, nonatomic, strong) UIViewController * _Nonnull foreViewController;
		[Abstract]
		[Export("foreViewController", ArgumentSemantic.Strong)]
		UIViewController ForeViewController { get; }

		// @required @property (readonly, nonatomic, strong) UIView * _Nonnull containerView;
		[Abstract]
		[Export("containerView", ArgumentSemantic.Strong)]
		UIView ContainerView { get; }

		// @required @property (readonly, nonatomic, strong) UIPresentationController * _Nullable presentationController;
		[Abstract]
		[NullAllowed, Export("presentationController", ArgumentSemantic.Strong)]
		UIPresentationController PresentationController { get; }

        // @required -(void)deferToCompletion:(void (^ _Nonnull)(void))work;
        [Abstract]
        [Export("deferToCompletion:")]
        void DeferToCompletion(Action work);
	}

	// @protocol MDMTransition <NSObject>
	[Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MDMTransition
    {
        // @required -(void)startWithContext:(id<MDMTransitionContext> _Nonnull)context;
        [Abstract]
        [Export("startWithContext:")]
        void StartWithContext(MDMTransitionContext context);
    }

    // @protocol MDMTransitionWithCustomDuration
    [Protocol]//, Model]
    interface MDMTransitionWithCustomDuration
    {
        // @required -(NSTimeInterval)transitionDurationWithContext:(id<MDMTransitionContext> _Nonnull)context;
        [Abstract]
        [Export("transitionDurationWithContext:")]
        double TransitionDurationWithContext(MDMTransitionContext context);
    }

    // @protocol MDMTransitionWithFallback
    [Protocol]//, Model]
    interface MDMTransitionWithFallback
    {
        // @required -(id<MDMTransition> _Nullable)fallbackTransitionWithContext:(id<MDMTransitionContext> _Nonnull)context;
        [Abstract]
        [Export("fallbackTransitionWithContext:")]
        [return: NullAllowed]
        MDMTransition FallbackTransitionWithContext(MDMTransitionContext context);
    }


    // typedef CGRect (^MDMTransitionFrameCalculation)(UIPresentationController * _Nonnull);
    delegate CGRect MDMTransitionFrameCalculation(UIPresentationController arg0);

    // @interface MDMTransitionPresentationController : UIPresentationController
    [BaseType(typeof(UIPresentationController))]
    interface MDMTransitionPresentationController {
        // -(instancetype _Nonnull)initWithPresentedViewController:(UIViewController * _Nonnull)presentedViewController presentingViewController:(UIViewController * _Nonnull)presentingViewController calculateFrameOfPresentedView:(MDMTransitionFrameCalculation _Nullable)calculateFrameOfPresentedView __attribute__((objc_designated_initializer));
        [Export("initWithPresentedViewController:presentingViewController:calculateFrameOfPresentedView:")]
        [DesignatedInitializer]
        IntPtr Constructor(UIViewController presentedViewController, UIViewController presentingViewController, [NullAllowed] MDMTransitionFrameCalculation calculateFrameOfPresentedView);

        // @property (readonly, nonatomic, strong) UIView * _Nullable scrimView;
        [NullAllowed, Export("scrimView", ArgumentSemantic.Strong)]
        UIView ScrimView { get; }

        // @property (nonatomic, strong) id<MDMTransitionPresentationAnimationControlling> _Nullable animationController;
        [NullAllowed, Export("animationController", ArgumentSemantic.Strong)]
        MDMTransitionPresentationAnimationControlling AnimationController { get; set; }
    }

    // @protocol MDMTransitionWithPresentation <MDMTransition>
    [Protocol]//, Model]
    interface MDMTransitionWithPresentation : MDMTransition
    {
        // @required -(UIModalPresentationStyle)defaultModalPresentationStyle;
        [Abstract]
        [Export("defaultModalPresentationStyle")]
        //[Verify(MethodToProperty)]
        UIModalPresentationStyle DefaultModalPresentationStyle { get; }

        // @required -(UIPresentationController * _Nullable)presentationControllerForPresentedViewController:(UIViewController * _Nonnull)presented presentingViewController:(UIViewController * _Nonnull)presenting sourceViewController:(UIViewController * _Nullable)source;
        [Abstract]
        [Export("presentationControllerForPresentedViewController:presentingViewController:sourceViewController:")]
        [return: NullAllowed]
        UIPresentationController PresentingViewController(UIViewController presented, UIViewController presenting, [NullAllowed] UIViewController source);
    }

    // @protocol MDMTransitionPresentationAnimationControlling <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MDMTransitionPresentationAnimationControlling {
        // @optional -(void)presentationController:(MDMTransitionPresentationController * _Nonnull)presentationController startWithContext:(NSObject<MDMTransitionContext> * _Nonnull)context;
        [Export("presentationController:startWithContext:")]
        void PresentationController(MDMTransitionPresentationController presentationController, MDMTransitionContext context);

        // @optional -(void)dismissalTransitionWillBeginWithPresentationController:(MDMTransitionPresentationController * _Nonnull)presentationController;
        [Export("dismissalTransitionWillBeginWithPresentationController:")]
        void DismissalTransitionWillBeginWithPresentationController(MDMTransitionPresentationController presentationController);

        // @optional -(void)presentationController:(MDMTransitionPresentationController * _Nonnull)presentationController dismissalTransitionDidEnd:(BOOL)completed;
        [Export("presentationController:dismissalTransitionDidEnd:")]
        void PresentationController(MDMTransitionPresentationController presentationController, bool completed);
    }

    // @interface MDMTransitionViewSnapshotter : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MDMTransitionViewSnapshotter {
        // -(instancetype _Nonnull)initWithContainerView:(UIView * _Nonnull)containerView __attribute__((objc_designated_initializer));
        [Export("initWithContainerView:")]
        [DesignatedInitializer]
        IntPtr Constructor(UIView containerView);

        // -(UIView * _Nonnull)snapshotOfView:(UIView * _Nonnull)view isAppearing:(BOOL)isAppearing;
        [Export("snapshotOfView:isAppearing:")]
        UIView SnapshotOfView(UIView view, bool isAppearing);

        // -(void)removeAllSnapshots;
        [Export("removeAllSnapshots")]
        void RemoveAllSnapshots();
    }
}
