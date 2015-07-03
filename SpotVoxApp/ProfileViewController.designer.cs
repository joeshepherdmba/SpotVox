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
		UILabel lblCity { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblFullName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITabBarItem tbProfile { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblCity != null) {
				lblCity.Dispose ();
				lblCity = null;
			}
			if (lblFullName != null) {
				lblFullName.Dispose ();
				lblFullName = null;
			}
			if (tbProfile != null) {
				tbProfile.Dispose ();
				tbProfile = null;
			}
		}
	}
}
