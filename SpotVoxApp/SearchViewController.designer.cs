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
	[Register ("SearchViewController")]
	partial class SearchViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITabBarItem tbNearby { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (tbNearby != null) {
				tbNearby.Dispose ();
				tbNearby = null;
			}
		}
	}
}
