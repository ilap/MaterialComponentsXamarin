﻿using System;
using Foundation;
namespace Pesto.Model
{
    public class PestoData : NSObject
    {
        public static String DataBaseURL = "https://www.gstatic.com/angular/material-adaptive/pesto/";

        public String[] authors = {
            "Peter Carlsson", "Trevor Hansen", "Ali Connors", "Sandra Adams", 
            "Peter Carlsson", "Ali Connors", "Peter Carlsson", "Ali Connors", 
            "Sandra Adams", "Trevor Hansen", "Sandra Adams", "Ali Connors", 
            "Trevor Hansen"
        };

        public String[] iconNames = {
            "Timer", "Veggie", "Main", "Meat", "Spicy", "Veggie", "Timer",
            "Fish", "Veggie", "Veggie", "Spicy", "Main", "Timer"
        };        

        public String[] imageFileNames = { 
            "image2-01.png", "blue-potato.jpg", "image1-01.png", "sausage.jpg", 
            "image5.png", "white-rice.jpg", "IMG_0575.jpg", "fish-steaks.jpg", 
            "IMG_5438.png", "IMG_5332.png", "bok-choy.jpg", "pasta.png", 
            "IMG_5447.jpg"
        };

        public String[] titles = {
            "Pesto bruchetta", "Rustic mash", "Bacon sprouts", "Oven sausage", 
            "Chicken tostadas", "Coconut rice", "Sicilian-style sardines", 
            "Seared sesame fish", "Herb artichoke", "Pesto bruschetta", 
            "Garlic bok choy", "Fresh fettuccine", "Gin basil cocktail"
        };

        public String[] descriptions = {
            "Bask in greens this season by trying this delightful take on traditional bruschetta." +
            "Top with a dollop of homemade pesto, and season with freshly ground sea salt and pepper.",

            "Abundant in color, and healthy, delicious goodness, cooking with these South American purple " +
            "potatoes is a treat. Boil, mash, bake, or roast them. For taste cook with chicken stock, " +
            "and a dash of extra virgin olive oil.",
    
            "This beautiful sprouts recipe is the most glorious side dish on a cold winter’s night. " +
            "Construct it with bacon or fake-on, but always make sure the sprouts are deliciously " +
            "seasoned and appropriately sautéed.",
    
            "Robust cuts of portuguese sausage add layers of flavour. Bake or fry until sausages are " +
            "slightly browned and with a crispy skin. Serve warm and with cuts of pineapple for a " +
            "delightful mix of sweet and savory flavour. This is the perfect dish after a swim in the " +
            "sea.",
    
            "Crisp flavours and a bit of spice make this roasted chicken dish an easy go to when cooking " +
            "for large groups. Top with Baja sauce for an extra kick of spice.",

            "This dish is a terrific pairing to almost any main. Bonus- it’s quick, easy to make, and " +
            "turns even the simplest of dishes into a delicacy. Sweet coconut cream will leave your " +
            "mouth watering, with yummy caramelized flecks of rice adding an extra bit of taste. Fluff " +
            "with fork before serving for best results.",
    
            "My go to way to eat sardines is with a splash of tangy lemon and fresh fennel drizzled on " +
            "top. The best thing about this dish is the flavour it packs. Prepaid with wild caught " +
            "sardines or canned.",
    
            "Cuts of fish like this are perfect for simple searing with bright flavours. Try Sesame seeds " +
            "on these fillets for crusty skin filled with crunch. For added flavour try dipping in a " +
            "homemade ponzu sauce - delicious.",
    
            "This tasty and healthy veggie is a favorite. Artichoke like this can be paired with a hearty " +
            "main or works well as a small meal with some white wine on the side. Simple and fresh, all " +
            "foodies love tasty artichoke.",
    
            "Life is good when you add amazingly warm bread, fresh pesto sauce, and roasted tomatoes to " +
            "the table. This a classic starter to break out in a pinch. It’s easy to make and extra " +
            "tasty.",

            "Great stir-fried bok choy starts at the market. For me, nothing says tasty like garlic and " +
            "baby bok choy. Choose fresh, crisp greens. Once home, wash, chop, and then ready for the " + 
            "wok. No family style spread is complete without these greens.",
    
            "Satisfy a need for rich, creamy homemade goodness with this classic. Creamy fettuccine " +
            "alfredo will have you hitting the gym the next day, but it’s so good it’s worth it.",
    
            "This mellow and herb filled blending of simple ingredients is easy enough to mix that a " +
            "novice host will feel like a seasoned bartender. Top with crushed basil, shake or stir."
        };

        public PestoData()
        {
        }
    }
}
