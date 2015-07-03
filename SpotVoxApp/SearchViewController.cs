using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SpotVoxApp
{
	partial class SearchViewController : UIViewController
	{
		public SearchViewController (IntPtr handle) : base (handle)
		{
			CurrentUser = new User ();
		}

		public User CurrentUser {
			get;
			set;
		}
	}
}
