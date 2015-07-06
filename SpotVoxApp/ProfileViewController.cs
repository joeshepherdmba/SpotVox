using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SpotVoxApp
{
	partial class ProfileViewController : UIViewController
	{
		public ProfileViewController (IntPtr handle) : base (handle)
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
			lblFullName.Text = CurrentUser.FullName;
			lblCity.Text = CurrentUser.City;
		}
	}
}
