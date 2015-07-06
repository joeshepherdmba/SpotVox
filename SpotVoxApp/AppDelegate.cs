using Foundation;
using UIKit;

namespace SpotVoxApp
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		private bool isauthenticated = false;
		public User CurrentUser;

		public override UIWindow Window {
			get;
			set;
		}

		public UIStoryboard MainStoryBoard {
			get{ return UIStoryboard.FromName ("Main", NSBundle.MainBundle); }
		}

		public UIViewController GetViewController(UIStoryboard storyBoard, string viewControllerName){
			return storyBoard.InstantiateViewController (viewControllerName);
		}

		public void SetRootViewController(UIViewController rootViewController, bool animate){
			if(animate){
				var tranistionType = UIViewAnimationOptions.TransitionFlipFromRight;

				Window.RootViewController = rootViewController;
				UIView.Transition (Window, 0.5, tranistionType, 
					() => Window.RootViewController = rootViewController, null);
			}
			else{
				Window.RootViewController = rootViewController;
			}
		}


		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			if (isauthenticated) {
				var tabBarController = GetViewController (MainStoryBoard, "MainTabBarController");
				SetRootViewController (tabBarController, false);
			} else {
				var loginViewController = GetViewController (MainStoryBoard, "LoginViewController") as LoginViewController;
				loginViewController.OnLoginSuccess += LoginViewController_OnLoginSuccess;
				SetRootViewController (loginViewController, false);
			}
			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		void LoginViewController_OnLoginSuccess (object sender, System.EventArgs e)
		{
//			var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
			var mainStoryBoard = MainStoryBoard;
			var tabBarController = GetViewController(mainStoryBoard, "MainTabBarController");
			ProfileViewController profileViewController = tabBarController.ChildViewControllers[1] as ProfileViewController;
			profileViewController.CurrentUser = CurrentUser;
			tabBarController.ChildViewControllers [1] = profileViewController;
			SetRootViewController(tabBarController, true);

//			var tabBarController = GetViewController (MainStoryBoard, "MainTabBarController");
//			SetRootViewController (tabBarController, true);
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}


