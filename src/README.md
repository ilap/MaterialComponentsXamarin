# Xamarin Binding Project for Material Components for iOS
Xamarin binding project for Material Components for iOS (MDC-iOS).

# Requirements
## MaterialComponents framework Dependencies
 The MaterialComponents for iOS Xanarin binding project requires the following Native Frameworks:
- MDFTextAccessibility, used by MaterialButtons components.

- MotionInterchange, ​MotionTransitioning and MotionAnimator used by MaterialMaskedTransition component.

The dependcies are resolved by Pod during the Xcode build phase.

# Xcode Build the required native frameworks (Optional)
The precompiled frameworks are provided
## Prerequisites

- Create an iOS SingleView Template Xcode project (Do not create Workspace)

- Create a "Podfile" file inside the Template project directory that contains the following:

``` ruby
target 'Template' do
  platform :ios, '8.0'
  use_frameworks!
  project 'Template.xcodeproj'
  pod 'MaterialComponents', '~> 31.0.0'
end
```
and then run
``` bash
$ pod install
```
## Build

- Open the "Pods" Xcode project
``` bash
$ cd Pods
$ open -a Xcode Pods.xcodeproj
```
- Build the "MaterialComponents" Target for "iphoneos" and for "iphonesimulator".

- Create **fat binaries** from the [built frameworks](#Framework dependencies) e.g.:
``` bash
    $ mkdir Frameworks
    $ for f in MaterialComponents MotionInterChange MotionAnimator MotionTransitioning
    do
        # Copy the required headers and other files.
        cp -pr build/Release/iponeos/${f}.framework Frameworks/
        lipo -create build/Release/ipone*/${f}.framework/${f} -output Frameworks/${f}.framework/${f}
        lipo -info Frameworks/${f}.framework/${f}
    done
```
- Copy the generated frameworks into Xamarin Binding's Frameworks direcotry.

# Framework dependencies
The Binding project requires the following Objective-C native frameworks (Native References):

    2.1. MDFTextAccessibiliby

    2.2. MotionInterChange

    2.3. MotionAnimator

    2.4. MotionTransitioning


# Latest releases

The latest release is v31.0.0, which is based on the same version fo the MaterialComponents for iOS.

# API references
For further details have a look at the [API Documentation](https://material.io/components/ios/catalog/) and the [Material Design guidelines](https://material.io/guidelines/).


# License

The MIT License (MIT)

Copyright (c) 2017 The Material Components for iOS Xamarin Binding Authors.
All Rights Reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so
, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
