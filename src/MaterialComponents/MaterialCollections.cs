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
using CoreGraphics;

namespace MaterialComponents.MaterialCollections
{
	using MaterialComponents.MaterialCollectionLayoutAttributes;
	using MaterialComponents.MaterialInk;

	// @protocol MDCCollectionViewEditing <NSObject>
	public interface IMDCCollectionViewEditing { }
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCCollectionViewEditing
	{
		// @required @property (readonly, nonatomic, weak) UICollectionView * _Nullable collectionView;
		//FIXME: [Abstract]
		[NullAllowed, Export("collectionView", ArgumentSemantic.Weak)]
		UICollectionView CollectionView { get; }

		[Wrap("WeakDelegate")] //FIXME: ", Abstract]"
		[NullAllowed]
		MDCCollectionViewEditingDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<MDCCollectionViewEditingDelegate> _Nullable delegate;
		//FIXME: [Abstract]
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required @property (readonly, nonatomic, strong) NSIndexPath * _Nullable reorderingCellIndexPath;
		[Abstract]
		[NullAllowed, Export("reorderingCellIndexPath", ArgumentSemantic.Strong)]
		NSIndexPath ReorderingCellIndexPath { get; }

		// @required @property (readonly, nonatomic, strong) NSIndexPath * _Nullable dismissingCellIndexPath;
		[Abstract]
		[NullAllowed, Export("dismissingCellIndexPath", ArgumentSemantic.Strong)]
		NSIndexPath DismissingCellIndexPath { get; }

		// @required @property (readonly, assign, nonatomic) NSInteger dismissingSection;
		[Abstract]
		[Export("dismissingSection")]
		nint DismissingSection { get; }

		// @required @property (getter = isEditing, nonatomic) BOOL editing;
		[Abstract]
		[Export("editing")]
		bool Editing { [Bind("isEditing")] get; set; }

		// @required -(void)setEditing:(BOOL)editing animated:(BOOL)animated;
		[Abstract]
		[Export("setEditing:animated:")]
		void Animated(bool editing, bool animated);
	}

	// @protocol MDCCollectionViewEditingDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCCollectionViewEditingDelegate
	{
		// @optional -(BOOL)collectionViewAllowsEditing:(UICollectionView * _Nonnull)collectionView;
		[Export("collectionViewAllowsEditing:")]
		bool AllowsEditing(UICollectionView collectionView);

		// @optional -(void)collectionViewWillBeginEditing:(UICollectionView * _Nonnull)collectionView;
		[Export("collectionViewWillBeginEditing:")]
		void WillBeginEditing(UICollectionView collectionView);

		// @optional -(void)collectionViewDidBeginEditing:(UICollectionView * _Nonnull)collectionView;
		[Export("collectionViewDidBeginEditing:")]
		void DidBeginEditing(UICollectionView collectionView);

		// @optional -(void)collectionViewWillEndEditing:(UICollectionView * _Nonnull)collectionView;
		[Export("collectionViewWillEndEditing:")]
		void WillEndEditing(UICollectionView collectionView);

		// @optional -(void)collectionViewDidEndEditing:(UICollectionView * _Nonnull)collectionView;
		[Export("collectionViewDidEndEditing:")]
		void DidEndEditing(UICollectionView collectionView);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView canEditItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:canEditItemAtIndexPath:")]
		bool CanEditItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView canSelectItemDuringEditingAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:canSelectItemDuringEditingAtIndexPath:")]
		bool CanSelectItemDuringEditingAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(BOOL)collectionViewAllowsReordering:(UICollectionView * _Nonnull)collectionView;
		[Export("collectionViewAllowsReordering:")]
		bool AllowsReordering(UICollectionView collectionView);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView canMoveItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:canMoveItemAtIndexPath:")]
		bool CanMoveItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView canMoveItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath toIndexPath:(NSIndexPath * _Nonnull)newIndexPath;
		[Export("collectionView:canMoveItemAtIndexPath:toIndexPath:")]
		bool CanMoveItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath, NSIndexPath newIndexPath);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView willMoveItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath toIndexPath:(NSIndexPath * _Nonnull)newIndexPath;
		[Export("collectionView:willMoveItemAtIndexPath:toIndexPath:")]
		void WillMoveItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath, NSIndexPath newIndexPath);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView didMoveItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath toIndexPath:(NSIndexPath * _Nonnull)newIndexPath;
		[Export("collectionView:didMoveItemAtIndexPath:toIndexPath:")]
		void DidMoveItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath, NSIndexPath newIndexPath);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView willBeginDraggingItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:willBeginDraggingItemAtIndexPath:")]
		void WillBeginDraggingItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView didEndDraggingItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:didEndDraggingItemAtIndexPath:")]
		void DidEndDraggingItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView willDeleteItemsAtIndexPaths:(NSArray<NSIndexPath *> * _Nonnull)indexPaths;
		[Export("collectionView:willDeleteItemsAtIndexPaths:")]
		void WillDeleteItemsAtIndexPaths(UICollectionView collectionView, NSIndexPath[] indexPaths);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView didDeleteItemsAtIndexPaths:(NSArray<NSIndexPath *> * _Nonnull)indexPaths;
		[Export("collectionView:didDeleteItemsAtIndexPaths:")]
		void DidDeleteItemsAtIndexPaths(UICollectionView collectionView, NSIndexPath[] indexPaths);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView willDeleteSections:(NSIndexSet * _Nonnull)sections;
		[Export("collectionView:willDeleteSections:")]
		void WillDeleteSections(UICollectionView collectionView, NSIndexSet sections);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView didDeleteSections:(NSIndexSet * _Nonnull)sections;
		[Export("collectionView:didDeleteSections:")]
		void DidDeletedSections(UICollectionView collectionView, NSIndexSet sections);

		// @optional -(BOOL)collectionViewAllowsSwipeToDismissItem:(UICollectionView * _Nonnull)collectionView;
		[Export("collectionViewAllowsSwipeToDismissItem:")]
		bool AllowsSwipeToDismissItem(UICollectionView collectionView);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView canSwipeToDismissItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:canSwipeToDismissItemAtIndexPath:")]
		bool CanSwipeToDismissItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView willBeginSwipeToDismissItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:willBeginSwipeToDismissItemAtIndexPath:")]
		void WillBeginSwipeToDismissItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView didEndSwipeToDismissItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:didEndSwipeToDismissItemAtIndexPath:")]
		void DidEndSwipeToDismissItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView didCancelSwipeToDismissItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:didCancelSwipeToDismissItemAtIndexPath:")]
		void DidCancelSwipeToDismissItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(BOOL)collectionViewAllowsSwipeToDismissSection:(UICollectionView * _Nonnull)collectionView;
		[Export("collectionViewAllowsSwipeToDismissSection:")]
		bool AllowsSwipeToDismissSection(UICollectionView collectionView);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView canSwipeToDismissSection:(NSInteger)section;
		[Export("collectionView:canSwipeToDismissSection:")]
		bool CanSwipeToDismissSection(UICollectionView collectionView, nint section);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView willBeginSwipeToDismissSection:(NSInteger)section;
		[Export("collectionView:willBeginSwipeToDismissSection:")]
		void WillBeginSwipeToDismissSection(UICollectionView collectionView, nint section);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView didEndSwipeToDismissSection:(NSInteger)section;
		[Export("collectionView:didEndSwipeToDismissSection:")]
		void DidEndSwipeToDismissSection(UICollectionView collectionView, nint section);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView didCancelSwipeToDismissSection:(NSInteger)section;
		[Export("collectionView:didCancelSwipeToDismissSection:")]
		void DidCancelSwipeToDismissSection(UICollectionView collectionView, nint section);
	}

	// @protocol MDCCollectionViewStyling <NSObject>
	// HACK: Fixed not an abstract class see details below
	// 1. created pulbic interface IMDCCollectionViewStyling
	// 2. used IMDCCollectionViewStyling everywhere
	public interface IMDCCollectionViewStyling { }

	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCCollectionViewStyling
	{
		// @required @property (readonly, nonatomic, weak) UICollectionView * _Nullable collectionView;
		//FIXME: [Abstract]
		[NullAllowed, Export("collectionView", ArgumentSemantic.Weak)]
		UICollectionView CollectionView { get; }

		[Wrap("WeakDelegate")] // FIXME: ", Abstract]"
		[NullAllowed]
		MDCCollectionViewStylingDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<MDCCollectionViewStylingDelegate> _Nullable delegate;
		//FIXME: [Abstract]
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required @property (assign, nonatomic) BOOL shouldInvalidateLayout;
		[Abstract]
		[Export("shouldInvalidateLayout")]
		bool ShouldInvalidateLayout { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Nonnull cellBackgroundColor;
		[Abstract]
		[Export("cellBackgroundColor", ArgumentSemantic.Strong)]
		UIColor CellBackgroundColor { get; set; }

		// @required @property (assign, nonatomic) MDCCollectionViewCellLayoutType cellLayoutType;
		[Abstract]
		[Export("cellLayoutType", ArgumentSemantic.Assign)]
		MDCCollectionViewCellLayoutType CellLayoutType { get; set; }

		// @required @property (assign, nonatomic) NSInteger gridColumnCount;
		[Abstract]
		[Export("gridColumnCount")]
		nint GridColumnCount { get; set; }

		// @required @property (assign, nonatomic) CGFloat gridPadding;
		[Abstract]
		[Export("gridPadding")]
		nfloat GridPadding { get; set; }

		// @required @property (assign, nonatomic) MDCCollectionViewCellStyle cellStyle;
		[Abstract]
		[Export("cellStyle", ArgumentSemantic.Assign)]
		MDCCollectionViewCellStyle CellStyle { get; set; }

		// @required -(void)setCellStyle:(MDCCollectionViewCellStyle)cellStyle animated:(BOOL)animated;
		[Abstract]
		[Export("setCellStyle:animated:")]
		void SetCellStyle(MDCCollectionViewCellStyle cellStyle, bool animated);

		// @required -(MDCCollectionViewCellStyle)cellStyleAtSectionIndex:(NSInteger)section;
		[Abstract]
		[Export("cellStyleAtSectionIndex:")]
		MDCCollectionViewCellStyle CellStyleAtSectionIndex(nint section);

		// @required -(UIEdgeInsets)backgroundImageViewOutsetsForCellWithAttribute:(MDCCollectionViewLayoutAttributes * _Nonnull)attr;
		[Abstract]
		[Export("backgroundImageViewOutsetsForCellWithAttribute:")]
		UIEdgeInsets BackgroundImageViewOutsetsForCellWithAttribute(MDCCollectionViewLayoutAttributes attr);

		// @required -(UIImage * _Nullable)backgroundImageForCellLayoutAttributes:(MDCCollectionViewLayoutAttributes * _Nonnull)attr;
		[Abstract]
		[Export("backgroundImageForCellLayoutAttributes:")]
		[return: NullAllowed]
		UIImage BackgroundImageForCellLayoutAttributes(MDCCollectionViewLayoutAttributes attr);

		// @required @property (nonatomic, strong) UIColor * _Nullable separatorColor;
		[Abstract]
		[NullAllowed, Export("separatorColor", ArgumentSemantic.Strong)]
		UIColor SeparatorColor { get; set; }

		// @required @property (nonatomic) UIEdgeInsets separatorInset;
		[Abstract]
		[Export("separatorInset", ArgumentSemantic.Assign)]
		UIEdgeInsets SeparatorInset { get; set; }

		// @required @property (nonatomic) CGFloat separatorLineHeight;
		[Abstract]
		[Export("separatorLineHeight")]
		nfloat SeparatorLineHeight { get; set; }

		// @required @property (nonatomic) BOOL shouldHideSeparators;
		[Abstract]
		[Export("shouldHideSeparators")]
		bool ShouldHideSeparators { get; set; }

		// @required -(BOOL)shouldHideSeparatorForCellLayoutAttributes:(MDCCollectionViewLayoutAttributes * _Nonnull)attr;
		[Abstract]
		[Export("shouldHideSeparatorForCellLayoutAttributes:")]
		bool ShouldHideSeparatorForCellLayoutAttributes(MDCCollectionViewLayoutAttributes attr);

		// @required @property (assign, nonatomic) BOOL allowsItemInlay;
		[Abstract]
		[Export("allowsItemInlay")]
		bool AllowsItemInlay { get; set; }

		// @required @property (assign, nonatomic) BOOL allowsMultipleItemInlays;
		[Abstract]
		[Export("allowsMultipleItemInlays")]
		bool AllowsMultipleItemInlays { get; set; }

		// @required -(NSArray<NSIndexPath *> * _Nullable)indexPathsForInlaidItems;
		[Abstract]
		[NullAllowed, Export("indexPathsForInlaidItems")]
		//[Verify(MethodToProperty)]
		NSIndexPath[] IndexPathsForInlaidItems { get; }

		// @required -(BOOL)isItemInlaidAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Abstract]
		[Export("isItemInlaidAtIndexPath:")]
		bool IsItemInlaidAtIndexPath(NSIndexPath indexPath);

		// @required -(void)applyInlayToItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath animated:(BOOL)animated;
		[Abstract]
		[Export("applyInlayToItemAtIndexPath:animated:")]
		void ApplyInlayToItemAtIndexPath(NSIndexPath indexPath, bool animated);

		// @required -(void)removeInlayFromItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath animated:(BOOL)animated;
		[Abstract]
		[Export("removeInlayFromItemAtIndexPath:animated:")]
		void RemoveInlayFromItemAtIndexPath(NSIndexPath indexPath, bool animated);

		// @required -(void)applyInlayToAllItemsAnimated:(BOOL)animated;
		[Abstract]
		[Export("applyInlayToAllItemsAnimated:")]
		void ApplyInlayToAllItemsAnimated(bool animated);

		// @required -(void)removeInlayFromAllItemsAnimated:(BOOL)animated;
		[Abstract]
		[Export("removeInlayFromAllItemsAnimated:")]
		void RemoveInlayFromAllItemsAnimated(bool animated);

		// @required -(void)resetIndexPathsForInlaidItems;
		[Abstract]
		[Export("resetIndexPathsForInlaidItems")]
		void ResetIndexPathsForInlaidItems();

		// @required @property (assign, nonatomic) BOOL shouldAnimateCellsOnAppearance;
		[Abstract]
		[Export("shouldAnimateCellsOnAppearance")]
		bool ShouldAnimateCellsOnAppearance { get; set; }

		// @required @property (readonly, assign, nonatomic) BOOL willAnimateCellsOnAppearance;
		[Abstract]
		[Export("willAnimateCellsOnAppearance")]
		bool WillAnimateCellsOnAppearance { get; }

		// @required @property (readonly, assign, nonatomic) CGFloat animateCellsOnAppearancePadding;
		[Abstract]
		[Export("animateCellsOnAppearancePadding")]
		nfloat AnimateCellsOnAppearancePadding { get; }

		// @required @property (readonly, assign, nonatomic) NSTimeInterval animateCellsOnAppearanceDuration;
		[Abstract]
		[Export("animateCellsOnAppearanceDuration")]
		double AnimateCellsOnAppearanceDuration { get; }

		// @required -(void)beginCellAppearanceAnimation;
		[Abstract]
		[Export("beginCellAppearanceAnimation")]
		void BeginCellAppearanceAnimation();
	}

	// @protocol MDCCollectionViewStylingDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCCollectionViewStylingDelegate
	{
		// @optional -(CGFloat)collectionView:(UICollectionView * _Nonnull)collectionView cellHeightAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:cellHeightAtIndexPath:")]
		nfloat CellHeightAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(MDCCollectionViewCellStyle)collectionView:(UICollectionView * _Nonnull)collectionView cellStyleForSection:(NSInteger)section;
		[Export("collectionView:cellStyleForSection:")]
		MDCCollectionViewCellStyle CellStyleForSection(UICollectionView collectionView, nint section);

		// @optional -(UIColor * _Nullable)collectionView:(UICollectionView * _Nonnull)collectionView cellBackgroundColorAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:cellBackgroundColorAtIndexPath:")]
		[return: NullAllowed]
		UIColor CellBackgroundColorAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView shouldHideItemBackgroundAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:shouldHideItemBackgroundAtIndexPath:")]
		bool ShouldHideItemBackgroundAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView shouldHideHeaderBackgroundForSection:(NSInteger)section;
		[Export("collectionView:shouldHideHeaderBackgroundForSection:")]
		bool ShouldHideHeaderBackgroundForSection(UICollectionView collectionView, nint section);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView shouldHideFooterBackgroundForSection:(NSInteger)section;
		[Export("collectionView:shouldHideFooterBackgroundForSection:")]
		bool ShouldHideFooterBackgroundForSection(UICollectionView collectionView, nint section);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView shouldHideItemSeparatorAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:shouldHideItemSeparatorAtIndexPath:")]
		bool ShouldHideItemSeparatorAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView shouldHideHeaderSeparatorForSection:(NSInteger)section;
		[Export("collectionView:shouldHideHeaderSeparatorForSection:")]
		bool ShouldHideHeaderSeparatorForSection(UICollectionView collectionView, nint section);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView shouldHideFooterSeparatorForSection:(NSInteger)section;
		[Export("collectionView:shouldHideFooterSeparatorForSection:")]
		bool ShouldHideFooterSeparatorForSection(UICollectionView collectionView, nint section);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView didApplyInlayToItemAtIndexPaths:(NSArray<NSIndexPath *> * _Nonnull)indexPaths;
		[Export("collectionView:didApplyInlayToItemAtIndexPaths:")]
		void DidApplyInlayToItemAtIndexPaths(UICollectionView collectionView, NSIndexPath[] indexPaths);

		// @optional -(void)collectionView:(UICollectionView * _Nonnull)collectionView didRemoveInlayFromItemAtIndexPaths:(NSArray<NSIndexPath *> * _Nonnull)indexPaths;
		[Export("collectionView:didRemoveInlayFromItemAtIndexPaths:")]
		void DidRemoveInlayFromItemAtIndexPaths(UICollectionView collectionView, NSIndexPath[] indexPaths);

		// @optional -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView hidesInkViewAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:hidesInkViewAtIndexPath:")]
		bool HidesInkViewAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(UIColor * _Nullable)collectionView:(UICollectionView * _Nonnull)collectionView inkColorAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:inkColorAtIndexPath:")]
		[return: NullAllowed]
		UIColor InkColorAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// @optional -(MDCInkView * _Nonnull)collectionView:(UICollectionView * _Nonnull)collectionView inkTouchController:(MDCInkTouchController * _Nonnull)inkTouchController inkViewAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export("collectionView:inkTouchController:inkViewAtIndexPath:")]
		MDCInkView InkTouchController(UICollectionView collectionView, MDCInkTouchController inkTouchController, NSIndexPath indexPath);
	}

	// @interface MDCCollectionViewController : UICollectionViewController <MDCCollectionViewEditingDelegate, MDCCollectionViewStylingDelegate, UICollectionViewDelegateFlowLayout>
	// HACK: Remove [
	//[Protocol,[
    //[ Model]
    [BaseType(typeof(UICollectionViewController))]
	interface MDCCollectionViewController : MDCCollectionViewEditingDelegate, MDCCollectionViewStylingDelegate, IUICollectionViewDelegateFlowLayout
	{
		// @property (readonly, nonatomic, strong) id<MDCCollectionViewStyling> _Nonnull styler;
		[Export("styler", ArgumentSemantic.Strong)]
		IMDCCollectionViewStyling Styler { get; }

		// @property (readonly, nonatomic, strong) id<MDCCollectionViewEditing> _Nonnull editor;
		[Export("editor", ArgumentSemantic.Strong)]
		IMDCCollectionViewEditing Editor { get; }

		// -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView shouldHighlightItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((objc_requires_super));
		[Export("collectionView:shouldHighlightItemAtIndexPath:")]
		//FIXME: Enable when Generator is updated [RequiresSuper]
		bool ShouldHighlightItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// -(void)collectionView:(UICollectionView * _Nonnull)collectionView didHighlightItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((objc_requires_super));
		[Export("collectionView:didHighlightItemAtIndexPath:")]
		//[RequiresSuper]
		void DidHighlightItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// -(void)collectionView:(UICollectionView * _Nonnull)collectionView didUnhighlightItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((objc_requires_super));
		[Export("collectionView:didUnhighlightItemAtIndexPath:")]
		//[RequiresSuper]
		void DidUnhighlightItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView shouldSelectItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((objc_requires_super));
		[Export("collectionView:shouldSelectItemAtIndexPath:")]
		//[RequiresSuper]
		bool ShouldSelectItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// -(BOOL)collectionView:(UICollectionView * _Nonnull)collectionView shouldDeselectItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((objc_requires_super));
		[Export("collectionView:shouldDeselectItemAtIndexPath:")]
		//[RequiresSuper]
		bool ShouldDeselectItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// -(void)collectionView:(UICollectionView * _Nonnull)collectionView didSelectItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((objc_requires_super));
		[Export("collectionView:didSelectItemAtIndexPath:")]
		//[RequiresSuper]
		void DidSelectItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// -(void)collectionView:(UICollectionView * _Nonnull)collectionView didDeselectItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((objc_requires_super));
		[Export("collectionView:didDeselectItemAtIndexPath:")]
		//[RequiresSuper]
		void DidDeselectItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

		// -(void)collectionViewWillBeginEditing:(UICollectionView * _Nonnull)collectionView __attribute__((objc_requires_super));
		[Export("collectionViewWillBeginEditing:")]
		//[RequiresSuper]
		new void WillBeginEditing(UICollectionView collectionView);

		// -(void)collectionViewWillEndEditing:(UICollectionView * _Nonnull)collectionView __attribute__((objc_requires_super));
		[Export("collectionViewWillEndEditing:")]
		//[RequiresSuper]
		//FIXME: added new
		new void WillEndEditing(UICollectionView collectionView);

		// -(CGFloat)cellWidthAtSectionIndex:(NSInteger)section;
		[Export("cellWidthAtSectionIndex:")]
		nfloat CellWidthAtSectionIndex(nint section);

        [Export("initWithCollectionViewLayout:")]
        [DesignatedInitializer]
        IntPtr Constructor(UICollectionViewLayout layout);
	}

	// @interface MDCCollectionViewFlowLayout : UICollectionViewFlowLayout
	[BaseType(typeof(UICollectionViewFlowLayout))]
	interface MDCCollectionViewFlowLayout
	{
	}


    // @interface MDCCollectionViewCell : UICollectionViewCell
	[BaseType(typeof(UICollectionViewCell))]
	interface MDCCollectionViewCell
	{
		// @property (nonatomic) MDCCollectionViewCellAccessoryType accessoryType;
		[Export("accessoryType", ArgumentSemantic.Assign)]
		MDCCollectionViewCellAccessoryType AccessoryType { get; set; }

		// @property (nonatomic, strong) UIView * _Nullable accessoryView;
		[NullAllowed, Export("accessoryView", ArgumentSemantic.Strong)]
		UIView AccessoryView { get; set; }

		// @property (nonatomic) UIEdgeInsets accessoryInset;
		[Export("accessoryInset", ArgumentSemantic.Assign)]
		UIEdgeInsets AccessoryInset { get; set; }

		// @property (nonatomic) BOOL shouldHideSeparator;
		[Export("shouldHideSeparator")]
		bool ShouldHideSeparator { get; set; }

		// @property (nonatomic) UIEdgeInsets separatorInset;
		[Export("separatorInset", ArgumentSemantic.Assign)]
		UIEdgeInsets SeparatorInset { get; set; }

		// @property (nonatomic) BOOL allowsCellInteractionsWhileEditing;
		[Export("allowsCellInteractionsWhileEditing")]
		bool AllowsCellInteractionsWhileEditing { get; set; }

		// @property (getter = isEditing, nonatomic) BOOL editing;
		[Export("editing")]
		bool Editing { [Bind("isEditing")] get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified editingSelectorColor __attribute__((annotate("ui_appearance_selector")));
		[Export("editingSelectorColor", ArgumentSemantic.Strong)]
		UIColor EditingSelectorColor { get; set; }

		// -(void)setEditing:(BOOL)editing animated:(BOOL)animated;
		[Export("setEditing:animated:")]
		void SetEditing(bool editing, bool animated);

		// @property (nonatomic, strong) MDCInkView * _Nullable inkView;
		[NullAllowed, Export("inkView", ArgumentSemantic.Strong)]
		MDCInkView InkView { get; set; }

        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

	}

	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const CGFloat MDCCellDefaultOneLineHeight;
		[Field("MDCCellDefaultOneLineHeight", "__Internal")]
		nfloat MDCCellDefaultOneLineHeight { get; }

		// extern const CGFloat MDCCellDefaultOneLineWithAvatarHeight;
		[Field("MDCCellDefaultOneLineWithAvatarHeight", "__Internal")]
		nfloat MDCCellDefaultOneLineWithAvatarHeight { get; }

		// extern const CGFloat MDCCellDefaultTwoLineHeight;
		[Field("MDCCellDefaultTwoLineHeight", "__Internal")]
		nfloat MDCCellDefaultTwoLineHeight { get; }

		// extern const CGFloat MDCCellDefaultThreeLineHeight;
		[Field("MDCCellDefaultThreeLineHeight", "__Internal")]
		nfloat MDCCellDefaultThreeLineHeight { get; }

		// extern NSString *const _Nonnull kSelectedCellAccessibilityHintKey;
		[Field("kSelectedCellAccessibilityHintKey", "__Internal")]
		NSString kSelectedCellAccessibilityHintKey { get; }

		// extern NSString *const _Nonnull kDeselectedCellAccessibilityHintKey;
		[Field("kDeselectedCellAccessibilityHintKey", "__Internal")]
		NSString kDeselectedCellAccessibilityHintKey { get; }


		// extern const CGFloat MDCCollectionViewCellStyleCardSectionInset;
		[Field("MDCCollectionViewCellStyleCardSectionInset", "__Internal")]
		float MDCCollectionViewCellStyleCardSectionInset { get; }

	}

	// @interface MDCCollectionViewTextCell : MDCCollectionViewCell
	[BaseType(typeof(MDCCollectionViewCell))]
	interface MDCCollectionViewTextCell
	{
		// @property (readonly, nonatomic, strong) UILabel * _Nullable textLabel;
		[NullAllowed, Export("textLabel", ArgumentSemantic.Strong)]
		UILabel TextLabel { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nullable detailTextLabel;
		[NullAllowed, Export("detailTextLabel", ArgumentSemantic.Strong)]
		UILabel DetailTextLabel { get; }

		// @property (readonly, nonatomic, strong) UIImageView * _Nullable imageView;
		[NullAllowed, Export("imageView", ArgumentSemantic.Strong)]
		UIImageView ImageView { get; }
	}
}
