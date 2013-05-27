Player/getInfos/
======================

Gets some basic information about MediaMonkey

- playbackTime: how many milliseconds of the current track were already played
- autoDJ: Whether AutoDJ function of player is enabled
- crossFade: Whether the CrossFade function of player is enabled
- paused: True if the playback is paused
- playing: True if there is a track playing. Will be true even if paused
- repeat: Whether the repeat function of player is enabled
- shuffle: Whether the shuffle function of player is enabled
- volume: The player volume, 0 being 0% and 1 being 100%
- stopAfterCurrent: True if playback will be stopped once current song is over 

### Method ###

    GET /Player/getInfos/

### Example ###

    GET http://127.0.0.1:8080/Player/getInfos/

```javascript
{
	result: {
		playbackTime: 802,
		autoDJ: false,
		crossFade: true,
		paused: true,
		playing: true,
		repeat: false,
		shuffle: false,
		volume: 1,
		stopAfterCurrent: false
	},
	status: 0
}
```

#### Links ####

[Go back to Player/](index.md)

[Go back to documentation index](../index.md)