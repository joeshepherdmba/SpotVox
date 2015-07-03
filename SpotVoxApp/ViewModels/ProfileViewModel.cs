using System;

namespace SpotVoxApp
{
	public class ProfileViewModel
	{
		public ProfileViewModel ()
		{}
		public string FullName {
			get;
			set;
		}
		public byte[] Photo {
			get;
			set;
		}
		public DateTime DateJoined {
			get;
			set;
		}
		public int NumberOfBusinessesReferred {
			get;
			set;
		}
		public string City {
			get;
			set;
		}
		public string State {
			get;
			set;
		}

	}
}

