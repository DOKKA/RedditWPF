using Reddit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditWPF
{

	public class RedditService
	{
		private RedditClient redditClient;
		private string subreddits;
		public RedditService()
		{
			var appSettings = ConfigurationManager.AppSettings;
			string app_id = appSettings["app_id"];
			string app_secret = appSettings["app_secret"];
			string refresh_token = appSettings["refresh_token"];
			subreddits = appSettings["subreddits"];
			redditClient = new RedditClient(app_id, refresh_token, app_secret);

		}

		public List<Subreddit> getSubreddits()
		{
			return subreddits.Split(',').Select(s => new Subreddit { Name = s }).ToList();
		}

	}

	public class Subreddit
	{
		public string Name { get; set; }
	}
}
