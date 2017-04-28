using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeatherApp.Data;

namespace WeatherApp.API
{
	class API_SK_WeatherPlanet
	{
		readonly string url = "http://apis.skplanetx.com/weather";
		readonly string key = "";
		/*
		public static async Task<Weather> GetWeather(string zipCode)
		{
			//Sign up for a free API key at http://openweathermap.org/appid

			string key = "YOUR API KEY HERE";
			string queryString = "http://api.openweathermap.org/data/2.5/weather?zip=
				+ zipCode + "&appid=" + key;
			
			var results = await WebService.getDataFromService(queryString).ConfigureAwait(false);
			
			if (results["weather"] != null)
			{
				Weather weather = new Weather();

				weather.Title = (string)results["name"];
				weather.Temperature = (string)results["main"]["temp"] + " F";
				weather.Wind = (string)results["wind"]["speed"] + " mph";
				weather.Humidity = (string)results["main"]["humidity"] + " %";
				weather.Visibility = (string)results["weather"][0]["main"];

				DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
				DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
				DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
				weather.Sunrise = sunrise.ToString() + " UTC";
				weather.Sunset = sunset.ToString() + " UTC";

				return weather;
			}
			else
			{
				return null;
			}
		}

		
		public static async Task<FineDust> getFineDust(Location loc)
		{
			string query = url + "/dust?version=1"
				+ "&lat=" + loc.latitude + ""
				+ "&lon=" + loc.longitude;
		}
*/
	}
}
