using System;
using UIKit;

namespace SpotVoxApp
{
	public class BaseViewController:UIViewController 
	{
		public BaseViewController (IntPtr handle) : base (handle)
		{
			CurrentUser = new User ();
		}
		public User CurrentUser {
			get;
			set;
		}
	}
}


