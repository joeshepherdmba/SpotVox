using System;
using CoreLocation;

namespace SpotVoxApp
{
	public class Business
	{
		public Business ()
		{
		}
		public int BusinessID {
			get;
			set;
		}
		public string BusinessName {
			get;
			set;
		}
		public string Description {
			get;
			set;
		}
		public string Address {
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
		public string FullAddress {
			get;
			set;
		}
		public string Email {
			get;
			set;
		}
		public string Website {
			get;
			set;
		}
		public bool IsActive {
			get;
			set;
		}
		public int SubscriptionPlanId {
			get;
			set;
		}
		public string SubscriptionPlan {
			get;
			set;
		}
		public double SubscriptionPlanCost {
			get;
			set;
		}
		public int BusinessCategoryId {
			get;
			set;
		}
		public string BusinessCategory {
			get;
			set;
		}
		public string BusinessOwnerId {
			get;
			set;
		}
		public double Longitude {
			get;
			set;
		}
		public double Latitude {
			get;
			set;
		}
		public string Coordinates {
			get;
			set;
		}
	}
}

