using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ConCode.NET.Domain;

namespace ConCode.NET.Mobile
{
	public class ConferenceData
	{
		HttpClient client;
		string Uri = "http://dev-concodenet.azurewebsites.net/api/";

		public ConferenceData()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<List<SpeakerListModel>> GetSpeakersAsync()
		{
			var Speakers = new List<SpeakerListModel>();

			try
			{
				var uri = new Uri(string.Format(Uri, string.Empty));

				var response = await client.GetAsync(uri + "/speaker");
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var tempSpeakers = JsonConvert.DeserializeObject<List<SpeakerInfo>>(content);

					foreach (var speaker in tempSpeakers)
					{
						Speakers.Add(new SpeakerListModel
						{
							Id = speaker.Id,
							FirstName = speaker.User.FirstName,
							LastName = speaker.User.LastName,
							TagLine = speaker.Tagline,
							Bio = speaker.User.Bio,
							Photo = speaker.User.Photo

						});
					}

					response.Dispose();
					content = null;
					tempSpeakers = null;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"ERROR {0}", ex.Message);
			}
			finally
			{
				client.Dispose();

			}

			return Speakers;
		}

		public async Task<List<SessionListModel>> GetSessionsAsync()
		{
			var Sessions = new List<SessionListModel>();

			try
			{
				var uri = new Uri(string.Format(Uri, string.Empty));

				var response = await client.GetAsync(uri + "/session");
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

