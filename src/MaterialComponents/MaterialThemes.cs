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

namespace MaterialComponents.MaterialThemes
{
	// @protocol MDCColorScheme
	[Protocol]
	interface MDCColorScheme
	{
		// @required @property (readonly, nonatomic, strong) UIColor * _Nonnull primaryColor;
		[Abstract]
		[Export("primaryColor", ArgumentSemantic.Strong)]
		UIColor PrimaryColor { get; }

		// @optional @property (readonly, nonatomic, strong) UIColor * _Nonnull primaryLightColor;
		[Export("primaryLightColor", ArgumentSemantic.Strong)]
		UIColor PrimaryLightColor { get; }

		// @optional @property (readonly, nonatomic, strong) UIColor * _Nonnull primaryDarkColor;
		[Export("primaryDarkColor", ArgumentSemantic.Strong)]
		UIColor PrimaryDarkColor { get; }

		// @optional @property (readonly, nonatomic, strong) UIColor * _Nonnull secondaryColor;
		[Export("secondaryColor", ArgumentSemantic.Strong)]
		UIColor SecondaryColor { get; }

		// @optional @property (readonly, nonatomic, strong) UIColor * _Nonnull secondaryLightColor;
		[Export("secondaryLightColor", ArgumentSemantic.Strong)]
		UIColor SecondaryLightColor { get; }

		// @optional @property (readonly, nonatomic, strong) UIColor * _Nonnull secondaryDarkColor;
		[Export("secondaryDarkColor", ArgumentSemantic.Strong)]
		UIColor SecondaryDarkColor { get; }
	}

	// @interface MDCBasicColorScheme : NSObject <MDCColorScheme, NSCopying>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface MDCBasicColorScheme : MDCColorScheme, INSCopying
	{
		// @property (readonly, nonatomic, strong) UIColor * _Nonnull primaryColor;
		[Export("primaryColor", ArgumentSemantic.Strong)]
		new UIColor PrimaryColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull primaryLightColor;
		[Export("primaryLightColor", ArgumentSemantic.Strong)]
		new UIColor PrimaryLightColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull primaryDarkColor;
		[Export("primaryDarkColor", ArgumentSemantic.Strong)]
		new UIColor PrimaryDarkColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull secondaryColor;
		[Export("secondaryColor", ArgumentSemantic.Strong)]
		new UIColor SecondaryColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull secondaryLightColor;
		[Export("secondaryLightColor", ArgumentSemantic.Strong)]
		new UIColor SecondaryLightColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull secondaryDarkColor;
		[Export("secondaryDarkColor", ArgumentSemantic.Strong)]
		new UIColor SecondaryDarkColor { get; }

		// -(instancetype _Nonnull)initWithPrimaryColor:(UIColor * _Nonnull)primaryColor primaryLightColor:(UIColor * _Nonnull)primaryLightColor primaryDarkColor:(UIColor * _Nonnull)primaryDarkColor secondaryColor:(UIColor * _Nonnull)secondaryColor secondaryLightColor:(UIColor * _Nonnull)secondaryLightColor secondaryDarkColor:(UIColor * _Nonnull)secondaryDarkColor __attribute__((objc_designated_initializer));
		[Export("initWithPrimaryColor:primaryLightColor:primaryDarkColor:secondaryColor:secondaryLightColor:secondaryDarkColor:")]
		[DesignatedInitializer]
		IntPtr Constructor(UIColor primaryColor, UIColor primaryLightColor, UIColor primaryDarkColor, UIColor secondaryColor, UIColor secondaryLightColor, UIColor secondaryDarkColor);

		// -(instancetype _Nonnull)initWithPrimaryColor:(UIColor * _Nonnull)primaryColor;
		[Export("initWithPrimaryColor:")]
		IntPtr Constructor(UIColor primaryColor);

		// -(instancetype _Nonnull)initWithPrimaryColor:(UIColor * _Nonnull)primaryColor primaryLightColor:(UIColor * _Nonnull)primaryLightColor primaryDarkColor:(UIColor * _Nonnull)primaryDarkColor;
		[Export("initWithPrimaryColor:primaryLightColor:primaryDarkColor:")]
		IntPtr Constructor(UIColor primaryColor, UIColor primaryLightColor, UIColor primaryDarkColor);

		// -(instancetype _Nonnull)initWithPrimaryColor:(UIColor * _Nonnull)primaryColor secondaryColor:(UIColor * _Nonnull)secondaryColor;
		[Export("initWithPrimaryColor:secondaryColor:")]
		IntPtr Constructor(UIColor primaryColor, UIColor secondaryColor);
	}

	// @interface MDCTonalPalette : NSObject <NSCoding, NSCopying>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface MDCTonalPalette : INSCoding, INSCopying
	{
		// @property (readonly, copy, nonatomic) NSArray<UIColor *> * _Nonnull colors;
		[Export("colors", ArgumentSemantic.Copy)]
		UIColor[] Colors { get; }

		// @property (readonly, nonatomic) NSUInteger mainColorIndex;
		[Export("mainColorIndex")]
		nuint MainColorIndex { get; }

		// @property (readonly, nonatomic) NSUInteger lightColorIndex;
		[Export("lightColorIndex")]
		nuint LightColorIndex { get; }

		// @property (readonly, nonatomic) NSUInteger darkColorIndex;
		[Export("darkColorIndex")]
		nuint DarkColorIndex { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull mainColor;
		[Export("mainColor", ArgumentSemantic.Strong)]
		UIColor MainColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull lightColor;
		[Export("lightColor", ArgumentSemantic.Strong)]
		UIColor LightColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull darkColor;
		[Export("darkColor", ArgumentSemantic.Strong)]
		UIColor DarkColor { get; }

		// -(instancetype _Nonnull)initWithColors:(NSArray<UIColor *> * _Nonnull)colors mainColorIndex:(NSUInteger)mainColorIndex lightColorIndex:(NSUInteger)lightColorIndex darkColorIndex:(NSUInteger)darkColorIndex __attribute__((objc_designated_initializer));
		[Export("initWithColors:mainColorIndex:lightColorIndex:darkColorIndex:")]
		[DesignatedInitializer]
		IntPtr Constructor(UIColor[] colors, nuint mainColorIndex, nuint lightColorIndex, nuint darkColorIndex);

		// -(instancetype _Nonnull)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
		//[Export("initWithCoder:")]
		//[DesignatedInitializer]
		//XXX: FIXED Do not required IntPtr Constructor(NSCoder coder);
	}

	// @interface MDCTonalColorScheme : NSObject <MDCColorScheme, NSCopying>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface MDCTonalColorScheme : MDCColorScheme, INSCopying
	{
		// @property (readonly, nonatomic, strong) UIColor * _Nonnull primaryColor;
		[Export("primaryColor", ArgumentSemantic.Strong)]
		new UIColor PrimaryColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull primaryLightColor;
		[Export("primaryLightColor", ArgumentSemantic.Strong)]
		new UIColor PrimaryLightColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull primaryDarkColor;
		[Export("primaryDarkColor", ArgumentSemantic.Strong)]
		new UIColor PrimaryDarkColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull secondaryColor;
		[Export("secondaryColor", ArgumentSemantic.Strong)]
		new UIColor SecondaryColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull secondaryLightColor;
		[Export("secondaryLightColor", ArgumentSemantic.Strong)]
		new UIColor SecondaryLightColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull secondaryDarkColor;
		[Export("secondaryDarkColor", ArgumentSemantic.Strong)]
		new UIColor SecondaryDarkColor { get; }

		// @property (readonly, nonatomic, strong) MDCTonalPalette * _Nonnull primaryTonalPalette;
		[Export("primaryTonalPalette", ArgumentSemantic.Strong)]
		MDCTonalPalette PrimaryTonalPalette { get; }

		// @property (readonly, nonatomic, strong) MDCTonalPalette * _Nonnull secondaryTonalPalette;
		[Export("secondaryTonalPalette", ArgumentSemantic.Strong)]
		MDCTonalPalette SecondaryTonalPalette { get; }

		// -(instancetype _Nonnull)initWithPrimaryTonalPalette:(MDCTonalPalette * _Nonnull)primaryTonalPalette secondaryTonalPalette:(MDCTonalPalette * _Nonnull)secondaryTonalPalette __attribute__((objc_designated_initializer));
		[Export("initWithPrimaryTonalPalette:secondaryTonalPalette:")]
		[DesignatedInitializer]
		IntPtr Constructor(MDCTonalPalette primaryTonalPalette, MDCTonalPalette secondaryTonalPalette);
	}
}
