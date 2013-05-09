using System;
using System.Diagnostics;

namespace JsonMM
{
	public static class NetAclChecker
	{
		public static bool AddAddress(string address)
		{
			return AddAddress(address, Environment.UserDomainName, Environment.UserName);
		}

		public static bool AddAddress(string address, string domain, string user)
		{
			string args = string.Format(@"http add urlacl url={0} user={1}\{2}", address, domain, user);

			ProcessStartInfo psi = new ProcessStartInfo("netsh", args);
			psi.Verb = "runas";
			psi.CreateNoWindow = true;
			psi.WindowStyle = ProcessWindowStyle.Hidden;
			psi.UseShellExecute = true;

			try
			{
				Process.Start(psi).WaitForExit();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
