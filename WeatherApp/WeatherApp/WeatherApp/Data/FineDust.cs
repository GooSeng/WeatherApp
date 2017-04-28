using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
	class FineDust
	{
		public string name { get; }
		public DateTime observeTime { get; }
		public double value { get; }
		public string grade { get; }

		public FineDust(string name, DateTime time, double value, string grade)
		{
			this.name = name;
			this.observeTime = time;
			this.value = value;
			this.grade = grade;
		}
	}
}
