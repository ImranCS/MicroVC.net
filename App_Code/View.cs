using System;

/// <summary>
/// Helper methods for the View
/// </summary>
public static class ViewHelper
{
	public static string Copyright()
	{
		return string.Format("&copy; {0} - {1}", Configs.Founded.Value, DateTime.Now.Year);
	}
}