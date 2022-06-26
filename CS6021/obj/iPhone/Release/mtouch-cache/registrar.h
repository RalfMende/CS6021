#pragma clang diagnostic ignored "-Wdeprecated-declarations"
#pragma clang diagnostic ignored "-Wtypedef-redefinition"
#pragma clang diagnostic ignored "-Wobjc-designated-initializers"
#pragma clang diagnostic ignored "-Wunguarded-availability-new"
#include <stdarg.h>
#include <objc/objc.h>
#include <objc/runtime.h>
#include <objc/message.h>
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <CoreGraphics/CoreGraphics.h>

@class SceneDelegate;
@class AppDelegate;
@class ViewCtrl_CentralUnit;
@class UITableViewSource;
@class CS6021_TableSource;
@class ViewCtrl_Keyboard;
@class ViewCtrl_Memory;
@class CS6021_UISliderCustom;
@class Foundation_NSDispatcher;
@class __MonoMac_NSSynchronizationContextDispatcher;
@class Foundation_NSAsyncDispatcher;
@class __MonoMac_NSAsyncActionDispatcher;
@class __MonoMac_NSAsyncSynchronizationContextDispatcher;
@class __NSObject_Disposer;
@class __UIGestureRecognizerToken;
@class __UILongPressGestureRecognizer;
@class UIKit_UIScrollView__UIScrollViewDelegate;

@interface SceneDelegate : UIResponder<UIWindowSceneDelegate> {
}
	@property (nonatomic, assign) UIWindow * window;
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIWindow *) window;
	-(void) setWindow:(UIWindow *)p0;
	-(void) scene:(UIScene *)p0 willConnectToSession:(UISceneSession *)p1 options:(UISceneConnectionOptions *)p2;
	-(void) sceneDidDisconnect:(UIScene *)p0;
	-(void) sceneDidBecomeActive:(UIScene *)p0;
	-(void) sceneWillResignActive:(UIScene *)p0;
	-(void) sceneWillEnterForeground:(UIScene *)p0;
	-(void) sceneDidEnterBackground:(UIScene *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface AppDelegate : UIResponder<UIApplicationDelegate> {
}
	@property (nonatomic, assign) UIWindow * window;
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIWindow *) window;
	-(void) setWindow:(UIWindow *)p0;
	-(BOOL) application:(UIApplication *)p0 didFinishLaunchingWithOptions:(NSDictionary *)p1;
	-(UISceneConfiguration *) application:(UIApplication *)p0 configurationForConnectingSceneSession:(UISceneSession *)p1 options:(UISceneConnectionOptions *)p2;
	-(void) application:(UIApplication *)p0 didDiscardSceneSessions:(NSSet <UISceneSession *>*)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface ViewCtrl_CentralUnit : UIViewController {
}
	@property (nonatomic, assign) UIButton * btn_direction;
	@property (nonatomic, assign) UIButton * btn_direction2;
	@property (nonatomic, assign) UIButton * btn_protocol;
	@property (nonatomic, assign) UIImageView * knob_Img;
	@property (nonatomic, assign) UILabel * lbl_address;
	@property (nonatomic, assign) UIImageView * led_f1_img;
	@property (nonatomic, assign) UIImageView * led_f2_img;
	@property (nonatomic, assign) UIImageView * led_f3_img;
	@property (nonatomic, assign) UIImageView * led_f4_img;
	@property (nonatomic, assign) UIImageView * led_function_img;
	@property (nonatomic, assign) UIImageView * led_Img;
	@property (nonatomic, assign) UISlider * sld_speed;
	@property (nonatomic, assign) UITableView * tablVw_locomotives;
	@property (nonatomic, assign) UITextField * txt_ipAddress;
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIButton *) btn_direction;
	-(void) setBtn_direction:(UIButton *)p0;
	-(UIButton *) btn_direction2;
	-(void) setBtn_direction2:(UIButton *)p0;
	-(UIButton *) btn_protocol;
	-(void) setBtn_protocol:(UIButton *)p0;
	-(UIImageView *) knob_Img;
	-(void) setKnob_Img:(UIImageView *)p0;
	-(UILabel *) lbl_address;
	-(void) setLbl_address:(UILabel *)p0;
	-(UIImageView *) led_f1_img;
	-(void) setLed_f1_img:(UIImageView *)p0;
	-(UIImageView *) led_f2_img;
	-(void) setLed_f2_img:(UIImageView *)p0;
	-(UIImageView *) led_f3_img;
	-(void) setLed_f3_img:(UIImageView *)p0;
	-(UIImageView *) led_f4_img;
	-(void) setLed_f4_img:(UIImageView *)p0;
	-(UIImageView *) led_function_img;
	-(void) setLed_function_img:(UIImageView *)p0;
	-(UIImageView *) led_Img;
	-(void) setLed_Img:(UIImageView *)p0;
	-(UISlider *) sld_speed;
	-(void) setSld_speed:(UISlider *)p0;
	-(UITableView *) tablVw_locomotives;
	-(void) setTablVw_locomotives:(UITableView *)p0;
	-(UITextField *) txt_ipAddress;
	-(void) setTxt_ipAddress:(UITextField *)p0;
	-(void) viewDidLoad;
	-(void) didReceiveMemoryWarning;
	-(void) btn_0_pressed:(UIButton *)p0;
	-(void) btn_1_pressed:(UIButton *)p0;
	-(void) btn_2_pressed:(UIButton *)p0;
	-(void) btn_3_pressed:(UIButton *)p0;
	-(void) btn_4_pressed:(UIButton *)p0;
	-(void) btn_5_pressed:(UIButton *)p0;
	-(void) btn_6_pressed:(UIButton *)p0;
	-(void) btn_7_pressed:(UIButton *)p0;
	-(void) btn_8_pressed:(UIButton *)p0;
	-(void) btn_9_pressed:(UIButton *)p0;
	-(void) btn_connect_pressed:(UIButton *)p0;
	-(void) btn_direction_pressed:(UIButton *)p0;
	-(void) btn_F_pressed:(UIButton *)p0;
	-(void) btn_f1_pressed:(UIButton *)p0;
	-(void) btn_f2_pressed:(UIButton *)p0;
	-(void) btn_f3_pressed:(UIButton *)p0;
	-(void) btn_f4_pressed:(UIButton *)p0;
	-(void) btn_function_pressed:(UIButton *)p0;
	-(void) btn_go_pressed:(UIButton *)p0;
	-(void) btn_L_pressed:(UIButton *)p0;
	-(void) btn_off_pressed:(UIButton *)p0;
	-(void) btn_protocol_pressed:(UIButton *)p0;
	-(void) btn_stop_pressed:(UIButton *)p0;
	-(void) sld_speed_value_changed:(UISlider *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface UITableViewSource : NSObject<UIScrollViewDelegate, UIScrollViewDelegate> {
}
	-(id) init;
@end

@interface CS6021_TableSource : NSObject<UIScrollViewDelegate, UIScrollViewDelegate, UIScrollViewDelegate> {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(NSInteger) tableView:(UITableView *)p0 numberOfRowsInSection:(NSInteger)p1;
	-(void) tableView:(UITableView *)p0 didSelectRowAtIndexPath:(NSIndexPath *)p1;
	-(UITableViewCell *) tableView:(UITableView *)p0 cellForRowAtIndexPath:(NSIndexPath *)p1;
	-(void) tableView:(UITableView *)p0 commitEditingStyle:(NSInteger)p1 forRowAtIndexPath:(NSIndexPath *)p2;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ViewCtrl_Keyboard : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) viewDidLoad;
	-(void) btn_1_green_pressed:(UIButton *)p0;
	-(void) btn_1_red_pressed:(UIButton *)p0;
	-(void) btn_10_green_pressed:(UIButton *)p0;
	-(void) btn_10_red_pressed:(UIButton *)p0;
	-(void) btn_11_green_pressed:(UIButton *)p0;
	-(void) btn_11_red_pressed:(UIButton *)p0;
	-(void) btn_12_green_pressed:(UIButton *)p0;
	-(void) btn_12_red_pressed:(UIButton *)p0;
	-(void) btn_13_green_pressed:(UIButton *)p0;
	-(void) btn_13_red_pressed:(UIButton *)p0;
	-(void) btn_14_green_pressed:(UIButton *)p0;
	-(void) btn_14_red_pressed:(UIButton *)p0;
	-(void) btn_15_green_pressed:(UIButton *)p0;
	-(void) btn_15_red_pressed:(UIButton *)p0;
	-(void) btn_16_green_pressed:(UIButton *)p0;
	-(void) btn_16_red_pressed:(UIButton *)p0;
	-(void) btn_2_green_pressed:(UIButton *)p0;
	-(void) btn_2_red_pressed:(UIButton *)p0;
	-(void) btn_3_green_pressed:(UIButton *)p0;
	-(void) btn_3_red_pressed:(UIButton *)p0;
	-(void) btn_4_green_pressed:(UIButton *)p0;
	-(void) btn_4_red_pressed:(UIButton *)p0;
	-(void) btn_5_green_pressed:(UIButton *)p0;
	-(void) btn_5_red_pressed:(UIButton *)p0;
	-(void) btn_6_green_pressed:(UIButton *)p0;
	-(void) btn_6_red_pressed:(UIButton *)p0;
	-(void) btn_7_green_pressed:(UIButton *)p0;
	-(void) btn_7_red_pressed:(UIButton *)p0;
	-(void) btn_8_green_pressed:(UIButton *)p0;
	-(void) btn_8_red_pressed:(UIButton *)p0;
	-(void) btn_9_green_pressed:(UIButton *)p0;
	-(void) btn_9_red_pressed:(UIButton *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface ViewCtrl_Memory : UIViewController {
}
	@property (nonatomic, assign) UIImageView * led_clear_img;
	@property (nonatomic, assign) UIImageView * led_end_img;
	@property (nonatomic, assign) UIImageView * led_extern_img;
	@property (nonatomic, assign) UIImageView * led_input_img;
	@property (nonatomic, assign) UIImageView * led_off_img;
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(UIImageView *) led_clear_img;
	-(void) setLed_clear_img:(UIImageView *)p0;
	-(UIImageView *) led_end_img;
	-(void) setLed_end_img:(UIImageView *)p0;
	-(UIImageView *) led_extern_img;
	-(void) setLed_extern_img:(UIImageView *)p0;
	-(UIImageView *) led_input_img;
	-(void) setLed_input_img:(UIImageView *)p0;
	-(UIImageView *) led_off_img;
	-(void) setLed_off_img:(UIImageView *)p0;
	-(void) viewDidLoad;
	-(void) btn_A1_pressed:(UIButton *)p0;
	-(void) btn_A2_pressed:(UIButton *)p0;
	-(void) btn_A3_pressed:(UIButton *)p0;
	-(void) btn_A4_pressed:(UIButton *)p0;
	-(void) btn_A5_pressed:(UIButton *)p0;
	-(void) btn_A6_pressed:(UIButton *)p0;
	-(void) btn_A7_pressed:(UIButton *)p0;
	-(void) btn_A8_pressed:(UIButton *)p0;
	-(void) btn_B1_pressed:(UIButton *)p0;
	-(void) btn_B2_pressed:(UIButton *)p0;
	-(void) btn_B3_pressed:(UIButton *)p0;
	-(void) btn_B4_pressed:(UIButton *)p0;
	-(void) btn_B5_pressed:(UIButton *)p0;
	-(void) btn_B6_pressed:(UIButton *)p0;
	-(void) btn_B7_pressed:(UIButton *)p0;
	-(void) btn_B8_pressed:(UIButton *)p0;
	-(void) btn_C1_pressed:(UIButton *)p0;
	-(void) btn_C2_pressed:(UIButton *)p0;
	-(void) btn_C3_pressed:(UIButton *)p0;
	-(void) btn_C4_pressed:(UIButton *)p0;
	-(void) btn_C5_pressed:(UIButton *)p0;
	-(void) btn_C6_pressed:(UIButton *)p0;
	-(void) btn_C7_pressed:(UIButton *)p0;
	-(void) btn_C8_pressed:(UIButton *)p0;
	-(void) btn_clear_pressed:(UIButton *)p0;
	-(void) btn_end_pressed:(UIButton *)p0;
	-(void) btn_extern_pressed:(UIButton *)p0;
	-(void) btn_input_pressed:(UIButton *)p0;
	-(void) btn_off_pressed:(UIButton *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface CS6021_UISliderCustom : UISlider {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(void) awakeFromNib;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface __UIGestureRecognizerToken : NSObject {
}
	-(void) release;
	-(id) retain;
	-(GCHandle) xamarinGetGCHandle;
	-(bool) xamarinSetGCHandle: (GCHandle) gchandle flags: (enum XamarinGCHandleFlags) flags;
	-(enum XamarinGCHandleFlags) xamarinGetFlags;
	-(void) xamarinSetFlags: (enum XamarinGCHandleFlags) flags;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end


