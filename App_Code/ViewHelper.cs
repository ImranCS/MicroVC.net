using System;
using System.Web;
using System.Collections.Generic;

/// <summary>
/// Helper methods for the View
/// </summary>
public static class ViewHelper
{
	public static ConfigReader.Const SelectedMenu = new ConfigReader.Const("SelectedMenu");
	private const string MenuItem = "  <li{0}><a href=\"{1}/\">{2}</a></li>";

	public static string Path()
	{
		var path = HttpContext.Current.Request.Path;
		if (string.IsNullOrEmpty(path) || path == "/") path = "Home";
		if (path.EndsWith("/")) path = path.Substring(0, path.Length - 1);
		return path;
	}

	public static string Copyright()
	{
		return string.Format("&copy; {0} - {1}", Configs.Founded.Value, DateTime.Now.Year);
	}

	public static string Menu(params string[] items)
	{
		var path = Path();
		var op = new List<string>();

		foreach (var item in items)
		{
			var bits = item.Split('|');

			var url = bits.Length > 1 ? bits[0] : "/" + bits[0].ToLower().Replace(" ", "-");
			var css = path == url || (path == "Home" && string.IsNullOrEmpty(url)) ? string.Format(" class=\"{0}\"", SelectedMenu.Value) : string.Empty;
			var text = bits.Length > 1 ? bits[1] : bits[0];

			op.Add(string.Format(MenuItem, css, url, text));
		}

		return string.Join(Environment.NewLine, op);
	}
}