using Reddit;
using Reddit.Controllers;
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

		public List<SubredditItem> GetSubreddits()
		{
			return subreddits.Split(',').Select(s => new SubredditItem { Name = s }).ToList();
		}

		public void LoadSubreddit(SubredditItem s)
		{
			Subreddit subreddit = redditClient.Subreddit(s.Name).About();
			s.SubredditObj = subreddit;
		}

		public List<Post> GetPosts(SubredditItem s)
		{
			return s.SubredditObj.Posts.Hot;
		}

	}

	public class SubredditItem
	{
		public string Name { get; set; }
		public Subreddit SubredditObj { get; set; }
	}
}
