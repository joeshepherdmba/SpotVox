using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SpotVoxApp
{
	partial class EditProfileViewController : UIViewController
	{
		public EditProfileViewController (IntPtr handle) : base (handle)
		{
			CurrentUser = new User ();
		}

		public User CurrentUser {
			get;
			set;
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			txtFirstName.Text = CurrentUser.FirstName;
			txtLastName.Text = CurrentUser.LastName;
			txtMobilePhone.Text = CurrentUser.PhoneNumber;
			txtEmail.Text = CurrentUser.Email;
		}

		async partial void btnSave_TouchUpInside(UIButton sender)
		{
			CurrentUser.FirstName = txtFirstName.Text;
			CurrentUser.LastName = txtLastName.Text;
			CurrentUser.Email = txtEmail.Text;
			CurrentUser.UserName = txtEmail.Text;
			CurrentUser.PhoneNumber = txtMobilePhone.Text;

			HttpClientFactory client =new HttpClientFactory(CurrentUser.UserAccessToken);
			UserRepository repository = new UserRepository(client);

			User user = await repository.UpdateAsync(CurrentUser);

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
	}
}
