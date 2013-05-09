using System;
using System.Net;
using System.Threading;
using System.Text;

namespace SimpleWebServer
{
	public class WebServer
	{
		private readonly HttpListener _listener = new HttpListener();
		private readonly Func<HttpListenerRequest, string> _responderMethod;

		public WebServer(string[] prefixes, Func<HttpListenerRequest, string> method)
		{
			if (!HttpListener.IsSupported)
				throw new NotSupportedException("Needs Windows XP SP2, Server 2003 or later.");

			if (prefixes == null || prefixes.Length == 0)
				throw new ArgumentException("prefixes");

			if (method == null)
				throw new ArgumentException("method");

			foreach (string s in prefixes)
				_listener.Prefixes.Add(s);

			_responderMethod = method;
			try
			{
				_listener.Start();
			}
			catch
			{
				Console.WriteLine("Application was unable to listen on port. We are now going to ask for an authorization.");
				Console.WriteLine("If any UAC window opens, please accept.");
				Console.WriteLine("Press any key to continue.");
				Console.ReadKey(true);
				Console.WriteLine("\n\n");
				if (JsonMM.NetAclChecker.AddAddress(prefixes[0]))
				{
					Console.WriteLine("Listening authorization has been granted, please restart application.");
					Console.WriteLine("Press any key to exit.");
				}
				else
				{
					Console.WriteLine("We were unable to get our authorization. If you refused the UAC prompt, please restart the application and try again.");
					Console.WriteLine("If you accepted the UAC prompt, a problem occured, please also try again. If the problem persists, contact us.");
					Console.WriteLine("Press any key to exit.");
				}
				Console.ReadKey(true);
				Environment.Exit(0);
			}
		}

		public WebServer(Func<HttpListenerRequest, string> method, params string[] prefixes)
			: this(prefixes, method) { }

		public void Run()
		{
			ThreadPool.QueueUserWorkItem((o) =>
			{
				Console.WriteLine("Webserver running...");
				try
				{
					while (_listener.IsListening)
					{
						ThreadPool.QueueUserWorkItem((c) =>
						{
							var ctx = c as HttpListenerContext;
							try
							{
								string rstr = _responderMethod(ctx.Request);
								byte[] buf = Encoding.UTF8.GetBytes(rstr);
								ctx.Response.ContentLength64 = buf.Length;
								ctx.Response.ContentType = "application/json";
								ctx.Response.OutputStream.Write(buf, 0, buf.Length);
							}
							catch { } // suppress any exceptions
							finally
							{
								// always close the stream
								ctx.Response.OutputStream.Close();
							}
						}, _listener.GetContext());
					}
				}
				catch { } // suppress any exceptions
			});
		}

		public void Stop()
		{
			_listener.Stop();
			_listener.Close();
		}
	}
}