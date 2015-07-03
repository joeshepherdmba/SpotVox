using System;

namespace SpotVoxApp
{
	public class User
	{
		public User ()
		{
		}
		public string Id {
			get;
			set;
		}
		public string UserName {
			get;
			set;
		}
		public string FirstName {
			get;
			set;
		}
		public string LastName {
			get;
			set;
		}
		public string Email {
			get;
			set;
		}
		public string PhoneNumber {
			get;
			set;
		}
		public bool EmailConfirmed {
			get;
			set;
		}
		public bool PhoneNumberConfirmed {
			get;
			set;
		}
		public string Address {
			get;
			set;
		}
		public string Address2 {
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
		public string Zipcode {
			get;
			set;
		}
		public string Passwordhash {
			get;
			set;
		}
		public TokenModel UserAccessToken  {
			get;
			set;
		}
	}
}

