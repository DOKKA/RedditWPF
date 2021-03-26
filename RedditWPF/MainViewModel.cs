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

            Subreddits = new ObservableCollection<Subreddit>(rs.getSubreddits());

		}


        private ObservableCollection<Subreddit> _subreddits;
        public ObservableCollection<Subreddit> Subreddits
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
    }
}
