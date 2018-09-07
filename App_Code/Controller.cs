using System.Web;

/// <summary>
/// Summary description for Controller
/// </summary>
public class Controller
{
	public static string GetTitle()
	{
		return ViewHelper.Path().Replace("/", " ") + " [" + Configs.Name.Value + "]";
	}

	public static string ExecutePage()
	{
		var path = "~/Protected/Pages/" + ViewHelper.Path() + ".aspx";
		HttpContext.Current.Server.Execute(path);
		return string.Empty;
	}

	public static void RequestBegins()
	{
		var path = HttpContext.Current.Request.Path;
		if (path.Contains("Protected"))
			ExecuteAndStop("~/Protected/Errors/404.aspx");
		else if (path != "" && !path.Contains("Assets"))
			ExecuteAndStop("~/Default.aspx");
	}

	private static void ExecuteAndStop(string path)
	{
		HttpContext.Current.Server.Execute(path);
		HttpContext.Current.Response.End();
	}
}