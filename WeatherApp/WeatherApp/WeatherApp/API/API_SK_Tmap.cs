using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using WeatherApp.Data;
using System.Net;

namespace WeatherApp.API
{
	class API_SK_Tmap
	{
		static readonly string url = "http://apis.skplanetx.com/tmap";
		static readonly string key = "2e3cb07a-ea06-305d-a1cd-a7c1d7698d9c";

		public static async Task<List<Location>> searchRegions(string searchKeyword, int count = 5, string categories = "legalDong", string searchType = "KEYWORD")
		{
			//https://developers.skplanetx.com/apidoc/kor/geofencing/geospatial/?leftAppId=15054956
	
			string query = url + "/geofencing/regions?version=1"
				+ "&page=" + ""
				+ "&count=" + count
				+ "&categories=" + categories
				+ "&searchType=" + searchType
				+ "&searchKeyword=" + searchKeyword
				+ "&resCoordType="
				+ "&reqLon="
				+ "&reqLat="
				+ "&callback=";

			var result = await WebService.getDataFromService(query, key);

			List<Location> resultRegions = null;
			if (result["searchRegionsInfo"] != null)
			{
				resultRegions = new List<Location>();
				var searchResult = JArray.Parse(result["searchRegionsInfo"].ToString());

				foreach(var item in searchResult)
				{
					var regionInfo = item["regionInfo"];

					var regionName = regionInfo["regionName"].ToString();
					var gu = regionInfo["properties"]["guName"].ToString();
					var doN = regionInfo["properties"]["doName"].ToString();

					var description = regionInfo["description"].ToString();

					var newItem = new Location(regionName, gu, doN, description);
					resultRegions.Add(newItem);
				}
			}

			return resultRegions;
		}

		public static async Task<Location> getLoction(Location loc)
		{
			//https://developers.skplanetx.com/apidoc/kor/t-map/geocoding/?leftAppId=15054956

			//TODO. 좌표타입 변경 
			var coordType = "KATECH";	//좌표 타입	
			string query = url + "/geo/geocoding?version=1"
				+ "&city_do=" + WebUtility.UrlEncode(loc.doName)
				+ "&gu_gun=" + WebUtility.UrlEncode(loc.guName)
				+ "&dong=" + WebUtility.UrlEncode(loc.dongName)
				+ "&bunji=" 
				+ "&detailAddress=" 
				+ "&addressFlag="
				+ "&coordType=" + coordType
				+ "&callback=";

		 	var result = await WebService.getDataFromService(query, key);

			if (result["coordinateInfo"] != null)
			{
				var info = result["coordinateInfo"];

				loc.latitude = double.Parse(info["lat"].ToString());
				loc.longitude = double.Parse(info["lon"].ToString());
			}

			return loc;
		}
	}
}
