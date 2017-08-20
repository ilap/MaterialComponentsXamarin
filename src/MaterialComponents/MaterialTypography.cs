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

namespace MaterialComponents.MaterialTypography
{
	// @protocol MDCTypographyFontLoading <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCTypographyFontLoading
	{
		// @required -(UIFont * _Nullable)lightFontOfSize:(CGFloat)fontSize;
		[Abstract]
		[Export("lightFontOfSize:")]
		[return: NullAllowed]
		UIFont LightFontOfSize(nfloat fontSize);

		// @required -(UIFont * _Nonnull)regularFontOfSize:(CGFloat)fontSize;
		[Abstract]
		[Export("regularFontOfSize:")]
		UIFont RegularFontOfSize(nfloat fontSize);

		// @required -(UIFont * _Nullable)mediumFontOfSize:(CGFloat)fontSize;
		[Abstract]
		[Export("mediumFontOfSize:")]
		[return: NullAllowed]
		UIFont MediumFontOfSize(nfloat fontSize);

		// @optional -(UIFont * _Nonnull)boldFontOfSize:(CGFloat)fontSize;
		[Export("boldFontOfSize:")]
		UIFont BoldFontOfSize(nfloat fontSize);

		// @optional -(UIFont * _Nonnull)italicFontOfSize:(CGFloat)fontSize;
		[Export("italicFontOfSize:")]
		UIFont ItalicFontOfSize(nfloat fontSize);

		// @optional -(UIFont * _Nullable)boldItalicFontOfSize:(CGFloat)fontSize;
		[Export("boldItalicFontOfSize:")]
		[return: NullAllowed]
		UIFont BoldItalicFontOfSize(nfloat fontSize);

		// @optional -(UIFont * _Nonnull)boldFontFromFont:(UIFont * _Nonnull)font;
		[Export("boldFontFromFont:")]
		UIFont BoldFontFromFont(UIFont font);

		// @optional -(UIFont * _Nonnull)italicFontFromFont:(UIFont * _Nonnull)font;
		[Export("italicFontFromFont:")]
		UIFont ItalicFontFromFont(UIFont font);

		// @optional -(BOOL)isLargeForContrastRatios:(UIFont * _Nonnull)font;
		[Export("isLargeForContrastRatios:")]
		bool IsLargeForContrastRatios(UIFont font);
	}

	// @interface MDCTypography : NSObject
	[BaseType(typeof(NSObject))]
	interface MDCTypography
	{
		// +(id<MDCTypographyFontLoading> _Nonnull)fontLoader;
		// +(void)setFontLoader:(id<MDCTypographyFontLoading> _Nonnull)fontLoader;
		[Static]
		[Export("fontLoader")]
		//[Verify(MethodToProperty)]
		MDCTypographyFontLoading FontLoader { get; set; }

		// +(UIFont * _Nonnull)display4Font;
		[Static]
		[Export("display4Font")]
		//[Verify(MethodToProperty)]
		UIFont Display4Font { get; }

		// +(CGFloat)display4FontOpacity;
		[Static]
		[Export("display4FontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat Display4FontOpacity { get; }

		// +(UIFont * _Nonnull)display3Font;
		[Static]
		[Export("display3Font")]
		//[Verify(MethodToProperty)]
		UIFont Display3Font { get; }

		// +(CGFloat)display3FontOpacity;
		[Static]
		[Export("display3FontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat Display3FontOpacity { get; }

		// +(UIFont * _Nonnull)display2Font;
		[Static]
		[Export("display2Font")]
		//[Verify(MethodToProperty)]
		UIFont Display2Font { get; }

		// +(CGFloat)display2FontOpacity;
		[Static]
		[Export("display2FontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat Display2FontOpacity { get; }

		// +(UIFont * _Nonnull)display1Font;
		[Static]
		[Export("display1Font")]
		//[Verify(MethodToProperty)]
		UIFont Display1Font { get; }

		// +(CGFloat)display1FontOpacity;
		[Static]
		[Export("display1FontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat Display1FontOpacity { get; }

		// +(UIFont * _Nonnull)headlineFont;
		[Static]
		[Export("headlineFont")]
		//[Verify(MethodToProperty)]
		UIFont HeadlineFont { get; }

		// +(CGFloat)headlineFontOpacity;
		[Static]
		[Export("headlineFontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat HeadlineFontOpacity { get; }

		// +(UIFont * _Nonnull)titleFont;
		[Static]
		[Export("titleFont")]
		//[Verify(MethodToProperty)]
		UIFont TitleFont { get; }

		// +(CGFloat)titleFontOpacity;
		[Static]
		[Export("titleFontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat TitleFontOpacity { get; }

		// +(UIFont * _Nonnull)subheadFont;
		[Static]
		[Export("subheadFont")]
		//[Verify(MethodToProperty)]
		UIFont SubheadFont { get; }

		// +(CGFloat)subheadFontOpacity;
		[Static]
		[Export("subheadFontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat SubheadFontOpacity { get; }

		// +(UIFont * _Nonnull)body2Font;
		[Static]
		[Export("body2Font")]
		//[Verify(MethodToProperty)]
		UIFont Body2Font { get; }

		// +(CGFloat)body2FontOpacity;
		[Static]
		[Export("body2FontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat Body2FontOpacity { get; }

		// +(UIFont * _Nonnull)body1Font;
		[Static]
		[Export("body1Font")]
		//[Verify(MethodToProperty)]
		UIFont Body1Font { get; }

		// +(CGFloat)body1FontOpacity;
		[Static]
		[Export("body1FontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat Body1FontOpacity { get; }

		// +(UIFont * _Nonnull)captionFont;
		[Static]
		[Export("captionFont")]
		//[Verify(MethodToProperty)]
		UIFont CaptionFont { get; }

		// +(CGFloat)captionFontOpacity;
		[Static]
		[Export("captionFontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat CaptionFontOpacity { get; }

		// +(UIFont * _Nonnull)buttonFont;
		[Static]
		[Export("buttonFont")]
		//[Verify(MethodToProperty)]
		UIFont ButtonFont { get; }

		// +(CGFloat)buttonFontOpacity;
		[Static]
		[Export("buttonFontOpacity")]
		//[Verify(MethodToProperty)]
		nfloat ButtonFontOpacity { get; }

		// +(UIFont * _Nonnull)boldFontFromFont:(UIFont * _Nonnull)font;
		[Static]
		[Export("boldFontFromFont:")]
		UIFont BoldFontFromFont(UIFont font);

		// +(UIFont * _Nonnull)italicFontFromFont:(UIFont * _Nonnull)font;
		[Static]
		[Export("italicFontFromFont:")]
		UIFont ItalicFontFromFont(UIFont font);

		// +(BOOL)isLargeForContrastRatios:(UIFont * _Nonnull)font;
		[Static]
		[Export("isLargeForContrastRatios:")]
		bool IsLargeForContrastRatios(UIFont font);
	}

	// @interface MDCSystemFontLoader : NSObject <MDCTypographyFontLoading>
	[BaseType(typeof(NSObject))]
	interface MDCSystemFontLoader : MDCTypographyFontLoading
	{
	}

	// @interface MaterialTypography (UIFont)
	//[Category]
	[BaseType(typeof(UIFont))]
	// XXX: Add Protocol for MT5211 MTOUCH Error
	[Protocol]
	interface UIFont_MaterialTypography
	{
		// +(UIFont * _Nonnull)mdc_preferredFontForMaterialTextStyle:(MDCFontTextStyle)style;
		[Static]
		[Export("mdc_preferredFontForMaterialTextStyle:")]
		UIFont Mdc_preferredFontForMaterialTextStyle(MDCFontTextStyle style);
	}

	// @interface MaterialTypography (UIFontDescriptor)
	//FIXME: Remove [Category]add [Protocol] MT5211 MTOUCH error
	[Protocol]
	[BaseType(typeof(UIFontDescriptor))]
	interface UIFontDescriptor_MaterialTypography
	{
		// +(UIFontDescriptor * _Nonnull)mdc_preferredFontDescriptorForMaterialTextStyle:(MDCFontTextStyle)style;
		[Static]
		[Export("mdc_preferredFontDescriptorForMaterialTextStyle:")]
		UIFontDescriptor Mdc_preferredFontDescriptorForMaterialTextStyle(MDCFontTextStyle style);
	}
}
