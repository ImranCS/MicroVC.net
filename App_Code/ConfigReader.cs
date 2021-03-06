﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConfigReader
/// </summary>
public static class ConfigReader
{
	public struct Const
	{
		private readonly string _key;

		public Const(string key)
		{
			_key = key;
		}

		public string Value
		{
			get
			{
				return config[_key];
			}
		}
	}

	private static readonly string Folder = HttpContext.Current.Server.MapPath("~/App_Data/");
	private const string ConfigFile = "WebsiteConfig.txt";
	private const string AdsFile = "Ads.txt";
	private static readonly string[] Delimiter = new string[] { ": " };

	static ConfigReader()
	{
		var fsw = new FileSystemWatcher(Folder) { EnableRaisingEvents = true };
		fsw.Changed += Fsw_Changed;
		config = ReadConfig(ConfigFile);
		if (File.Exists(Folder + AdsFile)) Ads = ReadConfig(AdsFile);
	}

	private static void Fsw_Changed(object sender, FileSystemEventArgs e)
	{
		//if (e.ChangeType == WatcherChangeTypes.Changed)
		//if (e.Name == ConfigFile) ReadWebsiteConfig();
		if (File.Exists(Folder + ConfigFile)) config = ReadConfig(ConfigFile);
		if (File.Exists(Folder + AdsFile)) Ads = ReadConfig(AdsFile);
	}

	private static Dictionary<string, string> config;

	public static Dictionary<string, string> Ads { get; private set; }

	public static string Get(string key, string defaultValue = null)
	{
		return config.ContainsKey(key) ? config[key] : defaultValue;
	}

	private static Dictionary<string, string> ReadConfig(string file)
	{
		return File.ReadAllLines(Folder + file)
			.Where(x => !string.IsNullOrEmpty(x) && !x.StartsWith("#"))
			.Select(x => x.Split(Delimiter, 2, StringSplitOptions.None))
			.ToDictionary(x => x[0], x => x[1]);
	}
}