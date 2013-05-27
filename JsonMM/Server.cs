using System;
using SimpleWebServer;
using System.Net;
using System.Collections.Specialized;
using SongsDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonMM
{
	class Server
	{
		SDBApplication SDB;
		bool SDB_initialized = false;
		int port = 8080;


		public void launchServer()
		{
			WebServer ws = new WebServer(handleRequest, "http://*:" + Convert.ToString(this.port) + "/");
			ws.Run();
			Console.WriteLine("Press a key to quit.");
			Console.ReadKey();
			ws.Stop();
		}
		private void checkSDB()
		{
			if (!this.SDB_initialized)
			{
				this.SDB = new SDBApplication();
				this.SDB.ShutdownAfterDisconnect = false;
				this.SDB_initialized = true;
			}
		}
		public string handleRequest(HttpListenerRequest request)
		{
			this.checkSDB();

			JObject retour = new JObject();
			int status = 0;
			if (!this.SDB.IsRunning)
			{
				status = 10;
				retour.Add("error", "Media Monkey is not running (or is starting)");
			}
			else
			{
				string[] segments = request.Url.Segments;
				for (var i = segments.Length - 1; i > 0; i--)
				{
					if (segments[i].EndsWith("/"))
					{
						segments[i] = segments[i].Remove(segments[i].Length - 1);
					}
				}
				try
				{
					switch (segments[1])
					{
						case "application":
						case "Application":
							switch (segments[2])
							{
								case "isRunning":
									retour.Add("result", this.application_isRunning());
									break;
								/*case "isPartyMode":
									retour.Add("result", this.application_isPartyMode());
									break;*/
								default:
									status = 1;
									retour.Add("error", "Unknown method");
									break;
							}
							break;
						case "player":
						case "Player":
							switch (segments[2])
							{
								case "getInfos":
									retour.Add("result", this.player_getInfos());
									break;
								case "getCurrentSong":
									retour.Add("result", this.player_getCurrentSong(request.QueryString));
									break;
								default:
									status = 1;
									retour.Add("error", "Unknown method");
									break;
							}
							break;
						default:
							status = 1;
							retour.Add("error", "Unknown method");
							break;
					}
				}
				catch (Exception e)
				{
					retour.Add("error", "Exception thrown");
					var exception = new JObject();
					exception.Add("Message", e.Message);
					exception.Add("Source", e.Source);
					exception.Add("StackTrace", e.StackTrace);
					retour.Add("Exception", exception);
					status = 2;
				}
			}
			retour.Add("status", status);

			return JsonConvert.SerializeObject(retour);
		}

		private bool application_isRunning()
		{
			return this.SDB.IsRunning;
		}


		private JObject player_getInfos()
		{
			JObject result = new JObject();

			result.Add("playbackTime", this.SDB.Player.PlaybackTime);
			result.Add("autoDJ", this.SDB.Player.isAutoDJ);
			result.Add("crossFade", this.SDB.Player.isCrossfade);
			result.Add("paused", this.SDB.Player.isPaused);
			result.Add("playing", this.SDB.Player.isPlaying);
			result.Add("repeat", this.SDB.Player.isRepeat);
			result.Add("shuffle", this.SDB.Player.isShuffle);
			result.Add("volume", this.SDB.Player.Volume);
			result.Add("stopAfterCurrent", this.SDB.Player.StopAfterCurrent);

			return result;
		}

		private JObject player_getCurrentSong(NameValueCollection options)
		{
			return MMUtils.getSongData(this.SDB.Player.CurrentSong, this.SDB, Convert.ToBoolean(options["getAlbum"]), Convert.ToBoolean(options["getAlbumArt"]), Convert.ToBoolean(options["getArtist"]));
		}
	}
}
