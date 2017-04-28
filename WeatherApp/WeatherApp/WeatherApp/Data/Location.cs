using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
	class Location
	{
		public double longitude { get; }
		public double latitude { get; }
//		public string name { get; }

		public Location(double lon, double lat)
		{
			this.longitude = lon;
			this.latitude = lat;
		}
	}
}
