using System;
using System.Web;

/// <summary>
/// Helper methods for the View
/// </summary>
public static class ViewHelper
{
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
}