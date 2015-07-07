using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using MapKit;
using CoreLocation;

namespace SpotVoxApp
{
	partial class SearchViewController : UIViewController
	{
		MKMapView map;
		public SearchViewController (IntPtr handle) : base (handle)
		{
			CurrentUser = new User ();
		}

		public User CurrentUser {
			get;
			set;
		}
		public override void ViewDidLoad(){
			base.ViewDidLoad ();
			map = new MKMapView(UIScreen.MainScreen.Bounds);
			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();
			map.ShowsUserLocation = true;

			View = map;
		}

	}
}
