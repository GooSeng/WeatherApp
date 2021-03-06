﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public async void click_weather(object sender, EventArgs e)
		{
//			var result = await API.API_SK_WeatherPlanet.getFineDust(new Data.Location(37.5714100000, 126.9658000000));
			var tmp = await API.API_SK_Tmap.searchRegions(address.Text);

			if (tmp != null)
			{
				var loc = await API.API_SK_Tmap.getLoction(tmp.First());

				var result = await API.API_SK_WeatherPlanet.getFineDust(loc);

				dust.Text = result.grade;
				now_dust.Text = address.Text + "미세먼지";

			}
		}
	}
}
