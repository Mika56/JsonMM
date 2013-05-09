using Newtonsoft.Json.Linq;
using SongsDB;
using System;
using System.IO;

namespace JsonMM
{
	public static class MMUtils
	{

		public static JObject getSongData(SDBSongData song, SDBApplication SDB, bool getAlbum, bool getAlbumArt, bool getArtist)
		{
			JObject result = new JObject();

			if (getAlbum)
			{
				result.Add("Album", getAlbumData(song.Album, SDB, false, false, false));
			}
			if (getAlbumArt)
			{
				JArray albumArts = new JArray();
				var length = song.AlbumArt.Count;
				for (int i = 0; i < length; i++)
				{
					albumArts.Add(MMUtils.getAlbumArt(song.AlbumArt.Item[i], SDB));
				}
				result.Add("AlbumArt", albumArts);
			}
			result.Add("AlbumArtistName", song.AlbumArtistName);
			result.Add("AlbumName", song.AlbumName);
			if (getArtist)
			{
				result.Add("Artist", getArtistData(song.Artist, SDB));
			}
			result.Add("ArtistName", song.ArtistName);
			result.Add("Author", song.Author);
			result.Add("Band", song.Band);
			result.Add("Bitrate", song.Bitrate);
			result.Add("Bookmark", song.Bookmark);
			result.Add("StartTime", song.StartTime);
			result.Add("StopTime", song.StopTime);
			result.Add("SkipCount", song.SkipCount);
			result.Add("TrackType", song.TrackType);
			result.Add("BPM", song.BPM);
			result.Add("CachedPath", song.CachedPath);
			result.Add("canCrossfade", song.canCrossfade);
			//result.Add("Channels", song.Channels);
			result.Add("Comment", song.Comment);
			result.Add("Conductor", song.Conductor);
			result.Add("Copyright", song.Copyright);
			result.Add("Custom1", song.Custom1);
			result.Add("Custom2", song.Custom2);
			result.Add("Custom3", song.Custom3);
			result.Add("Custom4", song.Custom4);
			result.Add("Custom5", song.Custom5);
			result.Add("Date", song.Date);
			result.Add("DateAdded", song.DateAdded);
			result.Add("DateDBModified", song.DateDBModified);
			result.Add("Day", song.Day);
			result.Add("DiscNumber", song.DiscNumber);
			result.Add("DiscNumberStr", song.DiscNumberStr);
			result.Add("Encoder", song.Encoder);
			result.Add("FileLength", song.FileLength);
			result.Add("FileModified", song.FileModified);
			result.Add("GaplessBytes", song.GaplessBytes);
			result.Add("Genre", song.Genre);
			result.Add("Grouping", song.Grouping);
			result.Add("ID", song.ID);
			result.Add("InvolvedPeople", song.InvolvedPeople);
			result.Add("isBookmarkable", song.isBookmarkable);
			result.Add("isShuffleIgnored", song.isShuffleIgnored);
			result.Add("IsntInDB", song.IsntInDB);
			result.Add("ISRC", song.ISRC);
			result.Add("LastPlayed", song.LastPlayed);
			result.Add("Leveling", song.Leveling);
			result.Add("LevelingAlbum", song.LevelingAlbum);
			result.Add("Lyricist", song.Lyricist);
			result.Add("Lyrics", song.Lyrics);
			result.Add("MediaLabel", song.MediaLabel);
			result.Add("Month", song.Month);
			result.Add("Mood", song.Mood);
			result.Add("MusicComposer", song.MusicComposer);
			result.Add("Occasion", song.Occasion);
			result.Add("OriginalArtist", song.OriginalArtist);
			result.Add("OriginalLyricist", song.OriginalLyricist);
			result.Add("OriginalTitle", song.OriginalTitle);
			result.Add("OriginalYear", song.OriginalYear);
			result.Add("OriginalMonth", song.OriginalMonth);
			result.Add("OriginalDay", song.OriginalDay);
			result.Add("Path", song.Path);
			result.Add("PeakValue", song.PeakValue);
			result.Add("PlayCounter", song.PlayCounter);
			result.Add("PlaylistOrder", song.PlaylistOrder);
			result.Add("PostGap", song.PostGap);
			result.Add("PreGap", song.PreGap);
			//result.Add("Preview", song.Preview);
			result.Add("PreviewPath", song.PreviewPath);
			result.Add("Publisher", song.Publisher);
			result.Add("Quality", song.Quality);
			result.Add("Rating", song.Rating);
			result.Add("RatingString", song.RatingString);
			result.Add("SampleRate", song.SampleRate);
			result.Add("SongLength", song.SongLength);
			result.Add("SongLengthString", song.SongLengthString);
			result.Add("Tempo", song.Tempo);
			result.Add("Title", song.Title);
			result.Add("TotalSamples", song.TotalSamples);
			result.Add("TrackOrder", song.TrackOrder);
			result.Add("TrackOrderStr", song.TrackOrderStr);
			result.Add("VBR", song.VBR);
			result.Add("Year", song.Year);
			return result;
		}

		public static JObject getAlbumData(SDBAlbum album, SDBApplication SDB, bool getTracks, bool getAlbumArt, bool getArtist)
		{
			JObject result = new JObject();


			if (getAlbumArt)
			{
				JArray albumArts  = new JArray();
				var length = album.AlbumArt.Count;
				for(int i=0;i<length;i++)
				{
					albumArts.Add(MMUtils.getAlbumArt(album.AlbumArt.Item[i], SDB));
				}
				result.Add("AlbumArt", albumArts);
			}
			result.Add("AlbumLength", album.AlbumLength);
			result.Add("AlbumLengthString", album.AlbumLengthString);
			if (getArtist)
			{
				result.Add("Artist", getArtistData(album.Artist, SDB));
			}
			result.Add("ID", album.ID);
			result.Add("Name", album.Name);
			if (getTracks)
			{
				result.Add("Tracks", "NA");
				throw new NotImplementedException();
			}

			return result;
		}

		public static JObject getAlbumArt(SDBAlbumArtItem albumArt, SDBApplication SDB)
		{
			JObject result = new JObject();
			JObject image = new JObject();
			image.Add("Height", albumArt.Image.Height);
			//image.Add("ImageData", albumArt.Image.ImageData);
			image.Add("ImageDataLen", albumArt.Image.ImageDataLen);
			image.Add("ImageFormat", albumArt.Image.ImageFormat);
			image.Add("Width", albumArt.Image.Width);
			if (albumArt.ItemStorage == 1 && File.Exists(albumArt.PicturePath))
			{
				image.Add("ImageDataReadFrom", albumArt.PicturePath);
				image.Add("ImageData", Convert.ToBase64String(File.ReadAllBytes(albumArt.PicturePath)));
			}
			else
			{
				string tempFile = Path.GetTempFileName();
				SDBTextFile artFile = SDB.Tools.FileSystem.CreateTextFile(tempFile, true);
				artFile.WriteData(albumArt.Image.ImageData, albumArt.Image.ImageDataLen);
				artFile.Close();
				image.Add("ImageDataReadFrom", tempFile);
				image.Add("ImageData", Convert.ToBase64String(File.ReadAllBytes(tempFile)));
				File.Delete(tempFile);
			}

			result.Add("Description", albumArt.Description);
			result.Add("Image", image);
			result.Add("ItemStorage", albumArt.ItemStorage);
			result.Add("ItemType", albumArt.ItemType);
			result.Add("PicturePath", albumArt.PicturePath);
			result.Add("RelativePicturePath", albumArt.RelativePicturePath);

			return result;
		}

		private static JObject getArtistData(SDBArtist artist, SDBApplication SDB)
		{
			JObject result = new JObject();

			result.Add("Comment", artist.Comment);
			result.Add("ID", artist.ID);
			result.Add("Name", artist.Name);

			return result;
		}

	}
}
