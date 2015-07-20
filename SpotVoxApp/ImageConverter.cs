using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Threading.Tasks;
using System.IO;
//using System.Net.Mime.MediaTypeNames;

namespace SpotVoxApp
{
	public static class ImageConverter
	{
		public static byte[] ToNSData(this UIImage image){

			if (image == null) {
				return null;
			}
			NSData data = null;

			try {
				data = image.AsPNG();
				return data.ToArray ();
			} catch (Exception ) {
				return null;
			}
			finally
			{
				if (image != null) {
					image.Dispose ();
					image = null;
				}
				if (data != null) {
					data.Dispose ();
					data = null;
				}
			}
		}

		public static UIImage ToImage(this byte[] data)
		{
			if (data==null) {
				return null;
			}
			UIImage image = null;
			try {

				image = new UIImage(NSData.FromArray(data));
				data = null;
			} catch (Exception ) {
				return null;
			}
			return image;
		}
	}
}
