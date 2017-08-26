using System;
using System.Runtime.InteropServices;
using StoreKit;
using Foundation;
using SystemConfiguration;
using ShrineXamarin.Model;
using System.Linq;
using CoreText;
using System.Collections.Generic;
      

namespace ShrineXamarin {

    public class ProductFactory {

        public const String Home = "/Home/";
        public const String Clothing = "/Clothing/";
        public const String Popslices = "popslice";
             
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
                    foreach (var filename in filenames)
                    {
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
                    for (int i = 0; i < 10; i++) {
                            var path = NSBundle.MainBundle.PathForResource(category, pngExtension);
                            files.Add(path);
                    }
                    break;
                        
            }

            //Product[] products = new Product[0];
            List<Product> products = new List<Product>();
            foreach (var file in files) {
                var product = new Product();
                product.ImagePath = file;
                products.Add(product);
            }

            return products;

        }
    }
}
