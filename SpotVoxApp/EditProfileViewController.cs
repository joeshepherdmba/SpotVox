using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Threading.Tasks;

namespace SpotVoxApp
{
	partial class EditProfileViewController : BaseViewController
	{
		UIImagePickerController imagePicker;
		UIImage originalImage;

		public EditProfileViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			txtFirstName.Text = CurrentUser.FirstName;
			txtLastName.Text = CurrentUser.LastName;
			txtMobilePhone.Text = CurrentUser.PhoneNumber;
			txtEmail.Text = CurrentUser.Email;
		}

		partial void btnUploadPhoto_TouchUpInside(UIButton sender)
		{
			try{
				imagePicker = new UIImagePickerController ();
				imagePicker.SourceType = UIImagePickerControllerSourceType.SavedPhotosAlbum;
				imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes (UIImagePickerControllerSourceType.SavedPhotosAlbum);
				imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
				imagePicker.Canceled += Handle_Canceled;

				this.PresentViewController(imagePicker, true, null);

			}
			catch(Exception e){
				UIAlertView alert = new UIAlertView (e.Message, "something went wrong", null, "OK", null);
				alert.Show ();
			}
		}

		protected void Handle_FinishedPickingMedia (object sender, UIImagePickerMediaPickedEventArgs e)
		{
			// determine what was selected, video or image
			bool isImage = false;

			if (e.Info [UIImagePickerController.MediaType].ToString () == "public.image") {
				isImage = true;
			}

//			// get common info (shared between images and video)
//			NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
//			if (referenceURL != null)
//				Console.WriteLine("Url:"+referenceURL.ToString ());

			// if it was an image, get the other image info
			if(isImage) {
				// get the original image
				originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
				if(originalImage != null) {
					// do something with the image
					imgProfilePic.Image = originalImage; // display
				}
			} else { // if it's a video
				UIAlertView alert = new UIAlertView ("Invalid Format", "Looks like you selected a video", null, "OK", null);
				alert.Show ();
			}
			// dismiss the picker
			imagePicker.DismissViewController (true, null);
		}

		void Handle_Canceled (object sender, EventArgs e) {
			imagePicker.DismissViewController(true, null);
		}

		async partial void btnSave_TouchUpInside (UIButton sender)
		{
			await SaveProfile();

			var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
			var mainStoryBoard = appDelegate.MainStoryBoard;
			var tabBarController = appDelegate.GetViewController(mainStoryBoard, "MainTabBarController");

			ProfileViewController profileViewController = tabBarController.ChildViewControllers[1] as ProfileViewController;
			profileViewController.CurrentUser = CurrentUser;
			tabBarController.ChildViewControllers [1] = profileViewController;
			tabBarController.ShowViewController (profileViewController,sender);
			appDelegate.SetRootViewController(tabBarController, true); //TODO: Find a better way to notify the user that theur save was successful
		}

		private async Task<User> SaveProfile()
		{
			CurrentUser.FirstName = txtFirstName.Text;
			CurrentUser.LastName = txtLastName.Text;
			CurrentUser.Email = txtEmail.Text;
			CurrentUser.UserName = txtEmail.Text;
			CurrentUser.PhoneNumber = txtMobilePhone.Text;

			if (originalImage != null) {
				byte[] imgArray = ImageConverter.ToNSData (originalImage); 
				CurrentUser.ProfilePicture = System.Convert.ToBase64String(imgArray); //Convert for JSON
			}

			HttpClientFactory client =new HttpClientFactory(CurrentUser.UserAccessToken);
			UserRepository repository = new UserRepository(client);

			User user = await repository.UpdateAsync(CurrentUser);
			user.UserAccessToken = CurrentUser.UserAccessToken;

			if (user != null) {
				return user;
			} else {
				return null;
			}
		}

//		async public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
//		{
//			base.PrepareForSegue (segue, sender);
//
//			//this.CurrentUser = await SaveProfile ();
//
//			var searchViewController = segue.DestinationViewController as SearchViewController;
//			if (searchViewController != null) {
//				searchViewController.CurrentUser = this.CurrentUser;
//			}

//			var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
//			var mainStoryBoard = appDelegate.MainStoryBoard;
//			var tabBarController = appDelegate.GetViewController(mainStoryBoard, "MainTabBarController");
//
//			ProfileViewController profileViewController = tabBarController.ChildViewControllers[1] as ProfileViewController;
//			profileViewController.CurrentUser = CurrentUser;
//			tabBarController.ChildViewControllers [1] = profileViewController;
//			tabBarController.ShowViewController (profileViewController,sender);
//			appDelegate.SetRootViewController(tabBarController, true); //TODO: Find a better way to notify the user that theur save was successful
//		}
	}
}
