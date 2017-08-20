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

namespace MaterialComponents.MaterialNavigationBar
{
	// @protocol MDCUINavigationItemObservables <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCUINavigationItemObservables
	{
		// @required @property (copy, nonatomic) NSString * _Nullable title;
		[Abstract]
		[NullAllowed, Export("title")]
		string Title { get; set; }

		// @required @property (nonatomic, strong) UIView * _Nullable titleView;
		[Abstract]
		[NullAllowed, Export("titleView", ArgumentSemantic.Strong)]
		UIView TitleView { get; set; }

		// @required @property (nonatomic) BOOL hidesBackButton;
		[Abstract]
		[Export("hidesBackButton")]
		bool HidesBackButton { get; set; }

		// @required @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable leftBarButtonItems;
		[Abstract]
		[NullAllowed, Export("leftBarButtonItems", ArgumentSemantic.Copy)]
		UIBarButtonItem[] LeftBarButtonItems { get; set; }

		// @required @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable rightBarButtonItems;
		[Abstract]
		[NullAllowed, Export("rightBarButtonItems", ArgumentSemantic.Copy)]
		UIBarButtonItem[] RightBarButtonItems { get; set; }

		// @required @property (nonatomic) BOOL leftItemsSupplementBackButton;
		[Abstract]
		[Export("leftItemsSupplementBackButton")]
		bool LeftItemsSupplementBackButton { get; set; }

		// @required @property (nonatomic, strong) UIBarButtonItem * _Nullable leftBarButtonItem;
		[Abstract]
		[NullAllowed, Export("leftBarButtonItem", ArgumentSemantic.Strong)]
		UIBarButtonItem LeftBarButtonItem { get; set; }

		// @required @property (nonatomic, strong) UIBarButtonItem * _Nullable rightBarButtonItem;
		[Abstract]
		[NullAllowed, Export("rightBarButtonItem", ArgumentSemantic.Strong)]
		UIBarButtonItem RightBarButtonItem { get; set; }
	}

	// @interface MDCNavigationBarTextColorAccessibilityMutator : NSObject
	[BaseType(typeof(NSObject))]
	interface MDCNavigationBarTextColorAccessibilityMutator
	{
		// -(void)mutate:(MDCNavigationBar * _Nonnull)navBar;
		[Export("mutate:")]
		void Mutate(MDCNavigationBar navBar);
	}

	// @interface MDCNavigationBar : UIView
	[BaseType(typeof(UIView))]
	interface MDCNavigationBar
	{
		// @property (copy, nonatomic) NSString * _Nullable title;
		[NullAllowed, Export("title")]
		string Title { get; set; }

		// @property (nonatomic, strong) UIView * _Nullable titleView;
		[NullAllowed, Export("titleView", ArgumentSemantic.Strong)]
		UIView TitleView { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable titleTextAttributes __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("titleTextAttributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> TitleTextAttributes { get; set; }

		// @property (nonatomic, strong) UIBarButtonItem * _Nullable backItem;
		[NullAllowed, Export("backItem", ArgumentSemantic.Strong)]
		UIBarButtonItem BackItem { get; set; }

		// @property (nonatomic) BOOL hidesBackButton;
		[Export("hidesBackButton")]
		bool HidesBackButton { get; set; }

		// @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable leadingBarButtonItems;
		[NullAllowed, Export("leadingBarButtonItems", ArgumentSemantic.Copy)]
		UIBarButtonItem[] LeadingBarButtonItems { get; set; }

		// @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable trailingBarButtonItems;
		[NullAllowed, Export("trailingBarButtonItems", ArgumentSemantic.Copy)]
		UIBarButtonItem[] TrailingBarButtonItems { get; set; }

		// @property (nonatomic) BOOL leadingItemsSupplementBackButton;
		[Export("leadingItemsSupplementBackButton")]
		bool LeadingItemsSupplementBackButton { get; set; }

		// @property (nonatomic, strong) UIBarButtonItem * _Nullable leadingBarButtonItem;
		[NullAllowed, Export("leadingBarButtonItem", ArgumentSemantic.Strong)]
		UIBarButtonItem LeadingBarButtonItem { get; set; }

		// @property (nonatomic, strong) UIBarButtonItem * _Nullable trailingBarButtonItem;
		[NullAllowed, Export("trailingBarButtonItem", ArgumentSemantic.Strong)]
		UIBarButtonItem TrailingBarButtonItem { get; set; }

		// @property (nonatomic) MDCNavigationBarTitleAlignment titleAlignment;
		[Export("titleAlignment", ArgumentSemantic.Assign)]
		MDCNavigationBarTitleAlignment TitleAlignment { get; set; }

		// -(void)observeNavigationItem:(UINavigationItem * _Nonnull)navigationItem;
		[Export("observeNavigationItem:")]
		void ObserveNavigationItem(UINavigationItem navigationItem);

		// -(void)unobserveNavigationItem;
		[Export("unobserveNavigationItem")]
		void UnobserveNavigationItem();

		// @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable leftBarButtonItems;
		[NullAllowed, Export("leftBarButtonItems", ArgumentSemantic.Copy)]
		UIBarButtonItem[] LeftBarButtonItems { get; set; }

		// @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable rightBarButtonItems;
		[NullAllowed, Export("rightBarButtonItems", ArgumentSemantic.Copy)]
		UIBarButtonItem[] RightBarButtonItems { get; set; }

		// @property (nonatomic, strong) UIBarButtonItem * _Nullable leftBarButtonItem;
		[NullAllowed, Export("leftBarButtonItem", ArgumentSemantic.Strong)]
		UIBarButtonItem LeftBarButtonItem { get; set; }

		// @property (nonatomic, strong) UIBarButtonItem * _Nullable rightBarButtonItem;
		[NullAllowed, Export("rightBarButtonItem", ArgumentSemantic.Strong)]
		UIBarButtonItem RightBarButtonItem { get; set; }

		// @property (nonatomic) BOOL leftItemsSupplementBackButton;
		[Export("leftItemsSupplementBackButton")]
		bool LeftItemsSupplementBackButton { get; set; }

		// @property (nonatomic) NSTextAlignment textAlignment __attribute__((deprecated("Use titleAlignment instead.")));
		[Export("textAlignment", ArgumentSemantic.Assign)]
		MDCNavigationBarTitleAlignment TextAlignment { get; set; }
		//NSTextAlignment TextAlignment { get; set; }
	}
}
