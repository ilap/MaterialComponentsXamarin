//
// ShrineData.cs
//
// Author:
//       Pal Dorogi "ilap" <pal.dorogi@gmail.com>
//
// Copyright (c) 2017 Pal Dorogi
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

using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Json;
using System.Runtime.CompilerServices;


namespace ShrineRemoteImage.iOS
{
    // https://developer.xamarin.com/guides/ios/application_fundamentals/working_with_the_file_system/
    public class Product
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }

    public class Shop
    {
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ShrineData
    {
        static String productsJson = "Resources.products.json";
#if __IOS__
        static String resourcePrefix = "ShrineRemoteImage.iOS.";
#elif __ANDROID__
        static String resourcePrefix = "ShrineRemoteImage.Droid.";
#elif __WINDOWS_PHONE
        static String resourcePrefix = "ShrineRemoteImage.WinPhone.";
#endif

        public List<string> imageNames = new List<string>();
        public List<string> titles = new List<string>();
        public List<string> descriptions = new List<string>();
        public List<string> prices = new List<string>();
        public List<string> avatars = new List<string>();
        public List<string> shopTitles = new List<string>();

        public static String baseURL = "https://www.gstatic.com/angular/material-adaptive/shrine/";

        public void readJSON() {

            var assembly = typeof(ShrineData).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream
                (resourcePrefix + productsJson);

            foreach (var res in assembly.GetManifestResourceNames())
            {
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }

            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();


            var json = JsonValue.Parse(text);
            var products = json["products"];

            
            foreach (JsonObject product in products) {
                // string myValue = dataItem.Value["myKey"]; 
                imageNames.Add(product["image"]);
                titles.Add(product["title"]);
                descriptions.Add(product["description"]);
                prices.Add(product["price"]);
            }

            var shops = json["shops"];
            foreach (JsonObject shop in shops) {
                avatars.Add(shop["avatar"]);
                shopTitles.Add(shop["shop"]);
            }
        }
    }
}
