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
using System.Collections.Generic;

using Foundation;
using ShrineXamarin.Model;

namespace ShrineXamarin 
{
    public class ProductFactory 
    {
        public const String Home = "/Home/";
        public const String Clothing = "/Clothing/";
        public const String Popslices = "popsicle";
             
        public static List<Product> ProductsForCategory(String category) {
                
            var resourcePath = NSBundle.MainBundle.ResourcePath;
            var pngExtension = "png";
            var folderPath = "";

            List<string> files = new List<string>();

            NSError error;
            string[] filenames;

            switch (category) {
                case Home:
                    
                    folderPath = resourcePath + category;
                    filenames = NSFileManager.DefaultManager.GetDirectoryContent(folderPath, out error);
                    foreach (var filename in filenames) {
                        files.Add(folderPath + filename);
                    }
                        
                    break;

                case Clothing:
                    
                    folderPath = resourcePath + category;
                    filenames = NSFileManager.DefaultManager.GetDirectoryContent(folderPath, out error);
                    foreach (var filename in filenames) {
                        files.Add(folderPath + filename);
                    }
                    break;

                case Popslices:
                    // 16 popslices
                    for (int i = 0; i < 16; i++) {
                            var path = NSBundle.MainBundle.PathForResource(category, pngExtension);
                            files.Add(path);
                    }
                    break;
            }


            var products = new List<Product>();

            foreach (var file in files) {
                Product p = new Product();
                p.ImagePath = file;
                products.Add(p);
            }

            return products;
        }
    }
}
