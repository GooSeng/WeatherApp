using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using WeatherApp.Data;
using Newtonsoft.Json.Linq;

namespace WeatherApp.API
{
	class API_SK_WeatherPlanet
	{
		static readonly string url = "http://apis.skplanetx.com/weather";
		static readonly string key = "2e3cb07a-ea06-305d-a1cd-a7c1d7698d9c";

		public static async Task<FineDust> getFineDust(Location loc)
		{
			FineDust dust = null;

			string query = url + "/dust?version=1"
				+ "&lat=" + loc.latitude + ""
				+ "&lon=" + loc.longitude;

			var result = await WebService.getDataFromService(query, key);

			if (result["weather"] != null)
			{
				var values = JsonConvert.DeserializeObject<JArray>(result["weather"]["dust"].ToString());

				var station = values[0]["station"];
				var name = station["name"].ToString();

				//				var lat = station["latitude"].ToString();
				//				var lon = station["longitude"].ToString();

				var time = DateTime.Parse(values[0]["timeObservation"].ToString());

				var value = Double.Parse(values[0]["pm10"]["value"].ToString());
				var grade = values[0]["pm10"]["grade"].ToString();

				dust = new FineDust(name, time, value, grade);
			}

			return dust;
		}
	}
}
