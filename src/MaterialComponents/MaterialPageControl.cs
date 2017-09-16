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

namespace MaterialComponents.MaterialPageControl
{
	// @interface MDCPageControl : UIControl <UIScrollViewDelegate>
	[BaseType(typeof(UIControl))]
	interface MDCPageControl : IUIScrollViewDelegate
	{
		// @property (nonatomic) NSInteger numberOfPages;
		[Export("numberOfPages")]
		nint NumberOfPages { get; set; }

		// @property (nonatomic) NSInteger currentPage;
		[Export("currentPage")]
		nint CurrentPage { get; set; }

		// -(void)setCurrentPage:(NSInteger)currentPage animated:(BOOL)animated;
		[Export("setCurrentPage:animated:")]
		void SetCurrentPage(nint currentPage, bool animated);

		// @property (nonatomic) BOOL hidesForSinglePage;
		[Export("hidesForSinglePage")]
		bool HidesForSinglePage { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable pageIndicatorTintColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("pageIndicatorTintColor", ArgumentSemantic.Strong)]
		UIColor PageIndicatorTintColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable currentPageIndicatorTintColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("currentPageIndicatorTintColor", ArgumentSemantic.Strong)]
		UIColor CurrentPageIndicatorTintColor { get; set; }

		// @property (nonatomic) BOOL defersCurrentPageDisplay;
		[Export("defersCurrentPageDisplay")]
		bool DefersCurrentPageDisplay { get; set; }

		// -(void)updateCurrentPageDisplay;
		[Export("updateCurrentPageDisplay")]
		void UpdateCurrentPageDisplay();

        // -(CGSize)sizeForNumberOfPages:(NSInteger)pageCount;
        [Static]
        [Export("sizeForNumberOfPages:")]
        CGSize SizeForNumberOfPages(nint pageCount);

		// -(void)scrollViewDidScroll:(UIScrollView * _Nonnull)scrollView;
		[Export("scrollViewDidScroll:")]
		void ScrollViewDidScroll(UIScrollView scrollView);

		// -(void)scrollViewDidEndDecelerating:(UIScrollView * _Nonnull)scrollView;
		[Export("scrollViewDidEndDecelerating:")]
		void ScrollViewDidEndDecelerating(UIScrollView scrollView);

		// -(void)scrollViewDidEndScrollingAnimation:(UIScrollView * _Nonnull)scrollView;
		[Export("scrollViewDidEndScrollingAnimation:")]
		void ScrollViewDidEndScrollingAnimation(UIScrollView scrollView);
	}
}
