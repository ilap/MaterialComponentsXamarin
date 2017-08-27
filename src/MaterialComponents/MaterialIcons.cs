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
using ObjCRuntime;
using UIKit;

namespace MaterialComponents.MaterialIcons
{
    // @interface MDCIcons : NSObject
    //[Category]
    [BaseType(typeof(NSObject))]
    //[DisableDefaultCtor]
    interface MDCIcons
    {
    /*}

    // @interface BundleLoader (MDCIcons)
    [Category]
    [BaseType(typeof(MDCIcons))]
    interface MDCIcons_BundleLoader
    {*/
        // +(NSString * _Nonnull)pathForIconName:(NSString * _Nonnull)iconName withBundleName:(NSString * _Nonnull)bundleName;
        [Static]
        [Export("pathForIconName:withBundleName:")]
        string PathForIconName(string iconName, string bundleName);

        // +(NSBundle * _Nullable)bundleNamed:(NSString * _Nonnull)bundleName;
        [Static]
        [Export("bundleNamed:")]
        [return: NullAllowed]
        NSBundle BundleNamed(string bundleName);
    /*}

    // @interface ic_arrow_back (MDCIcons)
    [Category]
    [BaseType(typeof(MDCIcons))]
    interface MDCIcons_ic_arrow_back
    {*/
        // +(NSString * _Nonnull)pathFor_ic_arrow_back;
        [Static]
        [Export("pathFor_ic_arrow_back")]
        //[Verify(MethodToProperty)]
        string PathFor_ic_arrow_back { get; }

        // +(void)ic_arrow_backUseNewStyle:(BOOL)useNewStyle;
        [Static]
        [Export("ic_arrow_backUseNewStyle:")]
        void Ic_arrow_backUseNewStyle(bool useNewStyle);

        // +(UIImage * _Nullable)imageFor_ic_arrow_back;
        [Static]
        [NullAllowed, Export("imageFor_ic_arrow_back")]
        //[Verify(MethodToProperty)]
        UIImage ImageFor_ic_arrow_back { get; }
    /*}

    // @interface ic_check (MDCIcons)
    [Category]
    [BaseType(typeof(MDCIcons))]
    interface MDCIcons_ic_check
    {*/
        // +(NSString * _Nonnull)pathFor_ic_check;
        [Static]
        [Export("pathFor_ic_check")]
        //[Verify(MethodToProperty)]
        string PathFor_ic_check { get; }

        // +(UIImage * _Nullable)imageFor_ic_check;
        [Static]
        [NullAllowed, Export("imageFor_ic_check")]
        //[Verify(MethodToProperty)]
        UIImage ImageFor_ic_check { get; }
    /*}

    // @interface ic_check_circle (MDCIcons)
    [Category]
    [BaseType(typeof(MDCIcons))]
    interface MDCIcons_ic_check_circle
    {*/
        // +(NSString * _Nonnull)pathFor_ic_check_circle;
        [Static]
        [Export("pathFor_ic_check_circle")]
        //[Verify(MethodToProperty)]
        string PathFor_ic_check_circle { get; }

        // +(UIImage * _Nullable)imageFor_ic_check_circle;
        [Static]
        [NullAllowed, Export("imageFor_ic_check_circle")]
        //[Verify(MethodToProperty)]
        UIImage ImageFor_ic_check_circle { get; }
    /*}

    // @interface ic_chevron_right (MDCIcons)
    [Category]
    [BaseType(typeof(MDCIcons))]
    interface MDCIcons_ic_chevron_right
    {*/
        // +(NSString * _Nonnull)pathFor_ic_chevron_right;
        [Static]
        [Export("pathFor_ic_chevron_right")]
        //[Verify(MethodToProperty)]
        string PathFor_ic_chevron_right { get; }

        // +(UIImage * _Nullable)imageFor_ic_chevron_right;
        [Static]
        [NullAllowed, Export("imageFor_ic_chevron_right")]
        //[Verify(MethodToProperty)]
        UIImage ImageFor_ic_chevron_right { get; }
    /*}

    // @interface ic_info (MDCIcons)
    [Category]
    [BaseType(typeof(MDCIcons))]
    interface MDCIcons_ic_info
    {*/
        // +(NSString * _Nonnull)pathFor_ic_info;
        [Static]
        [Export("pathFor_ic_info")]
        //[Verify(MethodToProperty)]
        string PathFor_ic_info { get; }

        // +(UIImage * _Nullable)imageFor_ic_info;
        [Static]
        [NullAllowed, Export("imageFor_ic_info")]
        //[Verify(MethodToProperty)]
        UIImage ImageFor_ic_info { get; }
    /*}

    // @interface ic_radio_button_unchecked (MDCIcons)
    [Category]
    [BaseType(typeof(MDCIcons))]
    interface MDCIcons_ic_radio_button_unchecked
    {*/
        // +(NSString * _Nonnull)pathFor_ic_radio_button_unchecked;
        [Static]
        [Export("pathFor_ic_radio_button_unchecked")]
        //[Verify(MethodToProperty)]
        string PathFor_ic_radio_button_unchecked { get; }

        // +(UIImage * _Nullable)imageFor_ic_radio_button_unchecked;
        [Static]
        [NullAllowed, Export("imageFor_ic_radio_button_unchecked")]
        //[Verify(MethodToProperty)]
        UIImage ImageFor_ic_radio_button_unchecked { get; }
    /*}

    // @interface ic_reorder (MDCIcons)
    [Category]
    [BaseType(typeof(MDCIcons))]
    interface MDCIcons_ic_reorder
    {*/
        // +(NSString * _Nonnull)pathFor_ic_reorder;
        [Static]
        [Export("pathFor_ic_reorder")]
        //[Verify(MethodToProperty)]
        string PathFor_ic_reorder { get; }

        // +(UIImage * _Nullable)imageFor_ic_reorder;
        [Static]
        [NullAllowed, Export("imageFor_ic_reorder")]
        //[Verify(MethodToProperty)]
        UIImage ImageFor_ic_reorder { get; }
    }
}
