using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Controller
/// </summary>
public class Controller
{
	public static string GetTitle()
	{
		return "[page] " + Configs.Name.Value;
	}

	public static string ExecutePage()
	{
		var path = GetPageView();
		HttpContext.Current.Server.Execute(path);
		return string.Empty;
	}

	public static string GetPageView()
	{
		var path = HttpContext.Current.Request.Path;
		if (string.IsNullOrEmpty(path) || path == "/") path = "Home";
		if (path.EndsWith("/")) path = path.Substring(0, path.Length - 1);
		return "~/Protected/Pages/" + path + ".aspx";
	}

	public static void RequestBegins()
	{
		var path = HttpContext.Current.Request.Path;
		if (path.Contains("Protected"))
			ExecuteAndStop("~/Protectes/Errors/404.aspx");
		else if (path != "" && !path.Contains("Assets"))
			ExecuteAndStop("~/Default.aspx");
	}

	private static void ExecuteAndStop(string path)
	{
		HttpContext.Current.Server.Execute(path);
		HttpContext.Current.Response.End();
	}
}