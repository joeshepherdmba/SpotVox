// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SpotVoxApp
{
	[Register ("EditProfileViewController")]
	partial class EditProfileViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSave { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtEmail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtFirstName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtLastName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtMobilePhone { get; set; }

		[Action ("btnSave_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnSave_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnSave != null) {
				btnSave.Dispose ();
				btnSave = null;
			}
			if (txtEmail != null) {
				txtEmail.Dispose ();
				txtEmail = null;
			}
			if (txtFirstName != null) {
				txtFirstName.Dispose ();
				txtFirstName = null;
			}
			if (txtLastName != null) {
				txtLastName.Dispose ();
				txtLastName = null;
			}
			if (txtMobilePhone != null) {
				txtMobilePhone.Dispose ();
				txtMobilePhone = null;
			}
		}
	}
}
