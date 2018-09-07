using System.Linq;
using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Ads
/// </summary>
public class Ads
{
	public static ConfigReader.Const AdImageUrl = new ConfigReader.Const("AdImageUrl");

	private static List<string> adKeys = ConfigReader.Ads.Keys.ToList();

	private static Random random = new Random(DateTime.Now.Millisecond);

	public static string One()
	{
		var ad = "<img src='%adImgUrl%/logo-spanda.png' width='80' />The <a href='http://spanda.org' target='_blank'>Spanda Foundation</a> is looking forward to the next 15 years of trying to achieve the <a href='www.un.org/millenniumgoals/' target='_blank'>Millennium Development Goals</a> in this, its 14th year as it launches a fresh version of its website.";
		if (ConfigReader.Ads.Count > 0)
		{
			if (adKeys.Count == 0) adKeys = ConfigReader.Ads.Keys.ToList();
			var key = adKeys[random.Next(adKeys.Count - 1)];
			if (!ConfigReader.Ads.ContainsKey(key))
			{
				adKeys = ConfigReader.Ads.Keys.ToList();
				key = adKeys[random.Next(adKeys.Count - 1)];
			}

			adKeys.Remove(key);
			ad = ConfigReader.Ads[key];
		}

		//$ad = isset($_GET['ad']) ? $_GET['ad'] : (isset($a['id']) ? $a['id'] : array_rand($ads));


		var r = "<!--googleoff: all-->";
		r += ad.Replace("%adImgUrl%", AdImageUrl.Value);
		r += "<!--googleon: all-->";
		return r;
	}
}