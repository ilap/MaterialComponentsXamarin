<link href='//fonts.googleapis.com/css?family=RobotoDraft:regular,bold,italic,thin,light,bolditalic,black,medium&amp;lang=en' rel='stylesheet' type='text/css'>

<h1 align="center">
  <br>
  <a href="http://www.amitmerchant.com/electron-markdownify"><img  src="arts/MDC.png" width="128" ></a>
  <br>
  Material Components for iOS binding for Xamarin.iOS.
  <br>
</h1>

[![Build Status](https://www.bitrise.io/app/90b72d60b57288b7/status.svg?token=EMYZt7i6cIt8J8-uNQRmkA&branch=master)](https://www.bitrise.io/app/90b72d60b57288b7)[![GitHub release](https://img.shields.io/github/release/ilap/MaterialComponentsXamarin.svg)](https://github.com/ilap/MaterialComponentsXamarin/releases)[![license](https://img.shields.io/github/license/ilap/MaterialComponentsXamarin.svg)](https://github.com/ilap/MaterialComponentsXamarin/blob/master/LICENSE)[![Github Releases (by Release)](https://img.shields.io/github/downloads/MaterialComponentsXamarin/MaterialComponentsXamarin/v35.0.0/total.svg)]()[![GitHub Issues](https://img.shields.io/github/issues/ilap/MaterialComponentsXamarin.svg)](https://github.com/ilap/MaterialComponentsXamarin/issues)[![NuGet Badge](https://buildstats.info/nuget/Xamarin.iOS.MaterialComponents)](https://www.nuget.org/packages/Xamarin.iOS.MaterialComponents/)[![Contributions welcome](https://img.shields.io/badge/contributions-welcome-orange.svg)](https://github.com/ilap/MaterialComponentsXamarin#contribute)

<table>
<tr>
<td><p>C# binding of the <a href="https://github.com/material-components/material-components-ios" target="_blank" >Material Components for iOS</a> the Modular and customisable <a href="https://material.io/" target="_blank" >Material Design UI components</a> for IOS.<br>Xamarin binding of Material Components for iOS and the adopted sample, demo and example iOS apps are written in C#.<br><br>The Xamarin binding versions follow the relevant MaterialComponents for iOS's versions. e.g. MaterialComponents for iOS v31.0.0 --> MaterialComponentBinding v31.0.0.</p>
</td>
</tr>
</table>
<p align="center">
<a href="samples/"><img  src="arts/Shrine.gif" width="33%"></a>
<a href="samples/"><img  src="arts/Pesto.gif" width="33%"></a>
<a href="samples/"><img  src="arts/ShrineRemoteImage.gif" width="33%"></a>
</p>

## Demos

These apps above were translated from the original Siwft/ObjC sample apps to C# using Material Components for iOSes' Xamarin.iOS bindigs.
Click on any image for further details.

## Current Version

- v35.0.0

## Usage

- Scenario 1: Try the Sample app - Clone and open the MaterialComponents solution.

``` bash
git clone https://github.com/ilap/MaterialComponentsXamarin
open -a "Visual Studio" MaterialComponentsXamarin/MaterialComponentsBinding.sln
```

- Scenario 2: Use it in your project/solution - Install the [NuGet package](https://www.nuget.org/packages/Xamarin.iOS.MaterialComponents).

For further usage details, have a look at the [Samples](samples/) directory and the [API Documentation](https://material.io/components/ios/catalog/).


# Requirements

## Xamarin Binding Build
- The built MaterialComponents native framework and its dependent frameworks, see [Dependencies](src/README.md#framework-dependencies).
- VisualStudio for Mac.
- Xamarin.iOS

## MaterialComponents Framework Build on macOS/OS X.
- Xcode 8.3
- Pod


# Contribute

Thank you for your interest in this Xamarin Bindings and the sample code.
Here are some ways you can contribute to this project:

- Fix issues opened in GitHub against the binding source code and/or the sample.
- Fix API definitions in the [Binding Project](src/MaterialComponents/).
- Add new features to the sample app.
- Add or improve comments to or in the sample code.



# Attributions #
This project uses some third-party assets with a license that requires attribution:

  - **[Material Design icons at Github](https://github.com/google/material-design-icons)**,
copyright Google Inc. and licensed under
[CC BY 4.0](https://creativecommons.org/licenses/by/4.0/).


  - **[Roboto Font at Google](https://www.google.com/fonts/specimen/Roboto)**, copyright [Christian Robertson](https://plus.google.com/110879635926653430880/about), and licensed under [Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0)

  - **[Raleway at Google Fonts](https://www.google.com/fonts/specimen/Raleway)**: copyright Matt McInerney, Pablo Impallari, Rodrigo Fuenzalida and by Igino Marini, and licensed [Open Font License](http://scripts.sil.org/cms/scripts/page.php?site_id=nrsi&id=OFL_web)

  - **This software** contains demo code, samples, examples and tutorials derived from the Google Inc.'s Material Components for iOS project and licensed under [Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0)  without a NOTICE file.


  - **Xamarin Binding of Material Components for iOS** uses: the Material Components for iOS and its dependents, copyright Google Inc. and licensed under [Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0) without a NOTICE file.

For extra information about licenses, you can see it at the dependency repositories.

# License #

Xamarin Binding of MaterialComponents for iOS

Copyright (c) 2017 The Material Components for iOS Xamarin Binding Authors.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
