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
		public List<SessionListModel> Sessions { get; private set; }
		HttpClient client;
		string Uri = "http://dev-concodenet.azurewebsites.net/api/session";

		public ConferenceData()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public Task<List<SessionListModel>> GetSessionsAsync()
		{
			return RefreshDataAsync();
		}

		public async Task<List<SessionListModel>> RefreshDataAsync()
		{
			Sessions = new List<SessionListModel>();

			try
			{
				var uri = new Uri(string.Format(Uri, string.Empty));

				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var tempSessions = JsonConvert.DeserializeObject<List<Session>>(content);

					foreach (var session in tempSessions)
					{
						Sessions.Add(new SessionListModel
						{
							Id = session.Id,
							Title = session.Talk.Title,
							DateTime = session.Start.ToString("hh:MM"),
							Level = session.Talk.Level.ToString(),
							Length = session.TalkType.Length.TotalMinutes.ToString(),
							Venue = session.Venue.Description,
			               	Status = session.Status,
							Tags = session.Talk.Tags
						});
					}
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

