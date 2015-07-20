using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SpotVoxApp
{
	partial class ProfileViewController : BaseViewController
	{
		public ProfileViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.lblFullName.Text = CurrentUser.FullName;
			this.lblMemberSince.Text = CurrentUser.DateJoined.ToShortDateString ();
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			var editProfileViewController = segue.DestinationViewController as EditProfileViewController;
			if (editProfileViewController != null) {
				editProfileViewController.CurrentUser = this.CurrentUser;
			}
		}

	}
}
