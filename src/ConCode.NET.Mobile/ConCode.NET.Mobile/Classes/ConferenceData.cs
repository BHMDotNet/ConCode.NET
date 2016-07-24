using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ConCode.NET.Core.Domain;

namespace ConCode.NET.Mobile
{


	public class ConferenceData
	{
		public List<Session> Sessions { get; private set; }
		HttpClient client;
		string Uri = "http://localhost:5000/api/session";

		public ConferenceData()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public Task<List<Session>> GetSessionsAsync()
		{
			return RefreshDataAsync();
		}

		public async Task<List<Session>> RefreshDataAsync()
		{
			Sessions = new List<Session>();

			try
			{
				var uri = new Uri(string.Format(Uri, string.Empty));

				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					Sessions = JsonConvert.DeserializeObject<List<Session>>(content);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"ERROR {0}", ex.Message);
			}

			return Sessions;
		}
	}

}

