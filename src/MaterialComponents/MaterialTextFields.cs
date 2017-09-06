using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using MaterialComponents;
using ObjCRuntime;
using UIKit;

namespace MaterialComponents.MaterialTextFields
{
    //public interface IMDCTextInput {}
	// @protocol MDCTextInput <NSObject>
	//[Protocol]//, Model]
	[BaseType (typeof(NSObject))]
    [Protocol, Model]
    interface MDCTextInput//: IMDCTextInput
	{
		// @required @property (copy, nonatomic) NSAttributedString * _Nullable attributedPlaceholder;
		[Abstract]
		[NullAllowed, Export ("attributedPlaceholder", ArgumentSemantic.Copy)]
		NSAttributedString AttributedPlaceholder { get; set; }

		// @required @property (copy, nonatomic) NSAttributedString * _Nullable attributedText;
		[Abstract]
		[NullAllowed, Export ("attributedText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedText { get; set; }

		// @required @property (readonly, nonatomic, strong) UIButton * _Nonnull clearButton;
		[Abstract]
		[Export ("clearButton", ArgumentSemantic.Strong)]
		UIButton ClearButton { get; }

		// @required @property (nonatomic, strong) UIColor * _Nullable clearButtonColor __attribute__((annotate("ui_appearance_selector")));
		[Abstract]
		[NullAllowed, Export ("clearButtonColor", ArgumentSemantic.Strong)]
		UIColor ClearButtonColor { get; set; }

		// @required @property (assign, nonatomic) UITextFieldViewMode clearButtonMode;
		[Abstract]
		[Export ("clearButtonMode", ArgumentSemantic.Assign)]
		UITextFieldViewMode ClearButtonMode { get; set; }

		// @required @property (readonly, getter = isEditing, assign, nonatomic) BOOL editing;
		[Abstract]
		[Export ("editing")]
		bool Editing { [Bind ("isEditing")] get; }

		// @required @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Abstract]
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// @required @property (nonatomic, strong) UIFont * _Nullable font;
		[Abstract]
		[NullAllowed, Export ("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// @required @property (assign, nonatomic) BOOL hidesPlaceholderOnInput;
		[Abstract]
		[Export ("hidesPlaceholderOnInput")]
		bool HidesPlaceholderOnInput { get; set; }

		// @required @property (readonly, nonatomic, strong) UILabel * _Nonnull leadingUnderlineLabel;
		[Abstract]
		[Export ("leadingUnderlineLabel", ArgumentSemantic.Strong)]
		UILabel LeadingUnderlineLabel { get; }

		// @required @property (nonatomic, setter = mdc_setAdjustsFontForContentSizeCategory:) BOOL mdc_adjustsFontForContentSizeCategory __attribute__((annotate("ui_appearance_selector")));
		[Abstract]
		[Export ("mdc_adjustsFontForContentSizeCategory")]
		bool Mdc_adjustsFontForContentSizeCategory { get; [Bind ("mdc_setAdjustsFontForContentSizeCategory:")] set; }

		// @required @property (copy, nonatomic) NSString * _Nullable placeholder;
		[Abstract]
		[NullAllowed, Export ("placeholder")]
		string Placeholder { get; set; }

		// @required @property (readonly, nonatomic, strong) UILabel * _Nonnull placeholderLabel;
		[Abstract]
		[Export ("placeholderLabel", ArgumentSemantic.Strong)]
		UILabel PlaceholderLabel { get; }

		[Wrap ("WeakPositioningDelegate")]//, Abstract]
		[NullAllowed]
		MDCTextInputPositioningDelegate PositioningDelegate { get; set; }

		// @required @property (nonatomic, weak) id<MDCTextInputPositioningDelegate> _Nullable positioningDelegate;
		//[Abstract]
		[NullAllowed, Export ("positioningDelegate", ArgumentSemantic.Weak)]
		NSObject WeakPositioningDelegate { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable text;
		[Abstract]
		[NullAllowed, Export ("text")]
		string Text { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Nullable textColor;
		[Abstract]
		[NullAllowed, Export ("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @required @property (readonly, assign, nonatomic) UIEdgeInsets textInsets;
		[Abstract]
		[Export ("textInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets TextInsets { get; }

		// @required @property (readonly, nonatomic, strong) UILabel * _Nonnull trailingUnderlineLabel;
		[Abstract]
		[Export ("trailingUnderlineLabel", ArgumentSemantic.Strong)]
		UILabel TrailingUnderlineLabel { get; }

		// @required @property (nonatomic, strong) UIView * _Nullable trailingView;
		[Abstract]
		[NullAllowed, Export ("trailingView", ArgumentSemantic.Strong)]
		UIView TrailingView { get; set; }

		// @required @property (assign, nonatomic) UITextFieldViewMode trailingViewMode;
		[Abstract]
		[Export ("trailingViewMode", ArgumentSemantic.Assign)]
		UITextFieldViewMode TrailingViewMode { get; set; }

		// @required @property (readonly, nonatomic, strong) MDCTextInputUnderlineView * _Nullable underline;
		[Abstract]
		[NullAllowed, Export ("underline", ArgumentSemantic.Strong)]
		MDCTextInputUnderlineView Underline { get; }
	}


    // @interface MDCTextInputUnderlineView : UIView <NSCopying, NSCoding>
    [BaseType(typeof(UIView))]
    interface MDCTextInputUnderlineView : INSCopying, INSCoding {
        // @property (nonatomic, strong) UIColor * color;
        [Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // @property (nonatomic, strong) UIColor * disabledColor;
        [Export("disabledColor", ArgumentSemantic.Strong)]
        UIColor DisabledColor { get; set; }

        // @property (assign, nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { get; set; }

        // @property (assign, nonatomic) CGFloat lineHeight;
        [Export("lineHeight")]
        nfloat LineHeight { get; set; }
    }

	// @interface MDCTextField : UITextField <MDCTextInput>
	[BaseType(typeof(UITextField))]
    //[Model]
	interface MDCTextField : MDCTextInput
	{
		[DesignatedInitializer]
		[Export("initWithFrame:")]
		IntPtr Constructor(CGRect frame);

		// @property (nonatomic, strong) UIView * _Nullable leadingView;
		[NullAllowed, Export("leadingView", ArgumentSemantic.Strong)]
		UIView LeadingView { get; set; }

		// @property (assign, nonatomic) UITextFieldViewMode leadingViewMode;
		[Export("leadingViewMode", ArgumentSemantic.Assign)]
		UITextFieldViewMode LeadingViewMode { get; set; }
	}


	//public interface IMDCTextInputPositioningDelegate { }
	// @protocol MDCTextInputPositioningDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCTextInputPositioningDelegate// : IMDCTextInputPositioningDelegate
	{
		// @optional -(UIEdgeInsets)textInsets:(UIEdgeInsets)defaultInsets;
		[Export("textInsets:")]
		UIEdgeInsets TextInsets(UIEdgeInsets defaultInsets);

		// @optional -(CGRect)editingRectForBounds:(CGRect)bounds defaultRect:(CGRect)defaultRect;
		[Export("editingRectForBounds:defaultRect:")]
		CGRect EditingRectForBounds(CGRect bounds, CGRect defaultRect);
	}


	// @protocol MDCMultilineTextInputLayoutDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface MDCMultilineTextInputLayoutDelegate
	{
		// @optional -(void)multilineTextField:(id<MDCMultilineTextInput> _Nonnull)multilineTextField didChangeContentSize:(CGSize)size;
		[Export("multilineTextField:didChangeContentSize:")]
		void DidChangeContentSize(MDCMultilineTextInput multilineTextField, CGSize size);
	}
    
    //public interface IMDCMultilineTextInput {}
	// @protocol MDCMultilineTextInput <MDCTextInput>
	[Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MDCMultilineTextInput : MDCTextInput
	{

		// @required @property (assign, nonatomic) NSUInteger minimumLines __attribute__((annotate("ui_appearance_selector")));
		[Abstract]
		[Export ("minimumLines")]
		nuint MinimumLines { get; set; }

		// @required @property (assign, nonatomic) BOOL expandsOnOverflow __attribute__((annotate("ui_appearance_selector")));
		[Abstract]
		[Export ("expandsOnOverflow")]
		bool ExpandsOnOverflow { get; set; }
	}

	[Static]
    // XXX: [Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull MDCTextFieldTextDidSetTextNotification;
		[Field ("MDCTextFieldTextDidSetTextNotification", "__Internal")]
		NSString MDCTextFieldTextDidSetTextNotification { get; }
 
        // extern const CGFloat MDCTextInputDefaultBorderRadius;
        [Field("MDCTextInputDefaultBorderRadius", "__Internal")]
        nfloat MDCTextInputDefaultBorderRadius { get; }

        // extern const CGFloat MDCTextInputDefaultUnderlineActiveHeight;
        [Field("MDCTextInputDefaultUnderlineActiveHeight", "__Internal")]
        nfloat MDCTextInputDefaultUnderlineActiveHeight { get; }
    }



    //public interface IMDCTextInputCharacterCounter {}
	// @protocol MDCTextInputCharacterCounter <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    interface MDCTextInputCharacterCounter//: IMDCTextInputCharacterCounter
	{
		// @required -(NSUInteger)characterCountForTextInput:(UIView<MDCTextInput> * _Nullable)textInput;
		[Abstract]
		[Export ("characterCountForTextInput:")]
		nuint CharacterCountForTextInput ([NullAllowed] MDCTextInput textInput);
	}

	// @interface MDCTextInputAllCharactersCounter : NSObject <MDCTextInputCharacterCounter>
	[BaseType (typeof(NSObject))]
	interface MDCTextInputAllCharactersCounter : MDCTextInputCharacterCounter
	{
	}

    //public interface IMDCTextInputController {}
	// @protocol MDCTextInputController <NSObject, NSCoding, NSCopying, MDCTextInputPositioningDelegate>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MDCTextInputController : INSCoding, INSCopying, MDCTextInputPositioningDelegate//, IMDCTextInputController
	{
        // @required @property (nonatomic, strong) UIColor * _Null_unspecified activeColor;
        [Abstract]
        [Export("activeColor", ArgumentSemantic.Strong)]
        UIColor ActiveColor { get; set; }

        // @required @property (nonatomic, strong, class) UIColor * _Null_unspecified activeColorDefault;
        [Static, Abstract]
        [Export("activeColorDefault", ArgumentSemantic.Strong)]
        UIColor ActiveColorDefault { get; set; }

		// @required @property (nonatomic, weak) id<MDCTextInputCharacterCounter> _Null_unspecified characterCounter;
		[Abstract]
		[Export ("characterCounter", ArgumentSemantic.Weak)]
		MDCTextInputCharacterCounter CharacterCounter { get; set; }

		// @required @property (assign, nonatomic) NSUInteger characterCountMax;
		[Abstract]
		[Export ("characterCountMax")]
		nuint CharacterCountMax { get; set; }

		// @required @property (assign, nonatomic) UITextFieldViewMode characterCountViewMode;
		[Abstract]
		[Export ("characterCountViewMode", ArgumentSemantic.Assign)]
		UITextFieldViewMode CharacterCountViewMode { get; set; }

        //v34.0.1
        // @required @property (assign, nonatomic) UIRectCorner roundedCorners;
        [Abstract]
        [Export("roundedCorners", ArgumentSemantic.Assign)]
        UIRectCorner RoundedCorners { get; set; }

        // @required @property (assign, nonatomic, class) UIRectCorner roundedCornersDefault;
        [Static, Abstract]
        [Export("roundedCornersDefault", ArgumentSemantic.Assign)]
        UIRectCorner RoundedCornersDefault { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Null_unspecified disabledColor;
        [Abstract]
        [Export("disabledColor", ArgumentSemantic.Strong)]
        UIColor DisabledColor { get; set; }

        // @required @property (nonatomic, strong, class) UIColor * _Null_unspecified disabledColorDefault;
        [Static, Abstract]
        [Export("disabledColorDefault", ArgumentSemantic.Strong)]
        UIColor DisabledColorDefault { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Null_unspecified errorColor;
		[Abstract]
		[Export ("errorColor", ArgumentSemantic.Strong)]
		UIColor ErrorColor { get; set; }

		// @required @property (nonatomic, strong, class) UIColor * _Null_unspecified errorColorDefault;
		[Static, Abstract]
		[Export ("errorColorDefault", ArgumentSemantic.Strong)]
		UIColor ErrorColorDefault { get; set; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable errorText;
		[Abstract]
		[NullAllowed, Export ("errorText")]
		string ErrorText { get; }

		// @required @property (copy, nonatomic) NSString * _Nullable helperText;
		[Abstract]
		[NullAllowed, Export ("helperText")]
		string HelperText { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Null_unspecified inlinePlaceholderColor;
		[Abstract]
		[Export ("inlinePlaceholderColor", ArgumentSemantic.Strong)]
		UIColor InlinePlaceholderColor { get; set; }

		// @required @property (nonatomic, strong, class) UIColor * _Null_unspecified inlinePlaceholderColorDefault;
		[Static, Abstract]
		[Export ("inlinePlaceholderColorDefault", ArgumentSemantic.Strong)]
		UIColor InlinePlaceholderColorDefault { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Null_unspecified leadingUnderlineLabelTextColor;
        [Abstract]
        [Export("leadingUnderlineLabelTextColor", ArgumentSemantic.Strong)]
        UIColor LeadingUnderlineLabelTextColor { get; set; }

        // @required @property (nonatomic, strong, class) UIColor * _Null_unspecified leadingUnderlineLabelTextColorDefault;
        [Static, Abstract]
        [Export("leadingUnderlineLabelTextColorDefault", ArgumentSemantic.Strong)]
        UIColor LeadingUnderlineLabelTextColorDefault { get; set; }

		// @required @property (assign, readwrite, nonatomic, setter = mdc_setAdjustsFontForContentSizeCategory:) BOOL mdc_adjustsFontForContentSizeCategory;
		[Abstract]
		[Export ("mdc_adjustsFontForContentSizeCategory")]
		bool Mdc_adjustsFontForContentSizeCategory { get; [Bind ("mdc_setAdjustsFontForContentSizeCategory:")] set; }

		// @required @property (assign, nonatomic, class) BOOL mdc_adjustsFontForContentSizeCategoryDefault;
		[Static, Abstract]
		[Export ("mdc_adjustsFontForContentSizeCategoryDefault")]
		bool Mdc_adjustsFontForContentSizeCategoryDefault { get; set; }


        // @required @property (nonatomic, strong) UIColor * _Null_unspecified normalColor;
        [Abstract]
        [Export("normalColor", ArgumentSemantic.Strong)]
        UIColor NormalColor { get; set; }

        // @required @property (nonatomic, strong, class) UIColor * _Null_unspecified normalColorDefault;
        [Static, Abstract]
        [Export("normalColorDefault", ArgumentSemantic.Strong)]
        UIColor NormalColorDefault { get; set; }

		// @required @property (nonatomic, strong) UIView<MDCTextInput> * _Nullable textInput;
		[Abstract]
		[NullAllowed, Export ("textInput", ArgumentSemantic.Strong)]
		MDCTextInput TextInput { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable trailingUnderlineLabelTextColor;
        [Abstract]
        [NullAllowed, Export("trailingUnderlineLabelTextColor", ArgumentSemantic.Strong)]
        UIColor TrailingUnderlineLabelTextColor { get; set; }

        // @required @property (nonatomic, strong, class) UIColor * _Nullable trailingUnderlineLabelTextColorDefault;
        [Static, Abstract]
        [NullAllowed, Export("trailingUnderlineLabelTextColorDefault", ArgumentSemantic.Strong)]
        UIColor TrailingUnderlineLabelTextColorDefault { get; set; }

		// @required @property (assign, nonatomic) UITextFieldViewMode underlineViewMode;
		[Abstract]
		[Export ("underlineViewMode", ArgumentSemantic.Assign)]
		UITextFieldViewMode UnderlineViewMode { get; set; }

		// @required @property (assign, nonatomic, class) UITextFieldViewMode underlineViewModeDefault;
		[Static, Abstract]
		[Export ("underlineViewModeDefault", ArgumentSemantic.Assign)]
		UITextFieldViewMode UnderlineViewModeDefault { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Null_unspecified underlineColorActive;
		//[Abstract]
		//[Export ("underlineColorActive", ArgumentSemantic.Strong)]
		//UIColor UnderlineColorActive { get; set; }

		// @required @property (nonatomic, strong, class) UIColor * _Null_unspecified underlineColorActiveDefault;
		//[Static, Abstract]
		//[Export ("underlineColorActiveDefault", ArgumentSemantic.Strong)]
		//UIColor UnderlineColorActiveDefault { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Null_unspecified underlineColorNormal;
		//[Abstract]
		//[Export ("underlineColorNormal", ArgumentSemantic.Strong)]
		//UIColor UnderlineColorNormal { get; set; }

		// @required @property (nonatomic, strong, class) UIColor * _Null_unspecified underlineColorNormalDefault;
		//[Static, Abstract]
		//[Export ("underlineColorNormalDefault", ArgumentSemantic.Strong)]
		//UIColor UnderlineColorNormalDefault { get; set; }

		// @required -(instancetype _Nonnull)initWithTextInput:(UIView<MDCTextInput> * _Nullable)input;
		//[Abstract]
		[Export ("initWithTextInput:")]
		IntPtr Constructor ([NullAllowed] MDCTextInput input);

		// @required -(void)setErrorText:(NSString * _Nullable)errorText errorAccessibilityValue:(NSString * _Nullable)errorAccessibilityValue;
		[Abstract]
		[Export ("setErrorText:errorAccessibilityValue:")]
		void SetErrorText ([NullAllowed] string errorText, [NullAllowed] string errorAccessibilityValue);
	}

	// @interface MDCTextInputControllerDefault : NSObject <MDCTextInputController>
	[BaseType (typeof(NSObject))]
	interface MDCTextInputControllerDefault : MDCTextInputController
	{
        //MARK: V34.0.1
        // @property (nonatomic, strong) UIColor * _Nullable borderFillColor;
        [NullAllowed, Export("borderFillColor", ArgumentSemantic.Strong)]
        UIColor BorderFillColor { get; set; }

        // @property (nonatomic, strong, class) UIColor * _Null_unspecified borderFillColorDefault;
        [Static]
        [Export("borderFillColorDefault", ArgumentSemantic.Strong)]
        UIColor BorderFillColorDefault { get; set; }

        // @property (assign, nonatomic) BOOL expandsOnOverflow;
        [Export("expandsOnOverflow")]
        bool ExpandsOnOverflow { get; set; }
		// @property (nonatomic, strong) UIColor * _Null_unspecified floatingPlaceholderColor;
		[Export ("floatingPlaceholderColor", ArgumentSemantic.Strong)]
		UIColor FloatingPlaceholderColor { get; set; }

		// @property (nonatomic, strong, class) UIColor * _Null_unspecified floatingPlaceholderColorDefault;
		[Static]
		[Export ("floatingPlaceholderColorDefault", ArgumentSemantic.Strong)]
		UIColor FloatingPlaceholderColorDefault { get; set; }

		// @property (nonatomic, strong) NSNumber * _Null_unspecified floatingPlaceholderScale;
		[Export ("floatingPlaceholderScale", ArgumentSemantic.Strong)]
		NSNumber FloatingPlaceholderScale { get; set; }

		// @property (assign, nonatomic, class) CGFloat floatingPlaceholderScaleDefault;
		[Static]
		[Export ("floatingPlaceholderScaleDefault")]
		nfloat FloatingPlaceholderScaleDefault { get; set; }

		// @property (getter = isFloatingEnabled, assign, nonatomic) BOOL floatingEnabled;
		[Export ("floatingEnabled")]
		bool FloatingEnabled { [Bind ("isFloatingEnabled")] get; set; }

		// @property (getter = isFloatingEnabledDefault, assign, nonatomic, class) BOOL floatingEnabledDefault;
		[Static]
		[Export ("floatingEnabledDefault")]
		bool FloatingEnabledDefault { [Bind ("isFloatingEnabledDefault")] get; set; }

        // @property (assign, nonatomic) NSUInteger minimumLines;
        [Export("minimumLines")]
        nuint MinimumLines { get; set; }
    }

	// @interface MDCTextInputControllerFullWidth : NSObject <MDCTextInputController>
	[BaseType (typeof(NSObject))]
	interface MDCTextInputControllerFullWidth : MDCTextInputController
	{
	}


	// @interface MDCMultilineTextField : UIView <MDCTextInput, MDCMultilineTextInput>
	[BaseType (typeof(UIView))]
	interface MDCMultilineTextField : MDCTextInput, MDCMultilineTextInput
	{
		// @property (assign, nonatomic) BOOL adjustsFontForContentSizeCategory;
		[Export ("adjustsFontForContentSizeCategory")]
		bool AdjustsFontForContentSizeCategory { get; set; }

		[Wrap ("WeakLayoutDelegate")]
		[NullAllowed]
		MDCMultilineTextInputLayoutDelegate LayoutDelegate { get; set; }

		// @property (nonatomic, weak) id<MDCMultilineTextInputLayoutDelegate> _Nullable layoutDelegate __attribute__((iboutlet));
		[NullAllowed, Export ("layoutDelegate", ArgumentSemantic.Weak)]
		NSObject WeakLayoutDelegate { get; set; }

		// @property (readonly, assign, nonatomic) UIEdgeInsets textInsets;
        //
		//FIXME: CS0108 added new keywError, test whether it works or not.
		[Export ("textInsets", ArgumentSemantic.Assign)]
		new UIEdgeInsets TextInsets { get; }

		// @property (nonatomic, weak) UITextView * _Nullable textView __attribute__((iboutlet));
		[NullAllowed, Export ("textView", ArgumentSemantic.Weak)]
		UITextView TextView { get; set; }
	}

    // @interface MDCTextInputControllerLegacyDefault : NSObject <MDCTextInputController>
    [BaseType(typeof(NSObject))]
    interface MDCTextInputControllerLegacyDefault : MDCTextInputController {
        // @property (nonatomic, strong) UIColor * _Null_unspecified floatingPlaceholderColor;
        [Export("floatingPlaceholderColor", ArgumentSemantic.Strong)]
        UIColor FloatingPlaceholderColor { get; set; }

        // @property (nonatomic, strong, class) UIColor * _Null_unspecified floatingPlaceholderColorDefault;
        [Static]
        [Export("floatingPlaceholderColorDefault", ArgumentSemantic.Strong)]
        UIColor FloatingPlaceholderColorDefault { get; set; }

        // @property (nonatomic, strong) NSNumber * _Null_unspecified floatingPlaceholderScale;
        [Export("floatingPlaceholderScale", ArgumentSemantic.Strong)]
        NSNumber FloatingPlaceholderScale { get; set; }

        // @property (assign, nonatomic, class) CGFloat floatingPlaceholderScaleDefault;
        [Static]
        [Export("floatingPlaceholderScaleDefault")]
        nfloat FloatingPlaceholderScaleDefault { get; set; }

        // @property (getter = isFloatingEnabled, assign, nonatomic) BOOL floatingEnabled;
        [Export("floatingEnabled")]
        bool FloatingEnabled { [Bind("isFloatingEnabled")] get; set; }

        // @property (getter = isFloatingEnabledDefault, assign, nonatomic, class) BOOL floatingEnabledDefault;
        [Static]
        [Export("floatingEnabledDefault")]
        bool FloatingEnabledDefault { [Bind("isFloatingEnabledDefault")] get; set; }
    }

    // @interface MDCTextInputControllerLegacyFullWidth : NSObject <MDCTextInputController>
    [BaseType(typeof(NSObject))]
    interface MDCTextInputControllerLegacyFullWidth : MDCTextInputController {
    }

    // @interface MDCTextInputControllerOutlinedField : MDCTextInputControllerDefault
    [BaseType(typeof(MDCTextInputControllerDefault))]
    interface MDCTextInputControllerOutlinedField {
    }

    // @interface MDCTextInputControllerTextArea : MDCTextInputControllerDefault
    [BaseType(typeof(MDCTextInputControllerDefault))]
    interface MDCTextInputControllerTextArea {
    }

    // @interface MDCTextInputControllerTextFieldBox : MDCTextInputControllerDefault
    [BaseType(typeof(MDCTextInputControllerDefault))]
    interface MDCTextInputControllerTextFieldBox {
    }

}
