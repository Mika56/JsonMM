Status code and errors
======================

Every request will always return a status code.
The used codes are the followings:
<table>
	<tr>
		<th>Code</th>
		<th>Description</th>
	</tr>
	<tr>
		<td>0</td>
		<td>Everything went fine. Result is available</td>
	</tr>
	<tr>
		<td>1</td>
		<td>An error occurred. Error description is available in the error string
	</tr>
	<tr>
		<td>2</td>
		<td>An exception occurred. Exception description is available in the exception object<br />The error string is also available</td>
	</tr>
</table>

A frequent error is when a method doesn't exist. The result looks like this:

	http://127.0.0.1:8080/idontexist

```javascript
{
	error: "Unknown method",
	status: 1
}
```

On the other side, a frequent Exception is when an argument is wrongly formed:

	http://127.0.0.1:8080/player/getCurrentSong?getAlbum=true&getAlbumArt=true&getArtist=tru

```javascript
{
	error: "Exception thrown",
	Exception: {
		Message: "String was not recognized as a valid Boolean.",
		Source: "mscorlib",
		StackTrace: " at System.Boolean.Parse(String value) at System.Convert.ToBoolean(String value) at JsonMM.Server.player_getCurrentSong(NameValueCollection options) in d:\Dev\CSharp\JsonMM\JsonMM\Server.cs:line 138 at JsonMM.Server.handleRequest(HttpListenerRequest request) in d:\Dev\CSharp\JsonMM\JsonMM\Server.cs:line 84"
	},
	status: 2
}
```

#### Links ####

[Go back to documentation index](index.md)