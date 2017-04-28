using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
	class Location
	{
		public double longitude { get; set; }
		public double latitude { get; set; }
//		public string name { get; }

		public string dongName { get; set; }
		public string guName { get; set; }
		public string doName { get; set; }
		public string description { get; }

		public Location(double lon, double lat)
		{
			this.longitude = lon;
			this.latitude = lat;
		}

		public Location(string dong, string gu, string doName, string description = null)
		{
			this.dongName = dong;
			this.guName = gu;
			this.doName = doName;
			this.description = description;
		}

		public override string ToString()
		{
//			return base.ToString();

			return description + "(" + longitude + ", " + latitude + ")";
		}
	}
}
