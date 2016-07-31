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

		public async Task<ConferenceInfoModel> GetConferenceInfoAsync()
		{
			var ConferenceInformation = new ConferenceInfoModel();

			try
			{
				var uri = new Uri(string.Format(Uri, string.Empty));

				var response = await client.GetAsync(uri + "/conference");
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var tempConferenceInfo = JsonConvert.DeserializeObject<ConferenceInfo>(content);

					ConferenceInformation = new ConferenceInfoModel
					{
						Name = tempConferenceInfo.Name,
						Description = tempConferenceInfo.Description,
						Dates = "1/1/2017",
						Location = tempConferenceInfo.Location

					};

					response.Dispose();
					content = null;
					tempConferenceInfo = null;
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

			return ConferenceInformation;
		}

		public async Task<List<SpeakerListModel>> GetSpeakersAsync()
		{
			var SpeakerList = new List<SpeakerListModel>();

			try
			{
				var uri = new Uri(string.Format(Uri, string.Empty));

				var response = await client.GetAsync(uri + "/speaker");
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var tempSpeakers = JsonConvert.DeserializeObject<List<User>>(content);

					foreach (var speaker in tempSpeakers)
					{
						SpeakerList.Add(new SpeakerListModel
						{
							Id = speaker.Id,
							FullName = speaker.FirstName + " " + speaker.LastName,
							TagLine = speaker.SpeakerInfo.Tagline,
							Bio = speaker.Bio,
							Photo = speaker.Photo

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

			return SpeakerList;
		}

		public async Task<List<SessionListModel>> GetSessionsAsync()
		{
			var SessionList = new List<SessionListModel>();

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
						SessionList.Add(new SessionListModel
						{
							Id = session.Id,
							Title = session.Talk.Title,
							DateTime = session.Start.ToString("hh:MM"),
							Level = session.Talk.Level.ToString(),
							Length = session.TalkType.Length.TotalMinutes.ToString(),
							Venue = session.Venue.Description,
							Status = session.Status,
							Tags = session.Talk.Tags,
							Abstract = session.Talk.Abstract
						});
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"ERROR {0}", ex.Message);
			}

			return SessionList;
		}

	}

}

