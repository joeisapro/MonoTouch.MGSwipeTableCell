using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace MonoTouch.MGSwipeTableCell
{
	
	// @interface MGSwipeSettings : NSObject
	[BaseType (typeof(NSObject))]
	interface MGSwipeSettings
	{
		// @property (assign, nonatomic) MGSwipeTransition transition;
		[Export ("transition", ArgumentSemantic.Assign)]
		MGSwipeTransition Transition { get; set; }

		// @property (assign, nonatomic) CGFloat threshold;
		[Export ("threshold", ArgumentSemantic.Assign)]
		nfloat Threshold { get; set; }

		// @property (assign, nonatomic) CGFloat offset;
		[Export ("offset", ArgumentSemantic.Assign)]
		nfloat Offset { get; set; }

		// @property (assign, nonatomic) CGFloat animationDuration;
		[Export ("animationDuration", ArgumentSemantic.Assign)]
		nfloat AnimationDuration { get; set; }
	}

	// @interface MGSwipeExpansionSettings : NSObject
	[BaseType (typeof(NSObject))]
	interface MGSwipeExpansionSettings
	{
		// @property (assign, nonatomic) NSInteger buttonIndex;
		[Export ("buttonIndex", ArgumentSemantic.Assign)]
		nint ButtonIndex { get; set; }

		// @property (assign, nonatomic) BOOL fillOnTrigger;
		[Export ("fillOnTrigger")]
		bool FillOnTrigger { get; set; }

		// @property (assign, nonatomic) CGFloat threshold;
		[Export ("threshold", ArgumentSemantic.Assign)]
		nfloat Threshold { get; set; }

		// @property (nonatomic, strong) UIColor * expansionColor;
		[Export ("expansionColor", ArgumentSemantic.Strong)]
		UIColor ExpansionColor { get; set; }

		// @property (assign, nonatomic) MGSwipeExpansionLayout expansionLayout;
		[Export ("expansionLayout", ArgumentSemantic.Assign)]
		MGSwipeExpansionLayout ExpansionLayout { get; set; }

		// @property (assign, nonatomic) CGFloat animationDuration;
		[Export ("animationDuration", ArgumentSemantic.Assign)]
		nfloat AnimationDuration { get; set; }
	}

	// @protocol MGSwipeTableCellDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MGSwipeTableCellDelegate
	{
		// @optional -(BOOL)swipeTableCell:(MGSwipeTableCell *)cell canSwipe:(MGSwipeDirection)direction;
		[Export ("swipeTableCell:canSwipe:")]
		bool SwipeTableCell (MGSwipeTableCell cell, MGSwipeDirection direction);

		// @optional -(void)swipeTableCell:(MGSwipeTableCell *)cell didChangeSwipeState:(MGSwipeState)state gestureIsActive:(BOOL)gestureIsActive;
		[Export ("swipeTableCell:didChangeSwipeState:gestureIsActive:")]
		void SwipeTableCell (MGSwipeTableCell cell, MGSwipeState state, bool gestureIsActive);

		// @optional -(BOOL)swipeTableCell:(MGSwipeTableCell *)cell tappedButtonAtIndex:(NSInteger)index direction:(MGSwipeDirection)direction fromExpansion:(BOOL)fromExpansion;
		[Export ("swipeTableCell:tappedButtonAtIndex:direction:fromExpansion:")]
		bool SwipeTableCell (MGSwipeTableCell cell, nint index, MGSwipeDirection direction, bool fromExpansion);

		// @optional -(NSArray *)swipeTableCell:(MGSwipeTableCell *)cell swipeButtonsForDirection:(MGSwipeDirection)direction swipeSettings:(MGSwipeSettings *)swipeSettings expansionSettings:(MGSwipeExpansionSettings *)expansionSettings;
		[Export ("swipeTableCell:swipeButtonsForDirection:swipeSettings:expansionSettings:")]
		NSObject[] SwipeTableCell (MGSwipeTableCell cell, MGSwipeDirection direction, MGSwipeSettings swipeSettings, MGSwipeExpansionSettings expansionSettings);
	}

	// @interface MGSwipeTableCell : UITableViewCell
	[BaseType (typeof(UITableViewCell))]
	interface MGSwipeTableCell
	{
		[Wrap ("WeakDelegate")]
		MGSwipeTableCellDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MGSwipeTableCellDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) UIView * swipeContentView;
		[Export ("swipeContentView", ArgumentSemantic.Strong)]
		UIView SwipeContentView { get; }

		// @property (copy, nonatomic) NSArray * leftButtons;
		[Export ("leftButtons", ArgumentSemantic.Copy)]
		NSObject[] LeftButtons { get; set; }

		// @property (copy, nonatomic) NSArray * rightButtons;
		[Export ("rightButtons", ArgumentSemantic.Copy)]
		NSObject[] RightButtons { get; set; }

		// @property (nonatomic, strong) MGSwipeSettings * leftSwipeSettings;
		[Export ("leftSwipeSettings", ArgumentSemantic.Strong)]
		MGSwipeSettings LeftSwipeSettings { get; set; }

		// @property (nonatomic, strong) MGSwipeSettings * rightSwipeSettings;
		[Export ("rightSwipeSettings", ArgumentSemantic.Strong)]
		MGSwipeSettings RightSwipeSettings { get; set; }

		// @property (nonatomic, strong) MGSwipeExpansionSettings * leftExpansion;
		[Export ("leftExpansion", ArgumentSemantic.Strong)]
		MGSwipeExpansionSettings LeftExpansion { get; set; }

		// @property (nonatomic, strong) MGSwipeExpansionSettings * rightExpansion;
		[Export ("rightExpansion", ArgumentSemantic.Strong)]
		MGSwipeExpansionSettings RightExpansion { get; set; }

		// @property (readonly, nonatomic) MGSwipeState swipeState;
		[Export ("swipeState")]
		MGSwipeState SwipeState { get; }

		// @property (readonly, nonatomic) BOOL isSwipeGestureActive;
		[Export ("isSwipeGestureActive")]
		bool IsSwipeGestureActive { get; }

		// @property (nonatomic) BOOL allowsMultipleSwipe;
		[Export ("allowsMultipleSwipe")]
		bool AllowsMultipleSwipe { get; set; }

		// @property (nonatomic) BOOL allowsButtonsWithDifferentWidth;
		[Export ("allowsButtonsWithDifferentWidth")]
		bool AllowsButtonsWithDifferentWidth { get; set; }

		// @property (nonatomic) BOOL allowsSwipeWhenTappingButtons;
		[Export ("allowsSwipeWhenTappingButtons")]
		bool AllowsSwipeWhenTappingButtons { get; set; }

		// @property (nonatomic, strong) UIColor * swipeBackgroundColor;
		[Export ("swipeBackgroundColor", ArgumentSemantic.Strong)]
		UIColor SwipeBackgroundColor { get; set; }

		// @property (assign, nonatomic) CGFloat swipeOffset;
		[Export ("swipeOffset", ArgumentSemantic.Assign)]
		nfloat SwipeOffset { get; set; }

		// -(void)hideSwipeAnimated:(BOOL)animated;
		[Export ("hideSwipeAnimated:")]
		void HideSwipeAnimated (bool animated);

		// -(void)hideSwipeAnimated:(BOOL)animated completion:(void (^)())completion;
		[Export ("hideSwipeAnimated:completion:")]
		void HideSwipeAnimated (bool animated, Action completion);

		// -(void)showSwipe:(MGSwipeDirection)direction animated:(BOOL)animated;
		[Export ("showSwipe:animated:")]
		void ShowSwipe (MGSwipeDirection direction, bool animated);

		// -(void)showSwipe:(MGSwipeDirection)direction animated:(BOOL)animated completion:(void (^)())completion;
		[Export ("showSwipe:animated:completion:")]
		void ShowSwipe (MGSwipeDirection direction, bool animated, Action completion);

		// -(void)setSwipeOffset:(CGFloat)offset animated:(BOOL)animated completion:(void (^)())completion;
		[Export ("setSwipeOffset:animated:completion:")]
		void SetSwipeOffset (nfloat offset, bool animated, Action completion);

		// -(void)expandSwipe:(MGSwipeDirection)direction animated:(BOOL)animated;
		[Export ("expandSwipe:animated:")]
		void ExpandSwipe (MGSwipeDirection direction, bool animated);

		// -(void)refreshContentView;
		[Export ("refreshContentView")]
		void RefreshContentView ();

		// -(void)refreshButtons:(BOOL)usingDelegate;
		[Export ("refreshButtons:")]
		void RefreshButtons (bool usingDelegate);
	}

	// @interface MGSwipeButton : UIButton
	[BaseType (typeof(UIButton))]
	interface MGSwipeButton
	{
		// @property (nonatomic, strong) MGSwipeButtonCallback callback;
		[Export ("callback", ArgumentSemantic.Strong)]
		MGSwipeButtonCallback Callback { get; set; }

		// @property (assign, nonatomic) CGFloat buttonWidth;
		[Export ("buttonWidth", ArgumentSemantic.Assign)]
		nfloat ButtonWidth { get; set; }

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color;
		[Static]
		[Export ("buttonWithTitle:backgroundColor:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color);

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color padding:(NSInteger)padding;
		[Static]
		[Export ("buttonWithTitle:backgroundColor:padding:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color, nint padding);

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color insets:(UIEdgeInsets)insets;
		[Static]
		[Export ("buttonWithTitle:backgroundColor:insets:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color, UIEdgeInsets insets);

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color callback:(MGSwipeButtonCallback)callback;
		[Static]
		[Export ("buttonWithTitle:backgroundColor:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color, MGSwipeButtonCallback callback);

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color padding:(NSInteger)padding callback:(MGSwipeButtonCallback)callback;
		[Static]
		[Export ("buttonWithTitle:backgroundColor:padding:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color, nint padding, MGSwipeButtonCallback callback);

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color insets:(UIEdgeInsets)insets callback:(MGSwipeButtonCallback)callback;
		[Static]
		[Export ("buttonWithTitle:backgroundColor:insets:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color, UIEdgeInsets insets, MGSwipeButtonCallback callback);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color;
		[Static]
		[Export ("buttonWithTitle:icon:backgroundColor:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color padding:(NSInteger)padding;
		[Static]
		[Export ("buttonWithTitle:icon:backgroundColor:padding:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color, nint padding);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color insets:(UIEdgeInsets)insets;
		[Static]
		[Export ("buttonWithTitle:icon:backgroundColor:insets:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color, UIEdgeInsets insets);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color callback:(MGSwipeButtonCallback)callback;
		[Static]
		[Export ("buttonWithTitle:icon:backgroundColor:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color, MGSwipeButtonCallback callback);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color padding:(NSInteger)padding callback:(MGSwipeButtonCallback)callback;
		[Static]
		[Export ("buttonWithTitle:icon:backgroundColor:padding:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color, nint padding, MGSwipeButtonCallback callback);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color insets:(UIEdgeInsets)insets callback:(MGSwipeButtonCallback)callback;
		[Static]
		[Export ("buttonWithTitle:icon:backgroundColor:insets:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color, UIEdgeInsets insets, MGSwipeButtonCallback callback);

		// -(void)setPadding:(CGFloat)padding;
		[Export ("setPadding:")]
		void SetPadding (nfloat padding);

		// -(void)setEdgeInsets:(UIEdgeInsets)insets;
		[Export ("setEdgeInsets:")]
		void SetEdgeInsets (UIEdgeInsets insets);

		// -(void)centerIconOverText;
		[Export ("centerIconOverText")]
		void CenterIconOverText ();
	}

	// typedef BOOL (^MGSwipeButtonCallback)(MGSwipeTableCell *);
	delegate bool MGSwipeButtonCallback (MGSwipeTableCell arg0);
}
