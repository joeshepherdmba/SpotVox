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
	[Register ("ProfileViewController")]
	partial class ProfileViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnEditProfile { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblFullName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblMemberSince { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblReferralsSent { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnEditProfile != null) {
				btnEditProfile.Dispose ();
				btnEditProfile = null;
			}
			if (lblFullName != null) {
				lblFullName.Dispose ();
				lblFullName = null;
			}
			if (lblMemberSince != null) {
				lblMemberSince.Dispose ();
				lblMemberSince = null;
			}
			if (lblReferralsSent != null) {
				lblReferralsSent.Dispose ();
				lblReferralsSent = null;
			}
		}
	}
}
