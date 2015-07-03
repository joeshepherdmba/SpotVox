using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SpotVoxApp
{
	public class HttpClientFactory
	{
		private HttpClient client;
		string BASE_ADDRESS = "http://spotvox.azurewebsites.net/";

		public HttpClientFactory ()
		{
			CreateHttpClient(BASE_ADDRESS);
		}

		public HttpClientFactory(TokenModel tokenModel)
		{
			CreateHttpClient (BASE_ADDRESS);
			CreateSecureHttpClient (tokenModel);
		}

		public HttpClient CreateHttpClient()
		{
			return client;
		}

		private void CreateHttpClient(string baseAddress)
		{
			client = new HttpClient ();
			client.BaseAddress = new Uri(baseAddress);
			client.DefaultRequestHeaders.Clear ();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		private void CreateSecureHttpClient(TokenModel tokenModel)
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Bearer", tokenModel.AccessToken);
		}
	}
}

