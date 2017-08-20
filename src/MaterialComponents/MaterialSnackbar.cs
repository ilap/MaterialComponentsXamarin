using System;
using Foundation;
using MaterialComponents;
using ObjCRuntime;
using UIKit;

namespace MaterialComponents.MaterialSnackbar
{
	// @interface MDCSnackbarManager : NSObject
	[BaseType (typeof(NSObject))]
	interface MDCSnackbarManager
	{
		// +(void)showMessage:(MDCSnackbarMessage *)message;
		[Static]
		[Export ("showMessage:")]
		void ShowMessage (MDCSnackbarMessage message);

		// +(void)setPresentationHostView:(UIView *)hostView;
		[Static]
		[Export ("setPresentationHostView:")]
		void SetPresentationHostView (UIView hostView);

		// +(void)dismissAndCallCompletionBlocksWithCategory:(NSString *)category;
		[Static]
		[Export ("dismissAndCallCompletionBlocksWithCategory:")]
		void DismissAndCallCompletionBlocksWithCategory (string category);

		// +(void)setBottomOffset:(CGFloat)offset;
		[Static]
		[Export ("setBottomOffset:")]
		void SetBottomOffset (nfloat offset);

		// +(id<MDCSnackbarSuspensionToken>)suspendAllMessages;
		[Static]
		[Export ("suspendAllMessages")]
		//[Verify (MethodToProperty)]
		MDCSnackbarSuspensionToken SuspendAllMessages { get; }

		// +(id<MDCSnackbarSuspensionToken>)suspendMessagesWithCategory:(NSString *)category;
		[Static]
		[Export ("suspendMessagesWithCategory:")]
		MDCSnackbarSuspensionToken SuspendMessagesWithCategory (string category);

		// +(void)resumeMessagesWithToken:(id<MDCSnackbarSuspensionToken>)token;
		[Static]
		[Export ("resumeMessagesWithToken:")]
		void ResumeMessagesWithToken (MDCSnackbarSuspensionToken token);
	}

	// @protocol MDCSnackbarSuspensionToken <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MDCSnackbarSuspensionToken
	{
	}

	// typedef void (^MDCSnackbarMessageCompletionHandler)(BOOL);
	delegate void MDCSnackbarMessageCompletionHandler (bool arg0);

	// typedef void (^MDCSnackbarMessageActionHandler)();
	delegate void MDCSnackbarMessageActionHandler ();

	[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const NSTimeInterval MDCSnackbarMessageDurationMax;
		[Field ("MDCSnackbarMessageDurationMax", "__Internal")]
		double MDCSnackbarMessageDurationMax { get; }

		// extern NSString *const MDCSnackbarMessageBoldAttributeName;
		[Field ("MDCSnackbarMessageBoldAttributeName", "__Internal")]
		NSString MDCSnackbarMessageBoldAttributeName { get; }
	}

	// @interface MDCSnackbarMessage : NSObject <NSCopying, UIAccessibilityIdentification>
	[BaseType (typeof(NSObject))]
	interface MDCSnackbarMessage : INSCopying, IUIAccessibilityIdentification
	{
		// +(instancetype)messageWithText:(NSString *)text;
		[Static]
		[Export ("messageWithText:")]
		MDCSnackbarMessage MessageWithText (string text);

		// +(instancetype)messageWithAttributedText:(NSAttributedString *)attributedText;
		[Static]
		[Export ("messageWithAttributedText:")]
		MDCSnackbarMessage MessageWithAttributedText (NSAttributedString attributedText);

		// @property (copy, nonatomic) NSString * text;
		[Export ("text")]
		string Text { get; set; }

		// @property (copy, nonatomic) NSAttributedString * attributedText;
		[Export ("attributedText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedText { get; set; }

		// @property (nonatomic, strong) MDCSnackbarMessageAction * action;
		[Export ("action", ArgumentSemantic.Strong)]
		MDCSnackbarMessageAction Action { get; set; }

		// @property (nonatomic, strong) UIColor * buttonTextColor;
		[Export ("buttonTextColor", ArgumentSemantic.Strong)]
		UIColor ButtonTextColor { get; set; }

		// @property (nonatomic, strong) UIColor * highlightedButtonTextColor;
		[Export ("highlightedButtonTextColor", ArgumentSemantic.Strong)]
		UIColor HighlightedButtonTextColor { get; set; }

		// @property (assign, nonatomic) NSTimeInterval duration;
		[Export ("duration")]
		double Duration { get; set; }

		// @property (copy, nonatomic) MDCSnackbarMessageCompletionHandler completionHandler;
		[Export ("completionHandler", ArgumentSemantic.Copy)]
		MDCSnackbarMessageCompletionHandler CompletionHandler { get; set; }

		// @property (copy, nonatomic) NSString * category;
		[Export ("category")]
		string Category { get; set; }

		// @property (copy, nonatomic) NSString * accessibilityLabel;
		[Export ("accessibilityLabel")]
		string AccessibilityLabel { get; set; }

		// @property (readonly, nonatomic) NSString * voiceNotificationText;
		[Export ("voiceNotificationText")]
		string VoiceNotificationText { get; }
	}

	// @interface MDCSnackbarMessageAction : NSObject <UIAccessibilityIdentification, NSCopying>
	[BaseType (typeof(NSObject))]
	interface MDCSnackbarMessageAction : IUIAccessibilityIdentification, INSCopying
	{
		// @property (copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) MDCSnackbarMessageActionHandler handler;
		[Export ("handler", ArgumentSemantic.Copy)]
		MDCSnackbarMessageActionHandler Handler { get; set; }
	}

	// @interface MDCSnackbarMessageView : UIView
	[BaseType (typeof(UIView))]
	interface MDCSnackbarMessageView
	{
		// @property (nonatomic, strong) UIColor * _Nullable snackbarMessageViewBackgroundColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export ("snackbarMessageViewBackgroundColor", ArgumentSemantic.Strong)]
		UIColor SnackbarMessageViewBackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable snackbarMessageViewShadowColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export ("snackbarMessageViewShadowColor", ArgumentSemantic.Strong)]
		UIColor SnackbarMessageViewShadowColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable snackbarMessageViewTextColor __attribute__((annotate("ui_appearance_selector")));
		[NullAllowed, Export ("snackbarMessageViewTextColor", ArgumentSemantic.Strong)]
		UIColor SnackbarMessageViewTextColor { get; set; }
	}
}
