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

namespace MaterialComponents.MaterialCollectionLayoutAttributes
{
	// @interface MDCCollectionViewLayoutAttributes : UICollectionViewLayoutAttributes <NSCopying>
	[BaseType(typeof(UICollectionViewLayoutAttributes))]
	interface MDCCollectionViewLayoutAttributes : INSCopying
	{
		// @property (getter = isEditing, nonatomic) BOOL editing;
		[Export("editing")]
		bool Editing { [Bind("isEditing")] get; set; }

		// @property (assign, nonatomic) BOOL shouldShowReorderStateMask;
		[Export("shouldShowReorderStateMask")]
		bool ShouldShowReorderStateMask { get; set; }

		// @property (assign, nonatomic) BOOL shouldShowSelectorStateMask;
		[Export("shouldShowSelectorStateMask")]
		bool ShouldShowSelectorStateMask { get; set; }

		// @property (assign, nonatomic) BOOL shouldShowGridBackground;
		[Export("shouldShowGridBackground")]
		bool ShouldShowGridBackground { get; set; }

		// @property (nonatomic, strong) UIImage * _Nullable backgroundImage;
		[NullAllowed, Export("backgroundImage", ArgumentSemantic.Strong)]
		UIImage BackgroundImage { get; set; }

		// @property (nonatomic) UIEdgeInsets backgroundImageViewInsets;
		[Export("backgroundImageViewInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets BackgroundImageViewInsets { get; set; }

		// @property (assign, nonatomic) BOOL isGridLayout;
		[Export("isGridLayout")]
		bool IsGridLayout { get; set; }

		// @property (assign, nonatomic) MDCCollectionViewOrdinalPosition sectionOrdinalPosition;
		[Export("sectionOrdinalPosition", ArgumentSemantic.Assign)]
		MDCCollectionViewOrdinalPosition SectionOrdinalPosition { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable separatorColor;
		[NullAllowed, Export("separatorColor", ArgumentSemantic.Strong)]
		UIColor SeparatorColor { get; set; }

		// @property (nonatomic) UIEdgeInsets separatorInset;
		[Export("separatorInset", ArgumentSemantic.Assign)]
		UIEdgeInsets SeparatorInset { get; set; }

		// @property (nonatomic) CGFloat separatorLineHeight;
		[Export("separatorLineHeight")]
		nfloat SeparatorLineHeight { get; set; }

		// @property (nonatomic) BOOL shouldHideSeparators;
		[Export("shouldHideSeparators")]
		bool ShouldHideSeparators { get; set; }

		// @property (assign, nonatomic) BOOL willAnimateCellsOnAppearance;
		[Export("willAnimateCellsOnAppearance")]
		bool WillAnimateCellsOnAppearance { get; set; }

		// @property (assign, nonatomic) NSTimeInterval animateCellsOnAppearanceDuration;
		[Export("animateCellsOnAppearanceDuration")]
		double AnimateCellsOnAppearanceDuration { get; set; }

		// @property (assign, nonatomic) NSTimeInterval animateCellsOnAppearanceDelay;
		[Export("animateCellsOnAppearanceDelay")]
		double AnimateCellsOnAppearanceDelay { get; set; }
	}
}
