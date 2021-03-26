﻿using Reddit.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace RedditWPF
{
	public class MainViewModel : ViewModelBase
	{
		RedditService rs;
        public WebBrowser Browser { get; set; }
		public MainViewModel()
		{
			rs = new RedditService();

            Subreddits = new ObservableCollection<SubredditItem>(rs.GetSubreddits());

		}


        private ObservableCollection<SubredditItem> _subreddits;
        public ObservableCollection<SubredditItem> Subreddits
        {
            get
            {
                return this._subreddits;
            }
            set
            {
                this._subreddits = value;
                RaisePropertyChanged();
            }
        }

        private SubredditItem _subreddit;
        public SubredditItem SelectedSubreddit
		{
			get
			{
                return this._subreddit;
			}
			set
			{
                this._subreddit = value;
                if(_subreddit.SubredditObj == null)
				{
                    rs.LoadSubreddit(_subreddit);
				}
                Posts = new ObservableCollection<Post>(rs.GetPosts(_subreddit));
                RaisePropertyChanged();
			}
		}

        private ObservableCollection<Post> _posts;
        public ObservableCollection<Post> Posts
        {
            get
            {
                return this._posts;
            }
            set
            {
                this._posts = value;
                RaisePropertyChanged();
            }
        }

        private Post _post;
        public Post SelectedPost
        {
            get
            {
                return this._post;
            }
            set
            {
                this._post = value;
                SetBrowserContent();
                RaisePropertyChanged();
            }
        }

        public void SetBrowserContent()
		{
            if(SelectedPost != null)
			{
                Browser.Source = new Uri("about:blank");
                if (SelectedPost.GetType() == typeof(SelfPost))
                {
                    SelfPost self = (SelfPost)SelectedPost;
                    Browser.NavigateToString(self.SelfTextHTML);

                }
                else if (SelectedPost.GetType() == typeof(LinkPost))
                {
                    LinkPost link = (LinkPost)SelectedPost;
                    Browser.Source = new Uri(link.URL);
                }
            }

		}
    }
}
