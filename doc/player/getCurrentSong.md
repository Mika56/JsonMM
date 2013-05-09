Player/getCurrentSong/
======================

Gets all information about the current playing song
See the [MediaMonkey Documentation](http://www.mediamonkey.com/wiki/index.php/SDBSongData) for detail about each property

### Method ###

    GET /Player/getCurrentSong/

### Parameters ###
<table>
	<tr>
		<th>Name</th>
		<th>Description</th>
		<th>Default value</th>
	</tr>
	<tr>
		<td>getAlbum</td>
		<td>Get advanced information about the album</td>
		<td>false</td>
	</tr>
	<tr>
		<td>getAlbumArt</td>
		<td>Whether to fetch or not the AlbumArts</td>
		<td>false</td>
	</tr>
	<tr>
		<td>getArtist</td>
		<td>Get advanced information about the artist</td>
		<td>false</td>
	</tr>
</table>

### Example ###

    GET http://127.0.0.1:8080/player/getCurrentSong?getAlbum=true&getAlbumArt=true&getArtist=true

```javascript
{
	result: {
		Album: {
			AlbumLength: 495560,
			AlbumLengthString: "8:15",
			ID: 142,
			Name: "The Heist"
		},
		AlbumArt: [
			{
				Description: null,
				Image: {
					Height: 500,
					ImageDataLen: 36535,
					ImageFormat: "image/jpeg",
					Width: 500,
					ImageDataReadFrom: "D:\\Temp\\tmpC3BC.tmp",
					ImageData: "base64encoded"
				},
				ItemStorage: 0,
				ItemType: 3,
				PicturePath: "\\\\SERVER\\Folders Redirection\\Mikael\\Music\\Macklemore\\The Heist\\",
				RelativePicturePath: null
			}
		],
		AlbumArtistName: "Macklemore",
		AlbumName: "The Heist",
		Artist: {
			Comment: null,
			ID: 0,
			Name: "Macklemore; Ryan Lewis; Ray Dalton"
		},
		ArtistName: "Macklemore; Ryan Lewis; Ray Dalton",
		Author: null,
		Band: null,
		Bitrate: 1022246,
		Bookmark: 0,
		StartTime: 0,
		StopTime: 258427,
		SkipCount: 0,
		TrackType: 0,
		BPM: -1,
		CachedPath: null,
		canCrossfade: true,
		Comment: null,
		Conductor: null,
		Copyright: null,
		Custom1: null,
		Custom2: null,
		Custom3: null,
		Custom4: null,
		Custom5: null,
		Date: "2013-05-09T15:39:58.185",
		DateAdded: "2013-05-03T14:03:19.062",
		DateDBModified: "2013-05-09T11:34:07.093",
		Day: 0,
		DiscNumber: 1,
		DiscNumberStr: "1",
		Encoder: "reference libFLAC 1.2.1 20070917",
		FileLength: 33054610,
		FileModified: "2013-05-06T21:51:13.831",
		GaplessBytes: -1,
		Genre: null,
		Grouping: null,
		ID: 4257,
		InvolvedPeople: null,
		isBookmarkable: false,
		isShuffleIgnored: false,
		IsntInDB: false,
		ISRC: null,
		LastPlayed: "2013-05-09T11:34:07.093",
		Leveling: -999999,
		LevelingAlbum: -999999,
		Lyricist: null,
		Lyrics: null,
		MediaLabel: "Network",
		Month: 0,
		Mood: null,
		MusicComposer: null,
		Occasion: null,
		OriginalArtist: null,
		OriginalLyricist: null,
		OriginalTitle: null,
		OriginalYear: -1,
		OriginalMonth: 0,
		OriginalDay: 0,
		Path: "\\\\SERVER\\Folders Redirection\\Mikael\\Music\\Macklemore\\The Heist\\02 - Can't Hold Us.flac",
		PeakValue: -1,
		PlayCounter: 16,
		PlaylistOrder: -1,
		PostGap: -1,
		PreGap: -1,
		PreviewPath: null,
		Publisher: null,
		Quality: null,
		Rating: 100,
		RatingString: null,
		SampleRate: 44100,
		SongLength: 258427,
		SongLengthString: "4:18",
		Tempo: null,
		Title: "Can't Hold Us",
		TotalSamples: -1,
		TrackOrder: 2,
		TrackOrderStr: "02",
		VBR: false,
		Year: 2012
	},
	status: 0
}
```

### Additionnal information ###
When you set getAlbumArt to true, the AlbumArt array is added to the response. Each item of that array represent an AlbumArt. The Image.ImageData field contains the image encoded using base64. You can learn more about this on [Wikipedia](http://en.wikipedia.org/wiki/Data_URI_scheme)

When the Album Art comes from a file, it is simply read and converted. However, when it is included in the song's tag (ItemStorage=0), it is extracted and copied in a temp folder, read and then deleted. This is why the ImageDataReadFrom field was added


#### Links ####

[Go back to Player/](index.md)

[Go back to documentation index](../index.md)