using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APBD1
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var url = "https://support.google.com/mail/thread/7926745?hl=en";
			var httpClient = new HttpClient();

			var response = await httpClient.GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				var body = await response.Content.ReadAsStringAsync();
				var emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);

				var emails = emailRegex.Matches(body);

				foreach(var email in emails)
				{
					
					////fsdfklsjdflksj
				}
			}


		}
	}
}
