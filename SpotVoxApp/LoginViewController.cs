using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Threading.Tasks;
using System.Net.Http;

namespace SpotVoxApp
{
	partial class LoginViewController : UIViewController
	{
		//string BASE_ADDRESS = "http://spotvox.azurewebsites.net/";

		public event EventHandler OnLoginSuccess;

		public LoginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		partial void btnRegister_TouchUpInside (UIButton sender)
		{
			var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
			var mainStoryBoard = appDelegate.MainStoryBoard;

			RegisterViewController registerController = appDelegate.GetViewController(mainStoryBoard, "RegisterViewController") as RegisterViewController;

//			RegisterViewController controller = this.Storyboard.InstantiateViewController("RegisterViewController") as RegisterViewController;
			RegisterViewModel registerModel = new RegisterViewModel();
			registerModel.Email = txtEmail.Text;
			registerModel.Password = txtPassword.Text;
//			controller.RegisterViewModel = registerModel;

			registerController.RegisterViewModel = registerModel;
			appDelegate.SetRootViewController(registerController, true);

		}

		async partial void btnLogin_TouchUpInside (UIButton sender)
		{
			//Create a variable to store the User Access Token for future requests
			User user = await Login();

			if(user != null)
			{
				if(OnLoginSuccess != null)
				{
					var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
					appDelegate.CurrentUser = user;
					OnLoginSuccess(sender, new EventArgs());
				}
				else{
					new UIAlertView("Login Error", "Bad UserName or Password", null, "OK", null);
				}
			}
			//Pass UserModel to next page with Access Token
//			ProfileViewController controller = this.Storyboard.InstantiateViewController("ProfileViewController") as ProfileViewController;
//			controller.CurrentUser = user;
//
//			this.NavigationController.PushViewController(controller, true);
		}
		private async Task<User> Login()
		{
			HttpClientFactory factory = new HttpClientFactory();
			UserRepository repository = new UserRepository(factory);

			LoginViewModel loginModel = new LoginViewModel();
			loginModel.Email = txtEmail.Text;
			loginModel.Password = txtPassword.Text;


			return await repository.LoginAsync(loginModel);
			//string token = response.Result;
		}
	}
}
