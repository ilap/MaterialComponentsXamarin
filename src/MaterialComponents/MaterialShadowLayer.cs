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
using CoreAnimation;
using UIKit;
using MaterialComponents;
using ObjCRuntime;

namespace MaterialComponents.MaterialShadowLayer
{
	// @interface MDCShadowMetrics : NSObject
	[BaseType(typeof(NSObject))]
	interface MDCShadowMetrics
	{
		// @property (readonly, nonatomic) CGFloat topShadowRadius;
		[Export("topShadowRadius")]
		nfloat TopShadowRadius { get; }

		// @property (readonly, nonatomic) CGSize topShadowOffset;
		[Export("topShadowOffset")]
		CGSize TopShadowOffset { get; }

		// @property (readonly, nonatomic) float topShadowOpacity;
		[Export("topShadowOpacity")]
		float TopShadowOpacity { get; }

		// @property (readonly, nonatomic) CGFloat bottomShadowRadius;
		[Export("bottomShadowRadius")]
		nfloat BottomShadowRadius { get; }

		// @property (readonly, nonatomic) CGSize bottomShadowOffset;
		[Export("bottomShadowOffset")]
		CGSize BottomShadowOffset { get; }

		// @property (readonly, nonatomic) float bottomShadowOpacity;
		[Export("bottomShadowOpacity")]
		float BottomShadowOpacity { get; }

		// +(MDCShadowMetrics * _Nonnull)metricsWithElevation:(CGFloat)elevation;
		[Static]
		[Export("metricsWithElevation:")]
		MDCShadowMetrics MetricsWithElevation(nfloat elevation);
	}

	// @interface MDCShadowLayer : CALayer
	[BaseType(typeof(CALayer))]
	interface MDCShadowLayer
	{
		// @property (assign, nonatomic) CGFloat elevation;
		[Export("elevation")]
		nfloat Elevation { get; set; }

		// @property (getter = isShadowMaskEnabled, assign, nonatomic) BOOL shadowMaskEnabled;
		[Export("shadowMaskEnabled")]
		bool ShadowMaskEnabled { [Bind("isShadowMaskEnabled")] get; set; }
	}
}
