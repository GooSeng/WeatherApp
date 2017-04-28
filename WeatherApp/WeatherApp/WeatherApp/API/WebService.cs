using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace WeatherApp.API
{
	class WebService
	{
		public static async Task<JContainer> getDataFromService(string queryString, string appKey)
		{
			HttpClient client = new HttpClient();
			
//			client.DefaultRequestHeaders.Add("Content-Length", "320");
//			client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
			client.DefaultRequestHeaders.Add("Accept", "application/json; charset=utf-8");
			client.DefaultRequestHeaders.Add("Accept-Language", "ko");
//			client.DefaultRequestHeaders.Add("Host", "http://apis.skplanetx.com");
			client.DefaultRequestHeaders.Add("appKey", appKey);

			var response = await client.GetAsync(queryString);

			JContainer data = null;
			if (response != null)
			{
				var json = response.Content.ReadAsStringAsync().Result;

				data = (JContainer)JsonConvert.DeserializeObject(json);
			}

			return data;
		}
	}
}
