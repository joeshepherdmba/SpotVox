using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace SpotVoxApp
{
	public class UserRepository:IUserRepository
	{
		private HttpClientFactory clientFactory;
		private HttpClient client;
		private TokenModel tokenResponse;

		public UserRepository (HttpClientFactory httpClientFactory)
		{
			clientFactory = httpClientFactory;
		}


		#region IUserRepository implementation
		/// <summary>
		/// Logins the async.
		/// </summary>
		/// <returns>String</returns>
		/// <param name="loginViewModel">Login view model.</param>
		public async Task<User> LoginAsync (LoginViewModel loginViewModel)
		{
			client = clientFactory.CreateHttpClient ();

			HttpContent requestBody = new StringContent (string.Format ("grant_type=password&username={0}&password={1}", loginViewModel.Email, loginViewModel.Password));

			HttpResponseMessage response = await client.PostAsync("Token", requestBody);
			if (response.IsSuccessStatusCode) {
				string jsonMessage;
				using (Stream responseStream = await response.Content.ReadAsStreamAsync ()) {
					jsonMessage = new StreamReader (responseStream).ReadToEnd ();
				}

				tokenResponse = (TokenModel)JsonConvert.DeserializeObject (jsonMessage, typeof(TokenModel));
				User user = new User ();
				user = await GetUserByUserName(loginViewModel.Email);
				user.UserAccessToken = tokenResponse;
				return user;
			} else {
				return null;
			}
		}

		public async Task<User> RegisterAsync (RegisterViewModel registerViewModel)
		{
//			client = clientFactory.CreateHttpClient ();

			HttpClient client = new HttpClient ();
			client.BaseAddress = new Uri("http://spotvox.azurewebsites.net/");
			client.DefaultRequestHeaders.Clear ();
			client.DefaultRequestHeaders.Accept.Clear ();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			using (client) {
				
				string userJson = JsonConvert.SerializeObject (registerViewModel);
				HttpContent content = new StringContent (userJson, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.PostAsync ("api/account/register", content);

				if (response.IsSuccessStatusCode) {
					string jsonMessage;
					using (Stream responseStream = await response.Content.ReadAsStreamAsync ()) {
						jsonMessage = new StreamReader (responseStream).ReadToEnd ();
					}

					User user = (User)JsonConvert.DeserializeObject (jsonMessage, typeof(User));

					LoginViewModel loginModel = new LoginViewModel ();
					loginModel.Email = user.Email;
					loginModel.Password = registerViewModel.Password;

					user = await LoginAsync(loginModel);
					return user;
				} else {
					return null;
				}
			}
		}

		public async Task<User> UpdateAsync (User user)
		{
			//Does not work. There is a security stamp field in the database that gets out of sync when using the UsersRepository to make these updates. Look at UserManager instead
			HttpClientFactory factory = new HttpClientFactory(user.UserAccessToken);
			client = factory.CreateHttpClient ();

			string userJson = JsonConvert.SerializeObject (user);
			HttpContent content = new StringContent (userJson, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PutAsync (string.Format("api/users/{0}/", user.Email), content);

			if (response.IsSuccessStatusCode) {
				string jsonMessage;
				using (Stream responseStream = await response.Content.ReadAsStreamAsync ()) {
					jsonMessage = new StreamReader (responseStream).ReadToEnd ();
				}

				user = (User)JsonConvert.DeserializeObject (jsonMessage, typeof(User));
				return user;
			} else {
				return null;
			}

		}

		public async Task<User> GetUserByUserName (string userName)
		{
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue ("Bearer", tokenResponse.AccessToken);
			HttpResponseMessage response = await client.GetAsync (string.Format("api/users/{0}/", userName));

			if (response.IsSuccessStatusCode) {
				User user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
				return user;
			}
			else{
				return null;
			}
		}
		#endregion
	}
}
