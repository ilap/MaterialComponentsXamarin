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

namespace MaterialComponents.MaterialPalettes
{
	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern MDCPaletteTint  _Nonnull const MDCPaletteTint50Name;
		[Field("MDCPaletteTint50Name", "__Internal")]
		NSString MDCPaletteTint50Name { get; }

		// extern MDCPaletteTint  _Nonnull const MDCPaletteTint100Name;
		[Field("MDCPaletteTint100Name", "__Internal")]
		NSString MDCPaletteTint100Name { get; }

		// extern MDCPaletteTint  _Nonnull const MDCPaletteTint200Name;
		[Field("MDCPaletteTint200Name", "__Internal")]
		NSString MDCPaletteTint200Name { get; }

		// extern MDCPaletteTint  _Nonnull const MDCPaletteTint300Name;
		[Field("MDCPaletteTint300Name", "__Internal")]
		NSString MDCPaletteTint300Name { get; }

		// extern MDCPaletteTint  _Nonnull const MDCPaletteTint400Name;
		[Field("MDCPaletteTint400Name", "__Internal")]
		NSString MDCPaletteTint400Name { get; }

		// extern MDCPaletteTint  _Nonnull const MDCPaletteTint500Name;
		[Field("MDCPaletteTint500Name", "__Internal")]
		NSString MDCPaletteTint500Name { get; }

		// extern MDCPaletteTint  _Nonnull const MDCPaletteTint600Name;
		[Field("MDCPaletteTint600Name", "__Internal")]
		NSString MDCPaletteTint600Name { get; }

		// extern MDCPaletteTint  _Nonnull const MDCPaletteTint700Name;
		[Field("MDCPaletteTint700Name", "__Internal")]
		NSString MDCPaletteTint700Name { get; }

		// extern MDCPaletteTint  _Nonnull const MDCPaletteTint800Name;
		[Field("MDCPaletteTint800Name", "__Internal")]
		NSString MDCPaletteTint800Name { get; }

		// extern MDCPaletteTint  _Nonnull const MDCPaletteTint900Name;
		[Field("MDCPaletteTint900Name", "__Internal")]
		NSString MDCPaletteTint900Name { get; }

		// extern MDCPaletteAccent  _Nonnull const MDCPaletteAccent100Name;
		[Field("MDCPaletteAccent100Name", "__Internal")]
		NSString MDCPaletteAccent100Name { get; }

		// extern MDCPaletteAccent  _Nonnull const MDCPaletteAccent200Name;
		[Field("MDCPaletteAccent200Name", "__Internal")]
		NSString MDCPaletteAccent200Name { get; }

		// extern MDCPaletteAccent  _Nonnull const MDCPaletteAccent400Name;
		[Field("MDCPaletteAccent400Name", "__Internal")]
		NSString MDCPaletteAccent400Name { get; }

		// extern MDCPaletteAccent  _Nonnull const MDCPaletteAccent700Name;
		[Field("MDCPaletteAccent700Name", "__Internal")]
		NSString MDCPaletteAccent700Name { get; }
	}

	// @interface MDCPalette : NSObject
	[BaseType(typeof(NSObject))]
	interface MDCPalette
	{
		// @property (readonly, strong, class) MDCPalette * _Nonnull redPalette;
		[Static]
		[Export("redPalette", ArgumentSemantic.Strong)]
		MDCPalette RedPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull pinkPalette;
		[Static]
		[Export("pinkPalette", ArgumentSemantic.Strong)]
		MDCPalette PinkPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull purplePalette;
		[Static]
		[Export("purplePalette", ArgumentSemantic.Strong)]
		MDCPalette PurplePalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull deepPurplePalette;
		[Static]
		[Export("deepPurplePalette", ArgumentSemantic.Strong)]
		MDCPalette DeepPurplePalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull indigoPalette;
		[Static]
		[Export("indigoPalette", ArgumentSemantic.Strong)]
		MDCPalette IndigoPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull bluePalette;
		[Static]
		[Export("bluePalette", ArgumentSemantic.Strong)]
		MDCPalette BluePalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull lightBluePalette;
		[Static]
		[Export("lightBluePalette", ArgumentSemantic.Strong)]
		MDCPalette LightBluePalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull cyanPalette;
		[Static]
		[Export("cyanPalette", ArgumentSemantic.Strong)]
		MDCPalette CyanPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull tealPalette;
		[Static]
		[Export("tealPalette", ArgumentSemantic.Strong)]
		MDCPalette TealPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull greenPalette;
		[Static]
		[Export("greenPalette", ArgumentSemantic.Strong)]
		MDCPalette GreenPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull lightGreenPalette;
		[Static]
		[Export("lightGreenPalette", ArgumentSemantic.Strong)]
		MDCPalette LightGreenPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull limePalette;
		[Static]
		[Export("limePalette", ArgumentSemantic.Strong)]
		MDCPalette LimePalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull yellowPalette;
		[Static]
		[Export("yellowPalette", ArgumentSemantic.Strong)]
		MDCPalette YellowPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull amberPalette;
		[Static]
		[Export("amberPalette", ArgumentSemantic.Strong)]
		MDCPalette AmberPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull orangePalette;
		[Static]
		[Export("orangePalette", ArgumentSemantic.Strong)]
		MDCPalette OrangePalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull deepOrangePalette;
		[Static]
		[Export("deepOrangePalette", ArgumentSemantic.Strong)]
		MDCPalette DeepOrangePalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull brownPalette;
		[Static]
		[Export("brownPalette", ArgumentSemantic.Strong)]
		MDCPalette BrownPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull greyPalette;
		[Static]
		[Export("greyPalette", ArgumentSemantic.Strong)]
		MDCPalette GreyPalette { get; }

		// @property (readonly, strong, class) MDCPalette * _Nonnull blueGreyPalette;
		[Static]
		[Export("blueGreyPalette", ArgumentSemantic.Strong)]
		MDCPalette BlueGreyPalette { get; }

		// +(instancetype _Nonnull)paletteGeneratedFromColor:(UIColor * _Nonnull)target500Color;
		[Static]
		[Export("paletteGeneratedFromColor:")]
		MDCPalette PaletteGeneratedFromColor(UIColor target500Color);

		// +(instancetype _Nonnull)paletteWithTints:(NSDictionary<MDCPaletteTint,UIColor *> * _Nonnull)tints accents:(NSDictionary<MDCPaletteAccent,UIColor *> * _Nullable)accents;
		[Static]
		[Export("paletteWithTints:accents:")]
		MDCPalette PaletteWithTints(NSDictionary<NSString, UIColor> tints, [NullAllowed] NSDictionary<NSString, UIColor> accents);

		// -(instancetype _Nonnull)initWithTints:(NSDictionary<MDCPaletteTint,UIColor *> * _Nonnull)tints accents:(NSDictionary<MDCPaletteAccent,UIColor *> * _Nullable)accents;
		[Export("initWithTints:accents:")]
		IntPtr Constructor(NSDictionary<NSString, UIColor> tints, [NullAllowed] NSDictionary<NSString, UIColor> accents);

		// @property (readonly, nonatomic) UIColor * _Nonnull tint50;
		[Export("tint50")]
		UIColor Tint50 { get; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tint100;
		[Export("tint100")]
		UIColor Tint100 { get; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tint200;
		[Export("tint200")]
		UIColor Tint200 { get; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tint300;
		[Export("tint300")]
		UIColor Tint300 { get; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tint400;
		[Export("tint400")]
		UIColor Tint400 { get; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tint500;
		[Export("tint500")]
		UIColor Tint500 { get; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tint600;
		[Export("tint600")]
		UIColor Tint600 { get; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tint700;
		[Export("tint700")]
		UIColor Tint700 { get; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tint800;
		[Export("tint800")]
		UIColor Tint800 { get; }

		// @property (readonly, nonatomic) UIColor * _Nonnull tint900;
		[Export("tint900")]
		UIColor Tint900 { get; }

		// @property (readonly, nonatomic) UIColor * _Nullable accent100;
		[NullAllowed, Export("accent100")]
		UIColor Accent100 { get; }

		// @property (readonly, nonatomic) UIColor * _Nullable accent200;
		[NullAllowed, Export("accent200")]
		UIColor Accent200 { get; }

		// @property (readonly, nonatomic) UIColor * _Nullable accent400;
		[NullAllowed, Export("accent400")]
		UIColor Accent400 { get; }

		// @property (readonly, nonatomic) UIColor * _Nullable accent700;
		[NullAllowed, Export("accent700")]
		UIColor Accent700 { get; }
	}
}
