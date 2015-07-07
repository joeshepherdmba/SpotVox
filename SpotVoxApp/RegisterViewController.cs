using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SpotVoxApp
{
	partial class RegisterViewController : UIViewController
	{
//		public event EventHandler OnRegisterSuccess;

		public RegisterViewController (IntPtr handle) : base (handle)
		{
			RegisterViewModel = new RegisterViewModel ();
		}

		public RegisterViewModel RegisterViewModel {
			get;
			set;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			txtEmail.Text = RegisterViewModel.Email;
			txtPassword.Text = RegisterViewModel.Password;

//			this.txtConfirm.ShouldReturn = delegate {
//				txtConfirm.ResignFirstResponder ();
//				return true;
//			};

			var g = new UITapGestureRecognizer (() => View.EndEditing (true));
			View.AddGestureRecognizer (g);
		}

		async partial void btnCreateAccount_TouchUpInside (UIButton sender){
			HttpClientFactory factory = new HttpClientFactory();
			UserRepository repository = new UserRepository(factory);

			RegisterViewModel.Email = txtEmail.Text;
			RegisterViewModel.Password = txtPassword.Text;
			RegisterViewModel.ConfirmPassword = txtConfirm.Text;

			if(RegisterViewModel.Password == RegisterViewModel.ConfirmPassword){
				User user = await repository.RegisterAsync(RegisterViewModel);

				if(user != null)
				{
					var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
					var mainStoryBoard = appDelegate.MainStoryBoard;
					var tabBarController = appDelegate.GetViewController(mainStoryBoard, "MainTabBarController");
					ProfileViewController profileViewController = tabBarController.ChildViewControllers[1] as ProfileViewController;
					profileViewController.CurrentUser = user;

					appDelegate.SetRootViewController(profileViewController, true);
				}
				else{
					new UIAlertView("Registration Error", "Please try again", null, "OK", null);
				}

			}
			else{
				
			}
		}
	}
}
