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
using ObjCRuntime;

namespace MotionTransitioning 
{

    [Native]
    public enum MDMTransitionDirection : ulong
    {
        Forward,
        Backward
    }
}

namespace MaterialComponents
{
	[Native]
	public enum MDCAnimationTimingFunction : ulong
	{
		EaseInOut,
		EaseOut,
		EaseIn,
		Translate = EaseInOut,
		TranslateOnScreen = EaseOut,
		TranslateOffScreen = EaseIn,
		FadeIn = EaseOut,
		FadeOut = EaseIn
	}

	[Native]
	public enum MDCFontTextStyle : long
	{
		Body1,
		Body2,
		Caption,
		Headline,
		Subheadline,
		Title,
		Display1,
		Display2,
		Display3,
		Display4,
		Button
	}

	[Native]
	public enum MDCInkStyle : long
	{
		Bounded,
		Unbounded
	}

	[Native]
	public enum MDCActivityIndicatorMode : long
	{
		Indeterminate,
		Determinate
	}

	[Native]
	public enum MDCCollectionViewOrdinalPosition : ulong
	{
		VerticalTop = 1 << 0,
		VerticalCenter = 1 << 1,
		VerticalBottom = 1 << 2,
		VerticalTopBottom = (VerticalTop | VerticalBottom),
		HorizontalLeft = 1 << 10,
		HorizontalCenter = 1 << 11,
		HorizontalRight = 1 << 12
	}

	[Native]
	public enum MDCProgressViewBackwardAnimationMode : long
	{
		Reset,
		Animate
	}

	[Native]
	public enum MDCCollectionViewCellAccessoryType : ulong
	{
		None,
		DisclosureIndicator,
		Checkmark,
		DetailButton
	}

	[Native]
	public enum MDCCollectionViewCellStyle : ulong
	{
		Default,
		Grouped,
		Card
	}

	[Native]
	public enum MDCCollectionViewCellLayoutType : ulong
	{
		List,
		Grid,
		Custom
	}

	[Native]
	public enum MDCFlexibleHeaderShiftBehavior : long
	{
		Disabled,
		Enabled,
		EnabledWithStatusBar
	}

	[Native]
	public enum MDCFlexibleHeaderContentImportance : long
	{
		Default,
		High
	}

	[Native]
	public enum MDCFlexibleHeaderScrollPhase : long
	{
		Shifting,
		Collapsing,
		OverExtending
	}

	[Native]
	public enum MDCTabBarAlignment : long
	{
		Leading,
		Justified,
		Center,
		CenterSelected
	}

	[Native]
	public enum MDCTabBarItemAppearance : long
	{
		Titles,
		Images,
		TitledImages
	}

	[Native]
	public enum MDMTransitionDirection : ulong
	{
		Forward,
		Backward
	}

	[Native]
	public enum MDCFloatingButtonShape : long
	{
		Default,
		Mini
	}

	[Native]
	public enum MDCButtonBarLayoutPosition : ulong
	{
		None = 0,
		Leading = 1 << 0,
		Left = Leading,
		Trailing = 1 << 1,
		Right = Trailing
	}

	[Native]
	public enum MDCBarButtonItemLayoutHints : ulong
	{
		None = 0,
		IsFirstButton = 1 << 0,
		IsLastButton = 1 << 1
	}

	[Native]
	public enum MDCNavigationBarTitleAlignment : long
	{
		Center,
		Leading
	}

}
