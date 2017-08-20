using Foundation;
using System;
using UIKit;
using MaterialComponents.MaterialTextFields;
using MaterialComponents.MaterialButtons;
using CoreGraphics;
using System.Linq;
using Cirrious.FluentLayouts;
using Cirrious.FluentLayouts.Touch;

namespace MaterialComponentsApp
{



	public partial class TextFieldsExample : UIViewController
	{

		private float LargeMargin = 16;
		private float SmallMargin = 8;
		private float FloatingHeight = 84;
		private float DefaultHeight = 62;
		private float StateWidth = 80;
		public TextFieldsExample(IntPtr handle) : base(handle)
		{


		}

		public override void ViewDidLoad()
		{

			base.ViewDidLoad();
			var scrollView = new UIScrollView()
			{
				BackgroundColor = UIColor.FromWhiteAlpha(0.97f, 1f),
				ShowsHorizontalScrollIndicator = false,
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight,
			};

			scrollView.Frame = View.Bounds;
			scrollView.ContentSize = new CGSize(scrollView.Bounds.Width - 2 * LargeMargin, 372);
			scrollView.TranslatesAutoresizingMaskIntoConstraints = true;

			View = scrollView;
			scrollView.TranslatesAutoresizingMaskIntoConstraints = true;

			//View.AddSubview(scrollView);

			base.ViewDidLoad();
            //View.BackgroundColor = UIColor.Blue;

			var name = new MDCTextField()
			{
				Placeholder = "Name",
				AutocapitalizationType = UITextAutocapitalizationType.Words,
			};
			Add(name);
			name.TranslatesAutoresizingMaskIntoConstraints = false;

			var address = new MDCTextField()
			{
				Placeholder = "Address",
				AutocapitalizationType = UITextAutocapitalizationType.Words
			};
			Add(address);
			address.TranslatesAutoresizingMaskIntoConstraints = false;

			var city = new MDCTextField()
			{
				Placeholder = "Brisbane City",
				AutocapitalizationType = UITextAutocapitalizationType.Words
			};
			Add(city);
			city.TranslatesAutoresizingMaskIntoConstraints = false;

			var state = new MDCTextField()
			{
				Placeholder = "State",
				AutocapitalizationType = UITextAutocapitalizationType.AllCharacters
			};
			Add(state);
			state.TranslatesAutoresizingMaskIntoConstraints = false;

			var zip = new MDCTextField()
			{
				Placeholder = "Zip",
                AutocapitalizationType = UITextAutocapitalizationType.AllCharacters
			};
			Add(zip);
			zip.TranslatesAutoresizingMaskIntoConstraints = false;


			var phone = new MDCTextField()
			{
				Placeholder = "Phone",
				//Text = "+61 4 1234 1234",
			};
			Add(phone);
			phone.TranslatesAutoresizingMaskIntoConstraints = false;

			//cityController = new MDCTextInputControllerDefault();
			//cityController.TextInput = (city as MDCTextField) as MDCTextInput;
			//zipController = new MDCTextInputControllerDefault();
			//zipController.TextInput =  zip;

			var commonWidth = View.Bounds.Width - 2 * LargeMargin;
			// isFloatingg enabled?
			var height = true ? FloatingHeight : DefaultHeight;

			View.AddConstraints(
				name.AtLeftOf(View, LargeMargin),
                name.AtTopOf(View, 2 * LargeMargin),
				name.AtRightOf(View, LargeMargin),
				name.Width().EqualTo(commonWidth),
				name.Height().EqualTo(height),

				address.WithSameLeft(name),
				address.Below(name, SmallMargin),
				address.WithSameWidth(name),
				address.WithSameHeight(name),

				city.WithSameLeft(name),
				city.WithSameWidth(name),
				city.WithSameHeight(name),
				city.Below(address, SmallMargin),

				state.Below(city, SmallMargin),
				state.WithSameLeft(name),
				state.WithSameHeight(name),
				state.Width().EqualTo(StateWidth),

                zip.WithSameTop(state),
                zip.ToRightOf(state, SmallMargin),
                zip.WithSameRight(name),

                phone.Below(state, SmallMargin),
                phone.WithSameLeft(name),
                phone.WithSameWidth(name),
				phone.WithSameHeight(name)

			);
		}
	}
}