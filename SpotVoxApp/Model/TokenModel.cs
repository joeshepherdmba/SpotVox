using System;
using Newtonsoft.Json;

namespace SpotVoxApp
{
	public class TokenModel
	{
		public TokenModel ()
		{
		}
		[JsonProperty("access_token")]
		public string AccessToken {
			get;
			set;
		}
		[JsonProperty("token_type")]
		public string TokenType {
			get;
			set;
		}
		[JsonProperty("expires_in")]
		public int ExpiresIn {
			get;
			set;
		}
		[JsonProperty("userName")]
		public string UserName {
			get;
			set;
		}
		[JsonProperty("issued_at")]
		public string IssuedAt {
			get;
			set;
		}
		[JsonProperty("expires_at")]
		public string ExpiresAt {
			get;
			set;
		}
	}
}

