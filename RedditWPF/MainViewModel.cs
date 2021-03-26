using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace RedditWPF
{
	public class MainViewModel : ViewModelBase
	{
		RedditService rs;
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
                rs.GetPosts(_subreddit);

                RaisePropertyChanged();
			}
		}
    }
}
