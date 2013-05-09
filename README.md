JsonMM
======
JsonMM is an application for Windows that allows you to send requests to MediaMonkey via HTTP and using JSON.
The application is still in an early development stage, so only few methods are available for now.

Compiling
=========
Because JsonMM is still in an early development stage, it is not available as an executable yet. In order to use it, you'll need to compile it yourself.
To do so, you will need Visual Studio for C# (VS Express should be enough). You will also need NuGet as JsonMM uses [Json.NET](http://json.codeplex.com/). After opening the project, download Josn.NET with NuGet, and you're ready to compile !

Utilization
===========
JsonMM acts as a HTTP Server on port 8080 (cannot be changed for now), and always answer in the JSON format.
For a complete list of methods, please read the [documentation](doc/index.md)

Bug reporting
=============
JsonMM is far from being perfect. If you find any bug, please report them using the Issues tab

Features Request and Pull Requests
================
If you have an idea for JsonMM, you have two options:

- Suggest it using the Issues tab
- Code it yourself! I do accept Pull Requests :stuck_out_tongue:

