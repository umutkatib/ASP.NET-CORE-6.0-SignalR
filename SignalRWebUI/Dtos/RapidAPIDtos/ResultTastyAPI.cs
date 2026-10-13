namespace SignalRWebUI.Dtos.RapidAPIDtos
{
	public class RootTastyAPI
	{
		public List<ResultTastyAPI> Results { get; set; }
	}
	public class ResultTastyAPI
	{
		public string Name { get; set; }
		public string original_video_url { get; set; }
		public int total_time_minutes { get; set; }
		public string thumbnail_url { get; set; }
		public string country { get; set; }
	}
}
