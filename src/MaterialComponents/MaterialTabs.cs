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

namespace MaterialComponents.MaterialTabs
{
	// @interface MDCTabBar : UIView <UIBarPositioning>
	[BaseType(typeof(UIView))]
	interface MDCTabBar : IUIBarPositioning
	{
		// +(CGFloat)defaultHeightForItemAppearance:(MDCTabBarItemAppearance)appearance;
		[Static]
		[Export("defaultHeightForItemAppearance:")]
		nfloat DefaultHeightForItemAppearance(MDCTabBarItemAppearance appearance);

		// @property (copy, nonatomic) NSArray<UITabBarItem *> * _Nonnull items;
		[Export("items", ArgumentSemantic.Copy)]
		UITabBarItem[] Items { get; set; }

		// @property (nonatomic, strong) UITabBarItem * _Nullable selectedItem;
		[NullAllowed, Export("selectedItem", ArgumentSemantic.Strong)]
		UITabBarItem SelectedItem { get; set; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		MDCTabBarDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MDCTabBarDelegate> _Nullable delegate __attribute__((iboutlet));
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified tintColor;
		[Export("tintColor", ArgumentSemantic.Strong)]
		UIColor TintColor { get; set; }

		// @property (nonatomic) UIColor * _Nullable selectedItemTintColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("selectedItemTintColor", ArgumentSemantic.Assign)]
		UIColor SelectedItemTintColor { get; set; }

		// @property (nonatomic) UIColor * _Nonnull unselectedItemTintColor __attribute__((annotate("ui_appearance_selector")));
		[Export("unselectedItemTintColor", ArgumentSemantic.Assign)]
		UIColor UnselectedItemTintColor { get; set; }

		// @property (nonatomic) UIColor * _Nonnull inkColor __attribute__((annotate("ui_appearance_selector")));
		[Export("inkColor", ArgumentSemantic.Assign)]
		UIColor InkColor { get; set; }

		// @property (nonatomic) UIColor * _Nullable barTintColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export("barTintColor", ArgumentSemantic.Assign)]
		UIColor BarTintColor { get; set; }

		// @property (nonatomic) MDCTabBarAlignment alignment;
		[Export("alignment", ArgumentSemantic.Assign)]
		MDCTabBarAlignment Alignment { get; set; }

		// @property (nonatomic) MDCTabBarItemAppearance itemAppearance;
		[Export("itemAppearance", ArgumentSemantic.Assign)]
		MDCTabBarItemAppearance ItemAppearance { get; set; }

		// @property (nonatomic) BOOL displaysUppercaseTitles;
		[Export("displaysUppercaseTitles")]
		bool DisplaysUppercaseTitles { get; set; }

		// -(void)setSelectedItem:(UITabBarItem * _Nullable)selectedItem animated:(BOOL)animated;
		[Export("setSelectedItem:animated:")]
		void SetSelectedItem([NullAllowed] UITabBarItem selectedItem, bool animated);

		// -(void)setAlignment:(MDCTabBarAlignment)alignment animated:(BOOL)animated;
		[Export("setAlignment:animated:")]
		void SetAlignment(MDCTabBarAlignment alignment, bool animated);
	}

	// @interface MDCAccessibility (MDCTabBar)
	[Category]
	[BaseType(typeof(MDCTabBar))]
	interface MDCTabBar_MDCAccessibility
	{
		// -(id _Nullable)accessibilityElementForItem:(UITabBarItem * _Nonnull)item;
		[Export("accessibilityElementForItem:")]
		[return: NullAllowed]
		NSObject AccessibilityElementForItem(UITabBarItem item);
	}

	// @protocol MDCTabBarDelegate <UIBarPositioningDelegate>
	[BaseType(typeof(UIBarPositioningDelegate))]
	[Protocol, Model]
	interface MDCTabBarDelegate
	{
		// @optional -(BOOL)tabBar:(MDCTabBar * _Nonnull)tabBar shouldSelectItem:(UITabBarItem * _Nonnull)item;
		[Export("tabBar:shouldSelectItem:")]
		bool TabBar_ShouldSelectItem(MDCTabBar tabBar, UITabBarItem item);

		// @optional -(void)tabBar:(MDCTabBar * _Nonnull)tabBar willSelectItem:(UITabBarItem * _Nonnull)item;
		[Export("tabBar:willSelectItem:")]
		void TabBar_WillSelectItem(MDCTabBar tabBar, UITabBarItem item);

		// @optional -(void)tabBar:(MDCTabBar * _Nonnull)tabBar didSelectItem:(UITabBarItem * _Nonnull)item;
		[Export("tabBar:didSelectItem:")]
		void TabBar_DidSelectItem(MDCTabBar tabBar, UITabBarItem item);
	}

	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const CGFloat MDCTabBarViewControllerAnimationDuration;
		[Field("MDCTabBarViewControllerAnimationDuration", "__Internal")]
		nfloat MDCTabBarViewControllerAnimationDuration { get; }
	}

	// @interface MDCTabBarViewController : UIViewController <MDCTabBarDelegate, UIBarPositioningDelegate>
	[BaseType(typeof(UIViewController))]
	interface MDCTabBarViewController : MDCTabBarDelegate, IUIBarPositioningDelegate
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		MDCTabBarControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MDCTabBarControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic) NSArray<UIViewController *> * _Nonnull viewControllers;
		[Export("viewControllers", ArgumentSemantic.Copy)]
		UIViewController[] ViewControllers { get; set; }

		// @property (nonatomic, weak) UIViewController * _Nullable selectedViewController;
		[NullAllowed, Export("selectedViewController", ArgumentSemantic.Weak)]
		UIViewController SelectedViewController { get; set; }

		// @property (readonly, nonatomic) MDCTabBar * _Nullable tabBar;
		[NullAllowed, Export("tabBar")]
		MDCTabBar TabBar { get; }

		// @property (nonatomic) BOOL tabBarHidden;
		[Export("tabBarHidden")]
		bool TabBarHidden { get; set; }

		// -(void)setTabBarHidden:(BOOL)hidden animated:(BOOL)animated;
		[Export("setTabBarHidden:animated:")]
		void SetTabBarHidden(bool hidden, bool animated);
	}

	// @protocol MDCTabBarControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCTabBarControllerDelegate
	{
		// @optional -(BOOL)tabBarController:(MDCTabBarViewController * _Nonnull)tabBarController shouldSelectViewController:(UIViewController * _Nonnull)viewController;
		[Export("tabBarController:shouldSelectViewController:")]
		bool TabBarController_ShouldSelectViewController(MDCTabBarViewController tabBarController, UIViewController viewController);

		// @optional -(void)tabBarController:(MDCTabBarViewController * _Nonnull)tabBarController didSelectViewController:(UIViewController * _Nonnull)viewController;
		[Export("tabBarController:didSelectViewController:")]
		void TabBarController_DidSelectViewController(MDCTabBarViewController tabBarController, UIViewController viewController);
	}
}
