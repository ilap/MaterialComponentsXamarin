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
using ObjCRuntime;
using MaterialComponents.MaterialInk;
using MaterialComponents.MaterialButtons;
using MaterialComponents;


namespace MaterialComponents.MaterialBottomAppBar {
    
    // @interface MDCBottomAppBarView : UIView
    [BaseType(typeof(UIView))]
    interface MDCBottomAppBarView {
        // @property (getter = isFloatingButtonHidden, assign, nonatomic) BOOL floatingButtonHidden;
        [Export("floatingButtonHidden")]
        bool FloatingButtonHidden { [Bind("isFloatingButtonHidden")] get; set; }

        // @property (assign, nonatomic) MDCBottomAppBarFloatingButtonElevation floatingButtonElevation;
        [Export("floatingButtonElevation", ArgumentSemantic.Assign)]
        MDCBottomAppBarFloatingButtonElevation FloatingButtonElevation { get; set; }

        // @property (assign, nonatomic) MDCBottomAppBarFloatingButtonPosition floatingButtonPosition;
        [Export("floatingButtonPosition", ArgumentSemantic.Assign)]
        MDCBottomAppBarFloatingButtonPosition FloatingButtonPosition { get; set; }

        // @property (readonly, nonatomic, strong) MDCFloatingButton * _Nonnull floatingButton;
        [Export("floatingButton", ArgumentSemantic.Strong)]
        MDCFloatingButton FloatingButton { get; }

        // @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable leadingBarButtonItems;
        [NullAllowed, Export("leadingBarButtonItems", ArgumentSemantic.Copy)]
        UIBarButtonItem[] LeadingBarButtonItems { get; set; }

        // @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable trailingBarButtonItems;
        [NullAllowed, Export("trailingBarButtonItems", ArgumentSemantic.Copy)]
        UIBarButtonItem[] TrailingBarButtonItems { get; set; }

        // -(void)setFloatingButtonHidden:(BOOL)floatingButtonHidden animated:(BOOL)animated;
        [Export("setFloatingButtonHidden:animated:")]
        void SetFloatingButtonHidden(bool floatingButtonHidden, bool animated);

        // -(void)setFloatingButtonElevation:(MDCBottomAppBarFloatingButtonElevation)floatingButtonElevation animated:(BOOL)animated;
        [Export("setFloatingButtonElevation:animated:")]
        void SetFloatingButtonElevation(MDCBottomAppBarFloatingButtonElevation floatingButtonElevation, bool animated);

        // -(void)setFloatingButtonPosition:(MDCBottomAppBarFloatingButtonPosition)floatingButtonPosition animated:(BOOL)animated;
        [Export("setFloatingButtonPosition:animated:")]
        void SetFloatingButtonPosition(MDCBottomAppBarFloatingButtonPosition floatingButtonPosition, bool animated);
    }
}
