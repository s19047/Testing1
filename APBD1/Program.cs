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
			if (args.Length == 1)
			{
				if (args[0] != null)
				{
					var url = args[0];
					var httpClient = new HttpClient();

					var response = await httpClient.GetAsync(url);

					if (response.IsSuccessStatusCode)
					{
						var body = await response.Content.ReadAsStringAsync();
						var emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);

						var emails = emailRegex.Matches(body);
						if (emails != null)
						{
							foreach (var email in emails)
							{
								Console.WriteLine(email);
							}
						}
						else
						{
							Console.WriteLine("No emails were found :(");
						}
					}
					else
					{
						Console.WriteLine("Error occured while downloading the Page :(");
					}

					httpClient.Dispose();
					response.Dispose();
				}
				else
				{
					throw new ArgumentException();
				}
			}
			else
			{
				throw new ArgumentNullException("Please pass a url");
			}

		}
	}
}
